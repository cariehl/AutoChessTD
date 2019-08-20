using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using AutoChessTD.Events;

namespace AutoChessTD.UI.Screens {

    public class EndScenarioScreen : BaseScreen {

        public override ScreenType ScreenType => ScreenType.EndScenario;

        [SerializeField] private TMP_Text statusInput;

        private void OnEnable() {
            EventManager.OnScenarioEnded += OnScenarioEnded;
        }

        private void OnDisable() {
            EventManager.OnScenarioEnded -= OnScenarioEnded;
        }

        private void OnScenarioEnded(bool success) {
            Show();

            if (success) {
                statusInput.text = "SUCCESS";
            } else {
                statusInput.text = "FAILURE";
            }
        }

        public void ExitToMainMenu() {
            GameManager.Instance.ReturnToMainMenu();
        }
    }
}
