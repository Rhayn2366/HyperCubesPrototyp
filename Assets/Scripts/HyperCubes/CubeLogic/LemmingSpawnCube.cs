using HypercubesPrototyp.GameLogic;
using HypercubesPrototyp.GameLogic.Utils;
using UnityEngine;

namespace HypercubesPrototyp.HyperCubeLogic
{
    public class LemmingSpawnCube : CubeLogic
    {
        [SerializeField] private int _lemmingID;
        [SerializeField] private Color _lemmingColor;

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