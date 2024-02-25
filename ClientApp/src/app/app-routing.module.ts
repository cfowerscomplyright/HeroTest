// app-routing.module.ts
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeroListComponent } from './hero-list/hero-list.component';
import { AddHeroComponent } from './add-hero/add-hero.component';  // Import AddHeroComponent

const routes: Routes = [
  { path: '', component: HeroListComponent },
  { path: 'add-hero', component: AddHeroComponent },  // Add the 'add-hero' route
  // Add other routes as needed
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
