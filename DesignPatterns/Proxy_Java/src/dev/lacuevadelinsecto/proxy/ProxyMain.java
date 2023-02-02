package dev.lacuevadelinsecto.proxy;

import dev.lacuevadelinsecto.inmemory.data.InMemory;
import dev.lacuevadelinsecto.proxy.app.App;
import dev.lacuevadelinsecto.proxy.auth.Authorization;
import dev.lacuevadelinsecto.proxy.auth.User;
import dev.lacuevadelinsecto.proxy.proxyExample.ProtectedDatabase;

public class ProxyMain {

    public static void main(String[] args) {

        // Utilizando app sin proxy
        /*new App(
                new InMemory()
        );*/


        // Utilizando app con proxy

        User user = new User("El Papa", Authorization.Role.READ_WRITE_USER);
        new App(
                new ProtectedDatabase(user)
        );
    }
}
