import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatSliderChange } from '@angular/material/slider';
import { ActivatedRoute } from '@angular/router';

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


    userId: string | null = null;
 
  userData: any = {
    id: null,
    amountRequired: 5000, // Default values or null if you prefer
    term: 1,
    title: 'Mr',
    firstName: '',
    lastName: '',
    dateOfBirth: '',
    mobile: '',
    email: '',
    financeDetails: null
  };

  constructor(private activatedRoute: ActivatedRoute, private http: HttpClient) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(params => {
      this.userId = params.get('id');
      if (this.userId) {
        this.fetchUserData(this.userId);
      }
    });
  }

  fetchUserData(userId: string) {
   
    const apiUrl = `https://localhost:7188/api/CustomerRequests/25`;
    this.http.get(apiUrl).subscribe({
      next: (data) => {
        this.userData = data;
        console.log(data);
      },
      error: (error) => console.error('Error:', error)
    });
  }
}
