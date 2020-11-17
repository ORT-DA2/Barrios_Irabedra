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
import { AccommodationsComponent } from './components/accommodations/accommodation/accommodations.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TouristSpotRegisterComponent } from './components/tourist-spots/tourist-spot-register/tourist-spot-register.component';
import { TouristSpotQueryComponent } from './components/tourist-spots/tourist-spot-query/tourist-spot-query.component';
import { AccommodationQueryComponent } from './components/accommodations/accommodation-query/accommodation-query.component';
import { AccommodationRegisterComponent } from './components/accommodations/accommodation-register/accommodation-register.component';
import { AccommodationDeletionComponent } from './components/accommodations/accommodation-deletion/accommodation-deletion.component';
import { AccommodationUpdateComponent } from './components/accommodations/accommodation-update/accommodation-update.component';
import { AdminComponent } from './components/admins/admin/admin.component';
import { AdminRegisterComponent } from './components/admins/admin-register/admin-register.component';
import { AdminDeletionComponent } from './components/admins/admin-deletion/admin-deletion.component';
import { AdminUpdateComponent } from './components/admins/admin-update/admin-update.component';
import { CategoryRegisterComponent } from './components/categories/category-register/category-register.component';
import { CategoryQueryComponent } from './components/categories/category-query/category-query.component';
import { ReportComponent } from './components/report/report.component';
import { TouristSpotService } from './services/tourist-spot.service';
import { HttpClientModule } from '@angular/common/http';
import { AddCategoryToTouristSpotComponent } from './components/tourist-spots/add-category-to-tourist-spot/add-category-to-tourist-spot.component';
import { NameProyectingPipe } from '../app/components/tourist-spots/nameProyectingPipe';
import { RegisterComponentComponent } from './components/register-component/register-component.component';
import { DatepickerComponent } from './components/extras/datepicker/datepicker.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ImportComponent } from './components/import/import.component';


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
  { path: 'accommodationRegister', component: AccommodationRegisterComponent},
  { path: 'accommodationDeletion', component: AccommodationDeletionComponent},
  { path: 'accommodationUpdate', component: AccommodationUpdateComponent},
  { path: 'admins', component: AdminComponent},
  { path: 'adminRegister', component: AdminRegisterComponent},
  { path: 'adminDeletion', component: AdminDeletionComponent},
  { path: 'adminUpdate', component: AdminUpdateComponent},
  { path: 'categoryRegister', component: CategoryRegisterComponent},
  { path: 'categoryQuery', component: CategoryQueryComponent},
  { path: 'reports', component: ReportComponent},
  { path: 'addCategoryToTouristSpot' , component: AddCategoryToTouristSpotComponent},
  { path: 'register' , component: RegisterComponentComponent },
  { path: 'import' , component : ImportComponent}
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
    AccommodationDeletionComponent,
    AccommodationUpdateComponent,
    AdminComponent,
    AdminRegisterComponent,
    AdminDeletionComponent,
    AdminUpdateComponent,
    CategoryRegisterComponent,
    CategoryQueryComponent,
    ReportComponent,
    AddCategoryToTouristSpotComponent,
    NameProyectingPipe,
    RegisterComponentComponent,
    DatepickerComponent,
    ImportComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    ReactiveFormsModule,
    NgbModule
  ],
  providers: [TouristSpotService],
  bootstrap: [AppComponent]
})
export class AppModule { }
