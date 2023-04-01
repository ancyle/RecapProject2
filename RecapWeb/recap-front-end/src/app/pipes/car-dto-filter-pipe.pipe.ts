import { Pipe, PipeTransform } from '@angular/core';
import { CarDetailDto } from '../models/carDetailDto';

@Pipe({
  name: 'carDtoFilterPipe',
})
export class CarDtoFilterPipePipe implements PipeTransform {
  transform(value: CarDetailDto[], filterValue: string): CarDetailDto[] {
    filterValue = filterValue ? filterValue.toLocaleLowerCase() : '';

      return filterValue
        ? value.filter(
            (cDD: CarDetailDto) =>
              cDD.modelYear
                .toString()
                .toLocaleLowerCase()
                .indexOf(filterValue) !== -1
          )
        : value;
  }
}
