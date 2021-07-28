using ChickenSim.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChickenSim.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChickenController : ControllerBase
    {
        ChickenSimContext db = new ChickenSimContext();

        public List<Chickens> GetChickens()
        {
            return db.Chickens.ToList();
        }

        [HttpGet("{id}")]
        public Chickens GetChicken(int id)
        {
            Chickens c = db.Chickens.Find(id);
            return c;
        }

        [Route("GetByFarm/{farmId}")]
        public List<Chickens> GetChickensByFarm(int farmId)
        {
            List<Chickens> output = db.Chickens.Where(x => x.FarmId == farmId).ToList();
            return output;
        }

        [Route("Farms")]
        public List<Farms> GetFarms()
        {
            return db.Farms.ToList();
        }

        [Route("Farms/{farmId}")]
        public Farms GetFarm(int farmId)
        {
            Farms f = db.Farms.Find(farmId);
            return f;
        }

        [HttpPost]
        [Route("AddChicken/n={name}&f={farmId}")]
        public void AddChicken(string name, int farmId)
        {
            Chickens c = new Chickens();
            Random rng = new Random();
            c.Name = name;
            c.Age = 1;
            c.FarmId = farmId;
            c.Smarts = rng.Next(1, 11);
            c.Strength = rng.Next(1, 11);
            c.Speed = rng.Next(1, 11);
            c.Luck = 1;

            string[] colors = { "red", "gray", "white", "black" };

            int pick = rng.Next(0, colors.Length);

            c.Color = colors[pick];

            db.Chickens.Add(c);
            db.SaveChanges();
        }

        [HttpPost("AddFarm/n={name}")]
        public void AddFarm(string name)
        {
            Farms f = new Farms();
            f.Name = name;
            f.Seeds = 100;

            db.Farms.Add(f);
            db.SaveChanges();
        }

        [HttpPut("ChangeSeed/farmId={id}&a={amount}")]
        public void ChangeSeeds(int id, int amount)
        {
            //Find the farm 
            Farms f = db.Farms.Find(id);

            //Increase its seeds 
            f.Seeds += amount;

            //Store and save the update farm model
            db.Farms.Update(f);
            db.SaveChanges();
        }

        [HttpPut("StatsUp/f={farmId}&c={chickenId}")]
        public void IncreaseStats(int farmId, int chickenId)
        {
            //Find both the farm and the chicken 
            Chickens c = db.Chickens.Find(chickenId);
            Farms f = db.Farms.Find(farmId);

            if(f.Id == c.FarmId)
            {
                f.Seeds--;
                db.Farms.Update(f);

                c.Age++;
                c.Smarts++;
                c.Speed++;
                c.Strength++;
                db.Chickens.Update(c);

                db.SaveChanges();

            }
        }
        
    }
}
