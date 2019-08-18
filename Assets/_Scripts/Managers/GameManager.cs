using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Data;
using AutoChessTD.Factories;
using AutoChessTD.UI;

namespace AutoChessTD {
    public class GameManager : MonoBehaviour {
        private static GameManager _instance;

        public static GameManager Instance {
            get {
                if (_instance == null) {
                    _instance = FindObjectOfType<GameManager>();
                }

                if (_instance == null) {
                    Debug.LogError("GameManager must be added to scene.");
                }

                return _instance;
            }
        }

        [Header("Prefabs")]
        public MinionFactory minionFactoryPrefab;

        // Managers
        public GameData GameData;
        public ScenarioManager ScenarioManager;

        // Factories
        [HideInInspector]
        public MinionFactory MinionFactory;

        // UI Managers
        [HideInInspector]
        public MainMenuManager MainMenuManager;

        [Space]
        public GameObject Grid;


        private void Awake() {
            if (_instance != null && _instance != this) {
                Destroy(this);
            } else {
                DontDestroyOnLoad(this);

                if (MinionFactory == null) {
                    MinionFactory = Instantiate<MinionFactory>(minionFactoryPrefab);
                }
                if (ScenarioManager == null) {
                    ScenarioManager = new ScenarioManager();
                }
                if (GameData == null) {
                    GameData = GameData.Instance;
                }
            }
        }

        private void Start() {
            //ScenarioManager.StartScenario();
        }

        public void StartScenario(int index) {
            if (MainMenuManager != null) {
                MainMenuManager.GoToPanel();
            }

            ScenarioManager.StartScenario(index);
        }

        // Called from UI (for testing)
        public void KillAll() {
            Instance.ScenarioManager.roundRunner.KillAll();
        }
    }
}
