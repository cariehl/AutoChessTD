using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.UI.Screens;

namespace AutoChessTD.UI {

    public class MainMenuUI : BaseUIManager {

        protected override void Awake() {
            base.Awake();

            GameManager.Instance.MainMenuUI = this;
        }
    }
}
