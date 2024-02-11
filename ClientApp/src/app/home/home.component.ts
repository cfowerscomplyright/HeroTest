import { Component, OnInit } from '@angular/core';
import { Hero } from '../models/hero.model';
import { HeroService } from '../services/hero.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  heroes: Hero[] = [];

  constructor(private heroService: HeroService) {}

  ngOnInit(): void {
    this.getAllHeros();
  }

  getAllHeros() {
    this.heroService.getAllHeroes().subscribe(result => {
      this.heroes = result;
    }, error => console.log(error));
  }

  deleteHero(id?: number) {
    if(id != null) {
      this.heroService.deleteHero(id).subscribe({
        next: (response) => {
          this.getAllHeros();
        }
      });
    }
  }
}
