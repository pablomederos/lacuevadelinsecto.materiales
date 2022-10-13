import { Menu } from "../base/Menu";

export class AdminMenu extends Menu {
    
    constructor() {
        super()
        this.insertMenuOptions(['Leer', 'Crear', 'Actualizar', 'Eliminar'])
    }
}