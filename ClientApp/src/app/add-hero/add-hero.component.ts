// add-hero.component.ts
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HeroService } from '../hero.service';

@Component({
  selector: 'app-add-hero',
  templateUrl: './add-hero.component.html',
  styleUrls: ['./add-hero.component.css'],
})
export class AddHeroComponent {
  heroForm: FormGroup;

  constructor(private fb: FormBuilder, private heroService: HeroService) {
    this.heroForm = this.fb.group({
      name: ['', Validators.required],
      alias: [''],
      brandId: ['', Validators.required],
    });
  }

  onSubmit(): void {
    console.log("clicked")
    if (this.heroForm.valid) {
      const heroData = this.heroForm.value;
      this.heroService.addHero(heroData).subscribe(
        (id) => {
          console.log(`Hero added with ID: ${id}`);
          // Optionally, navigate to the hero list or perform other actions.
        },
        (error) => {
          console.error('Error adding hero:', error);
        }
      );
    }
  }
}
