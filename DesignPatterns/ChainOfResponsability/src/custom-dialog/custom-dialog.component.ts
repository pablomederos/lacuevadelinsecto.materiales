import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-custom-dialog',
  templateUrl: './custom-dialog.component.html',
  styleUrls: ['./custom-dialog.component.css']
})
export class CustomDialogComponent {

  message: string | undefined = '';
  title: string | undefined = '';

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private dialogRef: MatDialogRef<CustomDialogComponent>) {
    this.message = data?.message as string;
    this.title = data?.title as string;
  }

  closeDialog() {
    this.dialogRef.close();
  }
}
