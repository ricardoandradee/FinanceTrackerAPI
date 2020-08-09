import { FormControl, NgForm, FormGroupDirective } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material';

export class ErrorUserNameAlreadyTakenMatcher implements ErrorStateMatcher {
  constructor(private userNames: string[]) { }
  isErrorState(control: FormControl, form: FormGroupDirective | NgForm): boolean {
    const inputValue = control && control.value ? control.value.toString() : '';
    const isFormValid = control && control.dirty && control.touched && this.userNames.indexOf(inputValue) > -1;

    if (isFormValid) {
      control.setErrors({ userNameAlreadyTaken: true });
    }

    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}
