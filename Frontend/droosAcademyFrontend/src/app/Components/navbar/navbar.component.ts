import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private loginService:LoginService) { }
  isOpen=false;
  queryParamId = 0;
  ngOnInit(): void {
    if(this.loginService.student != null){
      this.queryParamId = this.loginService.student.id;
    }
  }
  toggleNavbar(){
    this.isOpen=!this.isOpen;
  }

}
