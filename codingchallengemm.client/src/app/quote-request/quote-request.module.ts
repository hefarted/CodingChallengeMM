import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuoteRequestComponent } from './quote-request.component';
import { QuoteRequestRoutingModule } from './quote-request-routing.module';
import { MaterialModule } from '../material.module';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from '../app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    QuoteRequestComponent
  ],
  imports: [
    CommonModule,
    QuoteRequestRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
  ]
})
export class QuoteRequestModule { }
