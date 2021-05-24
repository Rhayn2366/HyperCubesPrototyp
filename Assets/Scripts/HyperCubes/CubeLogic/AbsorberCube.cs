using HypercubesPrototyp.GameLogic;
using System;
using UnityEngine;

namespace HypercubesPrototyp.HyperCubeLogic
{
    public abstract class AbsorberCube : CubeLogic
    {
        [SerializeField] private AbsorbItem _absorbItem;
        [SerializeField] private int _countForUse = 1;
        [SerializeField] private bool _isResetAfterUse;

        protected bool Triggered = false;
        protected GameControl GameControlInstance;

        [SerializeField] private int _counter;

        private void OnEnable()
        {
            GameControlInstance = GameControl.Instance;
            GameControlInstance.SubscribeAbsorber(this);
            OnEnableChild();
        }

        protected abstract void OnEnableChild();

        private void OnDisable()
        {
            GameControlInstance.UnsubscribeAbsorber(this);
            OnDisableChild();
        }

        protected abstract void OnDisableChild();

        private void Start()
        {
            _counter = _countForUse;
        }

        public override void DoCommand(Lemming lemming, HyperCube hyperCube)
        {
            LemmingModel id = lemming.GetLemmingId();
            LemmingColor color = lemming.GetLemmingColor();
            CheckIfLemmingMatchesAbsorbRequirementAndTrigger(id, color);

            Destroy(lemming.gameObject);
        }

        private void CheckIfLemmingMatchesAbsorbRequirementAndTrigger(LemmingModel id, LemmingColor color)
        {
            if (id == _absorbItem.Id && color == _absorbItem.Color)
            {
                _counter--;
                if (_counter <= 0 && !Triggered)
                {
                    Triggered = true;

                    DoAbsorbFunctionality();

                    if (_isResetAfterUse)
                    {
                        _counter = _countForUse;
                        Triggered = false;
                    }
                }
            }
        }

        protected abstract void DoAbsorbFunctionality();

        public void ResetValues()
        {
            _counter = _countForUse;
            Triggered = false;
        }
    }
}