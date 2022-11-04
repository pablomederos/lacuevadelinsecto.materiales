import 'i_prototype.dart';

abstract class AutomovilPrototype implements IPrototype {

  double precio;
  String marca;
  String modelo;
  var _impuesto = 0.0;

  AutomovilPrototype({required this.marca, required this.modelo, required this.precio});

  AutomovilPrototype.copy(AutomovilPrototype p)
      : marca = p.marca,
        modelo = p.modelo,
        precio = p.precio,
        _impuesto = p._impuesto; // este último es privado

  get impuesto => _impuesto;

  calcularImpuesto(int porcentaje) {
    _impuesto = (precio * porcentaje) / 100;
  }
}
