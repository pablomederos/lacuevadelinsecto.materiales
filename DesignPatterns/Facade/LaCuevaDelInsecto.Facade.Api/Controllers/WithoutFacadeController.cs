using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using LaCuevaDelInsecto.StarWarsApiConsumer;
using LaCuevaDelInsecto.StarWarsApiConsumer.Models;
using LaCuevaDelInsecto.Facade.Api.Models;

namespace LaCuevaDelInsecto.Facade.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WithoutFacadeController : ControllerBase
{
    private readonly SwapiClient _sWAPIClient;

    public WithoutFacadeController(SwapiClient sWAPIClient)
    {
        _sWAPIClient = sWAPIClient;
    }

    #region no DRY
    //[HttpGet("people/{id:int:min(1)}")]
    //[ActionName(nameof(GetPeople))]
    //public ActionResult<Character> GetPeople(uint id)
    //{
    //    try
    //    {
    //        if (
    //            RequestCache.GetCached<Character>(id) is var character
    //            && character != null
    //        )
    //        {
    //            return Ok(character);
    //        }

    //        character = _sWAPIClient.GetPeople(id);

    //        _ = RequestCache.TrySaveRequestCache<Character>(id, character);

    //        return character;
    //    }
    //    catch (Exception ex)
    //    {
    //        return new ObjectResult(ex)
    //        {
    //            StatusCode = StatusCodes.Status500InternalServerError
    //        };
    //    }
    //}

    //[HttpPost("people/")]
    //public ActionResult<Character> PostPeople(CharacterDTO character)
    //{
    //    try
    //    {
    //        // Esta no es la forma ideal pero cumple con el ejemplo
    //        Character model = character;

    //        uint id = (uint)new Guid().ToString().GetHashCode();

    //        // _sWAPIConsumer.Save(id, model); // Supuesto guardado en API

    //        _ = RequestCache.TrySaveRequestCache<Character>(
    //            id,
    //            model
    //        );

    //        return CreatedAtAction(nameof(GetPeople), new { id = id }, model);
    //    }
    //    catch (Exception ex)
    //    {
    //        return new ObjectResult(ex)
    //        {
    //            StatusCode = StatusCodes.Status500InternalServerError
    //        };
    //    }
    //}

    //[HttpGet("planet/{id:int:min(1)}")]
    //public ActionResult<Planet> GetPlanet(uint id)
    //{
    //    try
    //    {
    //        if (
    //            RequestCache.GetCached<Planet>(id) is var planet
    //            && planet != null
    //        )
    //        {
    //            return Ok(planet);
    //        }

    //        planet = _sWAPIClient.GetPlanet(id);

    //        _ = RequestCache.TrySaveRequestCache<Planet>(id, planet);

    //        return planet;
    //    }
    //    catch (Exception ex)
    //    {
    //        return new ObjectResult(ex)
    //        {
    //            StatusCode = StatusCodes.Status500InternalServerError
    //        };
    //    }
    //}

    //[HttpGet("starship/{id:int:min(1)}")]
    //public ActionResult<Starship> GetStarship(uint id)
    //{
    //    try
    //    {
    //        if (
    //            RequestCache.GetCached<Starship>(id) is var starship
    //            && starship != null
    //        )
    //        {
    //            return Ok(starship);
    //        }

    //        starship = _sWAPIClient.GetStarship(id);

    //        _ = RequestCache.TrySaveRequestCache<Starship>(id, starship);

    //        return starship;
    //    }
    //    catch (Exception ex)
    //    {
    //        return new ObjectResult(ex)
    //        {
    //            StatusCode = StatusCodes.Status500InternalServerError
    //        };
    //    }
    //}
    #endregion

    #region DRY
    [HttpGet("people/{id:int:min(1)}")]
    [ActionName(nameof(GetPeople))]
    public ActionResult<Character> GetPeople(uint id)
    {
        return GetElement(id, _sWAPIClient.GetPeople);
    }

    [HttpGet("planet/{id:int:min(1)}")]
    public ActionResult<Planet> GetPlanet(uint id)
    {
        return GetElement(id, _sWAPIClient.GetPlanet);
    }

    [HttpGet("starship/{id:int:min(1)}")]
    public ActionResult<Starship> GetStarship(uint id)
    {
        return GetElement(id, _sWAPIClient.GetStarship);
    }

    [HttpPost("people/")]
    public ActionResult<Character> PostPeople(CharacterDTO character)
    {
        try
        {
            // Esta no es la forma ideal pero cumple con el ejemplo
            Character model = (Character)character;

            uint id = (uint)new Guid().ToString().GetHashCode();

            // _sWAPIConsumer.Save(id, model); // Supuesto guardado en API

            _ = RequestCache.TrySaveRequestCache<Character>(
                id,
                model
            );

            return CreatedAtAction(nameof(GetPeople), new { id = id }, model);
        }
        catch (Exception ex)
        {
            return new ObjectResult(ex)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }

    private ActionResult<T> GetElement<T>(uint id, Func<uint, T> getStarWarsElement)
    {
        try
        {
            if (
                RequestCache.GetCached<T>(id) is var element
                && element != null
            )
            {
                return Ok(element);
            }

            element = getStarWarsElement(id);

            RequestCache.TrySaveRequestCache<T>(id, element);

            return element;
        }
        catch (Exception ex)
        {
            return new ObjectResult(ex)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
    #endregion
}



