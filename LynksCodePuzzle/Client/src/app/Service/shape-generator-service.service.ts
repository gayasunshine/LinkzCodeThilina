import { Injectable } from '@angular/core';
import { Shape } from '../Entities/shape.model';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ShapeGeneratorServiceService {

 // formData: Shape 
  //readonly rootUrl : 'http://localhost:53599/api'

  constructor(private http : HttpClient) { }

  postShape(formData : Shape)
  {

     return this.http.post('http://localhost:53599/api/Shapes',formData);
  }

  
}
