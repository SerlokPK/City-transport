/// <reference types="@types/googlemaps" />
import { Component, OnInit, ViewChild } from '@angular/core';
import { LineService } from '../services/line.service';
import { Line } from '../classes/line';
import { Station } from '../classes/station';
import { StationService } from '../services/station.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-line-map',
  templateUrl: './line-map.component.html',
  styleUrls: ['./line-map.component.css']
})
export class LineMapComponent implements OnInit {
  lineList: Line[] = [];
  markerList: google.maps.Marker[] = [];

  @ViewChild('gmap') gmapElement: any;
  map: google.maps.Map;

  constructor(private lineService: LineService, private stationService: StationService) { }

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

  showStations(event) {
    this.setMapOnAll(null);
    this.stationService.getStationsByLineNumber(event.target.value).subscribe(
      data => {
        data.map(x => this.placeMarker(new Station(x)));
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

  placeMarker(station: Station) {
    const location = new google.maps.LatLng(station.X, station.Y);
    const iconImage = {
      url: '../../../assets/Images/campground.svg',
      scaledSize: new google.maps.Size(20, 20),
    };
    const marker = new google.maps.Marker({
      position: location,
      map: this.map,
      icon: iconImage,
      title: station.Address,
    });
    this.markerList.push(marker);
    marker.addListener('click', () => {
      this.markerHandler(station);
    });
  }

  setMapOnAll(map) {
    this.markerList.map(x => x.setMap(map));
  }

  markerHandler(station: Station) {
    swal.fire({
      title: `${station.Name}`,
      html: `Adresa: ${station.Address}</br>
            Stanice: ${station.Lines.map(x => `${x.Number}`)}`,
      type: 'info',
      confirmButtonText: 'Ok'
    });
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
