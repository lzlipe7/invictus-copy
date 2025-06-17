using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Invictus.API.Controllers
{
    [ApiController]
    [Route("generate-copy")]
    public class CopyController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public CopyController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CopyRequest data)
        {
            if (data == null)
                return BadRequest("Dados inválidos.");

            string prompt = $"Gere uma copy de marketing para o produto '{data.Produto}', com tom '{data.Tom}', voltada para o público '{data.Publico}'. Tipo de post: '{data.TipoPost}'.";

            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "user", content = prompt }
                }
            };

            var apiKey = "OPENAI_API_KEY";
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            request.Content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(responseJson);
                var copy = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();

                return Ok(new { copy });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao acessar OpenAI: {ex.Message}");
            }
        }
    }

    public class CopyRequest
    {
        public string Produto { get; set; }
        public string Tom { get; set; }
        public string Publico { get; set; }
        public string TipoPost { get; set; }
    }
}
