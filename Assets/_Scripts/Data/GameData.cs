using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
