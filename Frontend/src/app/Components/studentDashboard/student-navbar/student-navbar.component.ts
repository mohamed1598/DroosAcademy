import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { Student } from 'src/app/Interfaces/i-student';
import { LoginService } from 'src/app/Services/login.service';
import { StudentService } from 'src/app/Services/student.service';
@Component({
  selector: 'app-student-navbar',
  templateUrl: './student-navbar.component.html',
  styleUrls: ['./student-navbar.component.css']
})
export class StudentNavbarComponent implements OnInit {

  constructor(private loginService:LoginService,private studentService:StudentService,private route:ActivatedRoute,private router:Router) { }
  student:Student={};
  queryParamId = 0;
  isOpen=false;
  ngOnInit(): void {
    this.route.queryParamMap.subscribe((params:any)=>{
      if( params.params.id != null && params.params.id != 0 ){ 
        this.studentService.getStudentById(params.params.id).subscribe((res:Ischema)=>{
          this.student=res.data;
        });
        this.student.id=+params.params.id;
        this.queryParamId = +params.params.id;
      }
      else{
        this.student = this.loginService.student;
      }
    })
    
  }
  toggleNavbar(){
    this.isOpen=!this.isOpen;
  }
  Logout(){
    localStorage.removeItem("userType");
    localStorage.removeItem("user");
    this.loginService.loggedIn =false;
    this.loginService.student = null;
    this.loginService.teacher = null;
    this.loginService.admin = null;
    this.loginService.type = null;
    this.router.navigate(["/"]);
  }
}
