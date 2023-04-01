import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ListResponseModel } from '../models/listResponseModel';
import { Color } from '../models/color';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ColorService {
  private apiUrl: string = 'https://localhost:7215/api';

  constructor(private httpCliet: HttpClient) {}

  getColors(): Observable<ListResponseModel<Color>> {
    let newPath: string = this.apiUrl + '/Colors/getall';
    return this.httpCliet.get<ListResponseModel<Color>>(newPath);
  }
}
