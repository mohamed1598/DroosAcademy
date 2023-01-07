// import { Injectable } from '@angular/core';
// import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
// import { Observable } from 'rxjs';
// import { map } from 'rxjs/operators';
// import { Ischema } from 'src/app/Interfaces/i-schema';
// import { ExamService } from '../exam.service';
// import { LoginService } from '../login.service';
// import { StudentHaveLectureService } from '../student-have-lecture.service';

// @Injectable({
//   providedIn: 'root'
// })
// export class ExamAuthGuardService {

//   constructor(private authService:LoginService,private router:Router,private studentHaveLecture:StudentHaveLectureService,private examService:ExamService) { }
//   canActivate(route :ActivatedRouteSnapshot,state:RouterStateSnapshot):Observable<Observable<boolean>>|Promise<boolean |Observable<boolean>>  |Promise<boolean>|boolean{
//     if(this.authService.type === 'admin'){
//       return true;
//     }
//     if(this.authService.type === "student"){
//       let examId = +state.root.queryParams['examId'];
//       var request={
//         studentId : this.authService.student.id,
//         lectureId : null
//       }
//       console.log(request);
//       return this.examService.getExamById(examId).pipe(map(
//         (res:Ischema)=>{
//           request.lectureId =res.data.lectureId;
//           console.log(request);
          
//           return this.studentHaveLecture.isLectureValid(request).pipe(map(
//             (res:Ischema)=>{
//               if(res.data){
//                 console.log( true);
                
//                 return true;
//               }else{
//                 console.log(false);
//                 return false;
//               }
//             }
//           )//end of map
//         )//end of pipe
//         }
//       ))
      
//     }//end of student
    
//   }
// }
