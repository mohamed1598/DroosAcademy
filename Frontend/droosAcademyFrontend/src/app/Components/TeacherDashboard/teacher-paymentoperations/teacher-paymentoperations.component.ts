import { Component, OnInit } from '@angular/core';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { LoginService } from 'src/app/Services/login.service';
import { TransactionService } from 'src/app/Services/transaction.service';

@Component({
  selector: 'app-teacher-paymentoperations',
  templateUrl: './teacher-paymentoperations.component.html',
  styleUrls: ['./teacher-paymentoperations.component.css']
})
export class TeacherPaymentoperationsComponent implements OnInit {

  constructor(private transactionService:TransactionService,private loginService:LoginService) { }
  transactions:any;
  ngOnInit(): void {
    this.transactionService.getTeacherTransaction(this.loginService.teacher.fullname).subscribe((res:Ischema)=>this.transactions=res.data)
  }

}
