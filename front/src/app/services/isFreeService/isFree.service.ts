import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../../models/listResponseModel'
import { PriceType } from '../../models/priceType'
import { ResponseModel } from 'src/app/models/responseModel';

@Injectable({
  providedIn: 'root'
})
export class IsFreeService {
  apiUrl = 'https://localhost:5001/api/';
  constructor(private httpClient:HttpClient) { }
  getIsFrees():Observable<ListResponseModel<PriceType>>
  {
    let newPath=this.apiUrl+"priceType/getall"
    return this.httpClient.get<ListResponseModel<PriceType>>(newPath);
  }

  getById(isFreeId:number):Observable<ListResponseModel<PriceType>>{
    let newPath=this.apiUrl+"priceType/getbyid?id="+isFreeId;
    return this.httpClient.get<ListResponseModel<PriceType>>(newPath);
  }

  add(isFree:PriceType):Observable<ResponseModel>{
    let newPath=this.apiUrl+"priceType/add"
    return this.httpClient.post<ResponseModel>(newPath,isFree);

  }

  update(isFree:PriceType):Observable<ResponseModel>{
    let newPath=this.apiUrl+"priceType/update"
    return this.httpClient.post<ResponseModel>(newPath,isFree)

  }
}
