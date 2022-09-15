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
     * Un Singleton nos obliga a tener la misma instancia de un objeto
     * durante toda la ejecución de nuestro programa, y previene la
     * creación de nuevas intancias del mismo tipo.
     */


    // Creamos una función autoejecutada de Javascript (() =>)()
    const nuestroSingleton = (() => {
        /** 
         * Dentro de esta función tendremos
         * los mismos componentes que en una clase normal 
         * */

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
    })()

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
    const object1 = nuestroSingleton // innecesario, ya que no usamos la palabra reservada 'new'
    createdAt1 = object1.getDate()

    // Retraso la asignación de una nueva referencia
    // a mi instancia para simular un escenario real
    // 
    const promise = new Promise((resolve) => {
        setTimeout(() => {
            const object2 = nuestroSingleton // innecesario, ya que no usamos la palabra reservada 'new'
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