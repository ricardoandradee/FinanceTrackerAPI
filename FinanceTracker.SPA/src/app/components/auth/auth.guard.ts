import { CanActivate, Router } from '@angular/router';
import { Injectable } from '@angular/core';

import { AuthService } from 'src/app/services/auth.service';
import { UiService } from 'src/app/services/ui.service';

@Injectable()
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router, private uiService: UiService) { }
  canActivate(): boolean {

    if (this.authService.loggedIn()) {
      return true;
    }
    this.uiService.showSnackBar('You shall not pass!!!', 3000);
    this.router.navigate(['/login']);
    return false;
  }
}