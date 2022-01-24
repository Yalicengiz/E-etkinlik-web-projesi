import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../../models/listResponseModel'
import { Activity } from '../../models/activity'
import { ResponseModel } from 'src/app/models/responseModel';
import { SingleResponseModel } from 'src/app/models/singleResponseModel';
import { ActivityDetail } from 'src/app/models/activityDetail';

import { JoinService } from '../joinService/join.service';
import { LocalStorageService } from '../localStorageService/local-storage.service';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ActivityService {
  apiUrl = 'https://localhost:5001/api/';
  sayi : any;

  constructor(private httpClient: HttpClient,private _joinService:JoinService,private _localStorage:LocalStorageService,private _toastr:ToastrService) { }

  getActivitys():Observable<ListResponseModel<ActivityDetail>> {
    let newPath=this.apiUrl+"activitys/getallactivity"
    return this.httpClient.get<ListResponseModel<ActivityDetail>>(newPath);
  }

  getActivitysbyActivityType(activityTypeId:number):Observable<ListResponseModel<Activity>> {
    let newPath=this.apiUrl+"activitys/getactivitydetailsbyactivitytypeid?id="+activityTypeId
    return this.httpClient.get<ListResponseModel<Activity>>(newPath);
  }

  getActivitysbyIsFree(isFreeId:number):Observable<ListResponseModel<Activity>>{
    let newPath=this.apiUrl+"Activitys/getactivitydetailsbypricetypeid?id="+isFreeId
    return this.httpClient.get<ListResponseModel<Activity>>(newPath);
  }

  getActivityDetailsByActivityId(activityId:number):Observable<ListResponseModel<Activity>>{
    let newPath = this.apiUrl + "activitys/getbyid?id="+activityId
    return this.httpClient.get<ListResponseModel<Activity>>(newPath)
  }

  getById(id:number):Observable<ListResponseModel<ActivityDetail>>{
    let newPath = this.apiUrl + "activitys/getbyid?id="+id
    return this.httpClient.get<ListResponseModel<ActivityDetail>>(newPath)
  }


  add(activity:Activity):Observable<ResponseModel>{
    let newPath=this.apiUrl+"activitys/add";
    return this.httpClient.post<ResponseModel>(newPath,activity);
  }

  update(activity:ActivityDetail):Observable<ResponseModel>{
    let newPath=this.apiUrl+"activitys/update";
    return this.httpClient.post<ResponseModel>(newPath,activity);
  }

  join(activity:any){
    let newPath=this.apiUrl+"joins/add";
      return  this.httpClient.post<ResponseModel>(newPath,activity);
    
 
   
  }

}
