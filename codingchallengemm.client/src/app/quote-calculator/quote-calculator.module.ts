import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuoteCalculatorComponent } from './quote-calculator.component';
import { QuoteCalculatorRoutingModule } from './quote-calculator-routing.module';
import { MaterialModule } from '../material.module';
import { AppRoutingModule } from '../app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    QuoteCalculatorComponent
  ],
  imports: [
    CommonModule,
    QuoteCalculatorRoutingModule,
    MaterialModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule
  ]
})
export class QuoteCalculatorModule { }
