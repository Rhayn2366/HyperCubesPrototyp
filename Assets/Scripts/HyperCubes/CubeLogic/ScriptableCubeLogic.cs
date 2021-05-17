using HypercubesPrototyp.GameLogic;
using UnityEngine;
namespace HypercubesPrototyp.HyperCubeLogic
{
    public abstract class ScriptableCubeLogic : ScriptableObject, ICubeCommand
    {
#nullable enable
        public abstract void DoCommand(Lemming? lemming, HyperCube hyperCube);
    }
}