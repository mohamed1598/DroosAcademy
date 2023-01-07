import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IAuthentication } from '../Interfaces/i-authentication';
import { Student } from '../Interfaces/i-student';
import { IPaginationRequest } from '../Interfaces/ipagination-request';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  paginationRequest:IPaginationRequest={skip:0,limit:2};
  constructor(private httpclient:HttpClient) {
   }
  getAllStudents(){
    return this.httpclient.post(`${environment.api_url}/Students/Pagination`,this.paginationRequest);
  }
  createUser(student:Student){
    return this.httpclient.post(`${environment.api_url}/Students`,student);
  }
  getStudentById(id:number){
    return this.httpclient.get(`${environment.api_url}/Students/${id}`);
  }
  getStudentByName(name:string){
    return this.httpclient.get(`${environment.api_url}/Students/SearchByName/${name}`);
  }
  getStudentByPhoneNumber(phoneNumber:string){
    return this.httpclient.get(`${environment.api_url}/Students/SearchByPhoneNumber/${phoneNumber}`);
  }
  login(student:IAuthentication){
    return this.httpclient.post(`${environment.api_url}/Students/Authentication`,student);
  }
  getStudentLecture(id:number){
    return this.httpclient.get(`${environment.api_url}/StudentHaveLectures/StudentLectures/${id}`);
  }
  getTeacherStudents(teacher:string){
    return this.httpclient.get(`${environment.api_url}/Students/Teacher/${teacher}`);
  }
  getLecturesNumberForStudent(id:number){
    return this.httpclient.get(`${environment.api_url}/StudentHaveLectures/LecturesNumberForStudent/${id}`);
  }
  getTeachersNumberForStudent(id:number){
    return this.httpclient.get(`${environment.api_url}/StudentHaveLectures/TeachersNumberForStudent/${id}`);
  }
}
