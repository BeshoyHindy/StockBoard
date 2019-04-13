
import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { Subject } from 'rxjs';
import { Stock } from '../models/Stock.Model';

const WAIT_UNTIL_ASPNETCORE_IS_READY_DELAY_IN_MS = 2000;

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  stockReceived = new Subject<Stock>();
  connectionEstablished = new Subject<Boolean>();

  //public vehicleStatusData: VehicleStatus[];

  private hubConnection: HubConnection

  constructor() {
    this.createConnection();
    this.registerOnServerEvents();
    this.startConnection();
  }


  private createConnection() {
    this.hubConnection = new HubConnectionBuilder()
      //.withUrl('https://localhost:44342/stockHub')
      .withUrl('http://localhost:6461/stockHub')// for http

      
      .build();
  }

  private startConnection() {
    setTimeout(() => {
      this.hubConnection
        .start()
        .then(() => {
          console.log('Hub connection started');
          this.connectionEstablished.next(true);
        })
        .catch(err => console.log('Error while starting connection: ' + err));
    }, WAIT_UNTIL_ASPNETCORE_IS_READY_DELAY_IN_MS);
  }



  public registerOnServerEvents = () => {
    this.hubConnection.on('stockUpdated', (data: any) => {
      console.log(data);
      this.stockReceived.next(data);
      console.log(this.stockReceived);
    });
  }

}
