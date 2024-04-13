import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-quote-summary',
  templateUrl: './quote-summary.component.html',
  styleUrl: './quote-summary.component.css'
})
export class QuoteSummaryComponent {
 
  constructor(private http: HttpClient, private router: Router) { }
}
