import {BrowserModule, Title} from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './pages/home/home.component';
import {RouterModule, Routes} from '@angular/router';
import { ItemsComponent } from './pages/items/items.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import {MatButtonModule, MatInputModule, MatToolbarModule} from '@angular/material';
import { LoginComponent } from './pages/login/login.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {AuthService} from './services/auth.service';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {AuthInterceptor} from './helpers/interceptors/auth.interceptor';
import {AnonGuard} from './guards/anon.guard';
import {AuthGuard} from './guards/auth.guard';
import { ItemComponent } from './components/item/item.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'items', component: ItemsComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent, canActivate: [AnonGuard] },
  { path: '**', pathMatch: 'full', redirectTo: '' }
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ItemsComponent,
    NavbarComponent,
    LoginComponent,
    ItemComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(routes),
    MatToolbarModule,
    MatButtonModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    AuthService, Title,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
