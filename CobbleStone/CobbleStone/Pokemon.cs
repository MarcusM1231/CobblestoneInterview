namespace CobbleStone
{
    public class Pokemon
    {
        public string Name { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public int Total { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpAtk { get; set; }
        public int SpDef { get; set; }
        public int Speed { get; set; }
        public int Generation { get; set; }
        public bool Legendary { get; set; }


        public void PokemonValidation(Pokemon pokemon, List<Pokemon> list)
        {

            //Checks if a pokemon is a legend or ghost type -- if not do nothing and dont add to list
            if(pokemon.Legendary == false || pokemon.Type1 == "Ghost")
            {
                //checks for type to either add or lower stats
                switch (pokemon.Type1)
                {
                    case "Steel":
                        pokemon.HP *= 2;
                        break;
                    case "Fire":
                        pokemon.Attack -= (int)(pokemon.Attack * .10);
                        break;
                    case "Bug":
                        //Check if bug and flying (not sure if should have checked flying and bug)
                        if (pokemon.Type2 == "Flying")
                        {
                            pokemon.Attack += (int)(pokemon.Attack * .10);
                        }
                        break;
                }

                //Checks each char in their name if it is not a g +5 defense
                if (pokemon.Name[0] == 'G')
                {
                    for (int i = 1; i < pokemon.Name.Length; i++)
                    {
                        if (pokemon.Name[i] != 'g' || pokemon.Name[i] != 'G')
                        {
                            pokemon.Defense += 5;
                        }
                        
                    }
                }

                //Adds the pokemon to the list
                list.Add(pokemon);

            }
        }
    }
}
