import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from './login.service';

@Injectable({
  providedIn: 'root'
})
export class HomeNavigationService {

  constructor(private loginService:LoginService,private router:Router) { 
    if(this.loginService.loggedIn == true){
      if(this.loginService.type == 'admin'){
        this.router.navigate(['/Admin'])
      }else if(this.loginService.type == 'student'){
        this.router.navigate(['/Student'],{queryParams:{ id: 0}})
      }else if(this.loginService.type == 'teacher'){
        this.router.navigate(['/Teacher'],{queryParams:{ id: 0}})
      }
    }
  }
}
