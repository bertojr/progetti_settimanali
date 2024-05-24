import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { FiatPageComponent } from './pages/fiat-page/fiat-page.component';
import { FordPageComponent } from './pages/ford-page/ford-page.component';
import { AudiPageComponent } from './pages/audi-page/audi-page.component';

const routes: Routes = [
  {
    path: '',
    component: HomePageComponent,
    pathMatch: 'full',
  },
  {
    path: 'fiat-page',
    component: FiatPageComponent,
  },
  {
    path: 'ford-page',
    component: FordPageComponent,
  },
  {
    path: 'audi-page',
    component: AudiPageComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
