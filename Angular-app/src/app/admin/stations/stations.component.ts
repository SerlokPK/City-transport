import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import swal from 'sweetalert2';
import { Station } from 'src/app/pages/classes/station';
import { StationService } from 'src/app/pages/services/station.service';
import { LineService } from 'src/app/pages/services/line.service';
import { Line } from 'src/app/pages/classes/line';

@Component({
  selector: 'app-stations',
  templateUrl: './stations.component.html',
  styleUrls: ['./stations.component.css']
})
export class StationsComponent implements OnInit {
  dropdownList = [];
  selectedItems = [];
  dropdownSettings = {};
  stationList: Station[] = [];
  lineList: Line[] = [];
  showEditor = false;
  selectedStation: Station;

  addStationForm = this.formBuilder.group({
    Name: ['', [Validators.required, Validators.maxLength(255)]],
    Address: ['', [Validators.required, Validators.maxLength(255)]],
    X: ['', [Validators.required, Validators.max(85), Validators.min(-85)]],
    Y: ['', [Validators.required, Validators.max(180), Validators.min(-180)]],
    Lines: ['', Validators.required],
  });

  updateStationForm = this.formBuilder.group({
    Name: ['', [Validators.required, Validators.maxLength(255)]],
    Address: ['', [Validators.required, Validators.maxLength(255)]],
    X: ['', [Validators.required, Validators.max(85), Validators.min(-85)]],
    Y: ['', [Validators.required, Validators.max(180), Validators.min(-180)]],
  });

  constructor(private formBuilder: FormBuilder, private stationService: StationService, private lineService: LineService) { }

  ngOnInit() {
    this.getAllLines();
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'Id',
      textField: 'Name',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };
    this.getAllStations();
  }

  get updateForm() { return this.updateStationForm; }

  getAllLines() {
    this.lineService.getAllLines().subscribe(
      data => {
        this.lineList = data.map(x => new Line(x));
        this.dropdownList = this.lineList.map(x => new Line(x));
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

  getAllStations() {
    this.stationService.getAllStations().subscribe(
      data => {
        this.stationList = data.map(x => new Station(x));
      },
      err => {
        swal.fire({
          title: 'Greska!',
          text: `${err.message}`,
          type: 'error',
          confirmButtonText: 'Ok'
        });
        console.log('Error while retrieving all stations from server. Reason: ', err.statusText);
      }
    );
  }

  onSaveStation() {
    const lineId = this.selectedItems.map(x => x.Id);
    const station = {
      Id: 0,
      Name: this.addStationForm.value.Name,
      Address: this.addStationForm.value.Address,
      X: this.addStationForm.value.X,
      Y: this.addStationForm.value.Y,
      LineIds: lineId
    };
    this.saveStation(station);
  }

  saveStation(station: any) {
    this.stationService.saveStation(station).subscribe(
      data => {
        station.Id = data;
        this.addStationForm.reset();
        this.stationList.push(station);
        swal.fire({
          title: 'Stanica sacuvana!',
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
        console.log('Error while retrieving all stations from server. Reason: ', err.statusText);
      }
    );
  }

  onUpdateStation() {
    const station = {
      Id: this.selectedStation.Id,
      Name: this.updateStationForm.value.Name,
      Address: this.updateStationForm.value.Address,
      X: this.updateStationForm.value.X,
      Y: this.updateStationForm.value.Y,
    };
    this.selectedStation.Name = this.updateStationForm.value.Name;
    this.selectedStation.Address = this.updateStationForm.value.Address;
    this.selectedStation.X = this.updateStationForm.value.X;
    this.selectedStation.Y = this.updateStationForm.value.Y;
    this.updateStation(station);
  }

  updateStation(station: any) {
    this.stationService.updateStation(station).subscribe(
      data => {
        swal.fire({
          title: 'Stanica izmenjena!',
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
        console.log('Error while updating station on server. Reason: ', err.statusText);
      }
    );
  }

  onSelectStation(event) {
    const id = event.target.value;
    if (id === '-1') {
      this.showEditor = false;
      return;
    }
    this.selectedStation = this.stationService.getStationById(parseInt(id, 10), this.stationList);
    this.updateForm.setValue({
      Name: this.selectedStation.Name, Address: this.selectedStation.Address,
      X: this.selectedStation.X, Y: this.selectedStation.Y
    });
    this.showEditor = true;
  }

  onItemSelect(item) {
    this.selectedItems.push(item);
  }

  onItemDeSelect(item) {
    this.selectedItems = this.selectedItems.filter(x => {
      return x !== item;
    });
  }
}
