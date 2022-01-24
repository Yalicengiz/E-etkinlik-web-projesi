import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PriceType } from 'src/app/models/priceType';
import { IsFreeService } from 'src/app/services/isFreeService/isFree.service';

@Component({
  selector: 'app-isFree-update',
  templateUrl: './isFree-update.component.html',
  styleUrls: ['./isFree-update.component.css']
})
export class IsFreeUpdateComponent implements OnInit {

  isFreeUpdateForm:FormGroup;
  isFreeDetails:PriceType;
  constructor(private isFreeService:IsFreeService,private formBuilder:FormBuilder,private toastrService:ToastrService,private activatedRoute:ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params:any) => {
      this.getIsFreeDetails(params['isFreeId']);
    });
  }

  createIsFreeUpdateForm(){
    this.isFreeUpdateForm=this.formBuilder.group({
      priceTypeId:[this.isFreeDetails.priceTypeId,Validators.required],
      priceTypeName:[this.isFreeDetails.priceTypeName,Validators.required]
    })
  };

  getIsFreeDetails(isFreeId:number){
    this.isFreeService.getById(isFreeId).subscribe(response=>{
      this.isFreeDetails=response.data[0];
      this.createIsFreeUpdateForm();
    })
  }

  update(){
    if(this.isFreeUpdateForm.valid){
      let isFreeModel=Object.assign({},this.isFreeUpdateForm.value);
      return this.isFreeService.update(isFreeModel).subscribe(response=>{
        return this.toastrService.success(response.message,"Renk güncellendi");
      })
    }
    else{
      return this.toastrService.error("hatalı form","Warning");
    }
  }

}
