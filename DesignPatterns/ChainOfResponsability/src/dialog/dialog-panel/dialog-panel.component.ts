import { Component } from '@angular/core';
import ComponentHelp from 'src/models/ValidationChain';

@Component({
  selector: 'app-dialog-panel',
  templateUrl: './dialog-panel.component.html',
  styleUrls: ['./dialog-panel.component.css']
})
export class DialogPanelComponent {
  
  termsAccepted: boolean  | undefined = undefined;
}
