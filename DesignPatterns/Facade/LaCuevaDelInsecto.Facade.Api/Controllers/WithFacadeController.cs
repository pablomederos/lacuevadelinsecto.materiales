using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using LaCuevaDelInsecto.StarWarsApiConsumer;
using LaCuevaDelInsecto.StarWarsApiConsumer.Models;
using LaCuevaDelInsecto.Facade.Api.Models;

namespace LaCuevaDelInsecto.Facade.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WithFacadeController : ControllerBase
{
    private readonly SwapiFacade _sWAPIFacade;

    public WithFacadeController(SwapiFacade sWAPIFacade)
    {
        _sWAPIFacade = sWAPIFacade;
    }

    #region DRY
    [HttpGet("people/{id:int:min(1)}")]
    [ActionName("GetPeopleFacade")]
    public ActionResult<Character> GetPeople(uint id)
    {
        return GetElement<Character>(id);
    }

    [HttpGet("planet/{id:int:min(1)}")]
    public ActionResult<Planet> GetPlanet(uint id)
    {
        return GetElement<Planet>(id);
    }

    [HttpGet("starship/{id:int:min(1)}")]
    public ActionResult<Starship> GetStarship(uint id)
    {
        return GetElement<Starship>(id);
    }

    [HttpPost("people/")]
    public ActionResult PostPeople(CharacterDTO character)
    {
        try
        {
            Character model = (Character)character;
            uint id = _sWAPIFacade.Save<Character>(model);

            return CreatedAtAction("GetPeopleFacade", new { id = id }, model);
        }
        catch (Exception ex)
        {
            return new ObjectResult(ex)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }

    private ActionResult<T> GetElement<T>(uint id)
    {
        try
        {
            return _sWAPIFacade.Get<T>(id);
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



