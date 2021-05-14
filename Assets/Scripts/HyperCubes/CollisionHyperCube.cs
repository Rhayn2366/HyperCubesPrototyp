using HypercubesPrototyp.GameLogic;
using UnityEngine;

namespace HypercubesPrototyp.HyperCubeLogic
{
    [RequireComponent(typeof(Collider))]
    public class CollisionHyperCube : HyperCube
    {
        public void OnCollisionDetected(Lemming lemming)
        {
            CubeLogic.DoCommand(lemming, this);
        }
    }
}