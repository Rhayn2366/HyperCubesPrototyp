using HypercubesPrototyp.GameLogic;
using UnityEngine;

namespace HypercubesPrototyp.HyperCubeLogic
{
    public class YRotationCube : CubeLogic
    {
        [SerializeField] private float _rotationAngle = 45f;

        public override void DoCommand(Lemming lemming, HyperCube hyperCube)
        {
            if (!lemming) return;
            lemming.transform.position = hyperCube.transform.position + Vector3.up * lemming.GetYOffset();
            lemming.AddRotationOnY(_rotationAngle);
            lemming.SetLastUsedGameObjectAndInit(hyperCube.gameObject);
        }
    }
}