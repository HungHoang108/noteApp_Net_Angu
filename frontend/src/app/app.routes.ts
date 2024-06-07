import { Routes } from '@angular/router';
import { TodoRouteComponent } from './todo-route/todo-route.component';
import { NoteComponent } from './note/note.component';

export const routes: Routes = [
  { path: 'note', component: NoteComponent },
  { path: 'todo', component: TodoRouteComponent },
  { path: '', redirectTo: '/note', pathMatch: 'full' },
  { path: '**', redirectTo: '/note' },
];
