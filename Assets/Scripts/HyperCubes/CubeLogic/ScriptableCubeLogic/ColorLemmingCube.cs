using HypercubesPrototyp.GameLogic;
using UnityEngine;

namespace HypercubesPrototyp.HyperCubeLogic
{
    public class ColorLemmingCube : MonobehaviourCubeLogic
    {
        [SerializeField] private Color _color = Color.red;

        public override void DoCommand(Lemming lemming, HyperCube hyperCube)
        {
            if (!lemming) return;
            lemming.SetColor(_color);
            lemming.SetLastUsedGameObjectAndInit(hyperCube.gameObject);
        }
    }
}