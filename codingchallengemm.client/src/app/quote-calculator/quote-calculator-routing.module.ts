import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { QuoteCalculatorComponent } from './quote-calculator.component';

const routes: Routes = [
  {
    path: 'quote-calculator', // Parent path, since `quote-calculator` is defined in the app-routing.module
    children: [
      { path: '', component: QuoteCalculatorComponent }, // Default path
      { path: ':id', component: QuoteCalculatorComponent } // Path with dynamic segment for ID
    ]
  }
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class QuoteCalculatorRoutingModule { }

