using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollisionHyperCube : HyperCube
{
    public void OnCollisionDetected(GameObject collidedObject)
    {
        StartCoroutine(CubeLogic.TriggerCommand(collidedObject, this));
    }
}