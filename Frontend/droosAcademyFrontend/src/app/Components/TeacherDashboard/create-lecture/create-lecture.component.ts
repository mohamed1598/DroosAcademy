import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ILecture } from 'src/app/Interfaces/i-lecture';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { IAttachement } from 'src/app/Interfaces/iattachement';
import { LectureFoldersService } from 'src/app/Services/lecture-folders.service';
import { LecturePartsService } from 'src/app/Services/lecture-parts.service';
import { LecturesService } from 'src/app/Services/lectures.service';
import { LoginService } from 'src/app/Services/login.service';
import { SubjectService } from 'src/app/Services/subject.service';
import {ScholageYearService} from '../../../Services/scholage-year.service';
@Component({
  selector: 'app-create-lecture',
  templateUrl: './create-lecture.component.html',
  styleUrls: ['./create-lecture.component.css']
})
export class CreateLectureComponent implements OnInit {

  constructor(private loginService:LoginService,private router:Router,
              private scholageYearService:ScholageYearService,private subjectService:SubjectService,private lectureService:LecturesService,private lecturePartsService:LecturePartsService,private lectureFolderService:LectureFoldersService) { }
  lecture:ILecture|any={};
  scholagesYears:any;
  subjects:any;
  selectedYear = 0;
  selectedSubject =0;
  attachment:IAttachement={};
  created = false;
  ngOnInit(): void {
    this.lecture.teacherId = this.loginService.teacher.id;
    this.scholageYearService.getAllCategories().subscribe((res:Ischema)=>{this.scholagesYears=res.data;});
    this.subjectService.getSubjects().subscribe((res:Ischema)=>{this.subjects = res.data;})
  }
  onChangeSchoolageYear(val:any){
    this.lecture.yearid=val;
  }
  onChangeSubject(val:any){
    this.lecture.subjectId=val;
  }
  createLecture(){
    this.lectureService.createLecture(this.lecture).subscribe((res:Ischema)=>{
      console.log(res);
      this.lecture.id = res.data.id;
      this.created = true;
    })
  }
  createVideo(){
    this.attachment.lectureId = this.lecture.id;
    console.log(this.attachment);
    
    this.lecturePartsService.createPart(this.attachment).subscribe((res:Ischema)=>{
      console.log(res);
      this.empty();
    });
  }
  createFile(){
    this.attachment.lectureId = this.lecture.id;
    this.attachment.embededCode = null;
    console.log(this.attachment);
    this.lectureFolderService.createFolder(this.attachment).subscribe((res:Ischema)=>{
      console.log(res);
      this.empty();
    });
  }
  goToExams(){
    this.router.navigate(['/Teacher/CreateExam'],{ queryParams: { lectureId: this.lecture.id } });
  }
  empty(){

    this.attachment.embededCode = "";
    this.attachment.lectureId = 0;
    this.attachment.link = "";
    this.attachment.name = "";
  }
  
}
