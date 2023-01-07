import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from '../login.service';

@Injectable({
  providedIn: 'root'
})
export class StudentAuthGuardService {

  constructor(private authService:LoginService,private router:Router) { }
  canActivate(route :ActivatedRouteSnapshot,state:RouterStateSnapshot):Observable<boolean> |Promise<boolean>|boolean{
    return this.authService.isAuthenticated().then(
      (authenticated:boolean|any)=>{
          if(authenticated){
            if(this.authService.type === "student" || this.authService.type === 'admin'){
              return true;
            }
            this.router.navigate(['/Student']);
            return false;
          }
          else{
            localStorage.setItem("returnUrl",state.url);
            this.router.navigate(['/StudentLogin']);
            return false;
        }
      }
  )
  }
}
