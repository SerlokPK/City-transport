import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing/app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './core/header/header.component';
import { FooterComponent } from './core/footer/footer.component';
import { NavbarComponent } from './core/navbar/navbar.component';
import { RidesComponent } from './pages/rides/rides.component';
import { LineMapComponent } from './pages/line-map/line-map.component';
import { RideLocationsComponent } from './pages/ride-locations/ride-locations.component';
import { PriceListComponent } from './pages/price-list/price-list.component';

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
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
