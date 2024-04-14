import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-quote-summary',
  templateUrl: './quote-summary.component.html',
  styleUrl: './quote-summary.component.css'
})
export class QuoteSummaryComponent {

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


  finance : any = {
    customerRequestId: 0,  // Assuming this is controlled by a form field
    productType: 'ProductB',
    id: 0,
    repaymentAmount: 0,
    RepaymentFrequency : 0
    // Assuming selectedProduct holds the product type
  };

  userId: string | null = null;
  constructor(private activatedRoute: ActivatedRoute, private http: HttpClient, private cdr: ChangeDetectorRef,
    private router: Router) { }

  ngOnInit() {
    console.log('test');
    this.activatedRoute.paramMap.subscribe(params => {
      this.finance.id = params.get('financeId');

      if (this.finance.id != null) {
        this.fetchFinanceData(this.finance.id);
      }

      
  
    });
  }

  fetchUserData(userId: string) {

    const apiUrl = `https://localhost:7188/api/CustomerRequests/` + userId;
    this.http.get(apiUrl).subscribe({
      next: (data) => {
        console.log('user data', data);
        this.userData = data;
        console.log(this.userData);
        this.cdr.detectChanges(); //
      },
      error: (error) => console.error('Error:', error)
    });
  }

  fetchFinanceData(financeId: string) {

    const apiUrl = `https://localhost:7188/api/Finances/` + financeId;
    this.http.get(apiUrl).subscribe({
      next: (data) => {
        console.log('finance data', data);
        this.finance = data;
        console.log(this.finance);
        this.fetchUserData(this.finance.customerRequestId);
        this.cdr.detectChanges(); //
      },
      error: (error) => console.error('Error:', error)
    });
  }
}
