import { NgModule } from '@angular/core';
import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AngularFireAuthModule } from '@angular/fire/auth';
import { SharedModule } from '../../shared/shared.module';
import { AuthRoutingModule } from './auth-routing.module';
import { VerifyUserProfileComponent } from '../verify-user-account/verify-user-profile.component';

@NgModule({
    declarations: [
        SignupComponent,
        LoginComponent,
        VerifyUserProfileComponent
    ],
    imports: [
        SharedModule,
        ReactiveFormsModule,
        AngularFireAuthModule,
        AuthRoutingModule
    ]
})
export class AuthModule {

}