import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { ShapesComponent } from './shapes/shapes.component';
import { AppComponent } from './app.component';
import { ShapeGeneratorServiceService } from './Service/shape-generator-service.service';
import { Route, RouterModule } from '@angular/router';
import {HttpClientModule} from '@angular/common/http';
import { from } from 'rxjs';
import {FormsModule} from '@angular/forms';

const ROUTES: Route[] = [
  { path: '', component: ShapesComponent}
]


@NgModule({
  declarations: [
    ShapesComponent,
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(ROUTES),
    HttpClientModule,
    FormsModule
   
  ],
  providers: [ShapeGeneratorServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }