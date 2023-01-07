import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { ILecture } from 'src/app/Interfaces/i-lecture';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { Student } from 'src/app/Interfaces/i-student';
import { LecturesService } from 'src/app/Services/lectures.service';
import { LoginService } from 'src/app/Services/login.service';
import { ViewsService } from 'src/app/Services/views.service';

@Component({
  selector: 'app-lecture-home',
  templateUrl: './lecture-home.component.html',
  styleUrls: ['./lecture-home.component.css']
})
export class LectureHomeComponent implements OnInit {
  private _inputpdf: string = `<div style="padding-bottom: 56.25%; position: relative;"><iframe width="100%" height="100%" src="https://player.vimeo.com/video/76979871?speed=1" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture; fullscreen"  style="position: absolute; top: 0px; left: 0px; width: 100%; height: 100%;"><small>Vimeo embedding powered by <a href="https://embed.tube">embed.tube</a></small></iframe></div>`;
id=0;
  constructor(private lectureService:LecturesService,private loginService:LoginService,private _sanitizer: DomSanitizer,private route:ActivatedRoute,private viewService:ViewsService,private router:Router) {
    
  }

   lecture:ILecture|any={};
   student:Student=this.loginService.student;
   isStudent:boolean;
  ngOnInit(): void {
    if(this.loginService.type == "student"){
      this.isStudent = true;
    }
    else{
      this.isStudent = false;
    }
    this.id=+this.route.snapshot.queryParams['lectureId'];

    this.lectureService.getLectureById(this.id).subscribe((res:Ischema)=>{
      this.lecture = res.data;
      console.log(this.lecture);
      this.increaseView();
      if(this.lecture.lectureParts.length == 0){
        this._inputpdf =`<h1>no video yet</h1>`
      }else{
        this._inputpdf = this.lecture.lectureParts[0].embededCode;
      }
    })
  }
  public get inputpdf() : SafeHtml {
    return this._sanitizer.bypassSecurityTrustHtml(this._inputpdf);
  }
  showVideo(id:number){
    for(var i =0;i<this.lecture.lectureParts.length;i++){
      if(this.lecture.lectureParts[i].id == id){
        this._inputpdf = this.lecture.lectureParts[i].embededCode;
        console.log(this.lecture.lectureParts[i]);
        
      }
    }
  }
  increaseView(){
    if(this.student != null){ // not admin or teacher
      let request ={
        studentId : this.student.id,
        lectureId : this.lecture.id
      }
      this.viewService.increaseViews(request).subscribe((res:Ischema)=>console.log(res.message))
    }
    
  }
  goToExam(id:number){
    this.router.navigate(['/Exam'], { queryParams: { examId: id } });
  }
}
