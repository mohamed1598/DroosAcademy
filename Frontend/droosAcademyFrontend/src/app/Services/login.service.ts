import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor() { 
    if(localStorage.getItem("userType")=="student"){
      this.loggedIn = true;
      this.type = "student";
      this.student =JSON.parse(localStorage.getItem("user"));
    }
    else if(localStorage.getItem("userType")=="teacher"){
      this.loggedIn = true;
      this.type = "teacher";
      this.teacher =JSON.parse(localStorage.getItem("user"));
    }
    else if(localStorage.getItem("userType")=="admin"){
      this.loggedIn = true;
      this.type = "admin";
      this.admin =JSON.parse(localStorage.getItem("user"));
    }
    
  }
  
  isAuthenticated(){
    const promise = new Promise(
        (resolve,reject)=>{
              resolve(this.loggedIn)
        }
    );
    return promise;
  }
  getToken(){
    return JSON.parse(localStorage.getItem("token"));
  }


  student:any;
  teacher:any;
  admin:any;
  type="";
  loggedIn:boolean;
  getCurrentUser(){
  }
}
