// hero-list.component.ts
import { Component, Inject, OnInit } from '@angular/core';
import { HeroService } from '../hero.service';

@Component({
  selector: 'app-hero-list',
  templateUrl: './hero-list.component.html',
  styleUrls: ['./hero-list.component.css'],
  providers: [HeroService],
})
export class HeroListComponent implements OnInit {
  heroes: any[] = [];

  constructor(@Inject(HeroService)private heroService: HeroService) {}

  ngOnInit(): void {
    this.loadHeroes();
  }

  loadHeroes(): void {
    this.heroService.getHeroes().subscribe((heroes: any[]) => {
      this.heroes = heroes;
    });
  }

  deleteHero(id: number): void {
    this.heroService.deleteHero(id).subscribe(() => {
      this.loadHeroes(); // Refresh the list after deletion
    });
  }
}
