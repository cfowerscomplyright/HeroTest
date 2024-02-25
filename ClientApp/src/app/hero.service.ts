// hero.service.ts
import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class HeroService {
  private apiUrl = 'https://localhost:5054/api/heroes'; 

  constructor(private http: HttpClient) {}

  getHeroes(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}`);
  }

  addHero(hero: any): Observable<number> {
    return this.http.post<number>(`${this.apiUrl}`, hero);
  }

  deleteHero(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
