import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Brand } from '../models/brand';
import { ListResponseModel } from '../models/listResponseModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BrandService {
  private apiUrl: string = 'https://localhost:7215/api';

  constructor(private httpCliet: HttpClient) {}

  getBrands(): Observable<ListResponseModel<Brand>> {
    let newPath: string = this.apiUrl + '/Brands/getall';
    return this.httpCliet.get<ListResponseModel<Brand>>(newPath);
  }
}
