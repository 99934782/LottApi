using LottGameApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace LottGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ButtonsLinksController: Controller
    {
        public IRepository Repository { get; }
        public ButtonsLinksController(IRepository repository)
        {
            this.Repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ButtonsLinksController button)
        {
            try
            {
                Repository.Add(button);
                if (await Repository.SaveChangesAsync())
                {
                    return Ok(button);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

            return BadRequest();
        }


        [HttpGet]
        public async Task<IActionResult> Get(string language)
        {
            try
            {
                if(language != "")
                {
                    var result_ = Repository.GetButtonsByLanguage(language);
                    return Ok(result_);
                }

                var result = Repository.GetAllButtons();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
            return BadRequest();
        }
    }
}
