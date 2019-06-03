import { Component, OnInit } from '@angular/core';

import { LineService } from '../services/line.service';
import { Line } from '../classes/line';

@Component({
  selector: 'app-rides',
  templateUrl: './rides.component.html',
  styleUrls: ['./rides.component.css']
})
export class RidesComponent implements OnInit {
  lineList: Line[] = [];
  selectedLine: Line;
  showTime = false;
  directionA: string[] = [];
  directionB: string[] = [];
  rideTypes: string[] = ['Gradski', 'Prigradski'];
  dayTypes: string[] = ['Radni dan', 'Subota', 'Nedelja'];
  dayType = 'WORKDAY';
  rideType = 'URBAN';

  constructor(private lineService: LineService) { }

  ngOnInit() {
    this.getAllLinesByRideType(this.rideType);
  }

  getAllLinesByRideType(rideType: string) {
    this.lineService.getAllLinesByRideType(rideType).subscribe(
      data => {
        this.lineList = data.map(x => new Line(x));
      },
      err => {
        console.log('Error while retrieving all lines from server. Reason: ', err.statusText);
      }
    );
  }

  selectRide(event) {
    this.rideType = this.lineService.returnValidRideType(event.target.value);
    this.getAllLinesByRideType(this.rideType);
  }

  selectLine(event) {
    this.selectedLine = this.lineService.getLine(parseInt(event.target.value, 10), this.lineList);
  }

  showDepartureTime() {
    this.lineService.getSchedules(this.selectedLine.Number.toString(), this.dayType).subscribe(
      data => {
        this.directionA = data.DirectionA.map(x => x.DeparturesAt);
        this.directionB = data.DirectionB.map(x => x.DeparturesAt);
      },
      err => {
        console.log('Error while retrieving schedules from server. Reason: ', err.statusText);
      }
    );
    this.showTime = true;
  }

  convertLineName(lineName: string) {
    const newName = lineName.split('-');
    return `${newName[1]}-${newName[0]}`;
  }

  selectDay(event) {
    this.dayType = this.lineService.returnValidDayType(event.target.value);
  }
}
