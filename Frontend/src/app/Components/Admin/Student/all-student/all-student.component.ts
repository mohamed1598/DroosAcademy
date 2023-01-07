import { Component, OnInit } from '@angular/core';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { StudentService } from 'src/app/Services/student.service';

@Component({
  selector: 'app-all-student',
  templateUrl: './all-student.component.html',
  styleUrls: ['./all-student.component.css']
})
export class AllStudentComponent implements OnInit {

  constructor(private studentService:StudentService) { }
  students:any;
  ngOnInit(): void {
    this.studentService.getAllStudents().subscribe((res:Ischema)=>this.students=res.data)
  }
  OnNext(){
    this.studentService.paginationRequest.skip+=1;
    this.studentService.getAllStudents().subscribe((res:Ischema)=>{
      if(res.data.length == 0){
        this.studentService.paginationRequest.skip-=1;
        alert("نهاية الطلبة");
      }
      else{
        this.students=res.data;
      }
    })
  }
  OnPast(){
    this.studentService.paginationRequest.skip-=1;
    this.studentService.getAllStudents().subscribe((res:Ischema)=>{
      if(this.studentService.paginationRequest.skip == -1){
        this.studentService.paginationRequest.skip+=1;
        alert("بداية الطلبة");
      }
      else{
        this.students=res.data;
      }
    })
  }
}
