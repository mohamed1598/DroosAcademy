import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ILecture } from 'src/app/Interfaces/i-lecture';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { SpinnerService } from 'src/app/Services/Animation/spinner-service.service';
import { LoginService } from 'src/app/Services/login.service';
import { StudentService } from 'src/app/Services/student.service';

@Component({
  selector: 'app-student-lectures',
  templateUrl: './student-lectures.component.html',
  styleUrls: ['./student-lectures.component.css']
})
export class StudentLecturesComponent implements OnInit {

  constructor(private studentService:StudentService,private loginService:LoginService , private route:ActivatedRoute) { }
  lectures:ILecture[] |any=[];
  student=this.loginService.student;
  height:any;
  ngOnInit(): void {
    this.route.queryParamMap.subscribe((params:any)=>{
      if( params.params.id != null && params.params.id!=0 ){ 
        console.log(+params.params.id);
        this.student.id=+params.params.id;
        console.log(this.student);
      }
    })
    this.height = window.innerHeight;
    this.studentService.getStudentLecture(this.student.id).subscribe((res:Ischema)=>{

      this.lectures =res.data;
      this.lectures =  [...new Map(this.lectures.map(item =>
        [item["id"], item])).values()];;
      
    })
  }
  transferListToUnique(array:any[]){

  }
}
