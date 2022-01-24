import { ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Activity } from 'src/app/models/activity';
import { ActivityService } from 'src/app/services/activityService/activity.service';
import {formatDate } from '@angular/common';

import {CartService } from '../../services/cartService/cart.service';
import { JoinService } from 'src/app/services/joinService/join.service';
import { LocalStorageService } from 'src/app/services/localStorageService/local-storage.service';

//backendeki dataya ulaşmak -> httpclient

@Component({
  selector: 'app-activity',
  templateUrl:'./activity.component.html',
  styleUrls: ['./activity.component.css'],
})
export class ActivityComponent implements OnInit {
  activitys: Activity[] = [];
  dataLoaded = false;
  currentActivity: Activity;


  

  filterText = '';

  constructor(
    private activityService: ActivityService,
    private activatedRoute: ActivatedRoute,
    private cartService:CartService,
    private _router: Router,
    private _toastr: ToastrService,
    private _joinService:JoinService,
    private _localService:LocalStorageService
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params:any) => {
      console.log("typeid",params['isFreeId'])
      if (params['activityTypeId']) {
        this.getActivitysbyActivityType(params['activityTypeId']);
      } else if (params['id']) {
        this.getActivityDetailsByActivityId(params['id']);
      } else if (params['isFreeId']) {
        this.getActivitysbyIsFree(params['isFreeId']);
      } else {
        this.getActivitys();
      }
    });
   

  }

  getActivitys() {
    this.activityService.getActivitys().subscribe((response:any) => {

      this.activitys = response.data;
      this.dataLoaded = true;
      console.log("activity",this.activitys)
    });
  }

  getActivitysbyActivityType(activityTypeId: number) {
    this.activityService.getActivitysbyActivityType(activityTypeId).subscribe((response:any) => {
      this.activitys = response.data;
      this.dataLoaded = true;
    });
  }

  getActivitysbyIsFree(priceTypeId: number) {
    this.activityService.getActivitysbyIsFree(priceTypeId).subscribe((response:any) => {
      this.activitys = response.data;
      this.dataLoaded = true;
    });
  }

  setCurrentActivity(activity: Activity) {
    this.currentActivity = activity;
  }

  getActivityDetailsByActivityId(activityId: number) {
    this.activityService.getActivityDetailsByActivityId(activityId).subscribe((response:any) => {
      this.activitys = response.data;
    });
  }

  control(){
    var result=localStorage.getItem("opId");
    if(result=="3"){
      this._router.navigateByUrl("/activitys/activityadd");
    }
    else{
      this._toastr.error("Etkinlik ekleyebilmek için süper kullanıcı olmalısınız");
    }
  }
  control2(activity:any){
    console.log("activity",activity)

    if(activity.insertUserId!=localStorage.getItem("id")){
      this._toastr.error("Bu etkinliği yalnızca ekleyen kişi güncelleyebilir!");
    }
    else{
      this._router.navigate([`/activitys/activityupdate/${activity.id}`])
    }
  }

  async join(activity:Activity){
    let join={activityId: activity.id,customerId: localStorage.getItem("id")};
    this._joinService.getJoinsByUserAndActivityId(parseInt(this._localService.get("id")),activity.id).subscribe((response)=>{
 
  
      if(response.data!=null){
        this._toastr.error("Bu etkinliğe daha önce katıldınız!")

      }
      else{
        this.activityService.join(join).subscribe((response:any)=>{
          if(response.message=="Bu etkinlikte yer kalmamıştır."){
            this._toastr.error(response.message)
          }
          else{
            this._toastr.success(response.message)
            setTimeout(() => {
              
              location.reload();
            }, 1000);
           

    
          }
          
        });
      }
    })
   
     
  
    
  }
  getFormatDate(date:any) {
    return formatDate(date, 'dd-MM-yyyy', 'en-US');
  }

}
