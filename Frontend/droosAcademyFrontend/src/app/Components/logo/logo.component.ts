import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-logo',
  templateUrl: './logo.component.html',
  styleUrls: ['./logo.component.css']
})
export class LogoComponent implements OnInit {

  constructor(private loginServ:LoginService,private router:Router) { }

  ngOnInit(): void {
  }

  GoToHome(){
    if(this.loginServ.loggedIn == true){
      if(this.loginServ.type == 'student'){
        this.router.navigate(['/Student'])
      }else if(this.loginServ.type == 'teacher'){
        this.router.navigate(['/Teacher'])
      }else if(this.loginServ.type == 'admin'){
        this.router.navigate(['/Admin'])
      }
    }else{
      this.router.navigate(['/'])
    }
   
  }

}
