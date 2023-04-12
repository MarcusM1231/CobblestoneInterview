using CobbleStone;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CobbleStone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Pokemon> Get(string name = null, int? attack = null, int? defense = null, int? hp = null)
        {
            //Creates a list of pokemon
            List<Pokemon> pokemonList = new List<Pokemon>();

            //Parses the CSV file
            using (var reader = new StreamReader("Data\\pokemon.csv"))
            {
                //Skips the column line
                reader.ReadLine();

                //Starts parsing the fields until the end
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    var pokemon = new Pokemon
                    {
                        Name = values[1],
                        Type1 = values[2],
                        Type2 = values[3],
                        Total = int.Parse(values[4]),
                        HP = int.Parse(values[5]),
                        Attack = int.Parse(values[6]),
                        Defense = int.Parse(values[7]),
                        SpAtk = int.Parse(values[8]),
                        SpDef = int.Parse(values[9]),
                        Speed = int.Parse(values[10]),
                        Generation = int.Parse(values[11]),
                        Legendary = bool.Parse(values[12])
                    };

                    //Performs the filtering 
                    if ((string.IsNullOrEmpty(name) || pokemon.Name.ToLower().Contains(name.ToLower())) &&
                        (!attack.HasValue || pokemon.Attack == attack.Value) &&
                        (!defense.HasValue || pokemon.Defense == defense.Value) &&
                        (!hp.HasValue || pokemon.HP == hp.Value))
                    {
                        //Modifies the stats and includes/remove pokemon not wanted
                        pokemon.PokemonValidation(pokemon, pokemonList);
                    }

                    
                }
            }
            return pokemonList;
        }
    }
}
