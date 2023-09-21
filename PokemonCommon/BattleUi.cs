using PokemonCommon.Enums;
using PokemonCommon.Pokemons;

namespace PokemonCommon;

public static class BattleUi
{
    private static Dictionary<Effectiveness, string> messages = new Dictionary<Effectiveness, string>()
    {
        { Effectiveness.None, "It has no effect..." },
        { Effectiveness.NotVery, "It's not very effective..." },
        { Effectiveness.Normal, "" },
        { Effectiveness.Super, "It's super effective!" }
    };

    public static void DisplayDamageEffectiveness(Effectiveness effectiveness, string attackName, string attacker)
    {
        Console.CursorLeft = 0;
        Console.WriteLine($"{attacker} used {attackName}! {messages[effectiveness]}");
    }

    public static void DisplayStartOfRound(Pokemon pokemon1, Pokemon pokemon2, bool isPlayerPokemonTurn)
    {
        Console.Clear();

        if (isPlayerPokemonTurn)
        {
            UpdateHealth(pokemon2, pokemon1);
        }
        else
        {
            UpdateHealth(pokemon1, pokemon2);
            Console.CursorLeft = 32;
        }
        Console.WriteLine($"{pokemon2.Name}s turn!");

        Console.WriteLine();
        if (isPlayerPokemonTurn)
        {
            Console.WriteLine($"Select attack!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{pokemon2.Attacks[0].Name}: 0 - {pokemon2.Attacks[1].Name}: 1");
            Console.WriteLine($"{pokemon2.Attacks[2].Name}: 2 - {pokemon2.Attacks[3].Name}: 3");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    public static void DisplayRoundResult(Pokemon pokemon1, Pokemon pokemon2, int selectedAttack)
    {
        double currentHp = pokemon1.HealthPoints;
        BattleEngine.MakeAttack(pokemon1, pokemon2.Attacks[selectedAttack], pokemon2.Name);
        Console.WriteLine($"{pokemon1.Name} takes {currentHp - pokemon1.HealthPoints} damage from {pokemon2.Attacks[selectedAttack].Name}!");
        Console.ReadKey();
        Console.Clear();
    }

    public static void UpdateHealth(Pokemon pokemon1, Pokemon pokemon2)
    {
        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write($"{pokemon1.Name} health points: {pokemon1.HealthPoints}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" - ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"{pokemon2.Name} health points: { pokemon2.HealthPoints}     ");
        Console.ForegroundColor = ConsoleColor.White;
    }
}