# WalletFlow — Personal Finance Management System
## Business Logic Documentation (Agent-Ready)

### Project Overview
**Better Project Name:** `WalletFlow` (instead of FinanceTrackerAPI)  
**Description:** A multi-currency, multi-account personal finance management system that enables users to track bank accounts, cards, transactions, expenses, and recurring payments across multiple financial institutions with different currencies.

---

## Domain Entities (Revised Names & Purpose)

### 1. User
**Purpose:** Core user account with identity and preferences  
**Properties:**
- `Id` (PK): Unique identifier
- `FullName`: User's display name
- `Email`: Unique email for authentication
- `PasswordHash` & `PasswordSalt`: Secure authentication
- `CurrencyId` (FK): Default/primary currency for user
- `StateTimeZoneId` (FK): User's timezone for display and scheduling
- `IsVerified`: Email verification status
- `ConfirmationCode`: Verification token (GUID)
- `CreatedDate`: Account creation timestamp

**Relationships:**
- Has many `FinancialInstitutions` (Bank)
- Has many `Wallets` (digital money pools)
- Has many `Categories` (expense categories)
- Has one `StateTimeZone`
- Has many `LoginAuditLogs` (UserLoginHistory)

**Key Constraint:** Data is always filtered by current user ID in queries (tenant isolation).

---

### 2. Currency
**Purpose:** Reference table for supported currencies  
**Properties:**
- `Id` (PK)
- `Code`: ISO 4217 code (e.g., "EUR", "BRL", "USD")

**Usage:** Users can select any currency for accounts, cards, wallets, and transactions. Each account/wallet has exactly one currency; no automatic conversion is performed.

---

### 3. StateTimeZone
**Purpose:** Timezone reference for scheduling and user preferences  
**Properties:**
- `Id` (PK)
- `UTC`: UTC offset (e.g., "UTC+01:00")
- `Description`: Human-readable name (e.g., "Europe/Berlin")
- `TimeZoneInfoId`: .NET TimeZoneInfo ID (for server-side scheduling)
- `SupportsDaylightSavingTime`: Boolean flag

**Usage:** Used to schedule recurring transactions and display user-relative dates.

---

### 4. FinancialInstitution (renamed from Bank)
**Purpose:** Represents a bank or financial entity the user banks with  
**Properties:**
- `Id` (PK)
- `UserId` (FK): Owner of this institution record
- `Name`: Bank name (e.g., "Revolut", "ING", "Bradesco")
- `Branch`: Branch code or location
- `IsActive`: Soft-delete flag (user can deactivate without losing data)
- `IsDeleted`: Hard-delete flag (for compliance/cleanup)
- `CreatedDate`: When user added this institution

**Relationships:**
- Has many `MoneyAccounts`
- Belongs to one `User`

**Key Constraint:** Records are filtered by `UserId == CurrentUserId` at query level.

---

### 5. MoneyAccount (renamed from Account)
**Purpose:** A specific account at a financial institution (e.g., Revolut EUR Checking Account)  
**Properties:**
- `Id` (PK)
- `FinancialInstitutionId` (FK): Which bank this account belongs to
- `Name`: Account alias (e.g., "Revolut EUR Savings")
- `Number`: Account/IBAN number (e.g., "DE89370400440532013000")
- `CurrencyId` (FK): Single currency for this account
- `CurrentBalance`: Decimal amount currently in the account
- `IsActive`: Account is usable (can post transactions)
- `IsDeleted`: Soft-delete (preserve history)
- `CreatedDate`: When user added this account

**Relationships:**
- Belongs to one `FinancialInstitution`
- Has many `FinancialTransactions`

**Key Constraint:** Records are filtered by `FinancialInstitution.UserId == CurrentUserId`.

---

