import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CarDetailDto } from '../models/carDetailDto';
import { SingleResponseModel } from '../models/singleResponseModel';

@Injectable({
  providedIn: 'root',
})
export class CarDetailsService {
  private apiUrl: string = 'https://localhost:7215/api';
  constructor(private httpClient: HttpClient) {}

  getCarDetails(carId: number): Observable<SingleResponseModel<CarDetailDto>> {
    let newPath: string = this.apiUrl + '/Cars/dtos/getbyid?carId=' + carId;
    return this.httpClient.get<SingleResponseModel<CarDetailDto>>(newPath);
  }
}
