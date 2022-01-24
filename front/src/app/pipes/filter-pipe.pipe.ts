import { Pipe, PipeTransform } from '@angular/core';
import { Activity } from '../models/activity'

@Pipe({
  name: 'filterPipe'
})
export class FilterPipePipe implements PipeTransform {

  transform(value: Activity[], filtertText: string): Activity[] {
    filtertText = filtertText?filtertText.toLocaleLowerCase():""
    //==-1 eğer varsa demek
    return filtertText?value.filter((p:Activity)=>p.activityName.toLocaleLowerCase().indexOf(filtertText)!==-1):value;
  }

}
