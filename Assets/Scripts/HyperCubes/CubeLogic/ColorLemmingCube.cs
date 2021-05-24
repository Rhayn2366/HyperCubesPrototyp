using HypercubesPrototyp.GameLogic;
using UnityEngine;

namespace HypercubesPrototyp.HyperCubeLogic
{
    public class ColorLemmingCube : CubeLogic
    {
        [SerializeField] private LemmingColor _color = LemmingColor.Red;

        public override void DoCommand(Lemming lemming, HyperCube hyperCube)
        {
            if (!lemming) return;
            lemming.SetColor(_color);
            lemming.SetLastUsedGameObjectAndInit(hyperCube.gameObject);
        }
    }
}