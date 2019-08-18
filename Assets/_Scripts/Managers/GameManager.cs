using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using AutoChessTD.Data;
using AutoChessTD.Factories;
using AutoChessTD.UI;

namespace AutoChessTD {
    public class GameManager : MonoBehaviour {
        private static readonly string defaultGameScene = "DefaultScenario";

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
        public MainMenuManager mainMenuManagerPrefab;
        public GameObject gridPrefab;

        // Managers
        public GameData GameData;
        public ScenarioManager ScenarioManager;

        // Factories
        [HideInInspector]
        public MinionFactory MinionFactory;

        // UI Managers
        [HideInInspector]
        public MainMenuManager MainMenuManager;

        [HideInInspector]
        public GameObject Grid { get; set; }

        private void Awake() {
            if (_instance != null && _instance != this) {
                Destroy(this);
            } else {
                DontDestroyOnLoad(this);
                
                if (ScenarioManager == null) {
                    ScenarioManager = new ScenarioManager();
                }
                if (GameData == null) {
                    GameData = GameData.Instance;
                }
            }
        }

        private void OnEnable() {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable() {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        public void StartScenario(ScenarioConfig scenario) {
            if (MainMenuManager != null) {
                MainMenuManager.GoToPanel();
            }

            ScenarioManager.CurrentScenario = scenario;
            SceneManager.LoadScene(defaultGameScene);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            InitializeScene(scene.name);
        }

        private void InitializeScene() {
            InitializeScene(SceneManager.GetActiveScene().name);
        }

        private void InitializeScene(string sceneName) {
            switch (sceneName) {
                case "MainMenu":
                    InitializeMainMenu();
                    return;
                default:    // Scenario Game Scene
                    InitializeScenario();
                    return;
            }
        }

        private void InitializeMainMenu() {
            MainMenuManager = Instantiate(mainMenuManagerPrefab);
            MainMenuManager.GoToPanel();
        }

        private void InitializeScenario() {
            Grid = Instantiate(gridPrefab);
            MinionFactory = Instantiate<MinionFactory>(minionFactoryPrefab);

            ScenarioManager.StartScenario();

        }

        // Called from UI (for testing)
        public void KillAll() {
            Instance.ScenarioManager?.roundRunner.KillAll();
        }
    }
}
