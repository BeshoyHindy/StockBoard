
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { MarketComponent } from './components/MarketComponent/market.component';
import { StockListComponent } from './components/MarketComponent/StockListComponent/stockList.component';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { StockBoardService } from './shared/services/StockBoard.Service';
import { SignalRService } from './shared/services/signal-r.service';


@NgModule({
  declarations: [
    AppComponent,
    MarketComponent,
    StockListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    //AppRoutingModule,  
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [
    StockBoardService,
    SignalRService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }