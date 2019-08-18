using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AutoChessTD.Data;

namespace AutoChessTD.UI.Panels {

    public class ScenarioSelectPanel : BasePanel {

        public override PanelType PanelType { get => PanelType.ScenarioSelect; }

        [SerializeField] private GameObject scenarioList;
        [SerializeField] private ScenarioListItem scenarioItemPrefab;

        private List<ScenarioListItem> scenarioUIItems = new List<ScenarioListItem>();


        public override void Show() {
            base.Show();
            RefreshScenariosList();
        }

        private void RefreshScenariosList() {
            ClearList();

            for (int i = 0; i < GameData.Instance.availableScenarios.Count; ++i) {
                var item = Instantiate<ScenarioListItem>(scenarioItemPrefab, scenarioList.transform);
                item.Init(GameData.Instance.availableScenarios[i]);

                AddLaunchBtnListener(item.launchButton, i);

                scenarioUIItems.Add(item);
            }
        }

        private void ClearList() {
            foreach (var item in scenarioUIItems) {
                Destroy(item.gameObject);
            }

            scenarioUIItems.Clear();
        }

        private void AddLaunchBtnListener(Button button, int index) {
            button.onClick.AddListener(() => {
                GameManager.Instance.StartScenario(index);
            });
        }
    }
}
