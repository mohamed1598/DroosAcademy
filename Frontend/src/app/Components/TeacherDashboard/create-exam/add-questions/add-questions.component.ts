import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ILecture } from 'src/app/Interfaces/i-lecture';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { IExam } from 'src/app/Interfaces/iexam';
import { ExamService } from 'src/app/Services/exam.service';
import { LecturesService } from 'src/app/Services/lectures.service';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-add-questions',
  templateUrl: './add-questions.component.html',
  styleUrls: ['./add-questions.component.css'],
  providers: [DatePipe]
})
export class AddQuestionsComponent implements OnInit {

  constructor(public loginService: LoginService, private route: ActivatedRoute, public datePipe: DatePipe, private examService: ExamService,private lectureService:LecturesService) {

  }
 id: number;
 exam: IExam|any = {};
 test = {};
 lecture:ILecture|any;
 date: any;
 seconds :any;
 minutes:any;
 unSolvedAnswers = 0;
 firstCharacter='';
 lastCharacter='';
 show=false;
 showAnswer=false;
 answerOrder = 0;
 question1:any={
  question:"",
  orders:0,
  correctAnswer:0,
  examId:+this.route.snapshot.queryParams['examId']
 };
 answer="";
//  answer1={
//   questionId:0,
//   answer:"",  
//   orders:0
//  };
 ListOfAnswers:any[]=[];
 list:any=[];
 ngOnInit(): void {
   this.id = +this.route.snapshot.queryParams['examId'];
   this.examService.getExamById(this.id).subscribe((res: Ischema) => {
     this.exam = res.data;
     console.log(this.exam);
     
     this.unSolvedAnswers = this.exam.examQuestions.length;
     this.exam.examQuestions.forEach(element => {
       let key = element.id;
       this.test[key] = {'value':0,"correct":element.orders};
     });
     this.lectureService.getLectureById(this.exam.lectureId).subscribe((res:Ischema)=>{
       this.lecture=res.data;
       let nameArray = this.lecture.teacher.fullname.split(" ");
       this.firstCharacter = nameArray[0].substring(0,1);
       this.lastCharacter = nameArray[nameArray.length-1].substring(0,1);
     })
     this.exam.startTime = this.datePipe.transform(this.exam.startTime, 'yyyy-MM-dd');
     this.seconds = 0;
     this.minutes = this.exam.time;
   })
 }
 openAddQuestion(){
  this.show= true;
  
  this.ListOfAnswers = [];
 }
 addQuestion(){
   this.unSolvedAnswers++;
   this.question1.orders = this.unSolvedAnswers;
   this.show=false;
   this.showAnswer=true;
 }
 addAnswer(){
   this.answerOrder++;
   const answer1 = {
      questionId:0,
      answer:"",  
      orders:0
     };
   answer1.orders = this.answerOrder;
   answer1.answer = this.answer;
   this.ListOfAnswers.push(answer1);
   this.answer = "";
   
 }
 activeAnswer(order:number){
  this.question1.correctAnswer= order;
  console.log(this.question1);
  console.log(this.ListOfAnswers);
  
  this.showAnswer = false;
  this.answerOrder = 0;
  this.examService.postQuestion(this.question1).subscribe((res:Ischema)=>{
    this.question1=res.data;
    let id = this.question1.id;
    this.exam.examQuestions.push(this.question1);
    this.question1={
      question:"",
      orders:0,
      correctAnswer:0,
      examId:+this.route.snapshot.queryParams['examId']
     };
    this.ListOfAnswers.forEach(element => {
      let item = element;
      item.questionId = id;
      this.examService.postAnswer(item).subscribe((res:Ischema)=>{
        this.exam.examQuestions[this.exam.examQuestions.length-1].questionMcqs.push(res.data);
      })
    });
  })
  
 }
 getResult()
 {
 }

}
