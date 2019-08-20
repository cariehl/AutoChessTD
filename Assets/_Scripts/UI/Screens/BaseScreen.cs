using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AutoChessTD.UI.Screens {

    public enum ScreenType {
        ScenarioSelect, EndScenario, NONE
    }

    [RequireComponent(typeof(CanvasScaler), typeof(GraphicRaycaster))]
    public class BaseScreen : MonoBehaviour {

        protected Canvas _canvas;
        private CanvasScaler _canvasScaler;

        public virtual ScreenType ScreenType { get; } = ScreenType.NONE;

        private void Awake() {
            _canvas = GetComponent<Canvas>();
            _canvasScaler = GetComponent<CanvasScaler>();

            _canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            _canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            _canvasScaler.referenceResolution = new Vector2(1600, 900);
        }

        public virtual void Show() {
            _canvas.enabled = true;
        }

        public virtual void Hide() {
            _canvas.enabled = false;
        }
    }
}
