import { Injectable } from '@angular/core';
import { CarImage } from '../models/carImage';
import { ListResponseModel } from '../models/listResponseModel';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class CarImageService {
  private apiUrl: string = 'https://localhost:7215/api';
  private apiRoot: string = 'https://localhost:7215/';
  constructor(private httpClient: HttpClient) {}

  getCarDetails(carId: number): Observable<ListResponseModel<CarImage>> {
    let newPath: string = this.apiUrl + '/CarImages/getallbycar?carId=' + carId;
    return this.httpClient.get<ListResponseModel<CarImage>>(newPath);
  }
  getImagePath(imagePath: string): string {
    let newPath: string = this.apiRoot + imagePath;
    return newPath;
  }
}
