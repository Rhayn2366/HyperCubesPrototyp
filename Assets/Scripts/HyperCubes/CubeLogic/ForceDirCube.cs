using HypercubesPrototyp.GameLogic;
using UnityEngine;

namespace HypercubesPrototyp.HyperCubeLogic
{
    public class ForceDirCube : CubeLogic
    {
        public override void DoCommand(Lemming lemming, HyperCube hyperCube)
        {
            if (!lemming) return;
            lemming.transform.position = hyperCube.transform.position + Vector3.up * lemming.GetYOffset();
            lemming.SetRotationOnY(hyperCube.transform.eulerAngles.y);
            lemming.SetLastUsedGameObjectAndInit(hyperCube.gameObject);
        }
    }
}