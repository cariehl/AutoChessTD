using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Units.Minions;

namespace AutoChessTD.Data {

    public class GameData {

        private static GameData _instance;
        public static GameData Instance {
            get {
                if (_instance == null) {
                    _instance = new GameData();
                }

                return _instance;
            }
        }

        public List<ScenarioConfig> availableScenarios;

        public GameData() {            
            availableScenarios = new List<ScenarioConfig>(Resources.LoadAll<ScenarioConfig>("Scenarios"));
        }
    }

    /// <summary>
    /// Represents a single instance of a game.  Contains specifc game configs and rounds
    /// </summary>
    [CreateAssetMenu(fileName = "GameData", menuName = "AutoChessTD/New Scenario Config", order = 0)]
    [Serializable]
    public class ScenarioConfig : ScriptableObject {

        public ScenarioConfig () { }

        /// <summary>
        /// Name of the Game
        /// </summary>
        public string DisplayName;

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
