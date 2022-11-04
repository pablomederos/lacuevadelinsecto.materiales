import 'package:patron_prototype/app/app_widget.dart';
import 'package:patron_prototype/models/automovil.dart';
import 'package:patron_prototype/models/tipos_de_auto.dart';

var suvProto = SUV(7, rural: false, marca: 'Lifan', modelo: 'X7', precio: 21000.0);

cargarAutos(List<AutoWidget> lista) {
  suvProto.calcularImpuesto(20);

  AutomovilPrototype expUruguay = suvProto.clone() as AutomovilPrototype;

  lista.add(
      AutoWidget(marca: expUruguay.marca, modelo: expUruguay.modelo, precio: expUruguay.precio,
          otraDescripcion: 'Fue exportado a Uruguay, y paga un impuesto de U\$S ${expUruguay.impuesto}. '
              '\nAdemás ${(expUruguay as SUV).rural ? "Sí" : "No"} es modelo rural, '
              'y tiene ${expUruguay.plazas} plazas de asientos.'
      )
  );

  SUV expChile = suvProto.clone() as SUV; // Me ahorré el cálculo del impuesto
  expChile.rural = true;

  lista.add(
      AutoWidget(marca: expChile.marca, modelo: expChile.modelo, precio: expChile.precio,
          otraDescripcion: 'Fue exportado a Chile, y paga un impuesto de U\$S ${expChile.impuesto}. '
              '\nAdemás ${expChile.rural ? "Sí" : "No"} es modelo rural, '
              'y tiene ${expChile.plazas} plazas de asientos.'
      )
  );

  SUV expArgentina = suvProto.clone() as SUV;
  expArgentina.calcularImpuesto(10);
  expArgentina.plazas = 5;

  lista.add(
      AutoWidget(marca: expArgentina.marca, modelo: expArgentina.modelo, precio: expArgentina.precio,
          otraDescripcion: 'Fue exportado a Argentina, y paga un impuesto de U\$S ${expArgentina.impuesto}. '
              '\nAdemás ${expArgentina.rural ? "Sí" : "No"} es modelo rural, '
              'y tiene ${expArgentina.plazas} plazas de asientos.'
      )
  );
}