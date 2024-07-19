import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventlogViewerComponent } from './components/eventlog-viewer/eventlog-viewer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ModalConsultComponent } from './components/eventlog-viewer/modal-consult/modal-consult.component';

@NgModule({
  declarations: [
    AppComponent,
    EventlogViewerComponent,
    ModalConsultComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
