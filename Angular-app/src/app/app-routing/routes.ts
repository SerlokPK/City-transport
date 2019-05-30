import { Routes } from '@angular/router';

import { RidesComponent } from '../pages/rides/rides.component';
import { LineMapComponent } from '../pages/line-map/line-map.component';
import { RideLocationsComponent } from '../pages/ride-locations/ride-locations.component';
import { PriceListComponent } from '../pages/price-list/price-list.component';

export const routes: Routes = [
    { path: 'rides', component: RidesComponent },
    { path: 'lineMap', component: LineMapComponent },
    { path: 'locations', component: RideLocationsComponent },
    { path: 'priceList', component: PriceListComponent },
    { path: '', redirectTo: '/rides', pathMatch: 'full' },
];
