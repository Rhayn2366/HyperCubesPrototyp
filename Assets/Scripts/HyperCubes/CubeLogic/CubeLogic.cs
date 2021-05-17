using HypercubesPrototyp.GameLogic;
using UnityEngine;

namespace HypercubesPrototyp.HyperCubeLogic
{
    public abstract class CubeLogic : MonoBehaviour
    {
#nullable enable
        public abstract void DoCommand(Lemming? lemming, HyperCube hyperCube);
    }
}