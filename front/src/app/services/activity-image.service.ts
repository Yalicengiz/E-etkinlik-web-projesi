import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserImage } from '../models/userImage';
import { ListResponseModel } from '../models/listResponseModel';

@Injectable({
  providedIn: 'root'
})
export class ActivityImageService {

  constructor(private httpClient:HttpClient) { }

  apiUrl = 'https://localhost:5001/api/';

  getActivityImages(): Observable<ListResponseModel<UserImage>> {
    let newPath=this.apiUrl+"activityimages/getall";
    return this.httpClient.get<ListResponseModel<UserImage>>(newPath);
  }
  getActivityImagesByActivityId(activityId:number):Observable<ListResponseModel<UserImage>> {
    let newPath=this.apiUrl+"activityimages/getimagesbyid?id="+activityId;
    return this.httpClient.get<ListResponseModel<UserImage>>(newPath);
  }
}
