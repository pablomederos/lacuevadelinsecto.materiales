import { Injectable } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { ResponsabilityHandler } from "./ResponsabilityHandler";
import { AuthenticationResponsabilityHandler } from "./AuthenticationResponsabilityHandler";
import { AuthorizationResponsabilityHandler } from "./AuthorizationResponsabilityHandler";
import { TransformationResponsabilityHandler } from "./TransformationResponsabilityHandler";

@Injectable({
    providedIn: 'root'
})
export default class ValidationChain {

    validationChainComponent: ResponsabilityHandler | undefined;

    isLogged: boolean = false;
    hasCorrectRole: boolean = false;

    constructor(dialog: MatDialog) {
        this.validationChainComponent = new AuthenticationResponsabilityHandler(dialog);
        const handler2 = new AuthorizationResponsabilityHandler(dialog)
        const handler3 = new TransformationResponsabilityHandler();
        
        this.validationChainComponent.setNextHandler(handler2);
        handler2.setNextHandler(handler3);

    }

}