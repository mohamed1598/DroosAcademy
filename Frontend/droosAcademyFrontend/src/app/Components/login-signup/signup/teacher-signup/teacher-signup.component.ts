import { Component, OnInit } from '@angular/core';
import { ISubject } from 'src/app/Interfaces/i-subject';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { Teacher } from 'src/app/Interfaces/i-teacher';
import { SubjectService } from 'src/app/Services/subject.service';
import { TeacherService } from 'src/app/Services/teacher.service';

@Component({
  selector: 'app-teacher-signup',
  templateUrl: './teacher-signup.component.html',
  styleUrls: ['./teacher-signup.component.css']
})
export class TeacherSignupComponent implements OnInit {
  constructor(private subjectService:SubjectService,private teacherService:TeacherService) { }
  teacher:Teacher={};
  subjects:ISubject[]=[]
  selectedSubject:any;
  check = false;
  ngOnInit(): void {
    this.subjectService.getSubjects().subscribe((res:Ischema)=>{
      this.subjects=res.data;
      console.log(this.subjects);
    })
  }
  onSignup(){
    this.teacherService.createUser(this.teacher).subscribe((res:Ischema)=>{
      console.log(res);
    })
  }
  onChangeSubject(val:any){
    this.teacher.subjectId=val;
    console.log(val);
  }
}
