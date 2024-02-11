import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Brand } from '../models/hero.model';

@Injectable({
  providedIn: 'root'
})
export class BrandService {

  baseApiUrl : string;
  
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    this.baseApiUrl = baseUrl;
  }

  getAllBrands() : Observable<Brand[]> {
    return this.http.get<Brand[]>(this.baseApiUrl + 'brand');
  }
}
