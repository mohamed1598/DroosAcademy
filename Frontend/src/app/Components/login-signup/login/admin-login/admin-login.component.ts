import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IAuthentication } from 'src/app/Interfaces/i-authentication';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { AdminService } from 'src/app/Services/admin.service';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-admin-login',
  templateUrl: './admin-login.component.html',
  styleUrls: ['./admin-login.component.css']
})
export class AdminLoginComponent implements OnInit {

  constructor(private adminService:AdminService,private router:Router,private loginService:LoginService) { }
  user:IAuthentication={};
  output:Ischema={};
  failed = false;
  ngOnInit(): void {
  }
  login(){
    this.adminService.login(this.user).subscribe(
      (res:Ischema)=>{
        this.output = res;
        if(res.data ==false){this.failed=true;this.output=res}
        else{
          console.log(res);
          localStorage.setItem("userType","admin");
          localStorage.setItem("user",JSON.stringify(res.data));
          localStorage.setItem("token",JSON.stringify(res.token))
          this.output = res;
          this.loginService.loggedIn = true;
          this.loginService.admin = res.data;
          this.loginService.type = "admin";
          this.router.navigate(["/Admin"])
        }
      }
    )
  }
}
