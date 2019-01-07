using System.Collections.Generic;
using DatingApp.Api.Models;
using Newtonsoft.Json;

namespace DatingApp.Api.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            this._context = context;
        }

        public void SeedUsers()
        {
            var countryData = System.IO.File.ReadAllText(@"Data/JSON/CountriesSeed.json");
            var coutries = JsonConvert.DeserializeObject<List<Country>>(countryData);

            var cityData = System.IO.File.ReadAllText(@"Data/JSON/CitySeed.json");
            var cities = JsonConvert.DeserializeObject<List<City>>(cityData);

            var genderData = System.IO.File.ReadAllText(@"Data/JSON/GendersSeed.json");
            var genders = JsonConvert.DeserializeObject<List<Gender>>(genderData);

            var userData = System.IO.File.ReadAllText(@"Data/JSON/UserSeed.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);

            _context.Countries.AddRange(coutries);
            _context.SaveChanges();
            _context.Cities.AddRange(cities);
            _context.SaveChanges();
            _context.Genders.AddRange(genders);
            _context.SaveChanges();
            foreach(var user in users)
            {
                byte[] passwordHash, passwordSalt;
                Security.Security.CreatePasswordHash("password", out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Username = user.Username.ToLower();

                _context.Users.Add(user);
            }
            _context.SaveChanges();
        }
    }
}