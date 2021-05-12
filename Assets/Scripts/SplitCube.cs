using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "CubeLogic/SplitCube")]
public class SplitCube : CubeLogic
{
    [SerializeField] private float _yOffset = .25f;
    [SerializeField] private SplitType _splitType;

    private enum SplitType
    {
        Y
    }


    public override IEnumerator DoCommand(GameObject lemming, HyperCube hyperCube)
    {
        if (!lemming) yield return null;

        var lemmingPrefab = lemming.GetComponent<Lemming>().GetLemmingPrefab();
        if (!lemmingPrefab) yield return null;

        Destroy(lemming.gameObject);

        if (_splitType == SplitType.Y)
        {
            YSplitt(hyperCube, lemmingPrefab);
        }

        yield return new WaitForSeconds(1f);
    }

    private void YSplitt(HyperCube hyperCube, GameObject lemmingPrefab)
    {
        var spawnPosition = hyperCube.transform.position + Vector3.up * _yOffset + hyperCube.transform.forward / 2;
        var rotation = Quaternion.Euler(new Vector3(0, 45, 0));

        SpawnAndInitGameObject(hyperCube, lemmingPrefab, spawnPosition + hyperCube.transform.right / 2, rotation);

        rotation = Quaternion.Euler(new Vector3(0, -45, 0));
        SpawnAndInitGameObject(hyperCube, lemmingPrefab, spawnPosition - hyperCube.transform.right / 2, rotation);
    }

    private static void SpawnAndInitGameObject(HyperCube hyperCube, GameObject cachedPrefab, Vector3 spawnPosition, Quaternion rotation)
    {
        var cache = Instantiate(cachedPrefab, spawnPosition, rotation);
        cache.GetComponent<Lemming>().SetLastUsedGameObject(hyperCube.gameObject);
    }
}