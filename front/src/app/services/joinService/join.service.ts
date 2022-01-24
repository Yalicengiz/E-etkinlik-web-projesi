import { HttpClient } from '@angular/common/http';
import { HostBinding, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Activity } from 'src/app/models/activity';
import { Customer } from 'src/app/models/customer';
import { ListResponseModel } from 'src/app/models/listResponseModel';
import { ResponseModel } from 'src/app/models/responseModel';
import { Join } from '../../models/join';
import { JoinDetail } from '../../models/joinDetail'

@Injectable({
  providedIn: 'root'
})
export class JoinService {
  apiUrl = 'https://localhost:5001/api/';
  constructor(private httpClient:HttpClient) { }

  getJoins(join:Join):Observable<ResponseModel>{
    let newPath=this.apiUrl+"joins/checkjoindates"
    return this.httpClient.post<ResponseModel>(newPath,join);
  }

  getbyActivityIdJoins(id:number):Observable<ListResponseModel<Join>>{
    let newPath=this.apiUrl+"joins/checkjoindates"
    return this.httpClient.get<ListResponseModel<Join>>("https://localhost:5001/api/Joins/getbyid?id="+id);
  }


  addJoin(join:Join):Observable<ResponseModel>{
    let newPath = this.apiUrl + 'joins/add';
    return this.httpClient.post<ResponseModel>(newPath,join)
  }

  getJoinsByUserId(id:number):Observable<ListResponseModel<JoinDetail>>{
    
    return this.httpClient.get<ListResponseModel<JoinDetail>>("https://localhost:5001/api/Joins/getjoinbyuserid?id="+id);
  }

  getJoinsByUserAndActivityId(id:number,actId:number):Observable<ListResponseModel<JoinDetail>>{
    
    return this.httpClient.get<ListResponseModel<JoinDetail>>("https://localhost:5001/api/Joins/getjoinbyuserandactivityid?id="+id+"&actId="+actId);
  }

  deleteJoin(id:number): Observable<ResponseModel>{
    return this.httpClient.get<ResponseModel>("https://localhost:5001/api/Joins/joinDelete?id="+id);
  }

}
