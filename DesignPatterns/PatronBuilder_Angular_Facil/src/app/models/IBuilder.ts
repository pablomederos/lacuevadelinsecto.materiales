import Direccion from "./Direccion"
import Telefono from "./Telefono"
import Vehiculo from "./Vehiculo"
import Persona from "./Persona"

export default interface IBuilder {
    agregarNombre(value: string): IBuilder

    agregarApellido(value: string): IBuilder

    agregarVehiculo(nombre: Vehiculo | string, opts?: Record<string, string>): IBuilder

    agregarDireccion(calle: Direccion | string, opts?: Record<string, string>): IBuilder

    agregarTelefono(numero: Telefono | string, opts?: Record<string, string>): IBuilder

    build(): Persona
}