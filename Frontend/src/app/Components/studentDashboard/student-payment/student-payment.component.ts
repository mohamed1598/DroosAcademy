import { Component, OnInit } from '@angular/core';
import { ICode } from 'src/app/Interfaces/i-code';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { Student } from 'src/app/Interfaces/i-student';
import { CodesService } from 'src/app/Services/codes.service';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-student-payment',
  templateUrl: './student-payment.component.html',
  styleUrls: ['./student-payment.component.css']
})
export class StudentPaymentComponent implements OnInit {

  constructor(private loginService:LoginService,private codeService:CodesService) { }
  student:Student=this.loginService.student;
  message:string ;
  code:ICode={};
  ngOnInit(): void {
    console.log(this.student);
  }
  activateCode(){

    this.code.studentId = this.student.id;
    this.message ='';
    this.codeService.activateCode(this.code).subscribe((res:Ischema)=>{this.message=res.message;this.code.code = ''}
    )
  }
}
