import { Component, OnInit } from '@angular/core';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { Student } from 'src/app/Interfaces/i-student';
import { LoginService } from 'src/app/Services/login.service';
import { StudentService } from 'src/app/Services/student.service';

@Component({
  selector: 'app-teacher-students',
  templateUrl: './teacher-students.component.html',
  styleUrls: ['./teacher-students.component.css']
})
export class TeacherStudentsComponent implements OnInit {

  constructor(private studentService:StudentService,private loginService:LoginService) { }
  students:Student[]=[];
  ngOnInit(): void {
    this.studentService.getTeacherStudents(this.loginService.teacher.fullname).subscribe((res:Ischema)=>{this.students=res.data;console.log(this.students);
    })
  }

}
