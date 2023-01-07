import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { Teacher } from 'src/app/Interfaces/i-teacher';
import { LoginService } from 'src/app/Services/login.service';
import { TeacherService } from 'src/app/Services/teacher.service';

@Component({
  selector: 'app-student-teachers',
  templateUrl: './student-teachers.component.html',
  styleUrls: ['./student-teachers.component.css']
})
export class StudentTeachersComponent implements OnInit {
  teachers:Teacher[]=[];
  height:any;
  student=this.loginService.student;
  constructor(private teacherService:TeacherService,private loginService:LoginService,private route:ActivatedRoute) { }
  ngOnInit(): void {
    this.route.queryParamMap.subscribe((params:any)=>{
      if( params.params.id != null && params.params.id!=0 ){ 
        this.student.id=+params.params.id;
      }
    })
    this.height = window.innerHeight;
    this.teacherService.getTeachersForStudent(this.student.id).subscribe((res:Ischema)=>{
      this.teachers=res.data;
    });
  }

}
