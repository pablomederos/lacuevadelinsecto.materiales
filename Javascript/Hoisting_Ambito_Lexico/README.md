# Hoisting:

```javascript
Saludar();


function Saludar() {
    console.log(nombre);
    console.log(edad);
 
    var nombre = "Gabriel";
    let edad = 34;
}
```


**DESCRIPCIÓN** - La declaración de las variables con var, let y const, y la declaración de funciones se elevan hasta lo más alto del ámbito en el que se ejecutan.


**¿Qué es elevarse?**
Básicamente, que al momento de crearse el ámbito, se reserva el espacio de memoria para dicha variable.

En el caso de “**var**”, estas además de elevarse, se inicializan con el tipo primitivo “**undefined**”, y no es hasta que de forma imperativa se le indique a var qué valor tendrá, qué este realmente tendrá un valor.

**undefined** es un tipo primitivo que existe en el scope global (es accesible desde cualquier parte del código). Se refiere a que aún no se ha asignado nada a esa variable. Es similar a **null** en otros lenguajes, pero en Javascript **null** es de tipo **object** y **undefined** es de tipo **undefined**. Dicho de otro modo **null** es un objeto, y **undefined** es un valor primitivo que le indica al stack que no hay una referencia utilizable.

**¿por qué let y const devuelven una excepción al ser declarados después de donde se espera su ejecución, pero no así con var?**

El motivo es que cualquier variable declarada con “**var**” además de ser elevada, es considerada una propiedad de ámbito, y como tal, cualquier propiedad de un objeto que no haya sido inicializada devuelve el valor undefined.

Sin embargo, **let** y **const** le dicen al compilador que esas variables también existen en ese ámbito, pero que no se les puede utilizar hasta su declaración e inicialización imperativa. Entonces **let** y **const** tendrán un valor solo después de que se llegue a la declaración de forma imperativa, o una asignación imperativa.
En otras palabras **let** y **const** sí son elevadas pero solo para conocimiento del compilador, y no para su uso, y a esto se le conoce como **Zona Muerta Temporal**.
Es como si mamá y papá deciden tener un hijo, pero mamá todavía no está embarazada, por lo que no pueden decidir de qué color pintar el cuarto, o el color de la ropa, ya que no saben si es nena o varón, y pueden elegir nombres pero no asignarlos. El ejemplo puede sonar primitivo, pero es demostrativo.

Por otra parte, las funciones se elevan completamente, lo que quiere decir que a diferencia de var, let y const, el cuerpo de las funciones está completamente asignado a la memoria reservada para ella en el momento de creación de ese ámbito.



Otro ejemplo del hoisting sería:


```javascript
var x = 5;

(function () {
   console.log("x:", x);
   var x = 10;
   console.log("x:", x);
}());

console.log(a);
```

En este ejemplo, y cómo explicaba anteriormente, dentro de la función, “**x**” se eleva en ese ámbito. La función ignora que en el ámbito global se declaró también **x**; no es asunto suyo porque en su ámbito local existe otro **x**, y por eso mencionaba antes que las variables se elevan dentro de su ámbito léxico. Esto hace que en el primer **console.log** el resultado de **x** sea **undefined**. 

Internamente, el código quedaría así:



var x = 5;


```javascript
(function () {
   var x;
   console.log("x:", x);
   x = 10;
   console.log("x:", x);
}());

console.log(a);
```


Un ejemplo más complicado del Hoisting y una fuente de fallos es el uso de var en un for loop que ejecuta un método asíncrono usando el resultado de cada iteración.
Esto está también relacionado con la forma en la que funcionan el call stack y el event loop en Javascript, pero ese ya es otro tema.

```javascript
for (var index = 0; index < 10; index++) {

   setTimeout(() => {
       console.log(index);
   }, 1000);

   console.log(index);
}

```

console.log(index);

En este caso **var** se eleva como se esperaba por causa del **hoisting** y pasa a formar parte del objeto global, **setTimeout** va a esperar un segundo en ejecutarse por primera vez, y para entonces ya todas las vueltas del bucle **for** terminaron de iterarse, así que cuando se ejecute la primera iteración del **setTimeout** el for ya asignó el valor a esa variable en el objeto global 10 veces, y el **setTimeout** va a obtener el valor que var tiene en el momento de su primera ejecución.

Tengo que comentar aquí que en este caso hay otros responsables de este comportamiento, como el **Call Stack** y el **Event Loop**, pero en este caso su interacción con el resultado es casi insignificante.

Una forma de resolverlo sería decirle a la función anónima dentro del **setTimeout** qué valor debe utilizar en cada iteración:



```javascript
for (var index = 0; index < 10; index++) {

   setTimeout((value) => {
       console.log(value);
   }, 1000, index);

   console.log(index);
}

console.log(index);
```


Pero esto además de sumar más código para evaluar por parte del compilador, suma más código para leer por parte del programador, más código para entender, cuando en realidad lo podemos resolver con una característica que tiene el **ámbito léxico**.

Las variables declaradas con **var** pertenecen al **ámbito global**, salvo que se declaren dentro de una **función**, en cuyo caso, su alcance es de **función**.
Pero las declaraciones hechas con **const** y **let** tienen ámbito de bloque. Lo que quiere decir, que sin importar qué tipo de bloque sea, **función**, **for loop**, **bloque simple**, **while loop**, **if**, **else**, etc., **let** y **const** solo existirán en ese ámbito.

```javascript
for (let index = 0; index < 10; index++) {

   setTimeout(() => {
       console.log(index);
   }, 1000)

   console.log(index);
}
```

En este caso, el uso de **let** le dice al compilador que el ámbito en el que va a funcionar, es **dentro del bloque del for loop**, por lo tanto para el valor de cada iteración del loop, es como si se declarase una constante dentro del bloque del for loop para cada vuelta, aunque no es esto realmente lo que está sucediendo internamente.


Si querés tener el panorama completo, te invito a visitar el video en el que explico esto con ejemplos de código y mostrando este comportamiento en un ambiente que ilustra mucho mejor lo que se explicó.

[El video está aquí](https://www.youtube.com/watch?v=-2URoQUAM9w// "El video está aquí")

Para ver más videos de temas de programación que podrían serte útiles, visita el canal de YouTube: [La Cueva del Insecto](https://www.youtube.com/channel/UCXyx4LyjmuFEWqcg_agU2Ig "La Cueva del Insecto")
