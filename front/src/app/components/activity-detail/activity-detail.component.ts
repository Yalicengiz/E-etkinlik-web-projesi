import { Component, OnInit,Input } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { JoinService } from 'src/app/services/joinService/join.service';
import { LocalStorageService } from 'src/app/services/localStorageService/local-storage.service';
import {formatDate } from '@angular/common';
import { Router } from '@angular/router';


@Component({
  selector: 'app-activity-detail',
  templateUrl: './activity-detail.component.html',
  styleUrls: ['./activity-detail.component.css'],
})
export class ActivityDetailComponent implements OnInit {
  activities:any=[];

  constructor(
    private _localStorage:LocalStorageService,
    private _toastr:ToastrService,
    private _joinService: JoinService,
    private _router:Router
  ) {}

  ngOnInit(): void {
    this.GetMyActivities(this._localStorage.get("id"))
  }

  async GetMyActivities(userId:any){
    
    await this._joinService.getJoinsByUserId(userId).subscribe((response:any)=>{
      this.activities=response.data;
    });

  }

  getFormatDate(date:any) {
    return formatDate(date, 'dd-MM-yyyy HH:mm:s', 'en-US');
  }

  async delete(id:any){
    this._joinService.deleteJoin(id).subscribe((response:any)=>{
      this._toastr.success(response.message)
    });
    location.reload();
  }







}


