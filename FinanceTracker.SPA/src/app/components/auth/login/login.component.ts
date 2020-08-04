import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../../../services/auth.service';
import { UiService } from 'src/app/services/ui.service';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit, OnDestroy {
  loginForm: FormGroup;
  private subscription: Subscription;

  constructor(private authService: AuthService, private uiService: UiService, private router: Router) { }

  ngOnInit() {
    this.loginForm = this.createFormGroup();
  }

  createFormGroup() {
    return new FormGroup({
      userName: new FormControl('', [Validators.required, Validators.minLength(6)]),
      password: new FormControl('', [Validators.required, Validators.minLength(6)])
    });
  }

  createFormGroupWithBuilder(formBuilder: FormBuilder) {
    return formBuilder.group({
      userName: 'loren',
      password: 'password'
    });
  }

  onLogin() {
    // Make sure to create a deep copy of the form-model
    const result: any = Object.assign({}, this.loginForm.value);
    this.subscription = this.authService.login({ Username: result.userName, Password: result.password});
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
