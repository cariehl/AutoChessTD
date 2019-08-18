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

        // returns true if a round has been started false if there was no round to start
        public bool StartRound() {
            ++roundIndex;

            var round = CurrentRound;
            if (round == null) {
                Debug.Log("Scenario Completed");
                return false;
            }

            SpawnObjects();

            return true;
        }

        public void SpawnObjects() {
            foreach (var minionSpawnConfig in CurrentRound.Minions) {
                var minion = GameManager.Instance.MinionFactory.SpawnMinion(minionSpawnConfig.minionToSpawn);
                activeMinions.Add(minion);
            }
        }

        public void OnMinionDeath(Unit unit) {
            unit.OnKilled -= OnMinionDeath;

            var minion = unit as MinionUnit;
            if (minion == null) return;

            activeMinions.Remove(minion);

            CheckRoundCompleted();
        }

        public void CheckRoundCompleted() {
            if (activeMinions.Count > 0) return;

            StartRound();
        }

        public void KillAll() {
            foreach (var minion in activeMinions) {
                minion.TakeDamage(minion.Health);
            }

            activeMinions.Clear();
            CheckRoundCompleted();
        }
    }
}
