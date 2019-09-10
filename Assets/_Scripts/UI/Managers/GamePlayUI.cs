using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoChessTD.UI {

    public class GamePlayUI : BaseUIManager {

        protected override void Awake() {
            base.Awake();

            GameManager.Instance.GamePlayUI = this;
        }
    }
}
