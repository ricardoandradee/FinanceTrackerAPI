import { Component, OnInit, EventEmitter, Output, OnDestroy } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Observable, Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material';
import { UserSettingsComponent } from '../../user-settings/user-settings.component';

@Component({
  selector: 'app-sidenav-list',
  templateUrl: './sidenav-list.component.html',
  styleUrls: ['./sidenav-list.component.scss']
})
export class SidenavListComponent implements OnInit, OnDestroy {
  @Output() sidenavClose = new EventEmitter<void>();
  private subscriptions: Subscription;
  isAuth$: Observable<boolean>;
  sidenavWidth = 4;
  
  constructor(private authService: AuthService,
              private router: Router, private dialog: MatDialog) { }

  ngOnInit() {
    this.isAuth$ = this.authService.getIsAuthenticated;
  }  

  isActive(url: string): boolean {
    return this.router.isActive(url, false);
  }
  
  openUserSettingsDialog() {
      const dialogRef = this.dialog.open(UserSettingsComponent);
      this.subscriptions = dialogRef.afterClosed().subscribe(result => {
        console.log({settings: result});
      });
  }

  onSignOut() {
    this.sidenavClose.emit();
    this.authService.logout();
  }
  
  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }
}
