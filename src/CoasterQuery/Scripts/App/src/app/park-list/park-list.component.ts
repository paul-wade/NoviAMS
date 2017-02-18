import { Component, OnInit } from '@angular/core';
import {ParkService} from "../park.service";
import {Park} from "../Models/park";

@Component({
  selector: 'app-park-list',
  templateUrl: './park-list.component.html',
  styleUrls: ['./park-list.component.css']
})
export class ParkListComponent implements OnInit {
  parks = [];

  constructor(private parkService: ParkService) {
  }

  GetAllParks(): void {
    this.parkService.getAllParks().then(response =>
    {
      this.parks = response;
    });
  }
  ngOnInit() {
    this.GetAllParks();
  }
}
