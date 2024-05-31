import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HeaderComponent } from './main-components/header/header.component';
import { HomeComponent } from './pages/home/home.component';
import { CompletedComponent } from './pages/completed/completed.component';
import { UsersComponent } from './pages/users/users.component';
import { FormsModule } from '@angular/forms';
import { SingleTaskComponent } from './components/single-task/single-task.component';
import { SingleItemComponent } from './components/single-item/single-item.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    CompletedComponent,
    UsersComponent,
    SingleTaskComponent,
    SingleItemComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, NgbModule, FormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
