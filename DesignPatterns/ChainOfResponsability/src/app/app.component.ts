import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DialogComponent } from 'src/dialog/dialog.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ChainOfResponsability';

  isLogged: boolean = false;
  isUser: boolean = false;

  constructor(private dialog: MatDialog) {
    this.isLogged = sessionStorage.getItem('isLogged') == 'true';
    this.isUser = sessionStorage.getItem('role') == 'USER';

  }

  showDialog() {
    this.dialog.open(DialogComponent, {
      width: '250px',
      height: '250px'
    })
  }

  onCheck(target: EventTarget | null) {

    const id: string | undefined = (target as any)?.id;


    switch (id) {
      case 'logged':
        this.isLogged = !this.isLogged;
        sessionStorage.setItem('isLogged', this.isLogged.toString());
        break;
      case 'isUser':
        this.isUser = !this.isUser;
        sessionStorage.setItem('role', this.isUser ? 'USER' : '');
        break;
      default:
        console.info('Otra opción…');
    }

  }
}
