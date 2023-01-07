import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ICode } from 'src/app/Interfaces/i-code';
import { ILecture } from 'src/app/Interfaces/i-lecture';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { CodesService } from 'src/app/Services/codes.service';
import { LecturesService } from 'src/app/Services/lectures.service';
import { LoginService } from 'src/app/Services/login.service';
import * as XLSX from "xlsx";
@Component({
  selector: 'app-teacher-lectures',
  templateUrl: './teacher-lectures.component.html',
  styleUrls: ['./teacher-lectures.component.css']
})
export class TeacherLecturesComponent implements OnInit {

  constructor(private lectureService:LecturesService,private loginService:LoginService,private router:Router,private codeService:CodesService) { }
  data=
  {
    skip: 0,
    limit: 10,
    teacherName: "عمر محمد محمود الملا",
    yearId: 1
  }
  codes:ICode|any=[];
  totalCount = 0;
  numberOfCodes = 0;
  lectureId:number;
  closed = false;
  codeShow = false;
  numberOfActivatedCode = -1;
  lectures:ILecture[]=[];
  selectedLecture:ILecture|any={};
  ngOnInit(): void {
    this.data.skip=0;
    this.data.limit=10;
    this.data.teacherName=this.loginService.teacher.fullname;
    this.data.yearId=1;
    this.lectureService.getTeacherLectures(this.data).subscribe((res:Ischema)=>{
      this.lectures=res.data;
      this.totalCount = this.lectures.length;
    });
  }
  getLectureActivatedCode(id){
    if(this.numberOfActivatedCode == -1){
      this.lectureService.getLectureActivatedCodes(id).subscribe((res:Ischema)=>{
        this.numberOfActivatedCode=res.data;
        return this.numberOfActivatedCode;
     })
    }
    
  }
  goToCode(id){
    this.lectureId = id;
    this.closed = true;
    this.lectures.forEach(element => {
      if(element.id == id){
        this.selectedLecture =element;
      }
    });
  }
  closeModel(){
    this.closed = false;
    this.codeShow = false;
  }
  // public exportTableToExcel(){
  //   const downloadLink = document.createElement('a');
  //   const dataType = 'application/vnd.ms-excel';
  //   const table = document.getElementById('codesTable');
  //   const tableHtml = table.outerHTML.replace(/ /g,'%20');
  //   document.body.appendChild(downloadLink);
  //   downloadLink.href = 'data: '+dataType+' '+tableHtml;
  //   downloadLink.download = 'codes.xls';
  //   downloadLink.click();
  // }
  exportTableToExcel(){
    let table = document.getElementById('codesTable');
    const ws:XLSX.WorkSheet = XLSX.utils.table_to_sheet(table);
    // generate workbook and and add work sheet
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb,ws,"Sheet1");
    // save to file
    XLSX.writeFile(wb,"codes.xlsx");
  }
  getCode(){
    var code:ICode={};
    code.numberOfCodes = this.numberOfCodes;
    code.lectureId = this.lectureId;
    this.codeService.extractCodes(code).subscribe(
      (res:Ischema)=>
      {
        console.log(res);
        this.codeShow=true;
        this.codes=res.data;
      }
    )
  }
}
