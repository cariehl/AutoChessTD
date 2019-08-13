using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Data;
using AutoChessTD.Factories;

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

        [Header("Prefabs")]
        public MinionFactory minionFactoryPrefab;

        // Managers
        public GameData GameData;

        // Factories
        [HideInInspector]
        public MinionFactory MinionFactory;

        [Space]
        public GameObject Grid;


        private void Awake() {
            if (_instance != null && _instance != this) {
                Destroy(this);
            } else {
                DontDestroyOnLoad(this);

                if (MinionFactory == null) {
                    MinionFactory = Instantiate<MinionFactory>(minionFactoryPrefab);
                }

                if (GameData == null) {
                    GameData = GameData.Instance;
                }
            }
        }
    }
}
