import { Component, OnInit } from '@angular/core';
import { Price } from '../classes/price';
import { PriceService } from '../services/price.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-price-list',
  templateUrl: './price-list.component.html',
  styleUrls: ['./price-list.component.css']
})
export class PriceListComponent implements OnInit {
  cardTypes: string[] = ['Vremenska', 'Dnevna', 'Mesecna', 'Godisnja'];
  passengerTypes: string[] = ['Djacka', 'Penzionerksa', 'Regularna'];
  selectedCard = 'Vremenska';
  selectedPassenger = 'Djacka';
  price = new Price({ Id: 1, Cost: 0, PassengerType: '', TicketType: '' });
  pdv = 10;

  constructor(private priceService: PriceService) { }

  ngOnInit() {
    const types = this.setTypes();
    this.getPrices(types);
  }

  selectCard(event) {
    this.selectedCard = event.target.value;
    const types = this.setTypes();
    this.getPrices(types);
  }

  selectPassenger(event) {
    this.selectedPassenger = event.target.value;
    const types = this.setTypes();
    this.getPrices(types);
  }

  setTypes() {
    return {
      passengerType: this.priceService.returnValidPassengerType(this.selectedPassenger),
      ticketType: this.priceService.returnValidCardType(this.selectedCard)
    };
  }

  getPrices(types: any) {
    this.priceService.getPrices(types).subscribe(
      data => {
        this.price = new Price(data);
      },
      err => {
        swal.fire({
          title: 'Greska!',
          text: `${err.message}`,
          type: 'error',
          confirmButtonText: 'Ok'
        });
        console.log('Error while retrieving all lines from server. Reason: ', err.statusText);
      }
    );
  }

  calculateFinalSum(cost: number, pdv: number) {
    return cost + (cost * pdv) / 100;
  }
}
