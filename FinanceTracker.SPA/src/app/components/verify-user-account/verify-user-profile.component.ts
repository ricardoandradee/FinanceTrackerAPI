import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserValidation } from 'src/app/models/user-validation.model';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-verify-user-profile',
  templateUrl: './verify-user-profile.component.html',
  styleUrls: ['./verify-user-profile.component.scss']
})
export class VerifyUserProfileComponent implements OnInit {
  private subscription: Subscription;
  processed = false;
  successfull = false;
  message_response = '';

  constructor(private route: ActivatedRoute,
              private authService: AuthService) { }

  ngOnInit() {
    let userId: number = this.route.snapshot.queryParams["userId"];
    let confirmationCode: string = this.route.snapshot.queryParams["confirmationCode"];

    var model = {
      userId: Number(userId),
      confirmationCode: confirmationCode
    } as UserValidation;
    
    this.subscription = this.authService
      .confirmUserRegistration(model).subscribe((response: any) => {
        this.successfull = response.ok;
        this.message_response = this.successfull ? response.data : response.message;
    }, error => {
      this.successfull = false;
      this.message_response = error;
    }, () => {
      this.processed = true;
    });
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
