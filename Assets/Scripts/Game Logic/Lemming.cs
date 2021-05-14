using HypercubesPrototyp.GameLogic.Utils;
using HypercubesPrototyp.HyperCubeLogic;
using UnityEngine;

namespace HypercubesPrototyp.GameLogic
{
    /// <summary>
    /// This class describes all game objects, that can move around and trigger hyper cubes with a collision.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class Lemming : MonoBehaviour
    {
        [SerializeField] private int _lemmingId;

        private GameObject _lastUsedGameObject;

        private bool _isInit;

        private LemmingManager _lemmingManager;

        private void OnEnable()
        {
            _lemmingManager = LemmingManager.Instance;
        }

        public void SetRotationOnY(float degrees)
        {
            transform.Rotate(Vector3.up, degrees);
        }

        public int GetLemmingId()
        {
            return _lemmingId;
        }

        public void SetLastUsedGameObject(GameObject gameObject)
        {
            _lastUsedGameObject = gameObject;
            _isInit = true;
            enabled = true;

            //Maybe start a coroutine here to make it possible to use the same collider after x seconds again.
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (!_isInit) return;
            //Prevents using the same collider multiple times!
            if (collider.gameObject != _lastUsedGameObject)
            {
                var collisionHyperCube = collider.gameObject.GetComponent<CollisionHyperCube>();
                if (collisionHyperCube != null)
                {
                    collisionHyperCube.OnCollisionDetected(gameObject);
                }
            }
        }

        public void Move()
        {
            if (!_isInit) return;
            transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward, Time.fixedDeltaTime);
        }

        public void OnDestroy()
        {
            _lemmingManager.RemoveLemming(this);
        }
    }
}