using HypercubesPrototyp.GameLogic;
using UnityEngine;

namespace HypercubesPrototyp.HyperCubeLogic
{
    public class AddLemmingTimeToLiveCube : CubeLogic
    {
        [SerializeField] private float _addValue = 10f; 

        public override void DoCommand(Lemming lemming, HyperCube hyperCube)
        {
            if (!lemming) return;
            lemming.AddTimeToLive(_addValue);
            lemming.SetLastUsedGameObjectAndInit(hyperCube.gameObject);
        }
    }
}