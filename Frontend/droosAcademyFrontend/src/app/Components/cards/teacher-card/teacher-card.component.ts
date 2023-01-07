import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Teacher } from 'src/app/Interfaces/i-teacher';

@Component({
  selector: 'app-teacher-card',
  templateUrl: './teacher-card.component.html',
  styleUrls: ['./teacher-card.component.css'],
})
export class TeacherCardComponent implements OnInit {
  @Input() teacher:Teacher|any;
  constructor(private router:Router) {
   }
  text='';
  imagePath=null;
  ngOnInit(): void {
  }
  ngOnChanges(){
    // make description
    // if(this.teacher.description!=null){
    //   if(this.teacher.description.length>50){
    //     this.text=this.teacher.description.slice(0,49)+'...';
    //   }
    //   else if(this.teacher.description.length===0){}
    //   else{
    //     this.text=this.teacher.description.slice(0,this.teacher.description.length);
    //     let i=0;
    //     let x= 50-this.teacher.description.length;
    //     this.text=this.teacher.description;
    //     while(i<x){
    //       this.text=this.text+".";
    //       i+=1;
    //     }
    //   }
      
    // }
}

}
