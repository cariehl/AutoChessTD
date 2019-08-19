using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.UI.Panels;

namespace AutoChessTD.UI {

    public class BaseUIManager : MonoBehaviour {

        [Header("Prefabs")]
        [SerializeField] private BasePanel[] panelPrefabs;

        private List<BasePanel> panels = new List<BasePanel>();


        protected virtual void Awake() {
            SpawnPanels();
            GoToPanel(PanelType.NONE);
        }

        private void Start() {
            GoToPanel(PanelType.ScenarioSelect);
        }

        private void SpawnPanels() {
            foreach (var panelPrefab in panelPrefabs) {
                var panel = Instantiate(panelPrefab, transform);
                panels.Add(panel);
            }
        }

        public void GoToPanel(params PanelType[] types) {
            foreach (var panel in panels) {
                if (panel.PanelType.In(types))
                    panel.Show();
                else
                    panel.Hide();
            }
        }
    }
}
