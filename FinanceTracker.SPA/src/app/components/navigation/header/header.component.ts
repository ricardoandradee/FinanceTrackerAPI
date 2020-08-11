import { Component, OnInit,  EventEmitter, Output, OnDestroy } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { CurrencyService } from 'src/app/services/currency.service';
import { User } from 'src/app/models/user.model';
import { Observable, Subscription } from 'rxjs';
import { BankAccountService } from 'src/app/services/bank-account.service';
import { Account } from 'src/app/models/account.model';
import { Currency } from 'src/app/models/currency.model';
import { CommonService } from 'src/app/services/common.service';
import { UserSettingsComponent } from '../../user-settings/user-settings.component';
import { MatDialog, TooltipPosition } from '@angular/material';
import { UserService } from 'src/app/services/user.service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit, OnDestroy {
  @Output() sidenavToggle = new EventEmitter<void>();
  private allSubscriptions: Subscription[] = [];
  public positionOptions: TooltipPosition[] = ['left'];
  public position = new FormControl(this.positionOptions[0]); 
  currentUser: User;
  currencies: Currency[];
  userBaseCurrency: Currency;
  openSideNav = false;
  disableBaseCurrency = true;
  allAccounts: Account[];
  isAuth$: Observable<boolean>;

  constructor(private authService: AuthService,
              private dialog: MatDialog,
              private userService: UserService,
              private bankAccountService: BankAccountService,
              private commonService: CommonService) { }

  ngOnInit() {   
    const userSettingsSubscription = this.userService.getUserSettings.subscribe((user: User) => {
      this.userBaseCurrency = user.currency;
      this.currentUser = user;
    });

    this.commonService.getAllCurrencies.subscribe(c => {
      this.currencies = c;
    });

    this.isAuth$ = this.authService.getIsAuthenticated; 

    const bankSubscription = this.bankAccountService.getBankAccountInfos.subscribe(bank => {
      const accounts = ([] as Account[]).concat(...bank.map(x => ( x.accounts )));
      this.allAccounts = [...accounts];
    });

    this.allSubscriptions.push(userSettingsSubscription);
    this.allSubscriptions.push(bankSubscription);
  }
  
  openUserSettingsDialog() {
    const dialogRef = this.dialog.open(UserSettingsComponent);
    let dialogSubscription = dialogRef.afterClosed().subscribe(result => {
      if (result.data && this.hasUserSettingsChanged(result.data)) {
        let updateSubscription = this.userService.updateUserSettings(result.data).subscribe((response) => {
          if (response.ok) {
            this.currentUser = {
              ...this.currentUser,
              currency: result.data.currency,
              country: result.data.country,
              stateTimeZone: result.data.stateTimeZone
            };
        
            this.userService.setUserSettings = this.currentUser;
            localStorage.setItem('user', JSON.stringify(this.currentUser));
          }
        });
        this.allSubscriptions.push(updateSubscription);
      }
    });
    this.allSubscriptions.push(dialogSubscription);
  }

  private hasUserSettingsChanged(model: any) {
    const userJson = JSON.stringify({ currency: this.currentUser.currency, stateTimeZone:  this.currentUser.stateTimeZone });
    const modifiedUserJson = JSON.stringify({ currency: model.currency, stateTimeZone:  model.stateTimeZone });

    return userJson.toLowerCase() !== modifiedUserJson.toLowerCase();
  }

  onToggleSidenav() {
    this.openSideNav = !this.openSideNav;
    this.sidenavToggle.emit();
  }

  onLogout() {
    if (this.openSideNav) {
      this.onToggleSidenav();
    }
    this.authService.logout();
  }

  ngOnDestroy(): void {
    this.allSubscriptions.forEach(s => { s.unsubscribe()});
  }
}