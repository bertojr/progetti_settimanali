import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './main-components/header/header.component';
import { FooterComponent } from './main-components/footer/footer.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { FiatPageComponent } from './pages/fiat-page/fiat-page.component';
import { FordPageComponent } from './pages/ford-page/ford-page.component';
import { AudiPageComponent } from './pages/audi-page/audi-page.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomePageComponent,
    FiatPageComponent,
    FordPageComponent,
    AudiPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
