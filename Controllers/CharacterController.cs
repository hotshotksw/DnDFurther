using DnD_Further.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Security.Claims;
using DnD_Further.Interfaces;
using Microsoft.AspNetCore.Authorization;

public class CharacterController : Controller
{
    private readonly HttpClient _httpClient;

    IDataAccessLayer dal;

    public CharacterController(IDataAccessLayer indal)
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://www.dnd5eapi.co/api/");

        dal = indal;
    }

    public IActionResult CharacterViewer()
    {
        return View(dal.GetCharacters());
    }

	[Authorize]
	[HttpGet]
    public IActionResult TempCreator()
    {
        return View();
    }

    [HttpPost]
    public IActionResult TempCreator(Character c)
    {
        if (ModelState.IsValid)
        {
            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dal.AddCharacter(c, userID);
            return RedirectToAction("CharacterViewer", "Character");
        }

        return View();
    }

    [HttpGet]
    public IActionResult Creator()
    {
        if (User.FindFirstValue(ClaimTypes.NameIdentifier) == null)
        {
            return RedirectToAction("Index", "Home");
        }
        return View(new Character());
    }

    [HttpPost]
    public IActionResult Creator(Character c)
    {
        
        if (ModelState.IsValid)
        {
            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dal.AddCharacter(c, userID);
            return RedirectToAction("CharacterViewer", "Character");
        }

        return View(c);
    }
    
    public async Task<IActionResult> GetSpell()
    {
        // Specify the spell you want to retrieve, for example, "acid-arrow"
        string spellName = "acid-arrow";

        // Make GET request to fetch spell information
        HttpResponseMessage response = await _httpClient.GetAsync($"spells");

        if (response.IsSuccessStatusCode)
        {
            // Deserialize the response content to your model
            string json = await response.Content.ReadAsStringAsync();
            var spell = JsonConvert.DeserializeObject<SpellList>(json);
            // Now 'spell' contains information about the specified spell
            // You can pass 'spell' to your view or do further processing
            return View(spell);
        }
        else
        {
            // Handle error here
            return View("Error");
        }
    }

    public async Task<IActionResult> GetClass(string className)
    {
        // Make GET request to fetch spell information
        HttpResponseMessage response = await _httpClient.GetAsync($"classes/{className}");

        if (response.IsSuccessStatusCode)
        {
            // Deserialize the response content to your model
            string json = await response.Content.ReadAsStringAsync();
            var clas = JsonConvert.DeserializeObject<Class>(json);
            // Now 'spell' contains information about the specified spell
            // You can pass 'spell' to your view or do further processing
            return View(clas);
        }
        else
        {
            // Handle error here
            return View("Error");
        }
    }

    public async Task<IActionResult> GetClassList()
    {
        // Make GET request to fetch spell information
        HttpResponseMessage response = await _httpClient.GetAsync($"classes");

        if (response.IsSuccessStatusCode)
        {
            // Deserialize the response content to your model
            string json = await response.Content.ReadAsStringAsync();
            var Classes = JsonConvert.DeserializeObject<ClassList>(json);
            // Now 'spell' contains information about the specified spell
            // You can pass 'spell' to your view or do further processing
            return View(Classes);
        }
        else
        {
            // Handle error here
            return View("Error");
        }
    }

    public async Task<IActionResult> GetRace(string raceName)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"races/{raceName}");

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();
            var rac = JsonConvert.DeserializeObject<Class>(json);
            return View(rac);
        }
        else
        {
            return View("Error");
        }
    }

    public async Task<IActionResult> GetRaceList()
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"races");
        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();
            var Races = JsonConvert.DeserializeObject<RaceList>(json);
            return View(Races);
        }
        else
        {
            return View("Error");           
        }
    }

    public IActionResult ChangeStat(Character c, string statToChange, int amount)
    {
        switch (statToChange)
        {
            case "strength":
                c.Strength += amount;
                break;
        }
        return RedirectToAction("Creator");
    }

    [HttpPost]
    public IActionResult Search(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            return View("CharacterViewer", dal.GetCharacters());
        }

        return View("CharacterViewer", dal.GetCharacters()
            .Where(x => x.Name!.ToLower().Contains(key.ToLower())));
    }

    #region EDIT/DELETE/SEARCH FAKE FUNCTIONS



    public IActionResult Edit()
    {
        return RedirectToAction("Index", "Home");
    }
    
    public IActionResult Delete()
    {
        return RedirectToAction("Index", "Home");
    }
    
    
    #endregion
}