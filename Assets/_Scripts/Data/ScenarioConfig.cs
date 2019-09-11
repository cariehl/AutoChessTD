using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Units.Minions;

namespace AutoChessTD.Data {
    /// <summary>
    /// Represents a single instance of a game.  Contains specifc game configs and rounds
    /// </summary>
    [CreateAssetMenu(fileName = "GameData", menuName = "AutoChessTD/New Scenario Config", order = 0)]
    [Serializable]
    public class ScenarioConfig : ScriptableObject {

        public ScenarioConfig() { }

        /// <summary>
        /// Name of the scene to load the config into
        /// A blank name will load the default scene
        /// </summary>
        public string SceneName;

        /// <summary>
        /// Name of the Game
        /// </summary>
        public string DisplayName;

        /// <summary>
        /// Height and width of Grid corresponding to number of cells to spawn
        /// </summary>
        public Vector2 GridSize = new Vector2(20, 20);

        /// <summary>
        /// Size of a single grid cell
        /// </summary>
        public float CellSize = 10f;

        /// <summary>
        /// Array of Round info. in a game
        /// </summary>
        public RoundConfig[] Rounds;
    }

    /// <summary>
    /// Represents a single round in a game
    /// </summary>
    [Serializable]
    public class RoundConfig {

        public RoundConfig() { }

        /// <summary>
        /// Name of the Round
        /// </summary>
        public string Name;

        // Array of minions to spawn in the round
        public MinionSpawnConfig[] Minions;
    }


    /// <summary>
    /// Represents a single minion to be spawned in a round
    /// </summary>
    [Serializable]
    public class MinionSpawnConfig {

        /// <summary>
        /// time in seconds after the start of a round that the minion should be spawned at
        /// </summary>
        public float SpawnTime;

        /// <summary>
        /// Configuration of minion to spawn
        /// </summary>
        public MinionConfiguration minionToSpawn;
    }

}
