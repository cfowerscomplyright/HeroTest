import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { AbstractControl, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-addHero',
  templateUrl: './addHero.component.html',
})
export class AddHeroComponent {
  mainForm = this.fb.group({
    id: [0],
    name: [null, Validators.required],
    alias: [null, Validators.required],
    isActive: false,
    brandId: [null, Validators.required]
  });

  public hero: Hero = {
      Id: 0,
      Name: '',
      Alias: '',
      IsActive: false,
      BrandId: 0
  };
  httpClient: HttpClient;
  baseURL: string;
  brands: Brand[]= [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private fb: FormBuilder) {
    this.httpClient = http;
    this.baseURL = baseUrl;
    http.get<Hero[]>(baseUrl + 'brand/getBrands').subscribe(result => {
      this.brands = result;
    }, error => console.error(error));
  }

  onSave() {
    this.mainForm.markAllAsTouched();
    if (this.mainForm.invalid) return;
    this.hero = this.mainForm.value as Hero;
    this.httpClient.post<Hero>(this.baseURL + 'heroes', this.hero).subscribe(result => {
      window.location.replace("");
    }, error => console.error(error));
  }
  onCancel() {
    window.location.replace("");
  }
}

interface Hero {
  Id: number;
  Name: string;
  Alias: string;
  IsActive: boolean;
  CreatedOn?: Date;
  UpdatedOn?: Date;
  BrandId: number;
}

interface Brand {
  Id: number;
  Name: string;
}
