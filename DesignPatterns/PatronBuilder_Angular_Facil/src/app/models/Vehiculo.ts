export default class Vehiculo {
    private _marca: string = ''
    private _modelo: string = ''


    constructor(marca: string, modelo: string) {
        this.marca = marca
        this.modelo = modelo
    }

    public get marca(): string {
        return this._marca;
    }

    public set marca(marca: string) {
        if(!marca?.trim()?.length)
            throw new Error('Marca no válida')
        this._marca = marca;
    }

    public get modelo(): string {
        return this._modelo;
    }

    public set modelo(modelo: string) {
        if(!modelo?.trim()?.length)
            throw new Error('Modelo no válido')
            console.log('seteando modelo');
            
        this._modelo =  modelo;
    }
}