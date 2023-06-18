import { MatDialog } from "@angular/material/dialog";
import { ResponsabilityHandler } from "./ResponsabilityHandler";
import { CustomDialogComponent } from "src/custom-dialog/custom-dialog.component";

export class AuthenticationResponsabilityHandler extends ResponsabilityHandler {

    constructor(private dialog: MatDialog) {
        super();
    }

    handle() {
        /**
         * Acá va la lógica super compleja de la nasa que decide qué pasa luego
         */

        if(sessionStorage.getItem('isLogged') != 'true')
        {
            this.dialog.open(CustomDialogComponent, {
                data: {
                    title: 'Error',
                    message: 'You must be logged in to access this page (Chain link 1).'
                }
            });
            
            throw new Error(); // No es necesario
        }

        /**
         * Acá puedo hacer otras cosas que sean mi responsabilidad
         * Por ejemplo validar que hay otros datos de sesión
         */

        // Puede que no haya un siguiente handler
        this.nextHandler?.handle();
    }
}