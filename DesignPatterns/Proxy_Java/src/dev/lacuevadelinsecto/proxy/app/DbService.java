package dev.lacuevadelinsecto.proxy.app;

import dev.lacuevadelinsecto.inmemory.base.IInmemory;
import dev.lacuevadelinsecto.proxy.models.Person;

import java.util.List;

public class DbService {
    private final IInmemory database;

    public DbService(IInmemory database)
    {
        this.database = database;
    }

    public boolean insertData() {
        Person person1 = new Person("Gabriel", "Mederos");
        Person person2 = new Person("María", "Pérez");
        Person person3 = new Person("Aldo", "Tristán");

        int lastId = 0;
        try {
            database.Insert(person1);
            database.Insert(person2);
            lastId = database.Insert(person3);
        }
        catch (Exception ex) {
            System.out.println(ex.getMessage());
        }

        return lastId != 0;
    }

    public List<Person> listData() {
        return database.List(Person.class, 0, 100);
    }

    public boolean updateData(int id, String name, String lastName) {
        Person person = database.Read(Person.class, id);
        if (person != null)
        {
            person.name = name;
            person.lastName = lastName;
        }

        try {
            return database.Update(person) != null;
        } catch (IllegalAccessException e) {
            throw new RuntimeException(e);
        }
    }

    public void deleteData(int id) {
        database.Delete(Person.class, id);
    }
}
