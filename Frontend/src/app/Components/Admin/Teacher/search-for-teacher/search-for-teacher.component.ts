import { Component, OnInit } from '@angular/core';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { Teacher } from 'src/app/Interfaces/i-teacher';
import { TeacherService } from 'src/app/Services/teacher.service';

@Component({
  selector: 'app-search-for-teacher',
  templateUrl: './search-for-teacher.component.html',
  styleUrls: ['./search-for-teacher.component.css']
})
export class SearchForTeacherComponent implements OnInit {

  constructor(private teacherService:TeacherService) { }
  teachers:Teacher[]=[];
  search="";
  ngOnInit(): void {
  }
  searchById(){
    this.teacherService.getTeacherById(+this.search).subscribe((res:Ischema)=>{
      this.teachers=[];
      this.teachers.push(res.data);

    })
  }
  searchByName(){
    this.teacherService.getTeacherByName(this.search).subscribe((res:Ischema)=>this.teachers=res.data)
  }
  searchByPhoneNumber(){
    this.teacherService.getTeacherByPhoneNumber(this.search).subscribe((res:Ischema)=>{
      this.teachers=[];
      this.teachers.push(res.data);

    })
  }
}
