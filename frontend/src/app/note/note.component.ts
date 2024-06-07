import { CommonModule } from '@angular/common';
import {
  HttpClient,
  HttpClientModule,
  HttpHeaders,
} from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { Note } from '../models/note';
import { NoteService } from '../../../services/note.service';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-note',
  standalone: true,
  imports: [HttpClientModule, CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './note.component.html',
  styleUrl: './note.component.css',
})
export class NoteComponent implements OnInit {
  form: FormGroup;

  constructor(private service: NoteService, private fb: FormBuilder) {
    this.form = this.fb.group({
      title: [''],
      description: [''],
    });
  }

  selectedNote: Note | null = null;
  data: Note[] = [];

  ngOnInit(): void {
    this.fetchData();
  }
  apiKey: string = '';
  baseURL = 'https://localhost:7107/api/v1/Notes';
  httpClient = inject(HttpClient);

  private headers: HttpHeaders = new HttpHeaders();

  identify() {
    this.service.identify(this.apiKey);
    this.fetchData();
  }

  fetchData() {
    this.service.getNotes().subscribe((data: any) => {
      this.data = data.sort((a: any, b: any) => a.id - b.id);
      console.log(data);
    });
  }

  deleteItem(id: number | undefined) {
    this.service
      .deleteItem(id)
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
    this.form.patchValue(note);
  }

  onSubmit() {
    if (this.selectedNote) {
      this.httpClient
        .patch(
          `https://localhost:7107/api/v1/Notes/${this.selectedNote.id}`,
          this.form.value,
          { headers: this.headers }
        )
        .subscribe(() => {
          this.fetchData();
          this.resetForm();
        });
    } else {
      this.service.addNote(this.form.value).subscribe(() => {
        this.fetchData();
        this.resetForm();
      });
    }
  }

  resetForm() {
    this.selectedNote = null;
    this.form.reset();
  }
}
