using HypercubesPrototyp.GameLogic.Utils;
using HypercubesPrototyp.HyperCubeLogic;
using System.Collections.Generic;
using UnityEngine;

namespace HypercubesPrototyp.GameLogic
{
    public class GameControl : MonoBehaviour
    {
        public static GameControl Instance;

        private readonly List<TriggerLogicHyperCube> _triggerLogicHyperCubes = new List<TriggerLogicHyperCube>();

        private LemmingManager _lemmingManager;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _lemmingManager = LemmingManager.Instance;
        }

        public void SubscribeHyperCube(TriggerLogicHyperCube hyperCubeToAdd)
        {
            _triggerLogicHyperCubes.Add(hyperCubeToAdd);
        }

        public void UnsubscribeHyperCube(TriggerLogicHyperCube hyperCubeToAdd)
        {
            _triggerLogicHyperCubes.Remove(hyperCubeToAdd);
        }

        public void OnStartStopToggle(bool isStarting)
        {
            if (isStarting)
            {
                TriggerHyperCubes();
            }
            else
            {
                _lemmingManager.DeleteAllLemmings();
            }
        }

        public void OnPauseContinueToggle(bool isPausing)
        {
            //Bad way to do this here, maybe we need a time manager later on!
            if (isPausing)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

        private void TriggerHyperCubes()
        {
            foreach (var hyperCube in _triggerLogicHyperCubes)
            {
                hyperCube.TriggerLogic();
            }
        }
    }
}