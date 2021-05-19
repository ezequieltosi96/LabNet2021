import { Injectable } from '@angular/core';
import { Category } from 'src/app/models/category';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private baseUrl: string = 'http://localhost:60168/api';

  private httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }

  constructor(private readonly httpClient: HttpClient, private readonly router: Router) { }

  getOne(id: Number): Observable<Category> {
    let category!: Observable<Category>;

    category = this.httpClient.get<Category>(this.baseUrl + '/category/' + id);

    return category;
  }

  getAll(searchString: string = ""): Observable<Category[]> {
    return this.httpClient.get<Category[]>(this.baseUrl + '/category?searchString=' + searchString).pipe(
      catchError(this.errorHandler)
    );
  }

  add(category: Category): Observable<Category> {
    return this.httpClient.post<Category>(this.baseUrl + '/category', category, this.httpOptions).pipe(
      catchError(this.errorHandler)
    );;
  }

  edit(category: Category): Observable<Category> {
    return this.httpClient.put<Category>(this.baseUrl + '/category', category, this.httpOptions).pipe(
      catchError(this.errorHandler)
    );;
  }

  delete(id: number): Observable<Number> {
    return this.httpClient.delete<Number>(this.baseUrl + '/category/' + id, this.httpOptions).pipe(
      catchError(this.errorHandler)
    );;
  }

  private errorHandler(error: HttpErrorResponse){
    
    let errorMessage = '';
     if(error.error instanceof ErrorEvent) { // client side
       errorMessage = error.error.message;
     } else { // server side
       errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
     }
     console.log(errorMessage);
     return throwError(errorMessage);
  }
}
