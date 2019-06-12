import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import swal from 'sweetalert2';
import { Price } from 'src/app/pages/classes/price';
import { PriceService } from 'src/app/pages/services/price.service';

@Component({
  selector: 'app-prices',
  templateUrl: './prices.component.html',
  styleUrls: ['./prices.component.css']
})
export class PricesComponent implements OnInit {
  priceList: Price[] = [];

  addPriceForm = this.formBuilder.group({
    PassengerType: ['', [Validators.required, Validators.maxLength(255)]],
    TicketType: ['', [Validators.required, Validators.maxLength(255)]],
    Cost: ['', [Validators.required, Validators.max(1000000), Validators.min(1)]]
  });

  updatePriceForm = this.formBuilder.group({
    PassengerType: ['', [Validators.required, Validators.maxLength(255)]],
    TicketType: ['', [Validators.required, Validators.maxLength(255)]],
    Cost: ['', [Validators.required, Validators.max(1000000), Validators.min(1)]]
  });

  constructor(private formBuilder: FormBuilder, private priceService: PriceService) { }

  ngOnInit() {
    this.getAllPrices();
  }

  getAllPrices() {
    // this.priceService.getPrices().subscribe(
    //   data => {
    //     this.lineList = data.map(x => new Line(x));
    //     this.dropdownList = this.lineList.map(x => new Line(x));
    //   },
    //   err => {
    //     swal.fire({
    //       title: 'Greska!',
    //       text: `${err.message}`,
    //       type: 'error',
    //       confirmButtonText: 'Ok'
    //     });
    //     console.log('Error while retrieving all lines from server. Reason: ', err.statusText);
    //   }
    // );
  }

  onSavePrice() {
    const price = {
      Id: 0,
      // tslint:disable-next-line: max-line-length
      PassengerType: this.addPriceForm.value.PassengerType, // this.priceService.returnValidPassengerType(this.addPriceForm.value.PassengerType),
      TicketType: this.addPriceForm.value.TicketType, // this.priceService.returnValidCardType(this.addPriceForm.value.TicketType),
      Cost: this.addPriceForm.value.Cost
    };
    this.savePrice(price);
  }

  savePrice(price: any) {
    this.priceService.savePrice(price).subscribe(
      data => {
        price.Id = data;
        this.addPriceForm.reset();
        this.priceList.push(price);
        swal.fire({
          title: 'Cena sacuvana!',
          type: 'success',
          confirmButtonText: 'Ok'
        });
      },
      err => {
        swal.fire({
          title: 'Greska!',
          text: `${err.message}`,
          type: 'error',
          confirmButtonText: 'Ok'
        });
        console.log('Error while saving price on server. Reason: ', err.statusText);
      }
    );
  }

  onUpdatePrice() {
    const passenger = this.priceService.returnValidPassengerType(this.addPriceForm.value.PassengerType);
    const ticket = this.priceService.returnValidCardType(this.addPriceForm.value.TicketType);
    const price = {
      Id: this.priceService.getIdByTypes({ PassengerType: passenger, TicketType: ticket }, this.priceList),
      // tslint:disable-next-line: max-line-length
      PassengerType: passenger,
      TicketType: ticket,
      Cost: this.addPriceForm.value.Cost
    };
    this.updatePrice(price);
  }

  updatePrice(price: any) {

  }
}
