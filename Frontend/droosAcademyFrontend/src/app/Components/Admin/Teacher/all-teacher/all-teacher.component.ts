import { Component, OnInit } from '@angular/core';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { TeacherService } from 'src/app/Services/teacher.service';

@Component({
  selector: 'app-all-teacher',
  templateUrl: './all-teacher.component.html',
  styleUrls: ['./all-teacher.component.css']
})
export class AllTeacherComponent implements OnInit {

  constructor(private teacherService:TeacherService) { }
  teachers:any;
  ngOnInit(): void {
    this.teacherService.getAllTeachers().subscribe((res:Ischema)=>this.teachers=res.data)
  }
  OnNext(){
    this.teacherService.paginationRequest.skip+=1;
    this.teacherService.getAllTeachers().subscribe((res:Ischema)=>{
      if(res.data.length == 0){
        this.teacherService.paginationRequest.skip-=1;
        alert("نهاية المدرسين");
      }
      else{
        this.teachers=res.data;
      }
    })
  }
  OnPast(){
    this.teacherService.paginationRequest.skip-=1;
    this.teacherService.getAllTeachers().subscribe((res:Ischema)=>{
      if(this.teacherService.paginationRequest.skip == -1){
        this.teacherService.paginationRequest.skip+=1;
        alert("بداية الطلبة");
      }
      else{
        this.teachers=res.data;
      }
    })
  }
}
