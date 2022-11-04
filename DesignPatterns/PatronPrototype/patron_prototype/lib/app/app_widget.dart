import 'dart:async';

import 'package:flutter/material.dart';
import 'package:patron_prototype/models/carga_de_autos.dart';

class AppWidget extends StatefulWidget {

  const AppWidget({Key? key}) : super(key: key);

  @override
  State<StatefulWidget> createState() => _AppWidget();

}

class _AppWidget extends State<AppWidget> {

  final _lista = <AutoWidget>[];

  _AppWidget() {
    Future.delayed(Duration.zero, populateList);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        decoration: const BoxDecoration(
          color: Color.fromRGBO(250, 10, 50, 0.5)
        ),
        child: Center(
          child: SingleChildScrollView(
            child: Column(
              children: _lista,
            ),
          ),
        ),
      ),
    );
  }

  Future<void> populateList() async {
    setState(() {
      cargarAutos(_lista);
    });
  }

}


class AutoWidget extends StatelessWidget {

  final double precio;
  final String marca;
  final String modelo;
  final String otraDescripcion;

  const AutoWidget({Key? key, required this.marca, required this.modelo, required this.precio, required this.otraDescripcion}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Text('Marca: $marca'),
        Text('Modelo: $modelo'),
        Text('Precio: $precio'),
        Text('Otra descipcion: $otraDescripcion'),
        Container(
          margin: const EdgeInsets.only(top: 30.0, bottom: 50.0),
          color: Colors.black,
          height: 2.0,
          width: 200.0,
        )
      ],
    );
  }

}