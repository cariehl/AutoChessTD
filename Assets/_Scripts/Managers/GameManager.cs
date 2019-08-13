using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Data;

namespace AutoChessTD {
    public class GameManager : MonoBehaviour {
        private static GameManager _instance;

        public static GameManager Instance {
            get {
                if (_instance == null) {
                    _instance = FindObjectOfType<GameManager>();
                }

                if (_instance == null) {
                    var go = Instantiate(Resources.Load<GameObject>("GameManager"));
                    _instance = go.GetComponent<GameManager>();
                }

                return _instance;
            }
        }

        // Managers
        public GameData GameData;

        private void Awake() {
            if (_instance != null && _instance != this) {
                Destroy(this);
            } else {
                DontDestroyOnLoad(this);

                GameData = GameData.Instance;
            }
        }
    }
}
