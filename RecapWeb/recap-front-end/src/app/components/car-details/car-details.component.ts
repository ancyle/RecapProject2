import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CarDetailDto } from 'src/app/models/carDetailDto';
import { CarImage } from 'src/app/models/carImage';
import { CarDetailsService } from 'src/app/services/car.details.service';
import { CarImageService } from 'src/app/services/car.image.service';

@Component({
  selector: 'app-car-details',
  templateUrl: './car-details.component.html',
  styleUrls: ['./car-details.component.scss'],
})
export class CarDetailsComponent implements OnInit {
  carDetailDto: CarDetailDto = {
    carId: 0,
    brandName: '',
    colorName: '',
    modelYear: 0,
    dailyPrice: 0,
    description: '',
  };
  carImages: CarImage[] = [];

  constructor(
    private carDetailsService: CarDetailsService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private carImageService: CarImageService
  ) {}
  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      if (params['']) {
        this.router.navigateByUrl('');
      } else {
        this.getCarDetailDto(params['carId']);
        this.getCarImages(params['carId']);
      }
    });
  }

  getCarDetailDto(carId: number) {
    this.carDetailsService.getCarDetails(carId).subscribe((response) => {
      this.carDetailDto = response.data;
    });
  }
  getCarImages(carId: number) {
    this.carImageService.getCarDetails(carId).subscribe((response) => {
      this.carImages = response.data;
    });
  }

  getImagePath(imagePath: string): string {
    return this.carImageService.getImagePath(imagePath);
  }
}
