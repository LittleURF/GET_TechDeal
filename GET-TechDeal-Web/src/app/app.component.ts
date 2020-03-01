import { Product } from './models/product';
import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'GET-TechDeal-Web';
  response: string;
  product: Product;
  lastHttpMadeAt: Date;

  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {
    this.sendHttp();
  }

  sendHttp(): void {
    this.http.get<Product>('https://localhost:44302/api/v1/products/current').subscribe({
      next: res => {this.product = res; console.log(res); console.log(this.product); },
      error: err => console.log(err)
    });
  }

  increment(): void {
      console.log(this.product.name);
      this.product.productId++;
      console.log(this.product);
  }

}


