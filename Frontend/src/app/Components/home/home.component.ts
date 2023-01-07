import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HomeNavigationService } from 'src/app/Services/home-navigation.service';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  height:any

  constructor(private homeNavigationService:HomeNavigationService, private loginServ:LoginService,private router:Router) {
    
   }

  ngOnInit(): void {
    this.height = window.innerHeight
  }

}
