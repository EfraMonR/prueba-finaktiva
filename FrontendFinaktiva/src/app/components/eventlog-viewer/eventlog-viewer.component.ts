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
    console.log('Agregar button clicked');
    // Implementa aquí la lógica para el botón Agregar
  }
}
