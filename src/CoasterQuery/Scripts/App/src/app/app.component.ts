import {Component} from "@angular/core";
import {ParkService} from "./Services/park.service";
import {Park} from "./Models/park";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'app works!';
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
