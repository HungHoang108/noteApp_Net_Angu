import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class NoteService {
  constructor() {}

  baseURL = 'https://localhost:7107/api/v1/Notes';
  httpClient = inject(HttpClient);

  private headers: HttpHeaders = new HttpHeaders();

  identify(apiKey: string) {
    this.headers = new HttpHeaders().set('x-api-key', apiKey);
  }

  getNotes() {
    return this.httpClient.get(`${this.baseURL}/`, { headers: this.headers });
  }

  deleteItem(id: number | undefined) {
    return this.httpClient.delete(`${this.baseURL}/${id}`, {
      headers: this.headers,
    });
  }
}
