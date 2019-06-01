import { Component, OnInit } from '@angular/core';

import { LineService } from '../services/line.service';
import { Line } from '../classes/line';

@Component({
  selector: 'app-rides',
  templateUrl: './rides.component.html',
  styleUrls: ['./rides.component.css']
})
export class RidesComponent implements OnInit {
  lineList: Line[];
  selectedLine: Line;
  showTime = false;

  params = { LineType: 'URBAN' };

  constructor(private lineService: LineService) { }

  ngOnInit() {
    this.lineService.getAllLines(this.params.LineType).subscribe(
      data => {
        this.lineList = data.lineList;
      },
      err => {
        console.log('Error while retrieving all lines from server. Reason: ', err.statusText);
      }
    );
  }

  selectLine(event) {
    this.selectedLine = this.lineService.getLine(parseInt(event.target.value, 10));
  }

  showDepartureTime() {
    this.showTime = true;
  }
}
