import { Component, OnInit } from '@angular/core';
import { ActivityTypeService } from 'src/app/services/activityTypeService/activityType.service';
import { ActivityService } from 'src/app/services/activityService/activity.service';
import { ActivityType} from '../../models/activityType';
import { Activity } from '../../models/activity';



@Component({
  selector: 'app-activityType',
  templateUrl: './activityType.component.html',
  styleUrls: ['./activityType.component.css'],

})
export class ActivityTypeComponent implements OnInit {
  activityTypes : ActivityType[]=[];
  activitys:Activity[]=[];
  currentActivityType : ActivityType;
  currentActivity : Activity;
  filterText1 = '';



  constructor(private activityTypeService:ActivityTypeService,private activityService:ActivityService) { }

  ngOnInit(): void {
    this.getActivityTypes();
  }

  getActivityTypes(){
    this.activityTypeService.getActivityTypes().subscribe((response:any)=>{
      this.activityTypes=response.data;
    })
  }



  setCurrentActivityType(activityType:ActivityType){
    this.currentActivityType=activityType;
  }

  getCurrentActivityTypeClass(activityType:ActivityType)
  {
    if(activityType==this.currentActivityType){
      return "list-group-item active"
    }
    else{
      return "list-group-item list-group-item-light"
    }
  }

}
