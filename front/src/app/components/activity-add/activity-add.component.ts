import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormGroup,Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ActivityType } from 'src/app/models/activityType';
import { PriceType } from 'src/app/models/priceType';
import { ActivityTypeService } from 'src/app/services/activityTypeService/activityType.service';
import { ActivityService } from 'src/app/services/activityService/activity.service';
import { IsFreeService } from 'src/app/services/isFreeService/isFree.service';

@Component({
  selector: 'app-activity-add',
  templateUrl: './activity-add.component.html',
  styleUrls: ['./activity-add.component.css']
})
export class ActivityAddComponent implements OnInit {
  activityAddForm:FormGroup;
  activityTypes:ActivityType[]=[];
  priceTypes:PriceType[]=[];
  constructor(private activityTypeService:ActivityTypeService,private isFreeService:IsFreeService,private activityService:ActivityService,private formBuilder:FormBuilder,private toastrService:ToastrService, private router:Router) { }

  ngOnInit(): void {
    this.createActivityAddForm();
    this.getActivityTypes();
    this.getIsFrees();
  }

  createActivityAddForm() {
   this.activityAddForm=this.formBuilder.group({
    activityName: ["",Validators.required],
    activityTypeId: ["", Validators.required],
    priceTypeId: ["", Validators.required],
    activityLocation: ["", Validators.required],
    price: ["", Validators.required],
    description: ["", Validators.required],
    activityDate: ["",Validators.required],
    insertUserId: [""],
    capacity: ["",Validators.required]
   })
  }

  getActivityTypes(){
    this.activityTypeService.getActivityTypes().subscribe((response:any)=>{
      this.activityTypes=response.data;
    })
  }

  getIsFrees(){
    this.isFreeService.getIsFrees().subscribe((response:any)=>{
      this.priceTypes=response.data;
    })
  }

  add(){
    if(this.activityAddForm.valid){
      let activityModel=Object.assign({},this.activityAddForm.value);
      activityModel.insertUserId=localStorage.getItem("id");
      this.activityService.add(activityModel).subscribe((response:any)=>{
        this.toastrService.success(response.message,"Etkinlik eklendi")
      },(responseError:any)=>
      {
        if(responseError.error.Errors>0){

           this.toastrService.error(responseError.error.Errors.ErrorMessage,"Doğrulama hatası")
         }


        }
      )
      this.router.navigateByUrl("")
    }
    else {
      this.toastrService.error('form eksik!');
    }
  }

}
