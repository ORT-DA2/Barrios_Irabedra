import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import { TouristSpotsComponent } from './components/tourist-spots/tourist-spots.component';
import { RegionsComponent } from './components/regions/regions.component';
import { CategoriesComponent } from './components/categories/categories.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { ReservationsComponent } from './components/reservations/reservations.component';
import { AccommodationsComponent } from './components/accommodations/accommodations.component';
import { FormsModule } from '@angular/forms';
import { TouristSpotRegisterComponent } from './components/tourist-spots/tourist-spot-register/tourist-spot-register.component';
import { TouristSpotQueryComponent } from './components/tourist-spots/tourist-spot-query/tourist-spot-query.component';
import { AccommodationQueryComponent } from './components/accommodations/accommodation-query/accommodation-query.component';
import { AccommodationRegisterComponent } from './components/accommodations/accommodation-register/accommodation-register.component';

const appRoutes: Routes = [
  { path: 'touristSpots', component: TouristSpotsComponent }, 
  { path: 'reservations', component: ReservationsComponent }, 
  { path: 'login', component: LoginComponent},
  { path: 'regions', component: RegionsComponent},
  { path: '', component: HomeComponent},
  { path: 'categories', component: CategoriesComponent},
  { path: 'accommodations', component: AccommodationsComponent},
  { path: 'touristSpotRegister', component: TouristSpotRegisterComponent},
  { path: 'touristSpotQuery', component: TouristSpotQueryComponent},
  { path: 'accommodationQuery', component: AccommodationQueryComponent},
  { path: 'accommodationRegister', component: AccommodationRegisterComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    TouristSpotsComponent,
    RegionsComponent,
    CategoriesComponent,
    LoginComponent,
    HomeComponent,
    ReservationsComponent,
    AccommodationsComponent,
    TouristSpotRegisterComponent,
    TouristSpotQueryComponent,
    AccommodationQueryComponent,
    AccommodationRegisterComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
