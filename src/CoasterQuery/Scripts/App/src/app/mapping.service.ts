import {Injectable} from "@angular/core";
import {Http, URLSearchParams} from "@angular/http";
import {Park} from "./Models/park";
import "rxjs/add/operator/toPromise";
import "rxjs/Rx";

@Injectable()
export class MappingService {
  rootUrl = "http://localhost:19502/api/";

  constructor(private http: Http) {
  }

  getLatLong(street: string, city: string, state: string, zip: string): Promise<Park> {
    let params: URLSearchParams = new URLSearchParams();
    if (street)
      params.set('street', street);
    if (city)
      params.set('city', city);
    if (state)
      params.set('state', state);
    if (zip)
      params.set('zip', zip);

    return this.http.get(this.rootUrl + "Mapping", {search: params})
      .map(response => response.json())
      .toPromise()
      .then(response => {
        return response as Park
      })
      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
