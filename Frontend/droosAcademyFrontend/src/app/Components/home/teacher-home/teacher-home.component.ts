import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HomeNavigationService } from 'src/app/Services/home-navigation.service';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-teacher-home',
  templateUrl: './teacher-home.component.html',
  styleUrls: ['./teacher-home.component.css']
})
export class TeacherHomeComponent implements OnInit {

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
    console.log(this.loginService.student);
    console.log(this.loginService.teacher);
    console.log(this.loginService.type);
    this.height=window.innerHeight
  }

}
