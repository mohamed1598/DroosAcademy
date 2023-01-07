import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IAttachement } from '../Interfaces/iattachement';

@Injectable({
  providedIn: 'root'
})
export class LecturePartsService {

  constructor(private httpclient:HttpClient) { }
  createPart(folder:IAttachement){
    return this.httpclient.post(`${environment.api_url}/LectureParts`,folder);
  }
}
