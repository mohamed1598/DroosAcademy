import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IAdmin } from '../Interfaces/i-admin';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private httpclient:HttpClient) { }
  login(user:IAdmin){
    return this.httpclient.post(`${environment.api_url}/Admins/Authentication`,user);
  }
}
