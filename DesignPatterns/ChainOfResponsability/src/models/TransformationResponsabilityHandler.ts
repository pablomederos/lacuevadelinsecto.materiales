import { ResponsabilityHandler } from "./ResponsabilityHandler";

export class TransformationResponsabilityHandler extends ResponsabilityHandler {
    constructor() {
        super();
    }
    handle() {
        /**
         * Acá va la lógica super compleja de la nasa que decide qué pasa luego
         */

        (() => {
            // Transformando data en silencio
            console.info('Transformando data en silencio');
        })()

        // Puede que no sea necesario transformar nada

        // Puede que no haya un siguiente handler
        this.nextHandler?.handle();
    }
}