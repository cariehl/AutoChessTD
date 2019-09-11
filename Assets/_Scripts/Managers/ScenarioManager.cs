using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Data;
using AutoChessTD.Events;

namespace AutoChessTD {

    public class ScenarioManager {
        private static readonly float WaitTimeBetweenRounds = 2.0f;

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

            GameManager.Instance.Grid.Initialize(CurrentScenario.GridSize, CurrentScenario.CellSize);

            roundRunner = new RoundRunner(CurrentScenario);
            roundRunner.OnRoundEnded += OnRoundEnded;
            roundRunner.StartScenario();
        }

        private void OnRoundEnded(bool success) {
            var nextRound = roundRunner.PeekNextRound();
            if (nextRound == null) {
                EndScenario();
                return;
            }

            GameManager.Instance.StartCoroutine(StartNextRound());
        }

        private void EndScenario() {
            Debug.Log("Scenario Ended");
            roundRunner.OnRoundEnded -= OnRoundEnded;

            bool success = roundRunner.HasCompletedScenario();
            roundRunner = null;

            EventManager.ScenarioEnded(success);
        }

        private IEnumerator StartNextRound() {
            yield return new WaitForSeconds(WaitTimeBetweenRounds);

            roundRunner.StartNextRound();
        }
    }
}
