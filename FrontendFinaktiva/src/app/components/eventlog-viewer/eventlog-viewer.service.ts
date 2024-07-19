import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { EventLog } from './../../models/eventlog.model'
import { EventAdd } from './../../models/eventlog.model'

@Injectable({
  providedIn: 'root'
})
export class EventlogViewerService {

  private apiUrl = 'http://localhost:5023/api/EventLog';

  constructor(private http: HttpClient) { }

  getAllEventLog(): Observable<EventLog[]> {
    return this.http.get<EventLog[]>(`${this.apiUrl}/GetEventsLogList`).pipe(
      catchError(this.handleError)
    );
  }

  addEventLog(event: EventAdd): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/CreateEventLog`, event).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse) {
    console.error('Ocurrió un error:', error.message);
    return throwError(() => new Error('Ocurrió un error en la solicitud. Inténtalo de nuevo más tarde.'));
  }
}
