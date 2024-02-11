import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Hero } from '../models/hero.model';

@Injectable({
  providedIn: 'root'
})
export class HeroService {

  baseApiUrl : string;
  
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    this.baseApiUrl = baseUrl;
  }

  getAllHeroes() : Observable<Hero[]> {
    return this.http.get<Hero[]>(this.baseApiUrl + 'heroes');
  }

  deleteHero(id: number) {
    return this.http.delete<Hero>(this.baseApiUrl + 'heroes/' + id);
  }

  addHero(hero: Hero): Observable<Hero> {
    return this.http.post<Hero>(this.baseApiUrl + 'heroes', hero, 
    {
      headers: {
        'Content-Type': 'application/json'
      }
    });
  }
}
