(async () => { // IGNORAR ESTE CÓDIGO POR EL MOMENTO
    /** 
     * Estoy corriendo todo el código en una función autoejecutada 
     * para simular un contexto asíncrono, pero esto no afecta
     * de ninguna manera al Singleton.
     * El ejemplo solo requiere el código que se describe a continuación:
     * /




    /**
     * COMIENZA LA CREACIÓN DEL SINGLETON
     * 
     * Un Singleton nos permite tener la misma instancia de un objeto
     * durante toda la ejecución de nuestro programa, sin la necesidad
     * de controlarlo de forma manual, frecuentemente.
     */


    // Creamos una objeto literal que contendrá nuestra instancia
    // y cumplirá la función de namespace
    const namespace = {
        _instance: undefined, // Variable que usaremos para contener nuestra instancia
        getInstance: function () { // Método que creará la instancia
            if (!this._instance) { // Aquí se crea la instancia por única vez

                // Esto puede ser una función (que se comportará como una Clase),
                // o una Clase como tal, e incluso puede estar definido fuera de este Scope
                const MyClass = function () {

                    /** 
                     * Dentro de esta función tendremos
                     * los mismos componentes que en una clase normal
                     */

                    // Creamos nuestras variables normalmente
                    this.hora = new Date().getTime()

                    // Creamos nuestros métodos normalmente
                    const getDate = () => {
                        return this.hora
                    }

                    // Devolvemos los métodos de la instancia
                    return {
                        getDate
                    }
                }

                // Asignamos la referencia de nuestro objeto a la variable _instance
                // creandola con la palabra reservada 'new'
                this._instance = new MyClass()
            }

            return this._instance // Retornamos la instancia en el método 'getInstance'
        }
    }

    /**
     * FINALIZA LA CREACIÓN DEL SINGLETON
     */


    /**
     * COMIENZA LA PRUEBA DEL SINGLETON
     */

    // Probamos que todas las instancias son las mismas
    // en este caso guardando la fecha de creación
    let createdAt1 = undefined
    let createdAt2 = undefined

    // Ya no puedo usar la palabra 'new' debido a que en
    // lugar de acceder a un TIPO, accedo a una instancia.
    // Así que solo accederé a la referencia de mi 
    // variable inicial
    const object1 = namespace.getInstance() // Innecesario, ya que no usamos la palabra reservada 'new'
    createdAt1 = object1.getDate()

    // Retraso la asignación de una nueva referencia
    // a mi instancia para simular un escenario real
    // 
    const promise = new Promise((resolve) => {
        setTimeout(() => {
            const object2 = namespace.getInstance() // Innecesario, ya que no usamos la palabra reservada 'new'
            resolve(object2.getDate())
        }, 1000);
    })

    createdAt2 = await promise

    // Finalmente comparo el resultado
    console.log(
        `\tLa fecha de creación de object1 (${createdAt1}) 
    es igual a la de object2 (${createdAt2}):
    ${createdAt1 === createdAt2}`
    )

    /**
     * TERIMNA LA PRUEBA DEL SINGLETON
     */


})() // Finaliza la función que ejecuta todo el código