import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NoteComponent } from './note/note.component';
import { NavbarComponent } from './navbar/navbar.component';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  imports: [RouterOutlet, NoteComponent, NavbarComponent],
})
export class AppComponent {
  title = 'frontend';
}
