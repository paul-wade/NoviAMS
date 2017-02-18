import {Component, OnInit} from "@angular/core";
import {ActivatedRoute, Params} from "@angular/router";
import {ParkService} from "../park.service";
import {MappingService} from "../mapping.service";
import {Park} from "../Models/park";
import "rxjs/add/operator/switchMap";

@Component({
  selector: 'app-park-detail',
  templateUrl: './park-detail.component.html',
  styleUrls: ['./park-detail.component.css']
})
export class ParkDetailComponent implements OnInit {
  park: Park = undefined;
  latlong = undefined;

  constructor(private parkService: ParkService,
              private route: ActivatedRoute,
              private mappingService: MappingService) {
  }

  ngOnInit(): void {
    this.route.params
      .switchMap((params: Params) => this.parkService.getPark(+params['ParkID']))
      .subscribe(park => {
        this.park = park;
        this.mappingService.getLatLong(park.Address, park.City, park.State, park.Zip).then(response => {
          this.latlong = response;
        });

      });

  }
}
