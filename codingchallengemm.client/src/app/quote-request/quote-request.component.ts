import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

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


  constructor(private http: HttpClient, private router: Router) { }

  submitRequestForm() {
    const apiUrl = 'https://localhost:7188/api/CustomerRequests';

    this.http.post<any>(apiUrl, this.request).subscribe({
      next: (response) => {
        console.log('Success:', response);

        // Assuming the domain is always the same, extract the path from the URL
        const path = new URL(response.url).pathname;

        // Use the extracted path for navigation
        this.router.navigateByUrl(path).then(success => {
          if (!success) {
            console.error('Failed to navigate.');
          }
        });
      },
      error: (error) => {
        console.error('Error:', error);
      }
    });
  }

}
