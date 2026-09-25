using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        
        private async Task<IActionResult> FetchDataAsync(string urlPath)
        {
            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://freecountries.vercel.app/api/v1/");
            client.DefaultRequestHeaders.Add("x-api-key", "demo-key-12345");

            var response = await client.GetAsync(urlPath);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return Content(data, "application/json");
            }

            return StatusCode((int)response.StatusCode, "Error fetching data from original API");
        }

    
        // GET /api/countries
        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            return await FetchDataAsync("countries");
        }

       
        // GET /api/countries/code/MM
        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetCountryByCode(string code)
        {
            return await FetchDataAsync($"countries/code/{code}");
        }

        // GET /api/countries/region/Asia
        [HttpGet("region/{region}")]
        public async Task<IActionResult> GetCountriesByRegion(string region)
        {
            return await FetchDataAsync($"countries/region/{region}");
        }

        
        // GET /api/countries/capital/Tokyo
        [HttpGet("capital/{capital}")]
        public async Task<IActionResult> GetCountriesByCapital(string capital)
        {
            return await FetchDataAsync($"countries/capital/{capital}");
        }

        // GET /api/countries/currency/MMK
        [HttpGet("currency/{currency}")]
        public async Task<IActionResult> GetCountriesByCurrency(string currency)
        {
            return await FetchDataAsync($"countries/currency/{currency}");
        }

       
        // GET /api/countries/language/mya
        [HttpGet("language/{lang}")]
        public async Task<IActionResult> GetCountriesByLanguage(string lang)
        {
            return await FetchDataAsync($"countries/language/{lang}");
        }

        // GET /api/countries/random
        [HttpGet("random")]
        public async Task<IActionResult> GetRandomCountry()
        {
            return await FetchDataAsync("countries/random");
        }

     
        // GET /api/countries/stats
        [HttpGet("stats")]
        public async Task<IActionResult> GetCountryStats()
        {
            return await FetchDataAsync("countries/stats");
        }

        
    //    // POST /api/countries/search-by-region
    //    [HttpPost("search-by-region")]
    //    public async Task<IActionResult> SearchByRegion([FromBody] CountrySearchRequest request)
    //    {
    //        if (string.IsNullOrWhiteSpace(request.Region))
    //        {
    //            return BadRequest(new CountrySearchResponse
    //            {
    //                IsSuccess = false,
    //                Message = "Region is required.",
    //                Data = null
    //            });
    //        }

    //        using var client = new HttpClient();
    //        client.BaseAddress = new Uri("https://freecountries.vercel.app/api/v1/");
    //        client.DefaultRequestHeaders.Add("x-api-key", "demo-key-12345");

    //        var response = await client.GetAsync($"countries/region/{request.Region}");

    //        if (response.IsSuccessStatusCode)
    //        {
    //            var dataString = await response.Content.ReadAsStringAsync();
    //            var dataObject = System.Text.Json.JsonSerializer.Deserialize<object>(dataString);

    //            return Ok(new CountrySearchResponse
    //            {
    //                IsSuccess = true,
    //                Message = "Successfully retrieved region data.",
    //                Data = dataObject
    //            });
    //        }

    //        return StatusCode((int)response.StatusCode, new CountrySearchResponse
    //        {
    //            IsSuccess = false,
    //            Message = "Failed to fetch data from external API.",
    //            Data = null
    //        });
    //    }
    //}

    //public class CountrySearchRequest
    //{
    //    public string Region { get; set; } = string.Empty;
    //}

    //public class CountrySearchResponse
    //{
    //    public bool IsSuccess { get; set; }
    //    public string Message { get; set; } = string.Empty;
    //    public object? Data { get; set; }
    //}
}