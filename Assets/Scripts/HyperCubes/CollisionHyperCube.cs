using HypercubesPrototyp.GameLogic;
using UnityEngine;

namespace HypercubesPrototyp.HyperCubeLogic
{
    /// <summary>
    /// A Hypercube that will be activated once a lemming (<see cref="Lemming"/>) steps inside them.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class CollisionHyperCube : HyperCube
    {
        /// <summary>
        /// Triggered whenever a lemming collided with this hyper cube.
        /// 
        /// Will in turn trigger the cube logic, so that something
        /// happens to the lemming
        /// </summary>
        /// <param name="lemming"> lemming that collided </param>
        public void OnCollisionDetected(Lemming lemming)
        {
            CubeLogic.DoCommand(lemming, this);
        }
    }
}