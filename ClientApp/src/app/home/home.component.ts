// src/app/home/home.component.ts
import { Component, OnInit } from '@angular/core';
import { HeroService } from '../hero.service';
import { Hero } from '../models/hero.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  heroes: Hero[] = [];

  constructor(private heroService: HeroService) {}

  ngOnInit(): void {
    this.getHeroes();
  }

  getHeroes(): void {
    this.heroService.getHeroes().subscribe(
      (data: Hero[]) => {
        this.heroes = data;
      },
      error => {
        console.error('Error fetching heroes:', error);
      }
    );
  }

  deleteHero(id: number): void {
    this.heroService.deleteHero(id).subscribe(
      () => {
        this.heroes = this.heroes.filter(hero => hero.id !== id);
      },
      error => {
        console.error('Error deleting hero:', error);
      }
    );
  }
}
