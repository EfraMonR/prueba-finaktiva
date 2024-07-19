import { Component } from '@angular/core';
import { EventlogViewerService } from './../eventlog-viewer.service';
import { EventAdd } from './../../../models/eventlog.model';
import { HttpErrorResponse } from '@angular/common/http';

declare var bootstrap: any;
@Component({
  selector: 'app-modal-add',
  templateUrl: './modal-add.component.html',
  styleUrls: ['./modal-add.component.scss']
})
export class ModalAddComponent {
  newEvent: EventAdd = {
    descripcion: '',
    tipoEvento: 2
  };
  successMessage: string | null = null;
  errorMessage: string | null = null;
  descriptionError: boolean = false;

  constructor(private eventlogViewerService: EventlogViewerService) {}

  onSubmit(): void {
    this.descriptionError = false;

    if (this.newEvent.descripcion.trim()) {
      this.eventlogViewerService.addEventLog(this.newEvent).subscribe({
        next: () => {
          this.successMessage = 'Evento agregado exitosamente.';
          this.errorMessage = null;
          this.newEvent.descripcion = '';
        },
        error: (error: HttpErrorResponse) => {
          this.errorMessage = 'Error al agregar el evento: ' + error.message;
          this.successMessage = null;
        }
      });
    } else {
      this.errorMessage = 'Por favor, completa todos los campos.';
      this.descriptionError = true;
      this.successMessage = null;
    }
  }

  closeModal(): void {
    const modalElement = document.getElementById('modalAgregate');
    if (modalElement) {
      const bootstrapModal = bootstrap.Modal.getInstance(modalElement) || new bootstrap.Modal(modalElement);
      bootstrapModal.hide();
    }
    this.clearMessages();
  }

  clearMessages(): void {
    this.successMessage = null;
    this.errorMessage = null;
    this.descriptionError = false;
  }

  clearAlert(type: 'success' | 'error'): void {
    if (type === 'success') {
      this.successMessage = null;
    } else {
      this.errorMessage = null;
    }
  }
}
