using HypercubesPrototyp.GameLogic.Utils;
using HypercubesPrototyp.HyperCubeLogic;
using System;
using UnityEngine;

namespace HypercubesPrototyp.GameLogic
{
    /// <summary>
    /// This class describes all game objects, that can move around and trigger hyper cubes with a collision.
    /// </summary>
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class Lemming : MonoBehaviour
    {
        [SerializeField] private int _lemmingId;
        [SerializeField] private Color _lemmingColor;
        [SerializeField] private float _yOffset = .25f;
        [SerializeField] private Renderer _renderer;

        private GameObject _lastUsedGameObject;
        private bool _isInit;
        private LemmingManager _lemmingManager;
        
        public int GetLemmingId()
        {
            return _lemmingId;
        }

        public void SetColor(Color newColor)
        {
            _lemmingColor = newColor;

            MaterialPropertyBlock props = new MaterialPropertyBlock();
            props.SetColor("_BaseColor", _lemmingColor);
            _renderer.SetPropertyBlock(props);
        }

        public Color GetLemmingColor()
        {
            return _lemmingColor;
        }

        public void AddRotationOnY(float degrees)
        {
            transform.Rotate(Vector3.up, degrees);
        }

        public void SetRotationOnY(float degrees)
        {
            transform.rotation = Quaternion.Euler(0, degrees, 0);
        }

        public void Move()
        {
            if (!_isInit) return;
            transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward, Time.fixedDeltaTime);
        }

        public float GetYOffset()
        {
            return _yOffset;
        }

        /// <summary>
        /// Sets the last game object this lemming interacted with, to avoid a second call on it.
        /// Also initializes the lemming, to let it move and interact with others.
        /// 
        /// This method should always be used after setting up the lemming (Color, Rotation, ...)
        /// </summary>
        /// <param name="gameObjectInteractedWith"> last game object interacted with </param>
        public void SetLastUsedGameObjectAndInit(GameObject gameObjectInteractedWith)
        {
            _lastUsedGameObject = gameObjectInteractedWith;
            _isInit = true;
            enabled = true;
            //Maybe start a coroutine here to make it possible to use the same collider after x seconds again.
        }

        #region Unity Callbacks
        private void OnEnable()
        {
            _lemmingManager = LemmingManager.Instance;
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
                    collisionHyperCube.OnCollisionDetected(this);
                }
            }
        }

        private void OnDestroy()
        {
            if (_lemmingManager)
            {
                _lemmingManager.RemoveLemming(this);
            }
        }
        #endregion
    }
}