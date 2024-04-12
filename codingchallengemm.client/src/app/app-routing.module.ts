import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [

  {
    path: 'quote-request',
    loadChildren: () => import('./quote-request/quote-request.module').then(m => m.QuoteRequestModule)
  },
  {
    path: 'quote-calculator',
    loadChildren: () => import('./quote-calculator/quote-calculator.module').then(m => m.QuoteCalculatorModule)
  },
  {
    path: '',
    redirectTo: '',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