### 6. FinancialTransaction (renamed from Transaction)
**Purpose:** An atomic debit or credit movement on a MoneyAccount  
**Properties:**
- `Id` (PK)
- `MoneyAccountId` (FK): Which account was affected
- `Description`: Transaction memo (e.g., "Restaurant XYZ")
- `Amount`: Decimal amount (positive for debit, negative for credit? or always positive with Action field?)
- `BalanceAfterTransaction`: Account balance post-transaction (immutable audit trail)
- `Action`: Type/category of transaction
  - Possible values: `"DEBIT"` (expense), `"CREDIT"` (income), `"TRANSFER"` (between accounts), `"PAYMENT"` (credit card payment), `"RECURRING"` (scheduled payment)
- `CreatedDate`: When transaction occurred

**Relationships:**
- Belongs to one `MoneyAccount`
- May link to one `Expense` (if created from an expense record)

**Key Constraint:**
- Records are filtered by `MoneyAccount.FinancialInstitution.UserId == CurrentUserId`
- **Immutability Rule:** Once a transaction is created/processed, it cannot be modified (maintains audit trail)

---

### 7. PaymentCard (suggested name; currently "Account" usage is overloaded)
**Purpose:** Debit or credit card associated with an account  
**Note:** Currently, the system does not have a separate PaymentCard entity; cards are inferred from the Account or could be added as a new entity.

**Proposed Properties (if to be added):**
- `Id` (PK)
- `MoneyAccountId` (FK): The account this card is tied to (optional; null for credit cards)
- `Name`: Card nickname (e.g., "My Revolut Card")
- `CardType`: `"DEBIT"` or `"CREDIT"`
- `LastFourDigits`: Last 4 digits for display
- `ExpiryDate`: Card expiry
- `IssuerBank`: Card issuer (may differ from account institution)
- `PaymentDueDay`: Day of month when credit card bill is due (e.g., 20th)
- `IsActive`: Card is usable
- `CreatedDate`

**Key Business Rule:** 
- If `PaymentCard.CardType == "CREDIT"`, it must have a `PaymentDueDay`.
- Credit card transactions generate `RecurringPayment` entries to track due dates.

---

### 8. Expense
**Purpose:** A spending event that can be recorded against a category and optionally linked to a FinancialTransaction  
**Properties:**
- `Id` (PK)
- `CategoryId` (FK): Which expense category (e.g., "Dining", "Healthcare")
- `Establishment`: Where the expense occurred (e.g., "Restaurant ABC", "Hospital XYZ")
- `CurrencyId` (FK): Currency of the expense
- `Price`: Amount spent
- `IsPaid`: Boolean indicating if this expense has been settled (linked to a transaction)
- `FinancialTransactionId` (FK, nullable): Links to the actual debit/credit transaction if processed
- `CreatedDate`: When expense was recorded

**Relationships:**
- Belongs to one `Category`
- Optionally belongs to one `FinancialTransaction`

**Key Workflow:**
1. User creates an `Expense` record when they spend money (e.g., restaurant bill).
2. User marks it `IsPaid = true` and links it to a `FinancialTransaction` (from their account).
3. The system debits the account balance.

---

### 9. Category
**Purpose:** User-defined categories for organizing expenses  
**Properties:**
- `Id` (PK)
- `UserId` (FK): Which user owns this category
- `Name`: Category name (e.g., "Dining", "Healthcare", "Transport")
- `CreatedDate`

**Relationships:**
- Belongs to one `User`
- Has many `Expenses`

---

### 10. Wallet
**Purpose:** A digital money pool for a user, independent of a bank account (e.g., savings goal, emergency fund)  
**Properties:**
- `Id` (PK)
- `UserId` (FK)
- `Name`: Wallet alias (e.g., "Emergency Fund", "Vacation Savings")
- `CurrencyId` (FK): Single currency
- `CurrentBalance`: Decimal amount
- `IsActive`: Wallet is usable
- `CreatedDate`

**Relationships:**
- Belongs to one `User`

**Key Difference from MoneyAccount:**  
- Wallets are **not tied to a bank** — they are user-managed digital pools.
- Used for savings goals, budgets, or personal tracking outside of official bank accounts.

---

