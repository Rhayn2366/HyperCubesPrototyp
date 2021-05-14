using UnityEngine;

[CreateAssetMenu(menuName = "CubeLogic/SpawnCube")]
public class LemmingSpawnCube : CubeLogic
{
    [SerializeField] private int _lemmingID;
    [SerializeField] private float _yOffset = .25f;

    protected override void DoCommand(GameObject lemming, HyperCube hyperCube)
    {
        var spawnPosition = hyperCube.transform.position + Vector3.up * _yOffset + hyperCube.transform.forward / 2;

        //Dependency hiding bad!
        var cache = LemmingFactory.Instance.CreateLemming(_lemmingID, spawnPosition);
        cache.SetLastUsedGameObject(hyperCube.gameObject);
    }
}