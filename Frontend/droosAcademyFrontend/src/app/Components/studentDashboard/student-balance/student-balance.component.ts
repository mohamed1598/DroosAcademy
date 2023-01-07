import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { Student } from 'src/app/Interfaces/i-student';
import { LoginService } from 'src/app/Services/login.service';
import { StudentService } from 'src/app/Services/student.service';

@Component({
  selector: 'app-student-balance',
  templateUrl: './student-balance.component.html',
  styleUrls: ['./student-balance.component.css']
})
export class StudentBalanceComponent implements OnInit {

  constructor(private loginService:LoginService,private studentService:StudentService,private route:ActivatedRoute) { }
  student:Student={};
  
  lectureNumbers = 0;
  teacherNumbers =0;
  ngOnInit(): void {
    if(this.loginService.student != null){
      this.student=this.loginService.student;
    }
    this.route.queryParamMap.subscribe((params:any)=>{
      if( +params.params.id > 0){ 
        this.student.id=+params.params.id;
      }
      this.studentService.getStudentById(this.student.id).subscribe((res:Ischema)=>{
        this.student = res.data;
      })
      this.studentService.getLecturesNumberForStudent(this.student.id).subscribe((res:Ischema)=>{
        this.lectureNumbers = res.data;
      });
      this.studentService.getTeachersNumberForStudent(this.student.id).subscribe((res:Ischema)=>{
        this.teacherNumbers = res.data;
      });
    })
    
    
    
  }

}
