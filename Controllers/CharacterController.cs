using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

public class CharacterController : CharacterController
{
    private readonly HttpClient _httpClient;

    public CharacterController()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://www.dnd5eapi.co/api/");
    }

    public async Task<ActionResult> Create()
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

    public async Task<ActionResult> Create(Character character)
    {
        return RedirectToAction("Index", "Home");
    }
}