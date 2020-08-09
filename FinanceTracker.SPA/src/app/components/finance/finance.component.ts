import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-finance',
  templateUrl: './finance.component.html',
  styleUrls: ['./finance.component.scss']
})
export class FinanceComponent implements OnInit, OnDestroy {
  currentPage = 'expensehistory';
  private subscription: Subscription;
  pageTitle = '';
  
  constructor(private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.subscription = this.activatedRoute.params.subscribe(params => {
       this.currentPage = params.pageId;
       this.pageTitle = this.currentPage === 'expensehistory' ? 'Expenses'
            : (this.currentPage === 'income' ? 'Income' : 'Categories');
     });
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
