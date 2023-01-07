import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-admin-navbar',
  templateUrl: './admin-navbar.component.html',
  styleUrls: ['./admin-navbar.component.css']
})
export class AdminNavbarComponent implements OnInit {

  constructor(public loginService:LoginService,private router:Router) { }
  isOpen=false;
  ngOnInit(): void {
    
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
