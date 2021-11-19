using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
//using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace RestfulAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Recipes : ControllerBase
    {


       public AppDbContext _context;
        public Recipes (AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<RestfulAPI.Recipes> Get()
        {
            return _context.Recipes;
        }
        public JObject Post([FromBody] RestfulAPI.Recipes model)
        {
            JObject jarrresp = new JObject();
            RestfulAPI.Response resp = new Response();
            string json;
            if (string.IsNullOrEmpty(model?.title) || string.IsNullOrEmpty(model?.making_time) || string.IsNullOrEmpty(model?.serves) || string.IsNullOrEmpty(model?.ingredients) || (model?.cost == null))
            {
                
                resp.message = "Recipe creation failed!";
                resp.required = "title, making_time, serves, ingredients, cost";
                 json = JsonConvert.SerializeObject(resp, Formatting.None);
                //jarrresp = JArray.Parse(json);
            }
            _context.Recipes.Add(model);
            _context.SaveChanges();
            resp.message = "Recipe successfully created!";
            resp.recipe = _context.Recipes.Where(x => x.title == model.title).FirstOrDefault();
             json = JsonConvert.SerializeObject(resp, Formatting.None);
            jarrresp = JObject.Parse(json);
            return jarrresp;
        }
        public JObject Get(int id)
        {
            JObject jarrresp = new JObject();
            RestfulAPI.Response resp = new Response();
            string json;
            resp.message = "Recipe details by id";
            resp.recipe = _context.Recipes.Where(x => x.id == id).FirstOrDefault();
            json = JsonConvert.SerializeObject(resp, Formatting.None);
            jarrresp = JObject.Parse(json);
            return jarrresp;
        }
        public JObject Patch(int id, [FromBody] RestfulAPI.Recipes model)
        {
            JObject jarrresp = new JObject();
            RestfulAPI.Response resp = new Response();
            string json;
            var temp=_context.Recipes.Where(x => x.id == id).First();
            temp.title = model.title;
            temp.ingredients = model.ingredients;
            temp.making_time = model.making_time;
            temp.serves = model.serves;
            temp.cost = model.cost;
            _context.SaveChanges();
            resp.message = "Recipe successfully updated!";
            resp.recipe = temp;
            json = JsonConvert.SerializeObject(resp, Formatting.None);
            jarrresp = JObject.Parse(json);
            return jarrresp;
        } 
        public JObject Delete(int id)
        {
            JObject jarrresp = new JObject();
            RestfulAPI.Response resp = new Response();
            string json;
            var temp = _context.Recipes.Where(x => x.id == id).FirstOrDefault();
            if (temp == null)
            {
                resp.message = "No recipe found";
            }
            else
            {
                _context.Recipes.Remove(temp);
                _context.SaveChanges();
                resp.message = "Recipe successfully removed!";
            }
            json = JsonConvert.SerializeObject(resp, Formatting.None);
            jarrresp = JObject.Parse(json);
            return jarrresp;
        }
    }
}
