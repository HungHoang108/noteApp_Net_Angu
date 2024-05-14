import { CommonModule } from '@angular/common';
import {
  HttpClient,
  HttpClientModule,
  HttpHeaders,
} from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { Note } from '../models/note';

@Component({
  selector: 'app-note',
  standalone: true,
  imports: [HttpClientModule, CommonModule, FormsModule],
  templateUrl: './note.component.html',
  styleUrl: './note.component.css',
})
export class NoteComponent implements OnInit {
  formData: Note = new Note();
  selectedNote: Note | null = null;
  data: Note[] = [];

  ngOnInit(): void {
    this.fetchData();
  }
  apiKey: string = '';
  baseURL = 'https://localhost:7107/api/v1/Notes';
  httpClient = inject(HttpClient);

  identify() {
    this.fetchData();
  }

  fetchData() {
    const headers = new HttpHeaders().set('x-api-key', this.apiKey);
    this.httpClient
      .get(`${this.baseURL}/`, { headers })
      .subscribe((data: any) => {
        this.data = data.sort((a: any, b: any) => a.id - b.id);
        console.log(data);
      });
  }

  deleteItem(id: any) {
    const headers = new HttpHeaders().set('x-api-key', this.apiKey);

    this.httpClient
      .delete(`${this.baseURL}/${id}`, { headers })
      .pipe(
        catchError((error) => {
          console.error('Error deleting item:', error);
          return throwError(error);
        })
      )
      .subscribe(() => {
        console.log('Item deleted successfully.');
        this.fetchData();
      });
  }

  openModifyForm(note: Note) {
    this.selectedNote = note;
    this.formData = { title: note.title, description: note.description };
  }

  onSubmit() {
    const headers = new HttpHeaders().set('x-api-key', this.apiKey);
    if (this.selectedNote) {
      this.httpClient
        .patch(
          `https://localhost:7107/api/v1/Notes/${this.selectedNote.id}`,
          this.formData,
          { headers }
        )
        .subscribe(() => {
          this.fetchData();
          this.resetForm();
        });
    } else {
      this.httpClient
        .post('https://localhost:7107/api/v1/Notes', this.formData, { headers })
        .subscribe(() => {
          this.fetchData();
          this.resetForm();
        });
    }
  }

  resetForm() {
    this.selectedNote = null;
    this.formData = new Note();
  }
}
