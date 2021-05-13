using UnityEngine;

/// <summary>
/// This class describes all game objects, that can move around and trigger hyper cubes with a collision.
/// </summary>
[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Lemming : MonoBehaviour
{
    [SerializeField] private GameObject _lemmingPrefab;

    public GameObject GetLemmingPrefab() => _lemmingPrefab;

    private GameObject _lastUsedGameObject;

    private bool _isInit;

    public void SetLastUsedGameObject(GameObject gameObject)
    {
        _lastUsedGameObject = gameObject;
        _isInit = true;
        enabled = true;

        //Maybe start a coroutine here to make it possible to use the same collider after x seconds again.
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_isInit) return;
        //Prevents using the same collider multiple times!
        if (collision.gameObject != _lastUsedGameObject)
        {
            var collisionHyperCube = collision.gameObject.GetComponent<CollisionHyperCube>();
            if (collisionHyperCube != null)
            {
                collisionHyperCube.OnCollisionDetected(gameObject);
            }
        } 
    }

    private void FixedUpdate()
    {
        //Might want to do this with a "Lemming Manager" instead, as each fixed update per game object (in large quantities) may be to much for a mobile plattform to handle
        transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward, Time.fixedDeltaTime);
    }
}