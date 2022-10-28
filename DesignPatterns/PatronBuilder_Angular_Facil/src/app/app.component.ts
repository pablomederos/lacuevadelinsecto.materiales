import { Component } from '@angular/core';
import Direccion from './models/Direccion';
import IBuilder from './models/IBuilder';
import Persona from './models/Persona';
import Telefono from './models/Telefono';
import Vehiculo from './models/Vehiculo';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  personas: Persona[] = []

  builder2?: IBuilder

  constructor() {

    this.crearPersona1()

    this.crearPersona2()

    this.crearPersona3()
  }

  crearPersona1() {
    const p: Persona = new Persona
      .Builder('Gabriel', 'Mederos')
      .agregarVehiculo(
        new Vehiculo('Mercedez Benz', 'GLC Coupé')
      )
      .agregarVehiculo(
        'Nissan', { modelo: 'Sentra' }
      )
      .agregarDireccion(
        new Direccion('Av. Principal', '3544')
      )
      .agregarDireccion('Otra Avenida', {
          esquina: 'Otra esquina', puerta: "4B"
        }
      )
      .agregarTelefono(
        new Telefono("+59898123456", 'Domicilio Principal')
      )
      .build()

    this.personas.push(p)
  }


  crearPersona2() {
    this.builder2 = new Persona.Builder('Daniel', 'Carballo')

    const persona2: Persona = this.builder2
      .agregarVehiculo('Fiat', { modelo: 'Palio' })
      .agregarDireccion(new Direccion('Calle 1', '4321'))
      .agregarTelefono(new Telefono("+59898987654", 'Trabajo'))
      .build()

    this.personas.push(persona2)
  }

  crearPersona3() {

    const p =
      this.builder2?.agregarNombre("Miguel")
        .agregarApellido('Camejo')
        .agregarVehiculo('Chevrolet', { modelo: 'Camaro' })
        .build()

    if (p)
      this.personas.push(p)

  }

}
