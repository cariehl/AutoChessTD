using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.UI.Screens;

namespace AutoChessTD.UI {

    public class BaseUIManager : MonoBehaviour {

        [Header("Prefabs")]
        [SerializeField] private BaseScreen[] screenPrefabs;

        private List<BaseScreen> screens = new List<BaseScreen>();


        protected virtual void Awake() {
            SpawnScreens();
            GoToScreen(ScreenType.NONE);
        }

        private void Start() {
            GoToScreen(ScreenType.ScenarioSelect);
        }

        private void SpawnScreens() {
            foreach (var screenPrefab in screenPrefabs) {
                var screen = Instantiate(screenPrefab, transform);
                screens.Add(screen);
            }
        }

        public void GoToScreen(params ScreenType[] types) {
            foreach (var screen in screens) {
                if (screen.ScreenType.In(types))
                    screen.Show();
                else
                    screen.Hide();
            }
        }
    }
}
