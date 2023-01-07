import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from '../login.service';

@Injectable({
  providedIn: 'root'
})
export class AdminAuthGuardService {

  constructor(private authService:LoginService,private router:Router) { }
  canActivate(route :ActivatedRouteSnapshot,state:RouterStateSnapshot):Observable<boolean> |Promise<boolean>|boolean{
    return this.authService.isAuthenticated().then(
      (authenticated:boolean|any)=>{
          if(true){
            if(this.authService.type === "admin"){
              return true;
            }
            // this.router.navigate(['/Admin']);
            return false;
          }
          else{
            console.log(this.authService.admin);
            console.log(this.authService.loggedIn);
            console.log(this.authService);
            
            
            localStorage.setItem("returnUrl",state.url);
            this.router.navigate(['/AdminLogin']);
            return false;
        }
      }
  )
  }
}
