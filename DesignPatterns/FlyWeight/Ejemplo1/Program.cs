using LaCuevaDelInsecto.SinFlyWeight;
using LaCuevaDelInsecto.SinFlyWeight.Models;

// Sin fly weight

FakeRepository repository = new ();

List<Car> cars = repository.GetCars(10_000);

_ = 0;