import { Component, OnInit } from '@angular/core';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { SellerService } from 'src/app/Services/seller.service';

@Component({
  selector: 'app-all-seller',
  templateUrl: './all-seller.component.html',
  styleUrls: ['./all-seller.component.css']
})
export class AllSellerComponent implements OnInit {

  constructor(private sellerService:SellerService) { }
  sellers:any;
  ngOnInit(): void {
    this.sellerService.getAllSellers().subscribe((res:Ischema)=>this.sellers=res.data)
  }
  OnNext(){
    this.sellerService.paginationRequest.skip+=1;
    this.sellerService.getAllSellers().subscribe((res:Ischema)=>{
      if(res.data.length == 0){
        this.sellerService.paginationRequest.skip-=1;
        alert("نهاية الطلبة");
      }
      else{
        this.sellers=res.data;
      }
    })
  }
  OnPast(){
    this.sellerService.paginationRequest.skip-=1;
    this.sellerService.getAllSellers().subscribe((res:Ischema)=>{
      if(this.sellerService.paginationRequest.skip == -1){
        this.sellerService.paginationRequest.skip+=1;
        alert("بداية الطلبة");
      }
      else{
        this.sellers=res.data;
      }
    })
  }

}
