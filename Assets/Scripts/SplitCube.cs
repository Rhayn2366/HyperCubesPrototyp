using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "CubeLogic/SplitCube")]
public class SplitCube : CubeLogic
{
    [SerializeField] private float _yOffset = .25f;
    [SerializeField] private SplitType _splitType;

    private enum SplitType
    {
        T,
        X,
        Y
    }


    public override IEnumerator DoCommand(GameObject lemming, HyperCube hyperCube)
    {
        if (!lemming) yield return null;

        var lemmingPrefab = lemming.GetComponent<Lemming>().GetLemmingPrefab();
        if (!lemmingPrefab) yield return null;

        Destroy(lemming.gameObject);

        if (_splitType == SplitType.T)
        {
            TSplit(hyperCube, lemmingPrefab);
        }
        else if (_splitType == SplitType.X)
        {
            XSplit(hyperCube, lemmingPrefab);
        }
        else if (_splitType == SplitType.Y)
        {
            YSplit(hyperCube, lemmingPrefab);
        }
        


        yield return new WaitForSeconds(1f);
    }

    private void TSplit(HyperCube hyperCube, GameObject lemmingPrefab)
    {
        var spawnPosition = hyperCube.transform.position + Vector3.up * _yOffset;
        var rotation = Quaternion.Euler(new Vector3(0, 90, 0));

        SpawnAndInitGameObject(hyperCube, lemmingPrefab, spawnPosition + hyperCube.transform.right / 2, rotation);

        rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        SpawnAndInitGameObject(hyperCube, lemmingPrefab, spawnPosition - hyperCube.transform.right / 2, rotation);

        spawnPosition += hyperCube.transform.forward / 2;
        rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        SpawnAndInitGameObject(hyperCube, lemmingPrefab, spawnPosition, rotation);
    }

    private void XSplit(HyperCube hyperCube, GameObject lemmingPrefab)
    {
        var spawnPosition = hyperCube.transform.position + Vector3.up * _yOffset + hyperCube.transform.forward / 2;
        var rotation = Quaternion.Euler(new Vector3(0, 45, 0));

        SpawnAndInitGameObject(hyperCube, lemmingPrefab, spawnPosition + hyperCube.transform.right / 2, rotation);

        rotation = Quaternion.Euler(new Vector3(0, -45, 0));
        SpawnAndInitGameObject(hyperCube, lemmingPrefab, spawnPosition - hyperCube.transform.right / 2, rotation);

        spawnPosition = hyperCube.transform.position + Vector3.up * _yOffset - hyperCube.transform.forward / 2;
        rotation = Quaternion.Euler(new Vector3(0, 135, 0));

        SpawnAndInitGameObject(hyperCube, lemmingPrefab, spawnPosition + hyperCube.transform.right / 2, rotation);

        rotation = Quaternion.Euler(new Vector3(0, -135, 0));
        SpawnAndInitGameObject(hyperCube, lemmingPrefab, spawnPosition - hyperCube.transform.right / 2, rotation);
    }

    private void YSplit(HyperCube hyperCube, GameObject lemmingPrefab)
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