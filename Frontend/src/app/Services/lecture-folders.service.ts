import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IAttachement } from '../Interfaces/iattachement';

@Injectable({
  providedIn: 'root'
})
export class LectureFoldersService {

  constructor(private httpclient:HttpClient) { }
  createFolder(folder:IAttachement){
    return this.httpclient.post(`${environment.api_url}/LectureFolders`,folder);
  }
}
