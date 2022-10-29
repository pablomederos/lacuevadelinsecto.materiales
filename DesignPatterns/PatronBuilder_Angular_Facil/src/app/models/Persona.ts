import Direccion from "./Direccion";
import Telefono from "./Telefono";
import Vehiculo from "./Vehiculo";

export class Persona {

    private _nombre: string;
    private _apellido: string;

    private _vehiculos?: Set<Vehiculo> | undefined;
    private _direcciones?: Set<Direccion> | undefined;
    private _telefonos?: Set<Telefono> | undefined;

    private constructor(builder: IPersonaBuilder) {
        this._nombre = (builder as any).nombre
        this._apellido = (builder as any).apellido
        
        this._direcciones = new Set((builder as any)._direcciones)
        this._telefonos = new Set((builder as any)._telefonos)
        this._vehiculos = new Set((builder as any)._vehiculos)
    }

    public get nombre(): string {
        return this._nombre;
    }
    public set nombre(value: string) {
        if (!value.trim().length)
            throw new Error("Nombre no válido")
        this._nombre = value;
    }

    public get apellido(): string {
        return this._apellido;
    }
    public set apellido(value: string) {
        if (!value.trim().length)
            throw new Error("Apellido no válido")
        this._apellido = value;
    }
    public get vehiculos(): Set<Vehiculo> | undefined {
        return this._vehiculos;
    }
    public set vehiculos(value: Set<Vehiculo> | undefined) {
        this._vehiculos = value;
    }

    public get direcciones(): Set<Direccion> | undefined {
        return this._direcciones;
    }

    public set direcciones(value: Set<Direccion> | undefined) {
        this._direcciones = value;
    }
    public get telefonos(): Set<Telefono> | undefined {
        return this._telefonos;
    }
    public set telefonos(value: Set<Telefono> | undefined) {
        this._telefonos = value;
    }

    static Builder = class implements IPersonaBuilder {
        
        private _nombre: string;
        private _apellido: string;

        private _vehiculos?: Set<Vehiculo> | undefined;
        private _direcciones?: Set<Direccion> | undefined;
        private _telefonos?: Set<Telefono> | undefined;

        constructor(nombre: string, apellido: string) {
            this._nombre = nombre
            this._apellido = apellido
        }

        get nombre():string 
        {
            return this._nombre
        }

        get apellido():string 
        {
            return this._apellido
        }

        get vehiculos():Set<Vehiculo> | undefined 
        {
            return this._vehiculos
        }

        get direcciones():Set<Direccion> | undefined
        {
            return this._direcciones
        }

        get telefonos():Set<Telefono> | undefined 
        {
            return this._telefonos
        }

        agregarNombre(value: string)
        {
            this._nombre = value
            return this
        }

        agregarApellido(value: string)
        {
            this._apellido = value
            return this
        }

        agregarVehiculo(nombre: Vehiculo | string, opts?: Record<string, string>) {

            if (!this._vehiculos)
                this._vehiculos = new Set<Vehiculo>()

            if (typeof nombre === 'string')
            {
                if (!opts)
                    throw new Error('Modelo no válido')

                this._vehiculos.add(new Vehiculo(nombre as string, (opts as any).modelo))
            }
            else 
                this._vehiculos.add(nombre as Vehiculo)

            return this
        }

        agregarDireccion(calle: Direccion | string, opts?: Record<string, string>) {

            if (!this._direcciones)
                this._direcciones = new Set<Direccion>()

            if (typeof calle === 'string')
            {
                if (!opts)
                    throw new Error('Se requiere más información de la dirección')

                const d = new Direccion(calle as string, (opts as any).puerta)
                d.esquina = (opts as any).esquina

                this._direcciones.add(d)
            }
            else
                this._direcciones.add(calle as Direccion)

            return this
        }

        agregarTelefono(numero: Telefono | string, opts?: Record<string, string>) {

            if (!this._telefonos)
                this._telefonos = new Set<Telefono>()

            if (typeof numero === 'string')
            {
                if (!opts)
                    throw new Error('Se requiere más información de la direccion')

                this._telefonos.add(new Telefono(numero as string, (opts as any).nombre))
            }
            else 
                this._telefonos.add(numero as Telefono)

            return this
        }

        build(): Persona 
        {
            const persona = new Persona(this)

            return persona
        }
    }
}

export interface IPersonaBuilder {
    agregarNombre(value: string): IPersonaBuilder

    agregarApellido(value: string): IPersonaBuilder

    agregarVehiculo(nombre: Vehiculo | string, opts?: Record<string, string>): IPersonaBuilder

    agregarDireccion(calle: Direccion | string, opts?: Record<string, string>): IPersonaBuilder

    agregarTelefono(numero: Telefono | string, opts?: Record<string, string>): IPersonaBuilder

    build(): Persona
}