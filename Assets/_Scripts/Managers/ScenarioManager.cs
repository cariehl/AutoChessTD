using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Data;

namespace AutoChessTD {

    public class ScenarioManager {

        public GameData GameData;

        public RoundRunner roundRunner;

        public ScenarioConfig CurrentScenario { get; set; }

        public ScenarioManager() {
            GameData = GameData.Instance;
        }

        public void StartScenario() {
            if (CurrentScenario == null) {
                Debug.LogError("No Scenario Configuration found.");
                return;
            }

            roundRunner = new RoundRunner(CurrentScenario);
            roundRunner.StartRound();
        }
    }
}
