export default class Telefono {
    private _numero: string = ''
    private _nombre: string = ''

    constructor(numero:string, nombre:string) {
        this.numero = numero
        this.nombre = nombre
    }

    public get numero(): string {
        return this._numero
    }
    public set numero(value: string) {
        if (!value.trim().length)
            throw new Error("Número no válido")
        this._numero = value
    }

    public get nombre(): string {
        return this._nombre
    }
    public set nombre(value: string) {
        if (!value.trim().length)
            throw new Error("Nombre no válido")
        this._nombre = value
    }
}