import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ExamService {

  constructor(private httpClient:HttpClient) { }
  getExamById(id:number){
    return this.httpClient.get(`${environment.api_url}/Exams/${id}`);
  }
  getLectureExams(id:number){
    return this.httpClient.get(`${environment.api_url}/Exams/LectureExams/${id}`);
  }
  postExam(request){
    return this.httpClient.post(`${environment.api_url}/Exams`,request);
  }
  postQuestion(request){
    return this.httpClient.post(`${environment.api_url}/ExamQuestions`,request);
  }
  postAnswer(request){
    return this.httpClient.post(`${environment.api_url}/QuestionMcqs`,request);
  }
}
