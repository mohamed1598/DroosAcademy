import { Component, OnInit } from '@angular/core';
import { Ischema } from 'src/app/Interfaces/i-schema';
import { ISeller } from 'src/app/Interfaces/i-seller';
import { SellerService } from 'src/app/Services/seller.service';

@Component({
  selector: 'app-search-for-seller',
  templateUrl: './search-for-seller.component.html',
  styleUrls: ['./search-for-seller.component.css']
})
export class SearchForSellerComponent implements OnInit {

  constructor(private sellerService:SellerService) { }
  sellers:ISeller[]=[];
  search="";
  ngOnInit(): void {
  }
  searchById(){
    this.sellerService.getSellerById(+this.search).subscribe((res:Ischema)=>{
      this.sellers=[];
      this.sellers.push(res.data);

    })
  }
  searchByName(){
    this.sellerService.getSellerByName(this.search).subscribe((res:Ischema)=>this.sellers=res.data)
  }
  searchByPhoneNumber(){
    this.sellerService.getSellerByPhoneNumber(this.search).subscribe((res:Ischema)=>{
      this.sellers=[];
      this.sellers.push(res.data);

    })
  }

}
