import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ILecture } from '../Interfaces/i-lecture';

@Injectable({
  providedIn: 'root'
})
export class LecturesService {

  constructor(private httpclient:HttpClient) { }
  getLectureById(id:number){
    return this.httpclient.get(`${environment.api_url}/Lectures/${id}`);
  }
  getTeacherLectures(teacherdata:any){
    return this.httpclient.post(`${environment.api_url}/Lectures/TeacherLectures`,teacherdata);
  }
  createLecture(lecture:ILecture){
    return this.httpclient.post(`${environment.api_url}/Lectures`,lecture);
  }
  getLectureActivatedCodes(id:number){
    return this.httpclient.get(`${environment.api_url}/Codes/getLectureNumberOfActivatedCodes/${id}`);
  }
  deleteLecture(id:number){
    return this.httpclient.delete(`${environment.api_url}/Lectures/${id}`);
  }
}
