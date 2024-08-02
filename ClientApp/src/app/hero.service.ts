import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Hero } from './models/hero.model';

@Injectable({
  providedIn: 'root'
})
export class HeroService {
  private apiUrl = 'https://localhost:44486/heroes'; // Replace with your actual API URL

  constructor(private http: HttpClient) {}

  getHeroes(): Observable<Hero[]> {
    return this.http.get<Hero[]>(this.apiUrl);
  }

  deleteHero(id: number): Observable<Hero> {
    return this.http.delete<Hero>(`${this.apiUrl}/${id}`);
  }

  saveHero(hero: Hero): Observable<Hero> {
    return this.http.post<Hero>(this.apiUrl, hero);
  }
}