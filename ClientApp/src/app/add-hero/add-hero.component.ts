import { Component } from '@angular/core';
import { HeroService } from '../hero.service';
import { Hero } from '../models/hero.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-hero',
  templateUrl: './add-hero.component.html',
  styleUrls: ['./add-hero.component.css']
})
export class AddHeroComponent {
  hero: Hero = {
    id: 0,
    name: '',
    alias: '',
    isActive: false,
    createdOn: new Date(),
    updatedOn: new Date(),
    brandId: 0
  };

  constructor(private heroService: HeroService, private router: Router) { }

  onSubmit(): void {
    this.heroService.saveHero(this.hero).subscribe(() => {
      this.router.navigate(['/']); // Navigate back to the home page or another route after saving
    });
  }
}
