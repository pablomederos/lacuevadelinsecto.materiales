import { Component } from '@angular/core';
import ComponentHelp from 'src/models/ValidationChain';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent {
  
  termsAccepted: boolean = false;
}
