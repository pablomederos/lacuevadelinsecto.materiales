import Direccion from "./Direccion";
import IBuilder from "./IBuilder";
import Telefono from "./Telefono";
import Vehiculo from "./Vehiculo";

export default class Persona {

    private _nombre: string;
    private _apellido: string;

    private _vehiculos?: Set<Vehiculo> | undefined;
    private _direcciones?: Set<Direccion> | undefined;
    private _telefonos?: Set<Telefono> | undefined;

    private constructor(nombre: string, apellido: string) {
        this._nombre = nombre
        this._apellido = apellido
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

    static Builder = class implements IBuilder {
        
        private _nombre: string;
        private _apellido: string;

        private _vehiculos?: Set<Vehiculo> | undefined;
        private _direcciones?: Set<Direccion> | undefined;
        private _telefonos?: Set<Telefono> | undefined;

        constructor(nombre: string, apellido: string) {
            this._nombre = nombre
            this._apellido = apellido
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
            const persona = new Persona(this._nombre, this._apellido)
            persona._direcciones = new Set(this._direcciones)
            persona._telefonos = new Set(this._telefonos)
            persona._vehiculos = new Set(this._vehiculos)

            return persona
        }
    }
}