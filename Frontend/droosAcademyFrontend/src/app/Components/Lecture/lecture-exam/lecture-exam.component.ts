import { DatePipe } from '@angular/common';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ILecture } from 'src/app/Interfaces/i-lecture';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { IExam } from 'src/app/Interfaces/iexam';
import { ExamService } from 'src/app/Services/exam.service';
import { LecturesService } from 'src/app/Services/lectures.service';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-lecture-exam',
  templateUrl: './lecture-exam.component.html',
  styleUrls: ['./lecture-exam.component.css'],
  providers: [DatePipe]
})
export class LectureExamComponent implements OnInit {

  constructor(public loginService: LoginService, private route: ActivatedRoute, public datePipe: DatePipe, private examService: ExamService,private lectureService:LecturesService) {

   }
  id: number;
  exam: IExam|any = {};
  test = {};
  lecture:ILecture|any;
  date: any;
  seconds :any;
  minutes:any;
  endOfExam = false;
  totalResult =0;
  interval:any;
  unSolvedAnswers = 0;
  solvedAnswers= 0;
  firstCharacter='';
  lastCharacter='';
  ngOnInit(): void {
    this.id = +this.route.snapshot.queryParams['examId'];
    this.examService.getExamById(this.id).subscribe((res: Ischema) => {
      this.exam = res.data;
      this.unSolvedAnswers = this.exam.examQuestions.length;
      this.exam.examQuestions.forEach(element => {
        let key = element.id;
        this.test[key] = {'value':0,"correct":element.correctAnswer};
      });
      this.lectureService.getLectureById(this.exam.lectureId).subscribe((res:Ischema)=>{
        this.lecture=res.data;
        let nameArray = this.lecture.teacher.fullname.split(" ");
        this.firstCharacter = nameArray[0].substring(0,1);
        this.lastCharacter = nameArray[nameArray.length-1].substring(0,1);
      })
      this.exam.startTime = this.datePipe.transform(this.exam.startTime, 'yyyy-MM-dd');
      this.seconds = 60;
      this.minutes = this.exam.time-1;
      this.interval = setInterval(() => {
        this.seconds -= 1;
        if(this.seconds <= 0){
          this.seconds = 60;
          this.minutes -=1;
        }
        if(this.minutes < 0){
          this.minutes = 0;
          this.seconds = 0;
          this.getResult();
          alert("لقد انتهى وقت الامتحان")
          clearInterval(this.interval);
        }
      }, 1000);
    })
  }
  activeAnswer(answerId,questionId){

    if(!this.endOfExam){
      if(this.test[questionId].value==0){
        this.solvedAnswers++;
        this.unSolvedAnswers--;
      }
      this.test[questionId].value = answerId;
      console.log(this.test);
    }
    
    
  }
  getResult(){
    this.exam.examQuestions.forEach(element => {
      if(this.test[element.id].value === this.test[element.id].correct){
        this.totalResult++;
      }
    });
    console.log(this.totalResult);
    this.endOfExam = true;
    clearInterval(this.interval);
    return this.totalResult;
  }
  // isAnswerActive(answerId,questionId){
  //   this.test.forEach(element => {
  //     if(answerId == element.answerId && questionId == element.questionId) {
  //       console.log(true);
        
  //       return true;
  //     }
  //   });
  //   return false
  // }
  // getTime() {
  //   const date = new Date();
  //   const hour = date.getSeconds();
  //   console.log(hour);
  //   this.cd.detectChanges()

  // }

}
