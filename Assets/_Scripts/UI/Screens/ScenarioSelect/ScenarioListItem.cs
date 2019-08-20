using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using AutoChessTD.Data;

namespace AutoChessTD.UI {

    public class ScenarioListItem : MonoBehaviour {

        [SerializeField] private TMP_Text scenarioTitle;
        public Button launchButton;

        private ScenarioConfig config;

        public void Init(ScenarioConfig _config) {
            config = _config;

            scenarioTitle.text = config.DisplayName;
        }
    }
}
