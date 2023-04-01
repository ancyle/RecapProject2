import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ListResponseModel } from '../models/listResponseModel';
import { Rental } from '../models/rental';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RentalService {
  private apiUrl: string = 'https://localhost:7215/api';
  constructor(private httpClient: HttpClient) {}

  getRentals(): Observable<ListResponseModel<Rental>> {
    let newPath: string = this.apiUrl + '/Rentals/dtos/getall';
    return this.httpClient.get<ListResponseModel<Rental>>(newPath);
  }

  addRental(rental: Rental) {
    let newPath: string = this.apiUrl + '/Rentals/add';
    this.httpClient.post(newPath, rental);
  }
}
