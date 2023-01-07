import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IPaginationRequest } from '../Interfaces/ipagination-request';

@Injectable({
  providedIn: 'root'
})
export class SellerService {

  constructor(private httpclient:HttpClient) { }
  paginationRequest:IPaginationRequest={skip:0,limit:2};
  getAllSellers(){
    return this.httpclient.post(`${environment.api_url}/Sellers/Pagination`,this.paginationRequest);
  }
  getSellerById(id:number){
    return this.httpclient.get(`${environment.api_url}/Sellers/${id}`);
  }
  getSellerByName(name:string){
    return this.httpclient.get(`${environment.api_url}/Sellers/SearchByName/${name}`);
  }
  getSellerByPhoneNumber(phoneNumber:string){
    return this.httpclient.get(`${environment.api_url}/Sellers/SearchByPhoneNumber/${phoneNumber}`);
  }
}
