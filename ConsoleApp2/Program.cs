using PokemonCommon;
using PokemonCommon.Characters;
using PokemonCommon.Enums;
using PokemonCommon.Pokemons;
using PokemonCommon.Pokemons.Attacks;


Trainer ash = new Trainer("Ash");

Pokemon sobble = new Pokemon("Sobble", 50, PokeTypes.Water);
Pokemon charmander = new Pokemon("Charmander", 60, PokeTypes.Fire);

charmander.LearnAttack(InstancedAttacks.ember, 0);
charmander.LearnAttack(InstancedAttacks.scratch, 1);
charmander.LearnAttack(InstancedAttacks.baddyBad, 2);
charmander.LearnAttack(InstancedAttacks.bugBite, 3);

sobble.LearnAttack(InstancedAttacks.waterGun, 0);
sobble.LearnAttack(InstancedAttacks.tackle, 1);
sobble.LearnAttack(InstancedAttacks.ember, 2);
sobble.LearnAttack(InstancedAttacks.bugBite, 3);


BattleEngine.PerformBattle(sobble, charmander);