export default class Direccion {

    private _calle: string
    private _esquina?: string
    private _puerta: string

    public get calle(): string {
        return this._calle;
    }

    public set calle(value: string) {
        if (!value.trim().length)
            throw new Error("Calle no válida")
        this._calle = value;
    }

    public get esquina(): string | undefined {
        return this._esquina
    }

    public set esquina(esquina: string | undefined) {
        this._esquina = esquina;
    }

    public get puerta(): string {
        return this._puerta;
    }

    public set puerta(value: string) {
        if (!value.trim().length)
            throw new Error("Número de puerta no válido")
        this._puerta = value;
    }


    constructor(calle: string, puerta: string) {
        this._calle = calle
        this._puerta = puerta
    }
}