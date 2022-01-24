import { Injectable } from '@angular/core';
import {HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../../models/listResponseModel';
import {ResponseModel } from '../../models/responseModel';
import { ActivityType } from '../../models/activityType'
@Injectable({
  providedIn: 'root'
})
export class ActivityTypeService {
  apiUrl = 'https://localhost:5001/api/';
  constructor(private httpClient: HttpClient) { }

  getActivityTypes():Observable<ListResponseModel<ActivityType>>{
    let newPath=this.apiUrl+"activityTypes/getall"
    return this.httpClient.get<ListResponseModel<ActivityType>>(newPath);
  }

  getById(activityTypeId:number):Observable<ListResponseModel<ActivityType>> {
    let newPath=this.apiUrl+'activityTypes/getbyid?id='+activityTypeId;
    return this.httpClient.get<ListResponseModel<ActivityType>>(newPath);
  }

  add(activityType:ActivityType):Observable<ResponseModel>{
    let newPath=this.apiUrl+"activityTypes/add";
    return this.httpClient.post<ResponseModel>(newPath,activityType);
  }

  update(activityType:ActivityType):Observable<ResponseModel>{
    let newPath=this.apiUrl+"activityTypes/update";
    return this.httpClient.post<ResponseModel>(newPath,activityType);
  }

}
