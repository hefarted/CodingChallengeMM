import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { QuoteSummaryComponent } from './quote-summary.component';

const routes: Routes = [
  {
    path: 'quote-summary', component: QuoteSummaryComponent,
    children: [
      { path: '', component: QuoteSummaryComponent }, // Default path
      { path: ':id', component: QuoteSummaryComponent } // Path with dynamic segment for ID
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class QuoteSummaryRoutingModule { }

