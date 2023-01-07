import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SubjectService {

  constructor(private httpclient:HttpClient) { }
  getSubjects(){
    return this.httpclient.get(`${environment.api_url}/Subjects`);
  }
}
