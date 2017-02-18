import {Injectable} from "@angular/core";
import {Park} from "./Models/park";
import {Http} from "@angular/http";
import "rxjs/add/operator/toPromise";
import "rxjs/Rx";
@Injectable()
export class ParkService {
  rootUrl = "http://localhost:19502/api/";

  constructor(private http: Http) {
  }


  getAllParks(): Promise<Park[]> {
    return this.http.get(this.rootUrl + "Park")
      .map(response => response.json())
      .toPromise()
      .then(response => {
        return response as Park[]
      })
      .catch(this.handleError);
  }

  getPark(id: number): Promise<Park> {
    return this.getAllParks()
      .then(heroes => heroes.find(park => park.ParkID === id));
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
