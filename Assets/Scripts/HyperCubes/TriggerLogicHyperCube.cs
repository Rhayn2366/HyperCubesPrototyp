using HypercubesPrototyp.GameLogic;
using UnityEngine;

namespace HypercubesPrototyp.HyperCubeLogic
{
    /// <summary>
    /// A Hypercube that will be activated through external events, such as a UI click (<see cref="GameControl"/>) 
    /// or another cube (<see cref="ActivatorCube"/>)
    /// 
    /// Can subscribe itself to the game controller to be triggered through the UI on start.
    /// </summary>
    public class TriggerLogicHyperCube : HyperCube
    {
        [SerializeField] private bool _isUIStartTrigger;
        private int _triggerLogic;
        private GameControl _gameControlInstance;

        /// <summary>
        /// Triggers through an external call.
        /// 
        /// Will add to a counter to track how many times it should call a certain logic.
        /// 
        /// Will work through the counter in the update method.
        /// </summary>
        public void TriggerLogic()
        {
            if (_triggerLogic <= 0) //Maybe we want a case where trigger logic can be less than zero to use it as an objectiv (Like activate something)
            {
                _triggerLogic = 1;
            }
            else
            {
                _triggerLogic++;
            }
        }

        #region Unity_callbacks
        private void OnEnable()
        {
            if (_isUIStartTrigger)
            {
                _gameControlInstance = GameControl.Instance;
                _gameControlInstance.SubscribeHyperCube(this);
            }
        }

        private void OnDisable()
        {
            if (_isUIStartTrigger && _gameControlInstance)
            {
                _gameControlInstance.UnsubscribeHyperCube(this);
            }
        }

        private void Update()
        {
            //Could do a manager for these as well, (Ex. Lemmings) but we will need to wait for the AR implementation first.
            if (_triggerLogic > 0)
            {
                CubeLogic.DoCommand(null, this);
                _triggerLogic--;
            }
        }
        #endregion
    }
}