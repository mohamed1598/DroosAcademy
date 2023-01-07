import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ViewsService {

  constructor(private httpclient:HttpClient) { }
  increaseViews(request:any){
    return this.httpclient.post(`${environment.api_url}/Views/IncreaseViews`,request);
  }
  getTotalViews(id:number){
    return this.httpclient.get(`${environment.api_url}/Views/${id}`);
  }
  getTodayViews(id:number){
    return this.httpclient.get(`${environment.api_url}/Views/Today/${id}`);
  }
  getYesterdayViews(id:number){
    return this.httpclient.get(`${environment.api_url}/Views/Yesterday/${id}`);
  }
  getThisMonthViews(id:number){
    return this.httpclient.get(`${environment.api_url}/Views/ThisMonth/${id}`);
  }
  getLastMonthViews(id:number){
    return this.httpclient.get(`${environment.api_url}/Views/LastMonth/${id}`);
  }
}
