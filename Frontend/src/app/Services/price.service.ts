import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PriceService {

  constructor(private httpclient:HttpClient) { }
  getTodayBenefits(id:number){
    return this.httpclient.get(`${environment.api_url}/Price/Today/${id}`);
  }
  getYesterdayBenefits(id:number){
    return this.httpclient.get(`${environment.api_url}/Price/Yesterday/${id}`);
  }
  getThisMonthBenefits(id:number){
    return this.httpclient.get(`${environment.api_url}/Price/ThisMonth/${id}`);
  }
  getLastMonthBenefits(id:number){
    return this.httpclient.get(`${environment.api_url}/Price/LastMonth/${id}`);
  }
}
