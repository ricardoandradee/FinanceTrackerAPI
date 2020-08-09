If Exists (Select 1 From sys.procedures Where Name = 'PerformAccountTransaction')
Begin
	Drop Procedure PerformAccountTransaction
End

Go


Create Procedure PerformAccountTransaction
(
	@action Varchar(10),
	@amount Decimal(10, 2),
	@description Varchar(100),
	@createdDate DateTimeOffset(7),
	@accountId Int,
    @transactionId Int Output
)
As
Begin

	Declare @balanceAfterTransaction As Decimal(10, 2);

	Begin Try
        Begin Transaction;

		Update Accounts 
		Set    Currentbalance = Case 
								  When @action = 'Deposit' Then currentbalance + @amount 
								  When @action = 'Withdraw' Then 
								  currentbalance - @amount 
								  Else currentbalance 
								End 
		Where  Id = @accountId;

		Select @balanceAfterTransaction = Currentbalance
		From Accounts
		Where  Id = @accountId;

		Insert Into Transactions 
					([Description], 
					 Amount, 
					 Balanceaftertransaction, 
					 [Action], 
					 Accountid, 
					 Createddate) 
		Values      (@description, 
					 @amount, 
					 @balanceAfterTransaction, 
					 @action, 
					 @accountId, 
					 @createdDate);

        Commit Transaction;  
    End Try
    Begin Catch
        
        -- Test if the transaction is uncommittable.  
        If (XACT_STATE()) = -1  
        Begin  
            Print  N'The transaction is in an uncommittable state.' +  
                    'Rolling back transaction.'  
			Rollback Transaction;  
        End;  
        
        -- Test if the transaction is committable.  
        If (XACT_STATE()) = 1  
        Begin  
            Print N'The transaction is committable.' +  
                'Committing transaction.'  
            Commit Transaction;    
        End;  
    End Catch

	Select @transactionId = SCOPE_IDENTITY();
End

Go

If Exists (Select 1 From sys.procedures Where Name = 'CreateBankWithAccount')
Begin
	Drop Procedure CreateBankWithAccount
End

Go

Create Procedure CreateBankWithAccount
(
	@userId Int,
	@bankName Varchar(100),
	@branch Varchar(50),
	@accountName Varchar(100),
	@accountNumber Varchar(25),
	@accountCurrency Int,
	@currentBalance Decimal(18, 2),
	@createdDate DateTimeOffset(7),
    @bankId Int Output
)
As
Begin

	Begin Try
        Begin Transaction;

		Insert Into Banks
					(Branch,
					[Name],
					IsActive,
					UserId,
					CreatedDate) 
		Values     (@branch,
				    @bankName,
				    1,
				    @userId,
				    @createdDate);
					
		Select @bankId = SCOPE_IDENTITY();

		Insert Into Accounts
					(BankId,
					[Name],
					[Number],
					IsActive,
					CurrencyId,
					CurrentBalance,
					CreatedDate) 
		Values     (@bankId,
				    @accountName,
					@accountNumber,
				    1,
					@accountCurrency,
				    @currentBalance,
				    @createdDate);

		Insert Into Transactions 
					([Description], 
					 Amount, 
					 Balanceaftertransaction, 
					 [Action], 
					 Accountid, 
					 Createddate) 
		Values      ('Initial bank account deposit.', 
					 @currentBalance, 
					 @currentBalance, 
					 'Deposit', 
					 SCOPE_IDENTITY(), 
					 @createdDate);

        Commit Transaction;  
    End Try
    Begin Catch
        
        -- Test if the transaction is uncommittable.  
        If (XACT_STATE()) = -1  
        Begin
			Set @bankId = 0;
            Print  N'The transaction is in an uncommittable state.' +  
                    'Rolling back transaction.'  
			Rollback Transaction;  
        End;  
        
        -- Test if the transaction is committable.  
        If (XACT_STATE()) = 1  
        Begin  
            Print N'The transaction is committable.' +  
                'Committing transaction.'  
            Commit Transaction;    
        End;  
    End Catch
End

Go

If Exists (Select 1 From sys.procedures Where Name = 'CreateAccount')
Begin
	Drop Procedure CreateAccount
End

Go

Create Procedure CreateAccount
(
	@bankId Int,
	@accountName Varchar(100),
	@accountNumber Varchar(25),
	@accountCurrency Int,
	@currentBalance Decimal(18, 2),
	@createdDate DateTimeOffset(7),
    @accountId Int Output
)
As
Begin

	Begin Try
        Begin Transaction;

		Insert Into Accounts
					(BankId,
					[Name],
					[Number],
					IsActive,
					CurrencyId,
					CurrentBalance,
					CreatedDate) 
		Values     (@bankId,
				    @accountName,
					@accountNumber,
				    1,
					@accountCurrency,
				    @currentBalance,
				    @createdDate);
					
		Select @accountId = SCOPE_IDENTITY();

		Insert Into Transactions 
					([Description], 
					 Amount, 
					 Balanceaftertransaction, 
					 [Action], 
					 Accountid, 
					 Createddate) 
		Values      ('Initial bank account deposit.', 
					 @currentBalance, 
					 @currentBalance, 
					 'Deposit', 
					 @accountId, 
					 @createdDate);

        Commit Transaction;  
    End Try
    Begin Catch
        
        -- Test if the transaction is uncommittable.  
        If (XACT_STATE()) = -1  
        Begin
			Set @accountId = 0;
            Print  N'The transaction is in an uncommittable state.' +  
                    'Rolling back transaction.'  
			Rollback Transaction;  
        End;  
        
        -- Test if the transaction is committable.  
        If (XACT_STATE()) = 1  
        Begin  
            Print N'The transaction is committable.' +  
                'Committing transaction.'  
            Commit Transaction;    
        End;  
    End Catch
End

Go