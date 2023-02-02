package dev.lacuevadelinsecto.proxy.app;

import dev.lacuevadelinsecto.inmemory.base.IInmemory;
import dev.lacuevadelinsecto.proxy.models.Person;

import java.util.List;

public class App {

    private final DbService dbService;

    public App(IInmemory database) {
        dbService = new DbService(database);

        runDummySteps();
    }

    private void runDummySteps() {

        new Thread(() -> {

            // 1.
            InsertarDataUI();
            // 2.
            ListarDataUI();
            // 3.
            ActualizarDataUI();
            // 4.
            ListarDataUI();
            // 5.
            EliminarDataUI();
            // 6.
            ListarDataUI();

        }).start();
    }

    /**
     * UI Methods
     */

    private void InsertarDataUI() {
        System.out.println("Insertando data ->");
        boolean result = dbService.insertData();

        if(result)
        {
            for (int second = 0; second < 6; second ++)
                try {
                    System.out.print(".");
                    Thread.sleep(250);
                } catch (InterruptedException e) {
                    throw new RuntimeException(e);
                }

            System.out.println("\nData insertada correctamente");
        }
    }
    private void ListarDataUI() {
        System.out.println("\n\nListando Data ->");

        List<Person> results;
        if(!(results = dbService.listData()).isEmpty())
        {
            results.forEach(person -> {
                try {
                    Thread.sleep(1000);
                } catch (InterruptedException e) {
                    throw new RuntimeException(e);
                }
                System.out.println("\t data:" + person.getId() + " " + person);
            });
            System.out.println("\nSe imprimieron todos los resultados.");
        }
        else
            System.out.println("\nNo hay resultados para mostrar.");

    }
    private void ActualizarDataUI() {
        System.out.println("\n\nActualizando el usuario con Id 1 ->");
        boolean result = dbService.updateData(1, "Pablo", "Caballero");

        if(result)
        {
            for (int second = 0; second < 6; second ++)
                try {
                    System.out.print(".");
                    Thread.sleep(250);
                } catch (InterruptedException e) {
                    throw new RuntimeException(e);
                }

            System.out.println("\nUsuario Actualizado correctamente.");
        }
        else
            System.out.println("No se pudo actulizar nada.");
    }
    private void EliminarDataUI() {
        System.out.println("\n\nEliminando Persona con id 2 ->");
        dbService.deleteData(2);
        for (int second = 0; second < 6; second ++)
            try {
                System.out.print(".");
                Thread.sleep(250);
            } catch (InterruptedException e) {
                throw new RuntimeException(e);
            }
        System.out.println("\nUsuario Eliminado correctamente.");
    }

}
