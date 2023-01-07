import { Component, OnInit } from '@angular/core';

import { faCoffee } from '@fortawesome/free-solid-svg-icons';
import { SpinnerService } from './Services/Animation/spinner-service.service';
import { LoginService } from './Services/login.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'droosacademy';
  constructor(private loginService:LoginService,public spinnerService:SpinnerService){
    
  }
  ngOnInit(){
    
  }
}
