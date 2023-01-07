import { DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ILecture } from 'src/app/Interfaces/i-lecture';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { LoginService } from 'src/app/Services/login.service';
import { StudentHaveLectureService } from 'src/app/Services/student-have-lecture.service';

@Component({
  selector: 'app-lecture-card',
  templateUrl: './lecture-card.component.html',
  styleUrls: ['./lecture-card.component.css'],
  providers: [DatePipe]
})
export class LectureCardComponent implements OnInit {
  @Input() lecture:ILecture|any;
  constructor(private router:Router,public datePipe:DatePipe,private studentHaveLecture:StudentHaveLectureService,private loginService:LoginService) {
   }
  text='';
  publishedDate:any;
  purchasedDate:any;
  imagePath=null;
  valid = false;
  ngOnInit(): void {
    var request={
      studentId : this.loginService.student.id,
      lectureId : this.lecture.id
    }
    this.studentHaveLecture.isLectureValid(request).subscribe((res:Ischema)=>{
      this.valid = res.data;
    })
  }
  ngOnChanges(){
    this.publishedDate = this.datePipe.transform(this.lecture.publishedDate, 'yyyy-MM-dd');
    this.purchasedDate = this.datePipe.transform(this.lecture.studentHaveLectures[0].startdate, 'yyyy-MM-dd');
  }
  goToLecture(){
    this.router.navigate(['/Lecture'], { queryParams: { lectureId: this.lecture.id } });
  }
  isLectureAvailable(){
    return this.valid
  }
}
