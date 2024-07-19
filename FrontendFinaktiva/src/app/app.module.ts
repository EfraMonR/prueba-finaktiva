import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { EventlogViewerComponent } from './components/eventlog-viewer/eventlog-viewer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ModalConsultComponent } from './components/eventlog-viewer/modal-consult/modal-consult.component';
import { ModalAddComponent } from './components/eventlog-viewer/modal-add/modal-add.component';

@NgModule({
  declarations: [
    AppComponent,
    EventlogViewerComponent,
    ModalConsultComponent,
    ModalAddComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
