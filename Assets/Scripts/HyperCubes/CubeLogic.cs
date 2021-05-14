using UnityEngine;
using System.Collections;
namespace HypercubesPrototyp.HyperCubeLogic
{
    public abstract class CubeLogic : ScriptableObject
    {
        private bool _isTriggered;

        public IEnumerator TriggerCommand(GameObject lemming, HyperCube hyperCube)
        {
            if (_isTriggered) yield return null;
            else
            {
                //Maybe check it a little bit different, Ex. add to a list and check if the game object triggered it already
                //If yes do nothing, else add it to the list and trigger the logic. After it is finished, remove the game object from the list.
                //However, this could lead to some problems if we destroy the game object. For now the current solution should suffice, we won't trigger
                //with multiple objects shortly after another though
                _isTriggered = true;
                DoCommand(lemming, hyperCube);
                _isTriggered = false;
            }
        }

        protected abstract void DoCommand(GameObject lemming, HyperCube hyperCube);
    }
}