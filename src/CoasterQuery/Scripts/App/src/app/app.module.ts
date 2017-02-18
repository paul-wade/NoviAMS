import {NgModule} from "@angular/core";
import {FormsModule} from "@angular/forms";
import {HttpModule} from "@angular/http";
import {AppComponent} from "./app.component";
import {MdCardModule} from "@angular2-material/card";
import {MdButtonModule} from "@angular2-material/button";
import {MdToolbarModule} from "@angular2-material/toolbar";
import {MdIconModule, MdIconRegistry} from "@angular2-material/icon";
import {BrowserModule} from "@angular/platform-browser";
import {ParkService} from "./park.service";
import {MappingService} from "./mapping.service";
import {MdGridListModule} from "@angular2-material/grid-list";
import {NgbModule} from "@ng-bootstrap/ng-bootstrap";
import {AgmCoreModule} from "angular2-google-maps/core";
import {RouterModule, Routes} from "@angular/router";
import {ParkListComponent} from "./park-list/park-list.component";
import {ParkDetailComponent} from "./park-detail/park-detail.component";

const appRoutes: Routes = [
  {path: 'home', component: ParkListComponent},
  {path: 'park', component: ParkDetailComponent},
];



@NgModule({
  declarations: [
    AppComponent,
    ParkListComponent,
    ParkDetailComponent
  ],
  imports: [
    FormsModule,
    HttpModule,
    BrowserModule,
    MdCardModule,
    MdButtonModule,
    MdIconModule,
    MdToolbarModule,
    MdGridListModule,
    NgbModule.forRoot(),
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyAdybAglxzKveYktptHsdXzn-tHepmymRM'
    }),
    RouterModule.forRoot(appRoutes)
  ],
  providers: [MdIconRegistry, ParkService, MappingService],
  bootstrap: [AppComponent]
})
export class AppModule { }
