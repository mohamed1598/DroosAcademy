import { Component, OnInit } from '@angular/core';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { LoginService } from 'src/app/Services/login.service';
import { PriceService } from 'src/app/Services/price.service';
import { ViewsService } from 'src/app/Services/views.service';

@Component({
  selector: 'app-teacher-statistics',
  templateUrl: './teacher-statistics.component.html',
  styleUrls: ['./teacher-statistics.component.css']
})
export class TeacherStatisticsComponent implements OnInit {

  constructor(private viewsService:ViewsService,public loginService:LoginService,private priceService:PriceService) { }
  totalViews = 0;
  todayViews = 0;
  yesterdayViews = 0;
  thisMonth = 0;
  LastMonth = 0;
  todayBenefits =0;
  yesterdayBenefits =0;
  thisMonthBenefits =0;
  LastMonthBenefits =0;
  ngOnInit(): void {
    this.viewsService.getTodayViews(this.loginService.teacher.id).subscribe((res:Ischema)=>this.todayViews=res.data)
    this.viewsService.getYesterdayViews(this.loginService.teacher.id).subscribe((res:Ischema)=>this.yesterdayViews=res.data)
    this.viewsService.getThisMonthViews(this.loginService.teacher.id).subscribe((res:Ischema)=>this.thisMonth=res.data)
    this.viewsService.getLastMonthViews(this.loginService.teacher.id).subscribe((res:Ischema)=>this.LastMonth=res.data)
    this.priceService.getTodayBenefits(this.loginService.teacher.id).subscribe((res:Ischema)=>this.todayBenefits = res.data.balanceForTeacher)
    this.priceService.getYesterdayBenefits(this.loginService.teacher.id).subscribe((res:Ischema)=>this.yesterdayBenefits = res.data.balanceForTeacher)
    this.priceService.getThisMonthBenefits(this.loginService.teacher.id).subscribe((res:Ischema)=>this.thisMonthBenefits = res.data.balanceForTeacher)
    this.priceService.getLastMonthBenefits(this.loginService.teacher.id).subscribe((res:Ischema)=>this.LastMonthBenefits = res.data.balanceForTeacher)
  }

}
