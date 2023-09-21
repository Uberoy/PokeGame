using PokemonCommon.Enums;
using PokemonCommon.Pokemons.Attacks;

namespace PokemonCommon.Pokemons
{
    public class Pokemon
    {
        #region Props

        // Property för health points 
        // Databehållaren "bakom" en property kallas för fält.
        private double _healthPoints = 100;
        public double HealthPoints
        {
            // Get är en metod som anropas när värdet på en property ska läsas
            get { return _healthPoints; }
            // Set är en metod som anropas när värdet på en property ska sättas
            set { _healthPoints = value; }
        }

        // Property för Name
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        // Property för Type
        private List<PokeTypes> _types = new List<PokeTypes>();
        public List<PokeTypes> Types
        {
            get { return _types; }
            set { _types = value; }
        }

        public Attack[] Attacks { get; } = new Attack[4];

        private int _speed;
        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }


        #endregion

        // Detta är en tom konstruktor, om ingen konstruktor deklareras så finns en sådan i alla klasser utan at tman behöver deklarera den.
        // En konstruktor är en metod som returnerar en ny instans av den typ den befinner sig i, returtyp och namn slås ihop.
        public Pokemon()
        {

        }

        // Detta är ytterligare en konstruktor, denna gång med parametrar. En klass kan ha 0 ... n konstruktorer, bara alla har olika signatur.
        public Pokemon(string name, int speed, params PokeTypes[] types)
        {
            _name = name;
            _speed = speed;
            _types = types.ToList();
        }

        public void LearnAttack(Attack attack, int attackIndex)
        {
            if (attackIndex > 3)
            {
                return;
            }

            if (attack == null)
            {
                return;
            }

            Attacks[attackIndex] = attack;
        }
    }
}
