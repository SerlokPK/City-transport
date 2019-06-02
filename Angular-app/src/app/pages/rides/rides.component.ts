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
    this.getAllLines(this.rideType);
  }

  getAllLines(rideType: string) {
    this.lineService.getAllLines(rideType).subscribe(
      data => {
        this.lineList = data.map(x => new Line(x));
      },
      err => {
        console.log('Error while retrieving all lines from server. Reason: ', err.statusText);
      }
    );
  }

  selectRide(event) {
    this.rideType = this.returnValidRideType(event.target.value);
    this.getAllLines(this.rideType);
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

  selectDay(event) {
    this.dayType = this.returnValidDayType(event.target.value);
  }

  convertLineName(lineName: string) {
    const newName = lineName.split('-');
    return `${newName[1]}-${newName[0]}`;
  }

  returnValidDayType(type: string) {
    if (type === 'Radni dan') {
      return 'WORKDAY';
    } else if (type === 'Subota') {
      return 'SATURDAY';
    } else {
      return 'SUNDAY';
    }
  }

  returnValidRideType(type: string) {
    if (type === 'Gradski') {
      return 'URBAN';
    } else {
      return 'SUBURBAN';
    }
  }
}
