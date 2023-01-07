import { Component, OnInit } from '@angular/core';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { Student } from 'src/app/Interfaces/i-student';
import { StudentService } from 'src/app/Services/student.service';

@Component({
  selector: 'app-search-for-student',
  templateUrl: './search-for-student.component.html',
  styleUrls: ['./search-for-student.component.css']
})
export class SearchForStudentComponent implements OnInit {

  constructor(private studentService:StudentService) { }
  students:Student[]=[];
  search="";
  ngOnInit(): void {
  }
  searchById(){
    this.studentService.getStudentById(+this.search).subscribe((res:Ischema)=>{
      this.students=[];
      this.students.push(res.data);

    })
  }
  searchByName(){
    this.studentService.getStudentByName(this.search).subscribe((res:Ischema)=>this.students=res.data)
  }
  searchByPhoneNumber(){
    this.studentService.getStudentByPhoneNumber(this.search).subscribe((res:Ischema)=>{
      this.students=[];
      this.students.push(res.data);

    })
  }
}
