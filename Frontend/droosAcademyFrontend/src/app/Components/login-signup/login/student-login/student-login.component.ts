import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IAuthentication } from 'src/app/Interfaces/i-authentication';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { LoginService } from 'src/app/Services/login.service';
import { StudentService } from 'src/app/Services/student.service';

@Component({
  selector: 'app-student-login',
  templateUrl: './student-login.component.html',
  styleUrls: ['./student-login.component.css']
})
export class StudentLoginComponent implements OnInit {

  constructor(private studentService:StudentService , private loginService:LoginService,private router:Router) { }
  user:IAuthentication={};
  output:Ischema={};
  failed = false;
  ngOnInit(): void {
  }
  login(){
    this.studentService.login(this.user).subscribe(
      (res:Ischema)=>{
        if(res.data ==false){this.failed=true;this.output=res}
        else{
          console.log(res);
          localStorage.setItem("userType","student");
          localStorage.setItem("user",JSON.stringify(res.data));
          localStorage.setItem("token",JSON.stringify(res.token))
          this.output = res;
          this.loginService.student = res.data;
          this.loginService.type = "student";
          this.loginService.loggedIn = true;
          this.router.navigate(["/Student"])
        }
      }
    )
  }
}
