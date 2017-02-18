import {NgModule} from "@angular/core";
import {FormsModule} from "@angular/forms";
import {HttpModule} from "@angular/http";
import {AppComponent} from "./app.component";
import {MdCardModule} from "@angular2-material/card";
import {MdButtonModule} from "@angular2-material/button";
import {MdIconModule, MdIconRegistry} from "@angular2-material/icon";
import {BrowserModule} from "@angular/platform-browser";
import {ParkService} from "./Services/park.service";
import {MdGridListModule} from "@angular2-material/grid-list";
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    FormsModule,
    HttpModule,
    BrowserModule,
    MdCardModule,
    MdButtonModule,
    MdIconModule,
    MdGridListModule
  ],
  providers: [MdIconRegistry, ParkService],
  bootstrap: [AppComponent]
})
export class AppModule { }
