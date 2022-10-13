import { Menu } from "../base/Menu"

export class OperatorMenu extends Menu{

    constructor() {
        super()
        this.insertMenuOptions(['Leer', 'Crear', 'Actualizar'])
    }
}