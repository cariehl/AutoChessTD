using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using AutoChessTD.UI;
using AutoChessTD.Data;
using AutoChessTD.Events;
using AutoChessTD.Factories;

namespace AutoChessTD {
    public class GameManager : MonoBehaviour {
        private static readonly string MAIN_MENU_SCENE = "MainMenu";
        private static readonly string DEFAULT_GAME_SCENE = "DefaultScenario";

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
        public MainMenuUI mainMenuUIPrefab;
        public GamePlayUI gamePlayUIPrefab;
        public GameObject gridPrefab;
        public GameObject eventSystemPrefab;

        // Managers
        public GameData GameData;
        public ScenarioManager ScenarioManager;

        // Factories
        [HideInInspector] public MinionFactory MinionFactory;

        // UI Managers
        [HideInInspector] public MainMenuUI MainMenuUI;
        [HideInInspector] public GamePlayUI GamePlayUI;

        [HideInInspector] public GameObject Grid { get; set; }

        private void Awake() {
            if (_instance != null && _instance != this) {
                Destroy(gameObject);
            } else {
                DontDestroyOnLoad(this);

                var eventSystem = Instantiate(eventSystemPrefab);
                DontDestroyOnLoad(eventSystem);
                
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
            EventManager.OnScenarioEnded += OnScenarioEnded;
        }

        private void OnDisable() {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            EventManager.OnScenarioEnded -= OnScenarioEnded;
        }

        public void StartScenario(ScenarioConfig scenario) {
            if (MainMenuUI != null) {
                MainMenuUI.GoToScreen();
            }

            ScenarioManager.CurrentScenario = scenario;

            string scenarioScene = scenario.SceneName;
            if (string.IsNullOrWhiteSpace(scenarioScene)) {
                scenarioScene = DEFAULT_GAME_SCENE;
            }

            SceneManager.LoadScene(scenarioScene);
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
            MainMenuUI = Instantiate(mainMenuUIPrefab);
            MainMenuUI.GoToScreen();
        }

        private void InitializeScenario() {
            Grid = Instantiate(gridPrefab);
            MinionFactory = Instantiate<MinionFactory>(minionFactoryPrefab);

            ScenarioManager.StartScenario();
        }

        private void OnScenarioEnded(bool success) {
            // show success or failure message screen
        }

        public void ReturnToMainMenu() {
            SceneManager.LoadScene(MAIN_MENU_SCENE);
        }

        // Called from UI (for testing)
        public void KillAll() {
            Instance.ScenarioManager?.roundRunner.KillAll();
        }
    }
}
