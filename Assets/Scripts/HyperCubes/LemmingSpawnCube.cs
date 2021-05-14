using HypercubesPrototyp.GameLogic;
using HypercubesPrototyp.GameLogic.Utils;
using UnityEngine;

namespace HypercubesPrototyp.HyperCubeLogic
{
    [CreateAssetMenu(menuName = "CubeLogic/SpawnCube")]
    public class LemmingSpawnCube : CubeLogic
    {
        [SerializeField] private int _lemmingID;
        [SerializeField] private Color _lemmingColor;

        //TODO Get this from the lemming class as it can change depending on the lemming (Could be done in factory)

#nullable enable
        public override void DoCommand(Lemming? lemming, HyperCube hyperCube)
        {
            var spawnPosition = hyperCube.transform.position + hyperCube.transform.forward / 2;
            //Dependency hiding bad!
            var cache = LemmingFactory.Instance.CreateLemming(_lemmingID, spawnPosition, _lemmingColor);
            cache.SetLastUsedGameObjectAndInit(hyperCube.gameObject);
        }
    }
}