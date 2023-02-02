package dev.lacuevadelinsecto.proxy.proxyExample;

import dev.lacuevadelinsecto.inmemory.base.IInmemory;
import dev.lacuevadelinsecto.inmemory.data.InMemory;
import dev.lacuevadelinsecto.proxy.auth.Authorization;
import dev.lacuevadelinsecto.proxy.auth.User;

import java.util.ArrayList;

public class ProtectedDatabase implements IInmemory {

    private final Authorization authorization;
    private final IInmemory database;
    private final User user;

    public ProtectedDatabase(User user) {
        authorization = new Authorization(user);
        database = new InMemory();

        this.user = user;
    }

    @Override
    public <T> T Read(Class<T> target, int id) {
        return database.Read(target, id);
    }

    @Override
    public <T> ArrayList<T> List(Class<T> target, int offset, int total) {
        return database.List(target, offset, total);
    }

    @Override
    public <T> int Insert(T object) throws IllegalAccessException {
        if(authorization.canReadWriteAccess())
            return database.Insert(object);

        System.out.println("Usuario \"" + user.getUsername() + "\" no autorizado a insertar data.");
        return 0;
    }

    @Override
    public <T> T Update(T object) throws IllegalAccessException {
        if(authorization.canReadWriteAccess())
            return database.Update(object);

        System.out.println("Usuario \"" + user.getUsername() + "\" no autorizado a modificar data.");
        return null;
    }

    @Override
    public <T> boolean Delete(Class<T> object, int id) {
        if(authorization.canReadWriteAccess())
            return database.Delete(object, id);

        System.out.println("Usuario \"" + user.getUsername() + "\" no autorizado a eliminar data.");
        return false;
    }
}
