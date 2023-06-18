import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DialogComponent } from '../dialog/dialog.component';
import { DialogPanelComponent } from '../dialog/dialog-panel/dialog-panel.component';
import { DialogButtonComponent } from '../dialog/dialog-button/dialog-button.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTooltipModule } from '@angular/material/tooltip';
import { FormsModule } from '@angular/forms';
import { CustomDialogComponent } from '../custom-dialog/custom-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    DialogComponent,
    DialogPanelComponent,
    DialogButtonComponent,
    CustomDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatDialogModule,
    MatTooltipModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
