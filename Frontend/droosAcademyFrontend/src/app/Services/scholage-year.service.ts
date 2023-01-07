import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ScholageYearService {

  constructor(private httpClient:HttpClient) { }
  getAllCategories():Observable<any>{
    return this.httpClient.get(`${environment.api_url}/ScholageYears`);
  }
}
