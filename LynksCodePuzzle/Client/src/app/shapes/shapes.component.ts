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
    if(s.shapeName == 'Rectangle')
    {

    squire.drawRectrangle(5,2,s.height,s.width);
    }

    if(s.shapeName == 'IsoscelesTriangle')
    {
     alert("Traingle stated");
    squire.drawTraingle(s.width,s.height);
    }

   
    if(s.shapeName == 'ScaleneTriangle')
    {
     alert("Traingle Scalene stated");
    squire.drawTraingle(s.sideLength,s.sideLength);
    }

    if(s.shapeName == 'Hexagon')
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
      alert("aa");
      
      
      
    }

    

    bindData(form : NgForm)
    {
      //this.service.formData = form.value;
      alert(this.result.shapeName);
      alert(this.result.height);
      alert(this.result.width);
      alert(this.result.sideLength)
      alert(this.result.isIdentified);
      alert(this.result.isParametersMatched);
      alert(this.result.responceMessage);
      alert(this.result.shapeType);
      this.drawShape(this.result);
      this.responce = this.result.responceMessage;
      
      
     

    
      
    }

 
 
  
  
}






