using LottGameApi.Data;
using LottGameApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LottGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController: Controller
    {
        public IRepository Repository { get; }
        public BannerController(IRepository repository)
        {
            this.Repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Banner banner)
        {
            try
            {
                Repository.Add(banner);
                if (await Repository.SaveChangesAsync())
                {
                    return Ok(banner);
                }
            }
            catch(Exception ex)
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
                    var result_ = Repository.GetBannerByLanguage(language);
                    return Ok(result_);
                }

                var result = Repository.GetAllBanner();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
            return BadRequest();
        }
    }
}
