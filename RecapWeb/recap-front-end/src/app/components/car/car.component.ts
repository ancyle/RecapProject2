import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Brand } from 'src/app/models/brand';
import { Car } from 'src/app/models/car';
import { Color } from 'src/app/models/color';
import { BrandService } from 'src/app/services/brand.service';
import { CarService } from 'src/app/services/car.service';
import { ColorService } from 'src/app/services/color.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.scss'],
})
export class CarComponent implements OnInit {
  cars: Car[] = [];
  colors: Color[] = [];
  brands: Brand[] = [];
  currentBrand: string = '';
  currentColor: string = '';
  filterValue: string = '';

  constructor(
    private carService: CarService,
    private activatedRoute: ActivatedRoute,
    private brandService: BrandService,
    private colorService: ColorService
  ) {}
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.activatedRoute.params.subscribe((params) => {
      if (params['colorName']) {
        this.getCarsByColor(params['colorName']);
      } else if (params['brandName']) {
        this.getCarsByBrand(params['brandName']);
      } else {
        this.getCars();
      }
      this.getColors();
      this.getBrands();
    });
  }

  setCurrentColor(colorName: string) {
    this.currentColor = colorName;
  }
  setCurrentBrand(brandName: string) {
    this.currentBrand = brandName;
  }

  getColors() {
    this.colorService.getColors().subscribe((response) => {
      this.colors = response.data;
    });
  }
  getBrands() {
    this.brandService.getBrands().subscribe((response) => {
      this.brands = response.data;
    });
  }

  getCars() {
    this.carService.getCars().subscribe((response) => {
      this.cars = response.data;
    });
  }

  getCarsByColor(colorName: string) {
    this.carService.getCarsByColor(colorName).subscribe((response) => {
      this.cars = response.data;
    });
  }

  getCarsByBrand(brandName: string) {
    this.carService.getCarsByBrand(brandName).subscribe((response) => {
      this.cars = response.data;
    });
  }
}
