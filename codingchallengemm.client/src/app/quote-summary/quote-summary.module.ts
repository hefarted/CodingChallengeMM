import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MaterialModule } from '../material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { QuoteSummaryRoutingModule } from './quote-summary-routing.module';
import { QuoteSummaryComponent } from './quote-summary.component';
import { AppRoutingModule } from '../app-routing.module';


@NgModule({
  declarations: [
    QuoteSummaryComponent
  ],
  imports: [
    CommonModule,
    QuoteSummaryRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class QuoteSummaryModule { }
