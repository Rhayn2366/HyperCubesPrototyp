using HypercubesPrototyp.GameLogic;
using HypercubesPrototyp.GameLogic.Utils;
using UnityEngine;

namespace HypercubesPrototyp.HyperCubeLogic
{
    public class LemmingSpawnCube : CubeLogic
    {
        [SerializeField] private int _lemmingID;
        [SerializeField] private Color _lemmingColor;
        [SerializeField] private int _spawnCount = 1;
        [SerializeField] private float _timeToLive = 20f;

#nullable enable
        public override void DoCommand(Lemming? lemming, HyperCube hyperCube)
        {
            var spawnPosition = hyperCube.transform.position + hyperCube.transform.forward / 2;
            //Dependency hiding bad!
            for (int i = 0; i < _spawnCount; i++)
            {
                var cache = LemmingFactory.Instance.CreateLemming(_lemmingID, spawnPosition, _lemmingColor, _timeToLive, hyperCube.transform.eulerAngles.y);
                cache.SetLastUsedGameObjectAndInit(hyperCube.gameObject);
            }
        }
    }
}