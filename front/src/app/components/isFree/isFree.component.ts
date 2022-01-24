import { Component, OnInit } from '@angular/core';
import { IsFreeService } from 'src/app/services/isFreeService/isFree.service';
import { PriceType } from '../../models/priceType'
@Component({
  selector: 'app-isFree',
  templateUrl: './isFree.component.html',
  styleUrls: ['./isFree.component.css']
})
export class IsFreeComponent implements OnInit {
  priceTypes:PriceType[]=[];
  currentIsFree : PriceType;
  filterText='';
  constructor(private isFreeService:IsFreeService) { }

  ngOnInit(): void {
    this.getIsFrees();
  }

  getIsFrees()
  {
    this.isFreeService.getIsFrees().subscribe(response=>{
      this.priceTypes=response.data;
    })
  }

  setCurrentIsFree(isFree:PriceType){
    this.currentIsFree=isFree;
  }

  getCurrentIsFreeClass(isFree:PriceType)
  {
    if(isFree==this.currentIsFree){
      return "list-group-item active"
    }
    else{
      return "list-group-item list-group-item-light"
    }
  }

}
