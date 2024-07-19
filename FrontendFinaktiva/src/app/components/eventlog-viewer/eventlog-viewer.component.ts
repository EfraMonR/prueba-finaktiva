import { Component } from '@angular/core';
declare var bootstrap: any;
@Component({
  selector: 'app-eventlog-viewer',
  templateUrl: './eventlog-viewer.component.html',
  styleUrls: ['./eventlog-viewer.component.scss']
})
export class EventlogViewerComponent {
  openConsultModal() {
    const modalElement = document.getElementById('modalConsult');
    if (modalElement) {
      const modal = new bootstrap.Modal(modalElement);
      modal.show();
    };
  }

  openAddModal() {
    const modalElement = document.getElementById('modalAgregate');
    if (modalElement) {
      const modal = new bootstrap.Modal(modalElement);
      modal.show();
    };
  }
}
