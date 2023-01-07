import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { IExam } from 'src/app/Interfaces/iexam';
import { ExamService } from 'src/app/Services/exam.service';

@Component({
  selector: 'app-create-exam',
  templateUrl: './create-exam.component.html',
  styleUrls: ['./create-exam.component.css']
})
export class CreateExamComponent implements OnInit {

  constructor(private route:ActivatedRoute,private examService:ExamService,private router:Router) { }
  exam:IExam={};
  exams:IExam[]=[];
  ngOnInit(): void {
    this.exam.lectureId=+this.route.snapshot.queryParams['lectureId'];
    this.updateExams();
  }
  addExam(){
    this.examService.postExam(this.exam).subscribe((res:Ischema)=>{console.log(res);
      this.exams.push(res.data);
      this.exam.name ="";
      this.exam.time=0;
    })
    
  }
  updateExams(){
    this.examService.getLectureExams(this.exam.lectureId).subscribe((res:Ischema)=>{
      console.log(res);
      this.exams = res.data;
    })
  }
  goToExam(id:number){
    this.router.navigate(['/Teacher/AddQuestions'], { queryParams: { examId: id } });
  }
}
