package dev.lacuevadelinsecto.proxy.models;

import dev.lacuevadelinsecto.inmemory.annotations.IdElement;

public class Person {

    @SuppressWarnings("unused")
    @IdElement
    private int Id;
    public String name;
    public String lastName;


    public Person(String name, String lastName)
    {
        this.name = name;
        this.lastName = lastName;
    }

    public int getId() {
        return Id;
    }

    @Override
    public String toString() {
        return "Person{" +
                "Id=" + Id +
                ", name='" + name + '\'' +
                ", lastName='" + lastName + '\'' +
                '}';
    }
}
