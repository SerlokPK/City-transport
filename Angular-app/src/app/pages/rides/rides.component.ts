import { Component, OnInit } from '@angular/core';

import { LineService } from '../services/line.service';
import { Line } from '../classes/line';
import { Schedule } from '../classes/schedule';

@Component({
  selector: 'app-rides',
  templateUrl: './rides.component.html',
  styleUrls: ['./rides.component.css']
})
export class RidesComponent implements OnInit {
  lineList: Line[] = [];
  selectedLine: Line;
  showTime = false;
  DirectionA: string[] = [];
  DirectionB: string[] = [];

  initialParams = {
    lineType: 'URBAN'
  };

  constructor(private lineService: LineService) { }

  ngOnInit() {
    this.lineService.getAllLines(this.initialParams).subscribe(
      data => {
        this.lineList = data.map(x => new Line(x));
      },
      err => {
        console.log('Error while retrieving all lines from server. Reason: ', err.statusText);
      }
    );
  }

  selectLine(event) {
    this.selectedLine = this.lineService.getLine(parseInt(event.target.value, 10), this.lineList);
  }

  showDepartureTime() {
    this.lineService.getSchedules(this.selectedLine.Number.toString(), 'WORKDAY').subscribe(
      data => {
        this.DirectionA = data.DirectionA.map(x => x.DeparturesAt);
        this.DirectionB = data.DirectionB.map(x => x.DeparturesAt);
      },
      err => {
        console.log('Error while retrieving schedules from server. Reason: ', err.statusText);
      }
    );
    this.showTime = true;
  }
}
