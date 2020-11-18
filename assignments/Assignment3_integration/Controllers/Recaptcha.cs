using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Assignment3_integration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Assignment3_integration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Recaptcha : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> VerifyRecaptcha([FromBody] RecaptchaVerification recaptcha)
        {

            if (recaptcha.Response == null)
                return BadRequest("Recaptcha response param is null");
            if(recaptcha.Secret == null)
                return BadRequest("Recaptcha secret param is null");

            HttpClient client = new HttpClient();

            var parameters = new Dictionary<string, string>
            {
                {"secret", recaptcha.Secret },
                {"response", recaptcha.Response}
            };

            var encodedContent = new FormUrlEncodedContent(parameters);

            //var payload = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var uri = new Uri("https://www.google.com/recaptcha/api/siteverify");

            HttpResponseMessage response = await client.PostAsync(uri, encodedContent);


            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }

            //Fix this.
            return NotFound("Something went wrong");

        }
    }
}
