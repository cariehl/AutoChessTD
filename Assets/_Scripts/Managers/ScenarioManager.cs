using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Data;

namespace AutoChessTD {

    public class ScenarioManager {

        public GameData GameData;

        public RoundRunner roundRunner;

        public ScenarioManager() {
            GameData = GameData.Instance;
        }

        public void StartScenario(int scenarioIndex = 0) {

            if (scenarioIndex >= GameData.availableScenarios.Count) {
                Debug.LogError("No Scenario found with index: " + scenarioIndex);
                return;
            }

            var scenario = GameData.availableScenarios[scenarioIndex];

            roundRunner = new RoundRunner(scenario);
            roundRunner.StartRound();
        }
    }
}
