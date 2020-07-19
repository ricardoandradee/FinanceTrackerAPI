import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { Payment } from '../models/payment.model';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../models/user.model';
import { DatePipe } from '@angular/common';

@Injectable()
export class PaymentService {
    private baseUrl = environment.apiUrl + 'user/';
    private dataSource$: BehaviorSubject<Payment[]> = new BehaviorSubject([]);

    constructor(private http: HttpClient,
                private datePipe: DatePipe) {
    }

    get getPayments(): Observable<Payment[]> {
        return this.dataSource$.asObservable();
    }

    set setPayments(payments: Payment[]) {
        this.dataSource$.next(payments);
    }

    getPaymentsForUser(): Observable<Payment[]> {
        const user: User = JSON.parse(localStorage.getItem('user'));
        const url = `${this.baseUrl}${user.id}/Payment/GetPaymentsForUser`;
        return this.http.get<Payment[]>(url, { observe: 'response' })
        .pipe(
        map(response => {
            const payments: Payment[] = response.body;
            return payments;
        }));
    }

    createPayment(payment: Payment) {
        const user: User = JSON.parse(localStorage.getItem('user'));
        const newPayment = { ...payment, createdDate: this.datePipe.transform(payment.createdDate, 'yyyy-MM-ddTHH:mm:ss') };
        const url = `${this.baseUrl}${user.id}/Payment/CreatePayment`;
        const httpHeaders = new HttpHeaders({
            'Content-Type' : 'application/json'
        });
        return this.http.post(url, newPayment, { headers: httpHeaders, observe: 'response' });
    }

    updatePayment(payment: Payment) {
        const user: User = JSON.parse(localStorage.getItem('user')); 
        const newPayment = {
            categoryId: payment.categoryId,
            address: payment.address,
            establishment: payment.establishment,
            description: payment.description,
            currency: payment.currency,
            price: payment.price
        };
        
        const url = `${this.baseUrl}${user.id}/Payment/UpdatePayment/${payment.id}`;
        const httpHeaders = new HttpHeaders({
            'Content-Type' : 'application/json'
        });

        return this.http.put(url, newPayment, { headers: httpHeaders, observe: 'response' });
    }
    
    deletePayment(paymentId: number) {
        const user: User = JSON.parse(localStorage.getItem('user'));
        const url = `${this.baseUrl}${user.id}/Payment/DeletePayment/${paymentId}`;
        return this.http.delete(url, {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        });
    }
}