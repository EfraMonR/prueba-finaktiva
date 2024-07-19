import { Component } from '@angular/core';
import { EventlogViewerService } from './../eventlog-viewer.service';
import { EventLog } from './../../../models/eventlog.model';

declare var bootstrap: any;

@Component({
  selector: 'app-modal-consult',
  templateUrl: './modal-consult.component.html',
  styleUrls: ['./modal-consult.component.scss']
})
export class ModalConsultComponent {
  eventLogs: EventLog[] = [];
  filteredEvents: EventLog[] = [];
  eventTypeFilter: number | null = null;
  startDateFilter: Date | null = null;
  endDateFilter: Date | null = null;
  today: Date = new Date();
  errorMessage: string | null = null;

  constructor(private eventViewerService: EventlogViewerService) {

  }

  ngOnInit(): void {
    this.getEventLogs();
  }

  ngAfterViewInit(): void {
    const modalElement = document.getElementById('modalConsult');
    if (modalElement) {
      const bootstrapModal = new bootstrap.Modal(modalElement);
      modalElement.addEventListener('hidden.bs.modal', () => this.resetFilters());
      modalElement.addEventListener('shown.bs.modal', () => {
        this.setDefaultDates();
        this.resetEventTypeFilter();
      });
    }
  }

  getEventLogs(): void {
    this.eventViewerService.getAllEventLog().subscribe(eventLog => {
      this.eventLogs = eventLog;
      this.applyFilter(); // Aplica el filtro al cargar los eventos
    });
  }

  setDefaultDates(): void {
    const today = new Date();
    this.startDateFilter = new Date(today);
    this.endDateFilter = new Date(today);

    const startDateInput = document.getElementById('startDateInput') as HTMLInputElement;
    const endDateInput = document.getElementById('endDateInput') as HTMLInputElement;
    if (startDateInput) startDateInput.value = this.formatDate(today);
    if (endDateInput) endDateInput.value = this.formatDate(today);
  }

  formatDate(date: Date): string {
    const year = date.getFullYear();
    const month = (date.getMonth() + 1).toString().padStart(2, '0');
    const day = date.getDate().toString().padStart(2, '0');
    return `${year}-${month}-${day}`;
  }

  getEventTypeDescription(eventType: number): string {
    switch (eventType) {
      case 1:
        return 'Api';
      case 2:
        return 'Formulario de eventos manuales';
      default:
        return 'Desconocido';
    }
  }

  filterEvents(): EventLog[] {
    return this.eventLogs.filter(event => {
      const eventDate = new Date(event.fecha);
      const isDateInRange = (!this.startDateFilter || eventDate >= this.startDateFilter) &&
                            (!this.endDateFilter || eventDate <= this.endDateFilter);
      const isTypeMatch = this.eventTypeFilter === null ||
                           this.eventTypeFilter === undefined ||
                           this.eventTypeFilter === 0 ||
                           event.tipoEvento === this.eventTypeFilter;

      return isDateInRange && isTypeMatch;
    });
  }

  onEventTypeChange(event: Event): void {
    const target = event.target as HTMLSelectElement;
    this.eventTypeFilter = target.value ? +target.value : null;
  }

  onStartDateChange(event: Event): void {
    const target = event.target as HTMLInputElement;
    const selectedDate = target.value ? new Date(target.value) : null;

    if (selectedDate && selectedDate > this.today) {
      this.errorMessage = 'La fecha de inicio no puede ser superior a la fecha actual.';
      this.startDateFilter = null;
      target.value = '';
    } else {
      this.errorMessage = null;
      this.startDateFilter = selectedDate;
      this.applyFilter();
    }
  }

  onEndDateChange(event: Event): void {
    const target = event.target as HTMLInputElement;
    const selectedDate = target.value ? new Date(target.value) : null;

    if (selectedDate && selectedDate > this.today) {
      this.errorMessage = 'La fecha de fin no puede ser superior a la fecha actual.';
      this.endDateFilter = null;
      this.filteredEvents = []
      target.value = '';
    } else if (this.startDateFilter && selectedDate && selectedDate < this.startDateFilter) {
      this.errorMessage = 'La fecha de fin no puede ser anterior a la fecha de inicio.';
      this.endDateFilter = null;
      this.filteredEvents = []
      target.value = '';
    } else {
      this.errorMessage = null;
      this.endDateFilter = selectedDate;
      this.applyFilter();
    }
  }

  applyFilter(): void {
    this.filteredEvents = this.filterEvents();
  }

  resetFilters(): void {
    this.eventTypeFilter = null;
    this.startDateFilter = null;
    this.endDateFilter = null;
    this.filteredEvents = [];
    this.errorMessage = null;
  }

  resetEventTypeFilter(): void {
    const eventTypeSelect = document.getElementById('eventType') as HTMLSelectElement;
    if (eventTypeSelect) eventTypeSelect.value = ''; // Restablece a "Todos"
  }
}
