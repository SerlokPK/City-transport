import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { FormsModule } from '@angular/forms';

import { LineService } from './pages/services/line.service';
import { StationService } from './pages/services/station.service';
import { UserService } from './pages/services/user.service';
import { VehicleService } from './pages/services/vehicle.service';
import { PriceService } from './pages/services/price.service';

import { AppRoutingModule } from './app-routing/app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './core/header/header.component';
import { FooterComponent } from './core/footer/footer.component';
import { NavbarComponent } from './core/navbar/navbar.component';
import { RidesComponent } from './pages/rides/rides.component';
import { LineMapComponent } from './pages/line-map/line-map.component';
import { RideLocationsComponent } from './pages/ride-locations/ride-locations.component';
import { PriceListComponent } from './pages/price-list/price-list.component';
import { LoginComponent } from './pages/login/login.component';
import { LinesComponent } from './admin/lines/lines.component';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { RegisterComponent } from './pages/register/register.component';
import { StationsComponent } from './admin/stations/stations.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    NavbarComponent,
    RidesComponent,
    LineMapComponent,
    RideLocationsComponent,
    PriceListComponent,
    RegisterComponent,
    LoginComponent,
    LinesComponent,
    StationsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    SweetAlert2Module.forRoot({
      buttonsStyling: false,
      customClass: 'modal-content',
      confirmButtonClass: 'btn btn-primary',
      cancelButtonClass: 'btn'
    }),
    NgMultiSelectDropDownModule.forRoot(),
    FormsModule
  ],
  providers: [LineService, StationService, VehicleService, PriceService,
    UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
