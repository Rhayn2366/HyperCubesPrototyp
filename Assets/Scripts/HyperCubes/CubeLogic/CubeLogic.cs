using HypercubesPrototyp.GameLogic;
using UnityEngine;

namespace HypercubesPrototyp.HyperCubeLogic
{
    /// <summary>
    /// This abstract class is used and triggered through <see cref="HyperCube"/>.
    /// 
    /// Implements monobehaviour, for access to game object specific methods and things,
    /// such as Physics.OverlapSphere and a seperate collider <see cref="ActivatorCube"/>.
    /// as well as other things.
    /// </summary>
    public abstract class CubeLogic : MonoBehaviour
    {
        /// <summary>
        /// Triggers the specificly implemented cube logic.
        /// Can either changed the behaviour of a <paramref name="lemming"/>
        /// through a <see cref="CollisionHyperCube"/> or do some other things
        /// not neccessarilly related to a lemming (<see cref="LemmingSpawnCube"/>)
        /// through the <see cref="TriggerLogicHyperCube"/>.
        /// 
        /// Note: 
        /// <paramref name="lemming"/> can be null if it is triggered by
        /// a <see cref="TriggerLogicHyperCube"/>, but is needed to change the
        /// behaviour of a <see cref="Lemming"/> through a <see cref="CollisionHyperCube"/>.
        /// </summary>
        /// <param name="lemming"> lemming that triggered the logic </param>
        /// <param name="hyperCube"> cube that owns the logic </param>
#nullable enable
        public abstract void DoCommand(Lemming? lemming, HyperCube hyperCube);
    }
}