import { Component, OnInit, ViewChild } from '@angular/core';
import { Line } from '../classes/line';
import { LineService } from '../services/line.service';
import { Vehicle } from '../classes/vehicle';
import { VehicleService } from '../services/vehicle.service';

@Component({
  selector: 'app-ride-locations',
  templateUrl: './ride-locations.component.html',
  styleUrls: ['./ride-locations.component.css']
})
export class RideLocationsComponent implements OnInit {
  lineList: Line[] = [];
  markerList: google.maps.Marker[] = [];

  @ViewChild('gmap') gmapElement: any;
  map: google.maps.Map;

  constructor(private lineService: LineService, private vehicleService: VehicleService) { }

  ngOnInit() {
    this.gmapInit();
    this.getAllLines();
  }

  getAllLines() {
    this.lineService.getAllLines().subscribe(
      data => {
        this.lineList = data.map(x => new Line(x));
      },
      err => {
        console.log('Error while retrieving all lines from server. Reason: ', err.statusText);
      }
    );
  }

  showVehicles(event) {
    this.setMapOnAll(null);
    this.vehicleService.getVehiclesByLineNumber(event.target.value).subscribe(
      data => {
        data.map(x => this.placeMarker(new Vehicle(x)));
      },
      err => {
        console.log('Error while retrieving all lines from server. Reason: ', err.statusText);
      }
    );
  }

  placeMarker(vehicle: Vehicle) {
    const location = new google.maps.LatLng(vehicle.X, vehicle.Y);
    const iconImage = {
      url: '../../../assets/Images/bus-station.svg',
      scaledSize: new google.maps.Size(20, 20),
    };
    const marker = new google.maps.Marker({
      position: location,
      map: this.map,
      icon: iconImage,
    });
    this.markerList.push(marker);
    marker.addListener('click', () => {
      this.markerHandler(vehicle);
    });
  }

  setMapOnAll(map) {
    this.markerList.map(x => x.setMap(map));
  }

  markerHandler(vehicle: Vehicle) {
    alert('Marker\'s Title: ');
  }

  gmapInit() {
    const mapProp = {
      center: new google.maps.LatLng(45.2700573, 19.837304),
      zoom: 13,
      mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    this.map = new google.maps.Map(this.gmapElement.nativeElement, mapProp);
  }
}
