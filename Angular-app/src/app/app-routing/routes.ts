import { Routes } from '@angular/router';

import { RidesComponent } from '../pages/rides/rides.component';
import { LineMapComponent } from '../pages/line-map/line-map.component';
import { RideLocationsComponent } from '../pages/ride-locations/ride-locations.component';
import { PriceListComponent } from '../pages/price-list/price-list.component';
import { RegisterComponent } from '../pages/register/register.component';
import { LoginComponent } from '../pages/login/login.component';
import { LinesComponent } from '../admin/lines/lines.component';
import { StationsComponent } from '../admin/stations/stations.component';
import { AuthGuard } from '../guards/auth.guard';
import { PricesComponent } from '../admin/prices/prices.component';

export const routes: Routes = [
    { path: 'rides', component: RidesComponent },
    { path: 'lineMap', component: LineMapComponent },
    { path: 'locations', component: RideLocationsComponent },
    { path: 'priceList', component: PriceListComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'login', component: LoginComponent },
    { path: 'admin/lines', component: LinesComponent },
    { path: 'admin/stations', component: StationsComponent, canActivate: [AuthGuard] },
    { path: 'admin/prices', component: PricesComponent },
    { path: '', redirectTo: '/rides', pathMatch: 'full' },
];
