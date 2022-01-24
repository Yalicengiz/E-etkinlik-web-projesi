import { Pipe, PipeTransform } from '@angular/core';
import { PriceType } from '../models/priceType';

@Pipe({
  name: 'isFreeFilter'
})
export class IsFreeFilterPipe implements PipeTransform {

  transform(value: PriceType[], filterText:string): PriceType[] {
    filterText = filterText? filterText.toLocaleLowerCase() : "";
    return filterText? value.filter((c:PriceType)=> c.priceTypeName.toLocaleLowerCase().indexOf(filterText)!==-1):value;
  }

}
