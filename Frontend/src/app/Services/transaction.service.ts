import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  constructor(private httpClient:HttpClient) { }
  getTeacherTransaction(teacher:string){
    return this.httpClient.get(`${environment.api_url}/Transactions/${teacher}`);
  }
}
