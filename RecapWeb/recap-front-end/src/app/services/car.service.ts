import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../models/listResponseModel';
import { Car } from '../models/car';

@Injectable({
  providedIn: 'root',
})
export class CarService {
  private apiUrl: string = 'https://localhost:7215/api';
  constructor(private httpClient: HttpClient) {}

  getCars(): Observable<ListResponseModel<Car>> {
    let newPath: string = this.apiUrl + '/Cars/dtos/getall';
    return this.httpClient.get<ListResponseModel<Car>>(newPath);
  }

  getCarsByColor(colorName: string): Observable<ListResponseModel<Car>> {
    let newPath: string =
      this.apiUrl + '/Cars/dtos/getallbycolor?colorName=' + colorName;
    return this.httpClient.get<ListResponseModel<Car>>(newPath);
  }

  getCarsByBrand(brandName: string): Observable<ListResponseModel<Car>> {
    let newPath: string =
      this.apiUrl + '/Cars/dtos/getallbybrand?brandName=' + brandName;
    return this.httpClient.get<ListResponseModel<Car>>(newPath);
  }
}
