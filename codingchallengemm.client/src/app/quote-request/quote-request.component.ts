import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

interface CustomerRequest {
  title: string;
  firstName: string;
  lastName: string;
  dateOfBirth: Date; // or string if you're handling the date as a string
  mobile: string;
  email: string;
  amountRequired: number;
  term: number;
}
@Component({
  selector: 'app-quote-request',
  templateUrl: './quote-request.component.html',
  styleUrl: './quote-request.component.css'
})
export class QuoteRequestComponent {
  request: CustomerRequest = {
    title: '',
    firstName: '',
    lastName: '',
    dateOfBirth: new Date(), // Initialize with a default value or null/undefined
    mobile: '',
    email: '',
    amountRequired: 0,
    term: 0
  };

  constructor(private http: HttpClient) { }

  submitRequestForm() {
    // The URL of your back-end API
    const apiUrl = 'https://yourapi.com/api/CustomerRequests';

    // POST the data to your API
    this.http.post(apiUrl, this.request).subscribe({
      next: (response) => {
        // Handle the successful response here
        console.log('Success:', response);
      },
      error: (error) => {
        // Handle errors here, such as displaying an error message
        console.error('Error:', error);
      }
    });
  }
}
