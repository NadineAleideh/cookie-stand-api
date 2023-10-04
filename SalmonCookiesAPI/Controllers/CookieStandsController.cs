using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalmonCookiesAPI.Data;
using SalmonCookiesAPI.Models;
using SalmonCookiesAPI.Models.DTO;
using SalmonCookiesAPI.Models.Interfaces;
using SalmonCookiesAPI.Models.Services;

namespace SalmonCookiesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookieStandsController : ControllerBase
    {
        private readonly ICookieStand _cookieStandService;


        public CookieStandsController(ICookieStand cookieStandService)
        {
            _cookieStandService = cookieStandService;
        }

        // GET: api/CookieStands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CookieStandViewDto>>> GetCookieStands()
        {
            var cookieStands = await _cookieStandService.GetAll();
            return Ok(cookieStands);
        }

        // GET: api/CookieStands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CookieStandViewDto>> GetCookieStand(int id)
        {
            var cookieStand = await _cookieStandService.GetById(id);

            if (cookieStand == null)
            {
                return NotFound();
            }

            return Ok(cookieStand);
        }

        // PUT: api/CookieStands/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCookieStand(int id, CookieStandDto toupdatecookieStand)
        {

            var cookieStand = await _cookieStandService.Update(id, toupdatecookieStand);

            if (cookieStand == null)
            {
                return NotFound();
            }
            return Ok(cookieStand);
        }



        // POST: api/CookieStands

        [HttpPost]
        public async Task<ActionResult<CookieStand>> PostCookieStand(CookieStandDto cookieStand)
        {
            await _cookieStandService.Create(cookieStand);
            return Ok();
        }

        // DELETE: api/CookieStands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCookieStand(int id)
        {
            _cookieStandService.Delete(id);
            return NoContent();
        }


    }
}
