using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Data;
using AutoChessTD.Units;
using AutoChessTD.Events;
using AutoChessTD.Units.Minions;
using AutoChessTD.Units.HomeBases;

namespace AutoChessTD {

    public class RoundRunner {

        public delegate void BoolDelegate(bool success);
        public event BoolDelegate OnRoundEnded;

        public ScenarioConfig currentScenario;

        private int roundIndex = -1;
        public RoundConfig CurrentRound {
            get {
                return GetRound(roundIndex);
            }
        }

        public List<MinionUnit> activeMinions = new List<MinionUnit>();
        public HomeBaseUnit activeHomeBase;

        public bool isPlaying;
        public bool isScenarioActive;


        public RoundRunner(ScenarioConfig scenarioConfig) {
            currentScenario = scenarioConfig;
            isScenarioActive = true;
            isPlaying = false;

            EventManager.OnScenarioEnded += OnScenarioEnded;
            EventManager.OnRoundEnded += RoundEnded;
        }

        public void StartScenario() {
            Debug.Log("Scenario Started");
            isScenarioActive = true;

            StartNextRound();
        }

        // Assumes that there is a next round to start
        //   if the next round is null assume that scenario had no rounds to begin with
        public void StartNextRound() {
            Debug.Log("Round Started");
            isPlaying = true;
            ++roundIndex;

            if (CurrentRound == null) {
                CheckRoundCompleted();
                return;
            }
            SpawnObjects();
        }

        public RoundConfig PeekNextRound() {
            int nextIndex = roundIndex + 1;

            return GetRound(nextIndex);
        }

        public RoundConfig GetRound(int index) {
            if (index < 0 || index >= currentScenario.Rounds.Length)
                return null;

            return currentScenario.Rounds[index];
        }

        public void SpawnObjects() {
            activeHomeBase = GameManager.Instance.HomeBaseFactory.SpawnHomeBase(new Vector3(5, 0, 5));
            activeHomeBase.OnKilled += OnHomeBaseDestroyed;

            GameManager.Instance.Grid.HomeBase = activeHomeBase;

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

            EventManager.RoundEnded();
        }

        public void RoundEnded(bool success) {
            Debug.Log("Round Ended");
            CleanUp();
            isPlaying = false;
            OnRoundEnded?.Invoke(success);
        }

        public void OnScenarioEnded(bool success) {
            isScenarioActive = false;
            EventManager.OnScenarioEnded -= OnScenarioEnded;
            EventManager.OnRoundEnded -= RoundEnded;
        }

        private void OnHomeBaseDestroyed(Unit homeBase) {
            GameManager.Instance.Grid.HomeBase = null;
            EventManager.ScenarioEnded(false);
        }

        public bool HasCompletedScenario() {
            return !isPlaying && CurrentRound == GetRound(currentScenario.Rounds.Length - 1);
        }

        public void CleanUp() {
            if (activeHomeBase != null) {
                activeHomeBase.OnKilled -= OnHomeBaseDestroyed;
                GameObject.Destroy(activeHomeBase.gameObject);
                activeHomeBase = null;
            }

            foreach (var minion in activeMinions) {
                GameObject.Destroy(minion.gameObject);
            }

            activeMinions.Clear();
        }

        public void KillAll() {
            foreach (var minion in activeMinions) {
                minion.TakeDamage(minion.Health);
            }

            activeMinions.Clear();
            CheckRoundCompleted();
        }

        public void KillHomeBase() {
            activeHomeBase.TakeDamage(activeHomeBase.Health);
        }
    }
}
