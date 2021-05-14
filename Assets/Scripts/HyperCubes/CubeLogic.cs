using HypercubesPrototyp.GameLogic;
using UnityEngine;
namespace HypercubesPrototyp.HyperCubeLogic
{
    public abstract class CubeLogic : ScriptableObject
    {
#nullable enable
        public abstract void DoCommand(Lemming? lemming, HyperCube hyperCube);
    }
}