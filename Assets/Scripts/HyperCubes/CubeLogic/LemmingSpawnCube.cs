using HypercubesPrototyp.GameLogic;
using HypercubesPrototyp.GameLogic.Utils;
using UnityEngine;

namespace HypercubesPrototyp.HyperCubeLogic
{
    public class LemmingSpawnCube : CubeLogic
    {
        [SerializeField] private LemmingModel _lemmingID;
        [SerializeField] private LemmingColor _lemmingColor;
        [SerializeField] private int _spawnCount = 1;
        [SerializeField] private float _timeToLive = 20f;

#nullable enable
        public override void DoCommand(Lemming? lemming, HyperCube hyperCube)
        {
            var spawnPosition = hyperCube.transform.position + hyperCube.transform.forward / 2;
            
            for (int i = 0; i < _spawnCount; i++)
            {
                //Dependency hiding bad!
                var cache = LemmingFactory.Instance.CreateLemming(_lemmingID, spawnPosition, _lemmingColor, _timeToLive, hyperCube.transform.eulerAngles.y);
                cache.SetLastUsedGameObjectAndInit(hyperCube.gameObject);
            }
        }
    }
}