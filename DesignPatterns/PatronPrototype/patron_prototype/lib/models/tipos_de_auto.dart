import 'package:patron_prototype/models/automovil.dart';
import 'package:patron_prototype/models/i_prototype.dart';
// Tipo de auto SUV
class SUV extends AutomovilPrototype {
  late bool rural;
  late int plazas;

  SUV(this.plazas,
      {this.rural = false, required String marca, required String modelo, required double precio})
      : super(marca: marca, modelo: modelo, precio: precio);

  SUV._copy(SUV p) : super.copy(p) {
    rural = p.rural;
    plazas = p.plazas;
  }

  @override
  IPrototype clone() {
    return SUV._copy(this); // La palabra reservada new no es necesaria en DART
  }
}

//------------------//
// Tipo de auto HATCH
class Hatch extends AutomovilPrototype {

  Hatch({required marca, required modelo, required precio})
      : super(marca: marca, modelo: modelo, precio: precio);

  Hatch._copy(Hatch p) : super.copy(p);

  @override
  Hatch clone() { // Principio de sustitución de LISKOV (L en SOLID)
    return Hatch._copy(this); // La palabra reservada new no es necesaria en DART
  }
}
