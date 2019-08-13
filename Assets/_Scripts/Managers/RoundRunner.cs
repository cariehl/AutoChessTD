using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Data;
using AutoChessTD.Units;
using AutoChessTD.Units.Minions;

namespace AutoChessTD {

    public class RoundRunner {

        public ScenarioConfig currentScenario;

        private int roundIndex = -1;
        public RoundConfig CurrentRound {
            get {
                if (roundIndex < 0 || roundIndex >= currentScenario.Rounds.Length)
                    return null;

                return currentScenario.Rounds[roundIndex];
            }
        }

        public List<MinionUnit> activeMinions = new List<MinionUnit>();       


        public RoundRunner(ScenarioConfig scenarioConfig) {
            currentScenario = scenarioConfig;
        }

        public void StartRound() {
            ++roundIndex;

            var round = CurrentRound;

            SpawnObjects();
        }

        public void SpawnObjects() {
            foreach (var minionSpawnConfig in CurrentRound.Minions) {
                var minion = GameManager.Instance.MinionFactory.SpawnMinion(minionSpawnConfig.minionToSpawn);
                activeMinions.Add(minion);
            }
        }
    }
}
