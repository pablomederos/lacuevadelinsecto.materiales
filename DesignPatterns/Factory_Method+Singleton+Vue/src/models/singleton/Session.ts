import { Roles } from "../enums/Roles"

export default class Session {
    
    private static instance: Session

    private _username: string = ''
    private _role: Roles = Roles.NONE
    
    public get username(): string {
        return this._username
    }

    public get role(): Roles {
        return this._role
    }

    constructor()
    {
        if(!Session.instance)
        {
            console.log('Creando singleton');

            this.initFromStorage()
            
            Session.instance = this
        }
        else
            console.log('La instancia ya existe');

        return Session.instance
    }

    setUserData(options?: SessionData) {
        this._username = options?.username || ''
        this._role = options?.role as Roles || Roles.NONE

        this.createStorage()
    }

    private createStorage() {
        sessionStorage.username = this._username
        sessionStorage.role = Roles[this._role] ?? Roles[Roles.NONE]
    }

    private initFromStorage() {
        this._username = sessionStorage.username || ''
        this._role = Roles[sessionStorage.role as Roles] || Roles.NONE
    }

    public clearData() {
        this.setUserData()
    }

}

interface SessionData {
    username?: string
    role?: Roles
}

