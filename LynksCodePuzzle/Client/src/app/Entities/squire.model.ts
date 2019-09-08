import { tick } from '@angular/core/testing';

export class Squire {
    constructor(private ctx: CanvasRenderingContext2D) {}

  drawRectrangle(x: number, y: number, h: number, w:number) {
    this.ctx.rect(x,y,w,h);
    this.ctx.stroke();
    
  }

  drawTraingle(x: number,y:number) {
   this.ctx.beginPath();
   this.ctx.moveTo(x, x);
   this.ctx.lineTo(x, y);
   this.ctx.lineTo(y, x);
   this.ctx.closePath();
   this.ctx.stroke();
   
  }


drawHexagon(x: number,y:number,sidelength:number,side:number) {
  this.ctx.beginPath();
  this.ctx.moveTo(x + sidelength * Math.cos(0), y + sidelength * Math.sin(0));

    for (side; side < 7; side++) {
    this.ctx.lineTo(x + sidelength * Math.cos(side * 2 * Math.PI / 6), y + sidelength * Math.sin(side * 2 * Math.PI / 6));
}
alert("Hexagon Creator");
this.ctx.closePath();
this.ctx.stroke();
  }

  
}

 

