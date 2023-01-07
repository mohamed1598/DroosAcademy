import { Injectable } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { LoginService } from '../login.service';
import { StudentHaveLectureService } from '../student-have-lecture.service';

import { map } from 'rxjs/operators'
@Injectable({
  providedIn: 'root'
})
export class LectureAuthGuardService {

  constructor(private authService:LoginService,private router:Router,private studentHaveLecture:StudentHaveLectureService) { }
  canActivate(route :ActivatedRouteSnapshot,state:RouterStateSnapshot):Observable<boolean>|Promise<boolean |Observable<boolean>>  |Promise<boolean>|boolean{
    if(this.authService.type === 'admin'){
      return true;
    }
    if(this.authService.type === "student"){
      var request={
        studentId : this.authService.student.id,
        lectureId : +state.root.queryParams['lectureId']
      }
      console.log(request);
      return this.studentHaveLecture.isLectureValid(request).pipe(map(
          (res:Ischema)=>{
            if(res.data){
              console.log( true);
              
              return true;
            }else{
              console.log(false);
              
              return false;
            }
          }
        )//end of map
      )//end of pipe
    }//end of student
    
  }
  
}
  //   return this.authService.isAuthenticated().then(
  //     (authenticated:boolean|any)=>{
  //         if(authenticated){
  //           if(this.authService.type === 'admin'){
  //             return true;
  //           }
  //           if(this.authService.type === "student"){
  //             var request={
  //               studentId : this.authService.student.id,
  //               lectureId : +state.root.queryParams['lectureId']
  //             }
  //             console.log(request);
  //             return this.studentHaveLecture.isLectureValid(request).pipe(map(
  //                 (res:Ischema)=>{
  //                   if(res.data){
  //                     console.log( true);
                      
  //                     return true;
  //                   }else{
  //                     console.log(false);
                      
  //                     return false;
  //                   }
  //                 }
  //               )//end of map
  //             )//end of pipe
  //           }//end of student
            
  //         }
  //         else{
  //           localStorage.setItem("returnUrl",state.url);
  //           this.router.navigate(['/StudentLogin']);
  //           return false;
  //       }
  //     }
  // )
  // }
// }
