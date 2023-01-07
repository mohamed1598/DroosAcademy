import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StudentHaveLectureService {

  constructor(private httpClient:HttpClient) { }
  isLectureValid(request){
    return this.httpClient.post(`${environment.api_url}/StudentHaveLectures/IsLectureValid`,request);
  }
}
