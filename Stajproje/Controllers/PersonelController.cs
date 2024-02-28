using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace Stajproje.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {

        private static readonly string[] Adlar = new[]
        {
            "Eren","Emirhan","Ahmet","Ayşe","Adnan","Yağmur","Elasu","Efe","Mükayil","İpek"
        };


        private static readonly string[] Soyadlar = new[]
        {
            "Yanar","Bektaş","Kaya","Demir","Yılmaz","İlban","Çiftçi","Hocaoğlu","Uran","Sel"
        };

        private static readonly string[] Usernameler = new[]
        {
            "erenyanar","emranbektas","sadsaasddfa","fıjanjfıjdıfds","fojndafdd","a","b","c","d","f"
        };

        private readonly ILogger<PersonelController> _logger;

        public PersonelController(ILogger<PersonelController> logger)
        {
            _logger = logger;
        }


         [HttpGet("Getpersonel", Name = "Getpersonel")]
    public IEnumerable<Personel> Get([FromQuery] int count)
    {
        if (count <= 0)
        {
            return Enumerable.Empty<Personel>();
        }

        return Enumerable.Range(1, count).Select(index => new Personel
        {
            PersonelId = Random.Shared.Next(0, 100),
            Adi = Adlar[Random.Shared.Next(Adlar.Length)],
            Soyadi = Soyadlar[Random.Shared.Next(Soyadlar.Length)],
            Username = Usernameler[Random.Shared.Next(Usernameler.Length)]
        })
        .ToArray();
            
        }



    }
}
