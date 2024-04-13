import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { QuoteSummaryComponent } from './quote-summary.component';

const routes: Routes = [
  { path: 'quote-summary/123123', component: QuoteSummaryComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class QuoteSummaryRoutingModule { }

