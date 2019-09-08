import {Routes} from "@angular/router";
import { ShapesComponent } from './shapes/shapes.component';
export const ROUTES: Routes = [
    // Main redirect
    { path: '', redirectTo: './shapes/shapes.componen', pathMatch: 'full' },
    { path: '**', redirectTo: 'starterview' }
];
