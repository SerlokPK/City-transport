import { Routes } from '@angular/router';

import { RidesComponent } from '../pages/rides/rides.component';
import { LineMapComponent } from '../pages/line-map/line-map.component';

export const routes: Routes = [
    { path: 'rides', component: RidesComponent },
    { path: 'line-map', component: LineMapComponent },
    { path: '', redirectTo: '/rides', pathMatch: 'full' },
];
