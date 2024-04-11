import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { QuoteRequestComponent } from './quote-request.component'; // Adjust the path as necessary

const routes: Routes = [
  { path: 'quote-request', component: QuoteRequestComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class QuoteRequestRoutingModule { }

