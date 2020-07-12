
import { Category } from '../models/category.model';
import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { User } from '../models/user.model';
import { DatePipe } from '@angular/common';

@Injectable()
export class CategoryService {
    private baseUrl = environment.apiUrl + 'user/';
    private dataSource$: BehaviorSubject<Category[]> = new BehaviorSubject([]);

    constructor(private http: HttpClient,
                private datePipe: DatePipe) {
    }

    get getCategories(): Observable<Category[]> {
        return this.dataSource$.asObservable();
    }

    set setCategories(categories: Category[]) {
        this.dataSource$.next(categories);
    }

    getCategoriesForUser(): Observable<Category[]> {
        const user: User = JSON.parse(localStorage.getItem('user'));
        const url = `${this.baseUrl}${user.id}/category/GetCategoriesForUser`;

        return this.http.get<Category[]>(url, { observe: 'response' })
        .pipe(
        map(response => {
            const categories: Category[] = response.body;
            return categories;
        }));
    }
    
    deleteCategory(categoryId: number) {
        const user: User = JSON.parse(localStorage.getItem('user'));
        const url = `${this.baseUrl}${user.id}/category/DeleteCategory/${categoryId}`;
        return this.http.delete(url, {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        });
    }

    createCategory(category: Category) {
        const user: User = JSON.parse(localStorage.getItem('user')); 
        const newCategory = {
            userId: user.id,
            name: category.name,
            description: category.description,
            createdDate: this.datePipe.transform(category.createdDate, "yyyy-MM-ddTHH:mm:ss")
        };

        const url = `${this.baseUrl}${user.id}/category/CreateCategory`;
        
        let httpHeaders = new HttpHeaders({
            'Content-Type' : 'application/json'
        });

        return this.http.post(url, newCategory, { headers: httpHeaders, observe: 'response' });
    }

    updateCategory(category: Category) {
        const user: User = JSON.parse(localStorage.getItem('user')); 
        const newCategory = {
            name: category.name,
            description: category.description
        };

        const url = `${this.baseUrl}${user.id}/category/UpdateCategory/${category.id}`;
        
        let httpHeaders = new HttpHeaders({
            'Content-Type' : 'application/json'
        });

        return this.http.put(url, newCategory, { headers: httpHeaders, observe: 'response' });
    }
}