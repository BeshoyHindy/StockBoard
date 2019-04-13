
import { Stock } from '../models/Stock.Model';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class StockBoardService {

    stockList: Stock[];


  readonly baseApiURL = 'https://localhost:44342/api/v1';

  readonly stocksUrl = this.baseApiURL + "/Stock";

  constructor(private http: HttpClient) { }

  getAllStocks() {
    return this.http.get<any>(this.stocksUrl);

  }



}
