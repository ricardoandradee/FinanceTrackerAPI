import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-account-actions',
  templateUrl: './account-actions.component.html',
  styleUrls: ['./account-actions.component.scss']
})
export class AccountActionsComponent implements OnInit {
  accountAction = 'Deposit';
  
  constructor() { }

  ngOnInit() {
  }

}
