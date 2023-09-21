using PokemonCommon.Enums;
using PokemonCommon.Pokemons;
using PokemonCommon.Pokemons.Attacks;

namespace PokemonCommon;

public static class BattleEngine
{
    public static void PerformBattle(Pokemon pokemon1, Pokemon pokemon2)
    {
        Random rng = new Random();
        int turn = 0;
        bool adjustedTurnOrderForSpeed = false;
        Pokemon activePokemon = pokemon1;
        Pokemon activePokemon2 = pokemon2;
        while (pokemon1.HealthPoints > 0 && pokemon2.HealthPoints > 0)
        {
            if (pokemon1.Speed > pokemon2.Speed && adjustedTurnOrderForSpeed == false)
            {
                turn = 1;
                adjustedTurnOrderForSpeed = true;
            }
            if (turn % 2 == 0)
            {
                BattleUi.DisplayStartOfRound(pokemon1, pokemon2, true);
                var selectedAttack = int.Parse(Console.ReadKey().KeyChar.ToString());
                BattleUi.DisplayRoundResult(pokemon1, pokemon2, selectedAttack);
                turn++;
                continue;
            }

            if (turn % 2 != 0)
            {
                BattleUi.DisplayStartOfRound(pokemon2, pokemon1, false);
                int selectedAttack = rng.Next(0, 4);
                BattleUi.DisplayRoundResult(pokemon2, pokemon1, selectedAttack);
                turn++;
                continue;
            }
        }

        if (pokemon1.HealthPoints <= 0)
        {
            Console.WriteLine($"The winner is {pokemon2.Name}!");
        }
        if (pokemon2.HealthPoints <= 0)
        {
            Console.WriteLine($"The winner is {pokemon1.Name}!");
        }

        Console.ReadKey();
    }
    // Detta är en statisk metod. Statiska metoder anropas via typen och inte via objekt.
    public static void MakeAttack(Pokemon target, Attack attack, string attacker)
    {
        Effectiveness effectiveness = CheckEffectiveness(target.Types.ToArray(), attack.Type);

        BattleUi.DisplayDamageEffectiveness(effectiveness, attack.Name, attacker);
        double modifier = (double)effectiveness / 100f;

        target.HealthPoints -= attack.Damage*modifier;
    }

    public static Effectiveness CheckEffectiveness(PokeTypes[] targetTypes, PokeTypes attackType)
    {
        switch (attackType)
        {
            case PokeTypes.Normal:
                return NormalAttackEffectiveness(targetTypes);
            case PokeTypes.Fire:
                return FireAttackEffectiveness(targetTypes);
            case PokeTypes.Water:
                return WaterAttackEffectiveness(targetTypes);
            case PokeTypes.Grass:
                return GrassAttackEffectiveness(targetTypes);
            case PokeTypes.Electric:
                return ElectricAttackEffectiveness(targetTypes);
            case PokeTypes.Ice:
                return IceAttackEffectiveness(targetTypes);
            case PokeTypes.Fighting:
                return FightingAttackEffectiveness(targetTypes);
            case PokeTypes.Poison:
                return PoisonAttackEffectiveness(targetTypes);
            case PokeTypes.Ground:
                return GroundAttackEffectiveness(targetTypes);
            case PokeTypes.Flying:
                return FlyingAttackEffectiveness(targetTypes);
            case PokeTypes.Psychic:
                return PsychicAttackEffectiveness(targetTypes);
            case PokeTypes.Bug:
                return BugAttackEffectiveness(targetTypes);
            case PokeTypes.Rock:
                return RockAttackEffectiveness(targetTypes);
            case PokeTypes.Ghost:
                return GhostAttackEffectiveness(targetTypes);
            case PokeTypes.Dragon:
                return DragonAttackEffectiveness(targetTypes);
            case PokeTypes.Dark:
                return DarkAttackEffectiveness(targetTypes);
            case PokeTypes.Steel:
                return SteelAttackEffectiveness(targetTypes);
            case PokeTypes.Fairy:
                return FairyAttackEffectiveness(targetTypes);
            default:
                return Effectiveness.Normal;
        }
    }

    #region EffectivenessChecks
    private static Effectiveness FairyAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Fire))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Poison))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Fighting))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Dragon))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Dark))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness SteelAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Fire))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Water))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Electric))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Ice))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Rock))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Fairy))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness DarkAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Fighting))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Dragon))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Fairy))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Psychic))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Ghost))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness DragonAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Fairy))
            return Effectiveness.None;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Dragon))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness GhostAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Normal))
            return Effectiveness.None;
        if (targetTypes.Contains(PokeTypes.Dark))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Psychic))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Ghost))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness RockAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Fighting))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Ground))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Fire))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Ice))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Flying))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Bug))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness BugAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Fire))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Fighting))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Poison))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Flying))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Ghost))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Fairy))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Grass))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Psychic))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Dark))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness PsychicAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Dark))
            return Effectiveness.None;
        if (targetTypes.Contains(PokeTypes.Psychic))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Fighting))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Poison))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness FlyingAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Electric))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Rock))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Grass))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Fighting))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Bug))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness GroundAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Flying))
            return Effectiveness.None;
        if (targetTypes.Contains(PokeTypes.Bug))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Grass))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Fire))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Electric))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Poison))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Rock))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness PoisonAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.None;
        if (targetTypes.Contains(PokeTypes.Poison))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Ground))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Rock))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Ghost))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Grass))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Fairy))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness FightingAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Ghost))
            return Effectiveness.None;
        if (targetTypes.Contains(PokeTypes.Poison))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Flying))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Psychic))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Bug))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Fairy))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Normal))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Ice))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Rock))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Dark))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness IceAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Fire))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Water))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Ice))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Grass))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Ground))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Flying))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Ghost))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness ElectricAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Ground))
            return Effectiveness.None;
        if (targetTypes.Contains(PokeTypes.Electric))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Grass))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Dragon))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Water))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Flying))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness GrassAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Fire))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Grass))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Poison))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Flying))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Bug))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Dragon))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Water))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Ground))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Rock))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness WaterAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Water))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Grass))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Dragon))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Fire))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Ground))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Rock))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness FireAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Fire))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Water))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Rock))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Dragon))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Grass))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Ice))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Bug))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness NormalAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Ghost))
            return Effectiveness.None;
        if (targetTypes.Contains(PokeTypes.Rock))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.NotVery;

        return Effectiveness.Normal;
    }

    #endregion
}