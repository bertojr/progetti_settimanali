import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { FiatPageComponent } from './pages/brand-page/fiat-page/fiat-page.component';
import { FordPageComponent } from './pages/brand-page/ford-page/ford-page.component';
import { AudiPageComponent } from './pages/brand-page/audi-page/audi-page.component';

const routes: Routes = [
  {
    path: '',
    component: HomePageComponent,
    pathMatch: 'full',
  },
  {
    path: 'brand-page/:brand',
    component: FiatPageComponent,
  },
  {
    path: 'brand-page/:brand',
    component: FordPageComponent,
  },
  {
    path: 'brand-page/:brand',
    component: AudiPageComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
