using DnD_Further.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

public class CharacterController : Controller
{
    private readonly HttpClient _httpClient;

    public CharacterController()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://www.dnd5eapi.co/api/");
    }

    public async Task<IActionResult> Create()
    {
        var racesResponse = await _httpClient.GetAsync("races");
        var races = await racesResponse.Content.ReadAsAsync<IEnumerable<string>>();

        var classesResponse = await _httpClient.GetAsync("classes");
        var classes = await classesResponse.Content.ReadAsAsync<IEnumerable<string>>();

        var model = new CharacterViewModel
        {
            Races = races,
            Classes = classes
        };
        return View(model);

    }

    public async Task<IActionResult> Create(Character character)
    {
        return RedirectToAction("Index", "Home");
    }
}