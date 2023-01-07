import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IAuthentication } from 'src/app/Interfaces/i-authentication';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { LoginService } from 'src/app/Services/login.service';
import { TeacherService } from 'src/app/Services/teacher.service';

@Component({
  selector: 'app-teacher-login',
  templateUrl: './teacher-login.component.html',
  styleUrls: ['./teacher-login.component.css']
})
export class TeacherLoginComponent implements OnInit {

  constructor(private teacherService:TeacherService,private loginService:LoginService,private router:Router) { }
  user:IAuthentication={};
  output:Ischema={};
  failed = false;
  ngOnInit(): void {
  }
  login(){
    this.teacherService.login(this.user).subscribe(
        (res:Ischema)=>{
          if(res.data ==false){
            this.failed=true;
            this.output = res;
          }
          else{
            console.log(res);
            this.output = res;
            this.loginService.teacher = res.data;
            this.loginService.type = "teacher";
            localStorage.setItem("userType","teacher");
            localStorage.setItem("user",JSON.stringify(res.data));
            localStorage.setItem("token",JSON.stringify(res.token))
            this.output = res;
            this.loginService.teacher = res.data;
            this.loginService.type = "teacher";
            this.loginService.loggedIn = true;
            this.router.navigate(["/Teacher"]);
          }
        }
    )
  }
}
