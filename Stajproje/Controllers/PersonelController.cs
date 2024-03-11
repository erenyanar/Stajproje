﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;


namespace Stajproje.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<PersonelController> _logger;

        public PersonelController(AppDbContext dbContext, ILogger<PersonelController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        private static readonly string[] Firstnames = new[]
        {
            "Eren","Emirhan","Ahmet","Ayşe","Adnan","Yağmur","Elasu","Efe","Mükayil","İpek"
        };


        private static readonly string[] Lastnames = new[]
        {
            "Yanar","Bektaş","Kaya","Demir","Yılmaz","İlban","Çiftçi","Hocaoğlu","Uran","Sel"
        };

        private static readonly string[] Usernames = new[]
        {
            "erenyanar","emranbektas","sadsaasddfa","fıjanjfıjdıfds","fojndafdd","a","b","c","d","f"
        };

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
                Firstname = Firstnames[Random.Shared.Next(Firstnames.Length)],
                Lastname = Lastnames[Random.Shared.Next(Lastnames.Length)],
                Username = Usernames[Random.Shared.Next(Usernames.Length)]

            })
            .ToArray();

        }

        [HttpPost("Getpersonel", Name = "Getpersonel")]
        public IEnumerable<Personel> Post([FromBody] PostRequestModel req)
        {
            if (req.Count <= 0)
            {
                return Enumerable.Empty<Personel>();
            }

            return Enumerable.Range(1, req.Count).Select(index => new Personel
            {
                PersonelId = Random.Shared.Next(0, 100),
                Firstname = Firstnames[Random.Shared.Next(Firstnames.Length)],
                Lastname = Lastnames[Random.Shared.Next(Lastnames.Length)],
                Username = Usernames[Random.Shared.Next(Usernames.Length)]

            })
            .ToArray();

        }


        [HttpGet("GetpersonelFromDb", Name = "GetpersonelFromDb")]
        public List<Personel> GetAllPersonel()
        {
            var personeller = _dbContext.Personels.ToList();
            return personeller;

        }

        [HttpPost("GetPersonelByNumber")]
        public IActionResult GetPersonelByNumber([FromBody] GetPersonelByNumberRequestModel req )
        {
            try
            {
                if (int.TryParse(req.personelNumberString, out int personelNumber))
                {
                    var selectedPersonel = _dbContext.Personels.FirstOrDefault(p => p.PersonelId == personelNumber);

                    if (selectedPersonel == null)
                    {
                        return NotFound(new { IsSuccess = false, Message = "Belirtilen personel numarasına sahip personel bulunamadı." });
                    }

                    var response = new
                    {
                        IsSuccess = true,
                        Message = $"Seçilen Personel: {selectedPersonel.Firstname} {selectedPersonel.Lastname}",
                        Personel = selectedPersonel
                    };

                    return Ok(response);
                }
                else
                {
                    return BadRequest(new { IsSuccess=false, Message = "Geçersiz sayı formatı." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { IsSuccess = false, Message = $"Bir hata oluştu: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Personel>> Post([FromBody] AddPersonelRequestModel person)
        {
            if (person == null)
            {
                return BadRequest("Personel object is null.");
            }
            Personel personel=new Personel();
            personel.Firstname = person.Firstname;
            personel.Lastname = person.Lastname;
            personel.Username = person.Username;

            _dbContext.Personels.Add(personel);
            await _dbContext.SaveChangesAsync();


            var response = new
            {
                IsSuccess = true,
                Message = $"Eklenen Personel: {personel.Firstname} {personel.Lastname}",
                Personel =personel
            };

            return Ok(response);
        }

    }
}