### 11. RecurringPayment (suggested new entity)
**Purpose:** Automate recurring debits for bills, subscriptions, or credit card payments  
**Properties:**
- `Id` (PK)
- `UserId` (FK)
- `Name`: Payment name (e.g., "Internet Bill", "Gym Membership")
- `MoneyAccountId` (FK): Account from which to debit
- `Amount`: Fixed amount per cycle
- `CurrencyId` (FK)
- `Frequency`: `"MONTHLY"`, `"QUARTERLY"`, `"YEARLY"` (or cron-like schedule)
- `DayOfMonth`: Day to execute (e.g., 15th of each month)
- `StartDate`: When recurring payment begins
- `EndDate` (nullable): When it ends (if finite)
- `IsActive`: Payment is scheduled
- `IsProcessed`: Tracks if the payment has run in the current cycle (reset monthly)
- `LastExecutedDate`: Audit trail
- `CreatedDate`

**Relationships:**
- Belongs to one `User`
- Belongs to one `MoneyAccount`

**Key Workflow:**
1. User creates a `RecurringPayment` for "Internet Bill = €50 on the 20th of each month".
2. A background scheduler checks daily for due payments.
3. On the 20th, the system:
   - Creates a `FinancialTransaction` (debit of €50)
   - Updates the `MoneyAccount.CurrentBalance`
   - Logs the execution

---

### 12. LoginAuditLog (renamed from UserLoginHistory)
**Purpose:** Security audit trail for user authentication  
**Properties:**
- `Id` (PK)
- `UserId` (FK, nullable): User who logged in (null if login failed)
- `ActionDateTime`: When login occurred
- `IsSuccessful`: Login succeeded or failed
- `IPAddress`: Client IP for geo-location and anomaly detection
- `GeoLocation`: Derived geo-location (e.g., city, country)

---

## Core Workflows & Business Logic

### Workflow 1: User Registration & Setup
```
1. User creates account (Email, Password, FullName)
2. System generates ConfirmationCode (GUID)
3. Email confirmation sent (async)
4. User clicks confirmation link → IsVerified = true
5. User selects default Currency and TimeZone
→ User account is active and can create accounts/wallets
```

### Workflow 2: Create a Bank Account
```
1. User navigates to "Add Financial Institution"
2. User selects from list or adds custom: Name, Branch
3. System creates FinancialInstitution record (UserId = current user)
4. User then creates MoneyAccount under that institution:
   - Name, Number (IBAN/account number)
   - Currency (can differ from user default)
   - InitialBalance (optional; defaults to 0)
5. System creates MoneyAccount and initializes CurrentBalance
→ Account is ready to receive transactions
```

### Workflow 3: Record a Debit Card Transaction
```
1. User spends money at restaurant (uses debit card linked to their account)
2. User creates Expense:
   - Establishment: "Restaurant ABC"
   - Category: (user selects "Dining")
   - Price: €45.50
   - Currency: EUR
   - IsPaid: false (initially recorded but not yet processed)
3. Later, user marks expense as IsPaid = true and links to MoneyAccount
4. System creates FinancialTransaction:
   - MoneyAccountId: (the debit account)
   - Description: "Restaurant ABC"
   - Amount: 45.50 (debit)
   - Action: "DEBIT"
   - BalanceAfterTransaction: (previous balance - 45.50)
5. System updates MoneyAccount.CurrentBalance
6. Expense.FinancialTransactionId = (new transaction ID)
→ Expense is now marked as processed
```

### Workflow 4: Create a Recurring Payment (e.g., Gym Membership)
```
1. User creates RecurringPayment:
   - Name: "Gym Membership"
   - Amount: €50
   - Frequency: "MONTHLY"
   - DayOfMonth: 15
   - MoneyAccountId: (debit from EUR account)
2. System schedules the payment

3. Background job runs daily:
   - Checks for due RecurringPayments (today's date == DayOfMonth)
   - Finds "Gym Membership" due on 15th
   - Creates FinancialTransaction:
     - MoneyAccountId: (the specified account)
     - Description: "Gym Membership"
     - Amount: 50 (debit)
     - Action: "RECURRING"
   - Updates MoneyAccount.CurrentBalance
   - Updates RecurringPayment.LastExecutedDate
→ Automatic debit applied monthly
```

