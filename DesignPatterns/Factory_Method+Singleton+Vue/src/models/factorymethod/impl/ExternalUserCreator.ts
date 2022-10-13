import { Menu } from "../base/Menu";
import { MenuCreator } from "../base/MenuCreator";
import { AuditorMenu } from "./AuditorMenu";

export class ExternalUserCreator extends MenuCreator {

    CreateMenu(): Menu {
        return new AuditorMenu()
    }
    
}