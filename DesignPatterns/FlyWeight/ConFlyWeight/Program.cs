using LaCuevaDelInsecto.ConFlyWeight.Models;
using LaCuevaDelInsecto.ConFlyWeight;

// Con fly weight

FakeRepository fakeRepository = new ();

List<IntrinsecCarData> cars = fakeRepository.GetCars(10_000);

_ = 0;