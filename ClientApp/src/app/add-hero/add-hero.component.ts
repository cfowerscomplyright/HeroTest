import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Hero, Brand } from '../models/hero.model';
import { HeroService } from '../services/hero.service';
import { BrandService } from '../services/brand.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-hero',
  templateUrl: './add-hero.component.html',
  styleUrls: ['./add-hero.component.css']
})
export class AddHeroComponent implements OnInit {
  brands: Brand[] = [];
  submitted = false;

  form: FormGroup = new FormGroup({
    name: new FormControl(''),
    alias: new FormControl(''),
    brand: new FormControl('')
  });

  constructor(private heroService: HeroService, private brandService: BrandService,
     private formBuilder: FormBuilder, private router: Router) {}

  ngOnInit(): void {
    this.getBrands();

    this.form = this.formBuilder.group(
      {
        name: ['', Validators.required],
        alias: ['', Validators.required],
        brand: ['', Validators.required]
      }
    );
  }

  getBrands() {
    this.brandService.getAllBrands().subscribe(result => {
      this.brands = result;
    }, error => console.log(error));
  }

  onSubmit(): void {
    this.submitted = true;
    if (this.form.invalid) { return; }

    this.addHero();
  }

  addHero() {
    
    var hero: Hero = 
    {
      Name: this.form.controls.name.value,
      Alias: this.form.controls.alias.value,
      BrandId: this.form.controls.brand.value
    };

    this.heroService.addHero(hero).subscribe({
      next: (hero) => {
        this.router.navigate(['']);
      },
      error: (response) => {
        console.log(response);
      }
    });
  }
}
