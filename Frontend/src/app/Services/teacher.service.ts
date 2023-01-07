import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IAuthentication } from '../Interfaces/i-authentication';
import { Teacher } from '../Interfaces/i-teacher';
import { IPaginationRequest } from '../Interfaces/ipagination-request';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {
  constructor(private httpclient:HttpClient) { }
  paginationRequest:IPaginationRequest={skip:0,limit:2};
  createUser(teacher:Teacher){
    return this.httpclient.post(`${environment.api_url}/Teachers`,teacher);
  }
  login(student:IAuthentication){
    return this.httpclient.post(`${environment.api_url}/Teachers/Authentication`,student);
  }
  getTeachersForStudent(id:number){
    return this.httpclient.get(`${environment.api_url}/StudentHaveLectures/TeachersForStudent/${id}`);
  }
  getAllTeachers(){
    return this.httpclient.post(`${environment.api_url}/Teachers/Pagination`,this.paginationRequest);
  }
  getTeacherById(id:number){
    return this.httpclient.get(`${environment.api_url}/Teachers/${id}`);
  }
  getTeacherByName(name:string){
    return this.httpclient.get(`${environment.api_url}/Teachers/SearchByName/${name}`);
  }
  getTeacherByPhoneNumber(phoneNumber:string){
    return this.httpclient.get(`${environment.api_url}/Teachers/SearchByPhoneNumber/${phoneNumber}`);
  }
}
