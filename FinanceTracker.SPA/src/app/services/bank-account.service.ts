import { Injectable, OnDestroy } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { BankAccount } from '../models/bank-account.model';
import { User } from '../models/user.model';
import { Observable, BehaviorSubject, Subscription } from 'rxjs';
import { AuthService } from './auth.service';
import { AccountMinus } from '../models/account.minus.model';
import { AccountTransaction } from '../models/account.transaction.model';

@Injectable()
export class BankAccountService implements OnDestroy {
    private baseUrl = environment.apiUrl;
    private subscription: Subscription;
    private dataSource$: BehaviorSubject<BankAccount[]> = new BehaviorSubject([]);

    constructor(private http: HttpClient, private authService: AuthService) {
        this.authService.getIsAuthenticated.subscribe(isAuth => {
            if (isAuth) {
                this.loadBankAccounts();
            }
        })       
    }

        get getBankAccountInfos(): Observable<BankAccount[]> {
            return this.dataSource$.asObservable();
        }
    
        set setBankAccountInfos(bankInfos: BankAccount[]) {
            this.dataSource$.next(bankInfos);
        }
    
        set addAccountTransaction(accountTransaction: AccountTransaction) {
            this.subscription = this.dataSource$.pipe(take(1)).subscribe(banks => {
                var bank  = banks.find(b => b.accounts.some(a => a.id == accountTransaction.id));
                var accountToBeUpdated = bank.accounts.find(a => a.id === accountTransaction.id);
                accountToBeUpdated.transactions.push(accountTransaction.transaction);
                this.setBankAccountInfos = banks;
              });
        }

        set updateAccountBalance(accountMinus: AccountMinus) {
            this.subscription = this.dataSource$.pipe(take(1)).subscribe(banks => {
                var bank  = banks.find(b => b.accounts.some(a => a.id == accountMinus.id));
                var accountToBeUpdated = bank.accounts.find(a => a.id === accountMinus.id);
                accountToBeUpdated.currentBalance += accountMinus.transactionAmount;
                this.setBankAccountInfos = banks;
              });
        }
        
    private loadBankAccounts() {
        const user: User = JSON.parse(localStorage.getItem('user'));
        const url = `${this.baseUrl}user/${user.id}/bank/GetBanksByUserId`;
        
        return this.http.get<BankAccount[]>(url, { observe: 'response' })
        .pipe(map(response => {
            return (response.body as BankAccount[]).sort((a, b) => (a.name > b.name) ? 1 : -1);
        })).subscribe((bankAccounts: BankAccount[]) => {
            this.dataSource$.next(bankAccounts);
        });
    }
        
    deleteBankInfo(bankId: number) {
        const user: User = JSON.parse(localStorage.getItem('user'));
        const url = `${this.baseUrl}user/${user.id}/bank/DeleteBankInfo/${bankId}`;
        return this.http.delete(url, {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        });
    }
    
    createBankWithAccount(bankAccount: BankAccount) {
        const user: User = JSON.parse(localStorage.getItem('user'));
        const newBankInfo = {
            userId: user.id,
            name: bankAccount.name,
            branch: bankAccount.branch,
            isActive: bankAccount.isActive,
            accounts: bankAccount.accounts
        };

        const url = `${this.baseUrl}user/${user.id}/bank/CreateBankWithAccount`;
        const httpHeaders = new HttpHeaders({
            'Content-Type' : 'application/json'
        });

        return this.http.post(url, newBankInfo, { headers: httpHeaders, observe: 'response' });
    }

    updateBankInfo(bankAccount: BankAccount) {
        const user: User = JSON.parse(localStorage.getItem('user')); 
        const url = `${this.baseUrl}user/${user.id}/bank/updateBankInfo/${bankAccount.id}`;
        const newBankInfo = {
            name: bankAccount.name,
            branch: bankAccount.branch,
            isActive: bankAccount.isActive,
            accountsForCreation: bankAccount.accounts
        };
        
        const httpHeaders = new HttpHeaders({
            'Content-Type' : 'application/json'
        });

        return this.http.put(url, newBankInfo, { headers: httpHeaders, observe: 'response' });
    }

    ngOnDestroy(): void {
        if (this.subscription) {
          this.subscription.unsubscribe();
        }
    }
}