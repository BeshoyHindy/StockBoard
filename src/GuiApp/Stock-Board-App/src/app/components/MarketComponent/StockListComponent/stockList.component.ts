import { Stock } from '../../../shared/models/Stock.Model';
import { StockBoardService } from '../../../shared/services/StockBoard.Service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { SignalRService } from '../../../shared/services/signal-r.service';



@Component({
    selector: 'app-stock-list',
    templateUrl: './stockList.component.html',
    styleUrls: ['./stockList.component.css']
})
export class StockListComponent implements OnInit {

    public searchText: string;
    stocks: Stock[];

    constructor(
        private stockBoardService: StockBoardService,
        private signalRService: SignalRService
    ) {

    }

    ngOnInit() {
        this.getStocks();

        this.subscribeToEvents();
        this.signalRService.connectionEstablished.subscribe(() => {
            // pot soem logic here 
        });

    }


    private getStocks(): void {
        this.stockBoardService
            .getAllStocks()
            .subscribe((res: any) => {
                //
                console.log(res);
                this.stocks = res.data;
                console.log(this.stocks);
            },
                err => {

                    console.log(err);
                });

    }



    private subscribeToEvents(): void {
        this.signalRService.stockReceived.subscribe((data: Stock) => {

            console.log(data);
            this.updateStocks(data);
        });
    }

    private updateStocks(stockData: Stock): void {
        console.log(stockData);
        let stockIndex = this.stocks.findIndex(s => s.id == stockData.id);
        if (this.stocks[stockIndex] != null) {
            this.stocks[stockIndex].price = stockData.price
        }

        console.log(this.stocks[stockIndex]);

    }
}