### Workflow 5: Pay a Credit Card Bill
```
1. User has a PaymentCard (CREDIT) with PaymentDueDay = 20
2. User accrues charges on the credit card throughout the month
3. On the 20th (PaymentDueDay):
   - System creates a RecurringPayment or manually allows user to pay
   - User selects from which MoneyAccount to pay (e.g., EUR Checking)
   - System creates FinancialTransaction:
     - MoneyAccountId: (the checking account)
     - Description: "Credit Card Payment"
     - Amount: (total due)
     - Action: "PAYMENT"
   - Updates MoneyAccount.CurrentBalance
→ Credit card debt is settled, account balance decreases
```

### Workflow 6: Multi-Currency Tracking
```
1. User has multiple accounts:
   - BRL Account (Brazil, Bradesco): Balance 10,000 BRL
   - EUR Account (Germany, Deutsche Bank): Balance 5,000 EUR
2. User wants to track total wealth:
   - System displays each account in its native currency
   - (No automatic conversion; user must manually track or use external FX rates)
   - User can create Wallets in any currency to manually pool funds conceptually
→ User can see all accounts and wallets organized by currency
```

---

## Data Integrity Rules & Constraints

| Rule | Rationale |
|------|-----------|
| **User Data Isolation** | All queries filtered by `UserId == CurrentUserId` at DbContext level. Prevents users seeing others' data. |
| **Transaction Immutability** | Once a `FinancialTransaction` is created, it cannot be modified or deleted. Ensures audit trail and account balance accuracy. |
| **Single Currency per Account** | Each `MoneyAccount` and `Wallet` has exactly one currency. No automatic FX conversion. |
| **Balance Audit Trail** | `FinancialTransaction.BalanceAfterTransaction` is immutable, providing a point-in-time balance snapshot. |
| **Soft Deletes** | `FinancialInstitution` and `MoneyAccount` use `IsDeleted` flag to preserve transaction history. |
| **Credit Card Payment Due Day** | `PaymentCard.PaymentDueDay` is required and enforced if `CardType == "CREDIT"`. |
| **Recurring Payment Frequency** | Supported frequencies: `MONTHLY`, `QUARTERLY`, `YEARLY`. Execution happens on specified `DayOfMonth`. |
| **Email Uniqueness** | User `Email` is unique and used for authentication and recovery. |
| **Login History** | All login attempts (successful and failed) are logged with IP and geo-location for security audits. |

---

## API Endpoints (Functional Categories)

### Authentication
- `POST /auth/register` — Create user account
- `POST /auth/confirm-email` — Verify email with confirmation code
- `POST /auth/login` — Authenticate and return JWT
- `POST /auth/refresh-token` — Refresh expired JWT
- `POST /auth/logout` — Invalidate current token

### User Profile
- `GET /users/me` — Current user details
- `PUT /users/me` — Update profile (FullName, Email, TimeZone, DefaultCurrency)
- `GET /users/me/login-history` — View login audit trail

### Financial Institutions (Banks)
- `POST /institutions` — Create new bank/financial institution
- `GET /institutions` — List user's institutions
- `PUT /institutions/{id}` — Update institution details
- `DELETE /institutions/{id}` — Soft-delete institution

### Money Accounts
- `POST /institutions/{id}/accounts` — Add account to institution
- `GET /institutions/{id}/accounts` — List accounts for institution
- `PUT /accounts/{id}` — Update account (name, balance, active status)
- `DELETE /accounts/{id}` — Soft-delete account
- `GET /accounts/{id}/balance` — Get current balance

### Transactions
- `POST /accounts/{id}/transactions` — Record a transaction (debit/credit/transfer)
- `GET /accounts/{id}/transactions` — List transactions with filters (date range, amount, action)
- `GET /transactions/{id}` — Get single transaction details (immutable; view-only after creation)

