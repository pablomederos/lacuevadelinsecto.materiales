import { MatDialog } from "@angular/material/dialog";
import { ResponsabilityHandler } from "./ResponsabilityHandler";
import { CustomDialogComponent } from "src/custom-dialog/custom-dialog.component";

export class AuthorizationResponsabilityHandler extends ResponsabilityHandler {

    constructor(private dialog: MatDialog) {
        super();
    }

    handle() {
        /**
         * Acá va la lógica super compleja de la nasa que decide qué pasa luego
         */

        if(sessionStorage.getItem('role') != 'USER')
        {
            this.dialog.open(CustomDialogComponent, {
                data: {
                    title: 'Error',
                    message: 'You need to be an application User to submit the form (Chain link 2).'
                }
            });

            throw new Error(); // No es necesario
        }

        /**
         * Acá puedo hacer otras cosas que sean mi responsabilidad
         * Por ejemplo validar que el usuario está aún activo
         */

        // Puede que no haya un siguiente handler
        this.nextHandler?.handle();
    }
}