using HypercubesPrototyp.GameLogic;
using UnityEngine;

namespace HypercubesPrototyp.HyperCubeLogic
{
    public class TriggerLogicHyperCube : HyperCube
    {
        [SerializeField] private bool _isUIStartTrigger;
        private int _triggerLogic;
        private GameControl _gameControlInstance;

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

        private void Update()
        {
            //Could do a manager for these as well, (Ex. Lemmings) but we will need to wait for the AR implementation first.
            if (_triggerLogic > 0)
            {
                CubeLogic.DoCommand(null, this);
                _triggerLogic--;
            }
        }
    }
}