### Expenses
- `POST /expenses` — Create expense record
- `GET /expenses` — List expenses with filters
- `PUT /expenses/{id}` — Update unpaid expense (before linking to transaction)
- `DELETE /expenses/{id}` — Delete unpaid expense
- `POST /expenses/{id}/pay` — Link expense to transaction (mark as paid)

### Categories
- `POST /categories` — Create expense category
- `GET /categories` — List user's categories
- `PUT /categories/{id}` — Update category name
- `DELETE /categories/{id}` — Delete category (soft-delete)

### Wallets (Digital Money Pools)
- `POST /wallets` — Create wallet (savings goal, emergency fund, etc.)
- `GET /wallets` — List user's wallets
- `PUT /wallets/{id}` — Update wallet (name, balance, active status)
- `DELETE /wallets/{id}` — Delete wallet

### Recurring Payments
- `POST /recurring-payments` — Create recurring payment (bills, subscriptions, credit card payments)
- `GET /recurring-payments` — List active recurring payments
- `PUT /recurring-payments/{id}` — Update recurring payment (amount, day, frequency, start/end dates)
- `DELETE /recurring-payments/{id}` — Cancel recurring payment
- `GET /recurring-payments/{id}/execution-history` — View past executions

### Currencies & Timezones (Reference Data)
- `GET /currencies` — List all supported currencies
- `GET /timezones` — List all supported timezones

---

## Entity Relationship Diagram (ERM)

```
┌─────────────────────┐
│       User          │
├─────────────────────┤
│ Id (PK)             │
│ FullName            │
│ Email               │
│ PasswordHash/Salt   │
│ CurrencyId (FK)     │ ──────┐
│ StateTimeZoneId(FK) │ ──┐   │
│ IsVerified          │   │   │
│ ConfirmationCode    │   │   │
│ CreatedDate         │   │   │
└─────────────────────┘   │   │
     │ 1 to many          │   │
     │                    │   │
     ├─→ FinancialInstitution
     │
     ├─→ Category
     │
     ├─→ Wallet
     │
     └─→ RecurringPayment
                             │
┌──────────────────────────┐ │
│   Currency               │ │
├──────────────────────────┤ │
│ Id (PK)                  │←┘
│ Code (ISO 4217)          │
└──────────────────────────┘

┌──────────────────────────┐
│   StateTimeZone          │
├──────────────────────────┤
│ Id (PK)                  │
│ UTC                      │
│ Description              │
│ TimeZoneInfoId           │
│ SupportsDaylightSavingTime
└──────────────────────────┘

┌──────────────────────────────┐
│  FinancialInstitution (Bank) │
├──────────────────────────────┤
│ Id (PK)                      │
│ UserId (FK) ─────────┐       │
│ Name                 │       │
│ Branch               │       │
│ IsActive             │       │
│ IsDeleted            │       │
│ CreatedDate          │       │
└──────────────────────────────┘
     │ 1 to many
     │
     └─→ MoneyAccount
         │ 1 to many
         │
         └─→ FinancialTransaction

┌──────────────────────────────┐
│      MoneyAccount            │
├──────────────────────────────┤
│ Id (PK)                      │
│ FinancialInstitutionId (FK)  │
│ Name                         │
│ Number                       │
│ CurrencyId (FK)              │
│ CurrentBalance               │
│ IsActive                     │
│ IsDeleted                    │
│ CreatedDate                  │
└──────────────────────────────┘

┌──────────────────────────────┐
│    FinancialTransaction      │
├──────────────────────────────┤
│ Id (PK)                      │
│ MoneyAccountId (FK)          │
│ Description                  │
│ Amount                       │
│ BalanceAfterTransaction      │
│ Action (DEBIT/CREDIT/etc)    │
│ CreatedDate                  │
│ [IMMUTABLE after creation]   │
└──────────────────────────────┘
     ▲
     │ 0 to 1
     │
┌────────────────────┐
│    Expense         │
├────────────────────┤
│ Id (PK)            │
│ CategoryId (FK)    │
│ Establishment      │
│ CurrencyId (FK)    │
│ Price              │
│ IsPaid             │
│ TransactionId (FK) │
│ CreatedDate        │
└────────────────────┘

┌────────────────────┐
│    Category        │
├────────────────────┤
│ Id (PK)            │
│ UserId (FK)        │
│ Name               │
│ CreatedDate        │
└────────────────────┘

┌────────────────────┐
│     Wallet         │
├────────────────────┤
│ Id (PK)            │
│ UserId (FK)        │
│ Name               │
│ CurrencyId (FK)    │
│ CurrentBalance     │
│ IsActive           │
│ CreatedDate        │
└────────────────────┘

┌─────────────────────────────┐
│   RecurringPayment          │
├─────────────────────────────┤
│ Id (PK)                     │
│ UserId (FK)                 │
│ Name                        │
│ MoneyAccountId (FK)         │
│ Amount                      │
│ CurrencyId (FK)             │
│ Frequency (MONTHLY/etc)     │
│ DayOfMonth                  │
│ StartDate                   │
│ EndDate (nullable)          │
│ IsActive                    │
│ IsProcessed                 │
│ LastExecutedDate            │
│ CreatedDate                 │
└─────────────────────────────┘

┌─────────────────────────────┐
│    LoginAuditLog            │
├─────────────────────────────┤
│ Id (PK)                     │
│ UserId (FK, nullable)       │
│ ActionDateTime              │
│ IsSuccessful                │
│ IPAddress                   │
│ GeoLocation                 │
└─────────────────────────────┘
```

