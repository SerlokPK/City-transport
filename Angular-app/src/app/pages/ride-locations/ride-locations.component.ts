import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-ride-locations',
  templateUrl: './ride-locations.component.html',
  styleUrls: ['./ride-locations.component.css']
})
export class RideLocationsComponent implements OnInit {
  @ViewChild('gmap') gmapElement: any;
  map: google.maps.Map;

  constructor() { }

  ngOnInit() {
    this.gmapInit();
  }

  gmapInit() {
    const mapProp = {
      center: new google.maps.LatLng(45.2700573, 19.837304),
      zoom: 15,
      mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    this.map = new google.maps.Map(this.gmapElement.nativeElement, mapProp);
  }
}
