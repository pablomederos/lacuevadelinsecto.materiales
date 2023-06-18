import { Component, Input } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { CustomDialogComponent } from 'src/custom-dialog/custom-dialog.component';
import ValidationChain from 'src/models/ValidationChain';

@Component({
  selector: 'app-dialog-button',
  templateUrl: './dialog-button.component.html',
  styleUrls: ['./dialog-button.component.css']
})
export class DialogButtonComponent {

  @Input()
  disabled: boolean = false;

  constructor(
    private validationChain: ValidationChain,
    private dialogRef: MatDialogRef<DialogButtonComponent>,
    private dialog: MatDialog
  ) {

  }

  /**
   * Puse todo este código acá porque soy vago,
   * y alguien que está empezando podría seguir el flujo
   * desde el botón buscando el código que se ejecuta
   */

  accept() {
    this.dialogRef.close();
    try {
      this.validationChain.validationChainComponent?.handle();

      // Ahora que pasaron todas las validaciones, se envía el formulario
      // ...
      // this.http.post('url', this.form.value).subscribe(() => {...})
      // ...

      // Y le muestro al usuario que todo salió bien

      this.dialog.open(CustomDialogComponent, {
        data: {
          title: 'Success',
          message: 'You have been sent the form.'
        }
      })

    } catch {
      // ignorado
    }
  }
}
