import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ICode } from '../Interfaces/i-code';

@Injectable({
  providedIn: 'root'
})
export class CodesService {

  constructor(private httpClient:HttpClient) { }
  extractCodes(code:ICode){
    return this.httpClient.post(`${environment.api_url}/Codes/getListOfCodes`,code);
  }
  activateCode(code:ICode){
    return this.httpClient.post(`${environment.api_url}/Codes/ActivateCode`,code);
  }
}
