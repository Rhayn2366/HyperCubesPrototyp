using HypercubesPrototyp.GameLogic.Utils;
using HypercubesPrototyp.HyperCubeLogic;
using System.Collections.Generic;
using UnityEngine;

namespace HypercubesPrototyp.GameLogic
{
    /// <summary>
    /// This class is controlling the game UI behaviour and states.
    /// 
    /// Implementation of the singleton pattern to be available for other classes easily
    /// (<see cref="TriggerLogicHyperCube"/>)
    /// </summary>
    public class GameControl : MonoBehaviour
    {
        public static GameControl Instance;

        private readonly List<TriggerLogicHyperCube> _triggerLogicHyperCubes = new List<TriggerLogicHyperCube>();

        private LemmingManager _lemmingManager;

        /// <summary>
        /// Adds a trigger logic hyper cube, so it will be triggered by a UI start click.
        /// </summary>
        /// <param name="hyperCubeToRemove"> hyper cube that should  be triggered </param>
        public void SubscribeHyperCube(TriggerLogicHyperCube hyperCubeToAdd)
        {
            _triggerLogicHyperCubes.Add(hyperCubeToAdd);
        }

        /// <summary>
        /// Removes a trigger logic hyper cube, so it will no longer be triggered by a UI start click.
        /// </summary>
        /// <param name="hyperCubeToRemove"> hyper cube that will not be triggered anymore </param>
        public void UnsubscribeHyperCube(TriggerLogicHyperCube hyperCubeToRemove)
        {
            _triggerLogicHyperCubes.Remove(hyperCubeToRemove);
        }

        /// <summary>
        /// Toggles between playing and editing state.
        /// 
        /// Will invoke all subscribed hypercubes when it is
        /// starting, otherwise all lemmings will be deleted
        /// to reset the playing state.
        /// </summary>
        /// <param name="isStarting"></param>
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

        /// <summary>
        /// Toggles unitys time scale between 0 and 1 to achieve a pause or continue function
        /// </summary>
        /// <param name="isPausing"> is unity currently not playing </param>
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

        /// <summary>
        /// Invokes all subscribed hypercubes one time
        /// </summary>
        private void TriggerHyperCubes()
        {
            foreach (var hyperCube in _triggerLogicHyperCubes)
            {
                hyperCube.TriggerLogic();
            }
        }

        #region Unity_callbacks
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
        #endregion
    }
}