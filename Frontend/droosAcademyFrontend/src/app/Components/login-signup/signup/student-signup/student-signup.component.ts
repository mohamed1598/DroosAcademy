import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { IscholageYear } from 'src/app/Interfaces/i-scholage-year';
import { Student } from 'src/app/Interfaces/i-student';
import { ScholageYearService } from 'src/app/Services/scholage-year.service';
import { StudentService } from 'src/app/Services/student.service';

@Component({
  selector: 'app-student-signup',
  templateUrl: './student-signup.component.html',
  styleUrls: ['./student-signup.component.css']
})
export class StudentSignupComponent implements OnInit {

  constructor(private scholageyearService:ScholageYearService,private studentService:StudentService,private router:Router) { }
  student:Student={};
  scholagesYears:IscholageYear[]=[]
  selectedYear:any;
  check = false;
  ngOnInit(): void {
    this.scholageyearService.getAllCategories().subscribe((res:Ischema)=>{
      this.scholagesYears=res.data;
      console.log(this.scholagesYears);
      
    })
  }
  onSignup(){
    this.studentService.createUser(this.student).subscribe((res:Ischema)=>{
      console.log(res);
      if(res.message =="تم إنشاء الحساب بنجاح"){
        this.router.navigate(['/StudentLogin']);
      }
    })
  }
  onChangeSchoolageYear(val:any){
    this.student.currentYearId=val;
    console.log(val);
  }
}
