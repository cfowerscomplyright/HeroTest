import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public heros: Hero[] = [];
  httpClient: HttpClient;
  baseURL: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.httpClient = http;
    this.baseURL = baseUrl;
    http.get<Hero[]>(baseUrl + 'heroes').subscribe(result => {
      this.heros = result;
    }, error => console.error(error));
  }

  deleteHero(hero: Hero) {
    this.httpClient.delete(this.baseURL + 'heroes?id=' + hero.Id).subscribe(result => {
      this.httpClient.get<Hero[]>(this.baseURL + 'heroes').subscribe(result => {
        this.heros = result;
      }, error => console.error(error));
    }, error => console.error(error));
  }
}

interface Hero {
  Id: number;
  Name: string;
  Alias: string;
  IsActive: boolean;
  CreatedOn: Date;
  UpdatedOn: Date;
  BrandId: number;
  Brand: Brand;
}
interface Brand {
  Id: number;
  Name: string;
}
