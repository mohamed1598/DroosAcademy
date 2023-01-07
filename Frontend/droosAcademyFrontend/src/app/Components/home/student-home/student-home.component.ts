import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HomeNavigationService } from 'src/app/Services/home-navigation.service';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-student-home',
  templateUrl: './student-home.component.html',
  styleUrls: ['./student-home.component.css']
})
export class StudentHomeComponent implements OnInit {

  height:any

  constructor(private homeNavigationService:HomeNavigationService,private loginService:LoginService,private router:Router) {
    if(this.loginService.loggedIn == true){
      if(this.loginService.type == 'admin'){
        this.router.navigate(['/Admin'])
      }else if(this.loginService.type == 'student'){
        this.router.navigate(['/Student'])
      }else if(this.loginService.type == 'teacher'){
        this.router.navigate(['/Teacher'])
      }
    }
   }

  ngOnInit(): void {
    if(this.loginService.type=="student"){
      console.log(this.loginService.student);
    } 
    this.height = window.innerHeight
  }

}
