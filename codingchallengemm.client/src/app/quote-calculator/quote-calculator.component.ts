import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatSliderChange } from '@angular/material/slider';

@Component({
  selector: 'app-quote-calculator',
  templateUrl: './quote-calculator.component.html',
  styleUrls: ['./quote-calculator.component.css']
})
export class QuoteCalculatorComponent {

  selectedProduct: string = 'ProductA';

  selectedvalue = 0;
  min = 2000;           // Minimum value for the slider
  max = 20000;          // Maximum value for the slider
  step = 100;

  termSliderMinVal = 1;
  termSliderMaxValue = 36;
  termSliderStepValue = 1;
  termvalue = 0;

  selectedTitle: string = 'Mr';
  firstName: string = '';
  lastName: string = '';
  email: string = '';
  mobileNumber: string = '';
}
