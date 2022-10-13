import { Roles } from "../../enums/Roles";
import { Menu } from "../base/Menu";
import { MenuCreator } from "../base/MenuCreator";
import { AdminMenu } from "./AdminMenu";
import { AuditorMenu } from "./AuditorMenu";
import { OperatorMenu } from "./OperatorMenu";

export class UserMenuCreator extends MenuCreator {

    CreateMenu(role: Roles): Menu {

        let menu: Menu

        switch (role) {
            case Roles.ADMIN:
                menu = new AdminMenu()
                break;
            case Roles.OPERATOR:
                menu = new OperatorMenu()
                break;
            case Roles.AUDITOR:
                menu = new AuditorMenu()
                break;
            default:
                throw new Error("El rol no existe");
        }

        return menu
    }

}