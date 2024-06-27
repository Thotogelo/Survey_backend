using Microsoft.AspNetCore.Mvc;
using Survey_backend.Model;
using Survey_backend.Service;

namespace Survey_backend.Controller;

[ApiController]
[Route("api/[controller]")]
public class SurveyController : ControllerBase
{
    private readonly SurveyRepository _surveyRepository;

    public SurveyController(SurveyRepository surveyRepository)
    {
        _surveyRepository = surveyRepository;
    }

    [HttpPost]
    public IActionResult CreateSurvey([FromBody] SurveyDTO surveyDTO)
    {
        try
        {
            _surveyRepository.CreateSurvey(surveyDTO);
            return Ok("Survey created successfully");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public IActionResult GetSurveys(string type)
    {
        try
        {
            var surveys = _surveyRepository.GetByType(type);
            return Ok(surveys);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}