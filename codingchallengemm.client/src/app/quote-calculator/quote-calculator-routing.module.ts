import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { QuoteCalculatorComponent } from './quote-calculator.component';

const routes: Routes = [
  { path: 'quote-calculator', component: QuoteCalculatorComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class QuoteCalculatorRoutingModule { }

