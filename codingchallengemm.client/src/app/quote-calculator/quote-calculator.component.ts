import { ChangeDetectorRef, Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatSliderChange } from '@angular/material/slider';
import { ActivatedRoute, Router } from '@angular/router';



interface Finance {
  customerRequestId: number;
  productType: string;
}

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

  constructor(private activatedRoute: ActivatedRoute, private http: HttpClient, private cdr: ChangeDetectorRef,
    private router: Router
  ) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(params => {
      this.userId = params.get('id');
      console.log(params);
      if (this.userId) {
        this.fetchUserData(this.userId);
      }
    });
  }

  fetchUserData(userId: string) {

    const apiUrl = `https://localhost:7188/api/CustomerRequests/` + userId;
    this.http.get(apiUrl).subscribe({
      next: (data) => {
        console.log('data', data);
        this.userData = data;
        console.log(this.userData);
        this.cdr.detectChanges(); //
      },
      error: (error) => console.error('Error:', error)
    });
  }

  submitRequestForm() {
    const apiUrl = 'https://localhost:7188/api/Finances';
    // Prepare the POST request payload based on the required JSON structure
    var postData: Finance = {
      customerRequestId: this.userData.id,  // Assuming this is controlled by a form field
      productType: 'ProductB'  // Assuming selectedProduct holds the product type
    };

    console.log('post-data', postData);
    this.http.post<any>(apiUrl, postData).subscribe({
      next: response => {
        console.log('Finance record created:', response);
        // Navigate to success page or display success message
        // Assuming the domain is always the same, extract the path from the URL
        const path = new URL(response.url).pathname;
        console.log('path', path);
        // Use the extracted path for navigation
        this.router.navigateByUrl(path).then(success => {
          if (!success) {
            console.error('Failed to navigate.');
          }
        });
      },
      error: error => {
        console.error('Failed to create finance record:', error);
        // Handle error, display error message to the user
      }
    });
    
  }

}
