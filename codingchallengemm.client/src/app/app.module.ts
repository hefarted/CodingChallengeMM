import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { QuoteCalculatorComponent } from './quote-calculator/quote-calculator.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MatCardModule } from '@angular/material/card';
import { MaterialModule } from './material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { QuoteRequestModule } from './quote-request/quote-request.module';
import { QuoteCalculatorModule } from './quote-calculator/quote-calculator.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    QuoteRequestModule,
    QuoteCalculatorModule,
    BrowserModule, HttpClientModule,
    AppRoutingModule, 
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