---

## Suggested Improvements & New Features for Agents

1. **PaymentCard Entity** — Separate cards (debit/credit) from accounts for clarity on payment methods.
2. **TransactionCategory** — Link transactions to implicit or explicit categories for spending analysis.
3. **BudgetPolicy** — Define monthly/yearly budgets per category; alert when exceeded.
4. **ExchangeRate** — Log historical FX rates for multi-currency accounts (for reporting).
5. **TransactionReconciliation** — Mark transactions as reconciled against bank statements.
6. **Scheduled Reports** — Email daily/weekly summaries of spending, balance changes.
7. **Webhooks** — Notify user's app of large transactions or recurring payment failures.

---

## Technology Stack (Current)

- **Backend:** ASP.NET Core 8 (WebApplication minimal hosting)
- **ORM:** Entity Framework Core 8
- **Database:** SQL Server
- **API Pattern:** CQRS + MediatR 11.x + AutoMapper 12.x
- **Authentication:** JWT Bearer tokens
- **Validation:** FluentValidation
- **Email:** (configured but implementation not shown)

---

## Key Takeaways for Agents

**This system is a multi-tenant (per-user) financial tracking platform with:**
- **Accounts as the ledger:** MoneyAccount tracks balances and transactions.
- **Expenses as the tracker:** Separate recording of spending for budgeting and analysis.
- **Wallets for savings:** Independent money pools outside official accounts.
- **Recurring payments as automation:** Background scheduler debits recurring bills.
- **Immutable transactions:** Once posted, transactions form an immutable audit trail.
- **Multi-currency support:** Each account/wallet in single currency; no automatic conversion.
- **User isolation:** All queries filtered by current user; no cross-user data leaks.

Agents should focus on:
1. **Entity creation workflows** (user → institution → account → transactions)
2. **Transaction immutability** (no modifications after posting)
3. **Balance reconciliation** (BalanceAfterTransaction snapshot for each transaction)
4. **Recurring execution logic** (background job scheduling and execution tracking)
5. **Multi-currency handling** (no conversion; user manages currency-by-currency)

---

## File References (Current Codebase)

- **Entities:** `FinanceTracker.Domain/Entities/*.cs`
- **Application Context:** `FinanceTracker.Infrastructure/Persistence/ApplicationDbContext.cs`
- **Commands/Queries:** `FinanceTracker.Application/Commands/` & `/Queries/` (CQRS structure)
- **DTOs:** `FinanceTracker.Application/Dtos/`
- **API Controllers:** `FinanceTracker.API/Controllers/`

