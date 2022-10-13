import { Roles } from "../../enums/Roles";
import { Menu } from "./Menu";

export abstract class MenuCreator {

    abstract CreateMenu(role: Roles): Menu
}