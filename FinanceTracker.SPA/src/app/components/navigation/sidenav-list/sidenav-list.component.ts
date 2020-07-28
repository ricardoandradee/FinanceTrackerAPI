import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-sidenav-list',
  templateUrl: './sidenav-list.component.html',
  styleUrls: ['./sidenav-list.component.scss']
})
export class SidenavListComponent implements OnInit {
  @Output() sidenavClose = new EventEmitter<void>();
  isAuth$: Observable<boolean>;
  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.isAuth$ = this.authService.getIsAuthenticated;
  }
  
  onClose() {
    this.sidenavClose.emit();
  }
  onSignOut() {
    this.onClose();
    this.authService.logout();
  }
}
