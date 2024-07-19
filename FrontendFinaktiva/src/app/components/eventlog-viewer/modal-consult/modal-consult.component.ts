import { Component } from '@angular/core';
import { EventlogViewerService } from './../eventlog-viewer.service';
import { EventLog } from './../../../models/eventlog.model';

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

  constructor(private eventViewerService: EventlogViewerService) {

  }

  ngOnInit(): void {
    this.getEventLogs();
  }

  ngAfterViewInit(): void {
    const modalElement = document.getElementById('modalConsult');
    if (modalElement) {
      modalElement.addEventListener('hidden.bs.modal', () => this.resetFilters());
    }
  }

  getEventLogs(){
    this.eventViewerService.getAllEventLog()
      .subscribe(eventLog => this.eventLogs = eventLog)
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
    this.eventTypeFilter = +target.value;
  }

  onStartDateChange(event: Event): void {
    const target = event.target as HTMLInputElement;
    this.startDateFilter = target.value ? new Date(target.value) : null;
  }

  onEndDateChange(event: Event): void {
    const target = event.target as HTMLInputElement;
    this.endDateFilter = target.value ? new Date(target.value) : null;
  }

  applyFilter(): void {
    this.filteredEvents = this.filterEvents();
  }

  resetFilters(): void {
    this.eventTypeFilter = null;
    this.startDateFilter = null;
    this.endDateFilter = null;
    this.filteredEvents = [];
  }
}
