import { Pipe, PipeTransform } from '@angular/core';
import { ActivityType } from '../models/activityType';

@Pipe({
  name: 'activityTypeFilter'
})
export class ActivityTypeFilterPipe implements PipeTransform {

  transform(value: ActivityType[], filterText:string): ActivityType[] {
    filterText = filterText? filterText.toLocaleLowerCase() : "";
    return filterText? value.filter((b:ActivityType)=> b.activityTypeName.toLocaleLowerCase().indexOf(filterText)!==-1):value;
  }

}