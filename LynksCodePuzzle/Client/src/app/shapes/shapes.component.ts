import { Component,ElementRef,ViewChild, OnInit, SystemJsNgModuleLoaderConfig } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { ShapeGeneratorServiceService } from '../Service/shape-generator-service.service';
import { Shape } from '../Entities/shape.model';
import { Squire } from '../Entities/squire.model';


@Component({
  selector: 'app-shapes',
  templateUrl: './shapes.component.html',
  styleUrls: ['./shapes.component.css'],
  
})
export class ShapesComponent implements OnInit {
  @ViewChild('canvas', { static: true })
  canvas: ElementRef<HTMLCanvasElement>;  
  private ctx: CanvasRenderingContext2D;
 

  

  constructor(private service : ShapeGeneratorServiceService) { }


  result: Shape;
  responce:String;
  

  ngOnInit(): void {
  this.ctx = this.canvas.nativeElement.getContext('2d');
  this.resetForm();
   
   
  }

  drawShape(s:Shape): void {
 
    const squire = new Squire(this.ctx);
 
    if(s.shapeName == 'Square')
    {
      squire.drawRectrangle(5,2,s.sideLength,s.sideLength);
    }
    else if(s.shapeName == 'Rectangle')
    {

    squire.drawRectrangle(5,2,s.height,s.width);
    }

    else if(s.shapeName == 'IsoscelesTriangle')
    {
    squire.drawTraingle(s.width,s.height);
    }

   
    else if(s.shapeName == 'ScaleneTriangle')
    {
    squire.drawTraingle(s.sideLength,s.sideLength);
    }

    else if(s.shapeName == 'Hexagon')
    {
      squire.drawHexagon(5,6,s.sideLength,7);
    }
      
      
  }

  


  resetForm(form? : NgForm)
    {
    if(form != null)
      form.resetForm();
      this.service.formData = {
      userInput : '',
      shapeName :'',
      responceMessage:'',
      isIdentified : false,

      isParametersMatched:false,

      shapeType : '',

      height:0,

      width:0,

      sideLength:0
       
      }
        
      
    
    }

    onSubmit(form: NgForm)
    {
       this.injectUserInput(form);
       //alert(this.service.formData);
       
      
    }

    injectUserInput(form: NgForm)
    {
      this.service.postShape(form.value).subscribe(res => {this.result = res as Shape, this.bindData(form)});
      
    }

    

    bindData(form : NgForm)
    {
      //this.service.formData = form.value;
      this.drawShape(this.result);
      this.responce = this.result.responceMessage;
      
      
     

    
      
    }

 
 
  
  
}






