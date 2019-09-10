using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AutoChessTD.Data;

namespace AutoChessTD.UI.Screens {

    public class ScenarioSelectScreen : BaseScreen {

        public override ScreenType ScreenType => ScreenType.ScenarioSelect;

        [SerializeField] private GameObject scenarioList;
        [SerializeField] private ScenarioListItem scenarioItemPrefab;

        private List<ScenarioListItem> scenarioUIItems = new List<ScenarioListItem>();


        public override void Show() {
            base.Show();
            RefreshScenariosList();
        }

        private void RefreshScenariosList() {
            ClearList();

            foreach (var scenario in GameData.Instance.availableScenarios) {
                var item = Instantiate<ScenarioListItem>(scenarioItemPrefab, scenarioList.transform);
                item.Init(scenario);

                AddLaunchBtnListener(item.launchButton, scenario);

                scenarioUIItems.Add(item);
            }
        }

        private void ClearList() {
            foreach (var item in scenarioUIItems) {
                Destroy(item.gameObject);
            }

            scenarioUIItems.Clear();
        }

        private void AddLaunchBtnListener(Button button, ScenarioConfig scenario) {
            button.onClick.AddListener(() => {
                GameManager.Instance.StartScenario(scenario);
            });
        }
    }
}
