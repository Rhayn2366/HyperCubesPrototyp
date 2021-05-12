using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "CubeLogic/SpawnCube")]
public class SpawnCube : CubeLogic
{
    [SerializeField] private GameObject _objectToSpawn;
    [SerializeField] private float _yOffset = .25f;

    public override IEnumerator DoCommand(GameObject lemming, HyperCube hyperCube)
    {
        //Might want to think about object pooling

        var spawnPosition = hyperCube.transform.position + Vector3.up * _yOffset + hyperCube.transform.forward / 2;

        var cache = Instantiate(_objectToSpawn, spawnPosition, Quaternion.identity);
        cache.GetComponent<Lemming>().SetLastUsedGameObject(hyperCube.gameObject);

        yield return new WaitForSeconds(1f);
    }
}