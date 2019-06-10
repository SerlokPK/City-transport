import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { LineService } from 'src/app/pages/services/line.service';
import { Line } from 'src/app/pages/classes/line';
import swal from 'sweetalert2';
import { Station } from 'src/app/pages/classes/station';
import { StationService } from 'src/app/pages/services/station.service';

@Component({
  selector: 'app-lines',
  templateUrl: './lines.component.html',
  styleUrls: ['./lines.component.css']
})
export class LinesComponent implements OnInit {
  rideTypes: string[] = ['Gradski', 'Prigradski'];
  lineList: Line[] = [];
  rideType = 'URBAN';
  dropdownList = []; // Station[] = [];
  selectedItems = []; // Station[] = [];
  dropdownSettings = {};

  addLineForm = this.formBuilder.group({
    StartLocation: ['', [Validators.required, Validators.maxLength(255)]],
    EndLocation: ['', [Validators.required, Validators.maxLength(255)]],
    Number: ['', [Validators.required, Validators.max(1000), Validators.min(1)]],
    LineType: ['', Validators.required],
    SelectedItems: [''],
    WorkLineA: [''],
    WorkLineB: [''],
    SatLineA: [''],
    SatLineB: [''],
    SunLineA: [''],
    SunLineB: [''],
  });

  constructor(private formBuilder: FormBuilder, private lineService: LineService, private stationsService: StationService) { }

  ngOnInit() {
    this.dropdownList = ['prva', 'druga', 'treca'];
    this.dropdownSettings = {
      singleSelection: false,
      // idField: 'item_id',
      // textField: 'item_text',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };
  }

  onItemSelect(item: any) {
    this.selectedItems.push(item);
  }

  onItemDeSelect(item: any) {
    this.selectedItems = this.selectedItems.filter(x => {
      return x !== item;
    });
  }

  onSaveLine() {
    const workdayDepA = this.lineService.filterDepartures(this.addLineForm.value.WorkLineA);
    const workdayDepB = this.lineService.filterDepartures(this.addLineForm.value.WorkLineB);
    const satdayDepA = this.lineService.filterDepartures(this.addLineForm.value.SatLineA);
    const satdayDepB = this.lineService.filterDepartures(this.addLineForm.value.SatLineB);
    const sundayDepA = this.lineService.filterDepartures(this.addLineForm.value.SunLineA);
    const sundayDepB = this.lineService.filterDepartures(this.addLineForm.value.SunLineB);
    const line = {
      StartLocation: this.addLineForm.value.StartLocation,
      EndLocation: this.addLineForm.value.EndLocation,
      LineType: this.lineService.returnValidRideType(this.addLineForm.value.LineType),
      Stations: this.selectedItems,
      Number: this.addLineForm.value.Number,
      Departures: [
        {
          DayType: 'WORKDAY',
          Direction: 'A',
          DepartureTimes: workdayDepA
        },
        {
          DayType: 'WORKDAY',
          Direction: 'B',
          DepartureTimes: workdayDepB
        },
        {
          DayType: 'SUNDAY',
          Direction: 'A',
          DepartureTimes: sundayDepA
        },
        {
          DayType: 'SUNDAY',
          Direction: 'B',
          DepartureTimes: sundayDepB
        },
        {
          DayType: 'SATURDAY',
          Direction: 'A',
          DepartureTimes: satdayDepA
        },
        {
          DayType: 'SATURDAY',
          Direction: 'B',
          DepartureTimes: satdayDepB
        }
      ]
    };
    this.saveLine(line);
  }

  saveLine(line: any) {
    this.lineService.saveLine(line).subscribe(
      data => {
        swal.fire({
          title: 'Linija sacuvana!',
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
        console.log('Error while retrieving all lines from server. Reason: ', err.statusText);
      }
    );
  }
}
