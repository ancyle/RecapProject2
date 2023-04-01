import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarComponent } from './components/car/car.component';
import { CarDetailsComponent } from './components/car-details/car-details.component';
import { RentCarComponent } from './components/rent-car/rent-car.component';
import { ErrorComponent } from './components/error/error.component';
import { PaymentComponent } from './components/payment/payment.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: CarComponent },
  { path: 'cars', component: CarComponent },
  { path: 'cars/colors/:colorName', component: CarComponent },
  { path: 'cars/brands/:brandName', component: CarComponent },
  { path: 'cars/details/:carId', component: CarDetailsComponent },
  { path: 'cars/rent/:carId/user/:userId', component: RentCarComponent },
  {
    path: 'cars/rent/:carId/user/:userId/payment',
    component: PaymentComponent,
  },
  { path: '**', component: ErrorComponent, redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
