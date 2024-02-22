using DnD_Further.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Security.Claims;
using DnD_Further.Interfaces;

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
        HttpResponseMessage response = await _httpClient.GetAsync($"spells/{spellName}");

        if (response.IsSuccessStatusCode)
        {
            // Deserialize the response content to your model
            string json = await response.Content.ReadAsStringAsync();
            var spell = JsonConvert.DeserializeObject<SpellModel>(json);

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