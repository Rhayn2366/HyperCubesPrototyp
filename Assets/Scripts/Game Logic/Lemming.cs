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

        [SerializeField] private LemmingTimeToLiveDisplay _lemmingTTLDisplay;

        private GameObject _lastUsedGameObject;
        private bool _isInit;
        private float _timeToLive = 0f;

        private LemmingManager _lemmingManager;

        /// <summary>
        /// Adds <paramref name="degrees"/> to the transforms current rotation value.
        /// </summary>
        /// <param name="degrees"> rotation on the y axis in degrees </param>
        public void AddRotationOnY(float degrees)
        {
            transform.Rotate(Vector3.up, degrees);
        }

        /// <summary>
        /// Sets the transforms current rotation value to <paramref name="degrees"/>.
        /// Will overwrite an existing rotation.
        /// </summary>
        /// <param name="degrees"> rotation on the y axis in degrees </param>
        public void SetRotationOnY(float degrees)
        {
            transform.rotation = Quaternion.Euler(0, degrees, 0);
        }

        /// <summary>
        /// Instructs the transform to move forward if it is initialized.
        /// 
        /// Note:
        /// Will be called through a managing class to avoid update calls on each
        /// monobehaviour.
        /// </summary>
        public void Move()
        {
            if (!_isInit) return;
            transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward, Time.fixedDeltaTime);
        }

        /// <summary>
        /// Adds <paramref name="value"/> seconds to the transforms time to live.
        /// Will update a time to live display when its value has changed.
        /// </summary>
        /// <param name="value"> time to live value in seconds </param>
        public void AddTimeToLive(float value)
        {
            _timeToLive += value;
            UpdateTTL();
        }

        /// <summary>
        /// Subtracts <paramref name="value"/> seconds from the transforms time to live.
        /// Will update a time to live display when its value has changed.
        /// 
        /// If the time to live of the transform reaches zero or below, it will destroy itself.
        /// </summary>
        /// <param name="value"> time to live value in seconds </param>
        public void SubtractTimeToLive(float value)
        {
            _timeToLive -= value;

            if (_timeToLive <= 0)
            {
                Destroy(gameObject);
                return;
            }

            UpdateTTL();
        }

        /// <summary>
        /// Sets the last game object this lemming interacted with, to avoid a second call on it.
        /// Also initializes the lemming, to let it move and interact with others.
        /// 
        /// This method should always be used after setting up the lemming (color, rotation, ...)
        /// </summary>
        /// <param name="gameObjectInteractedWith"> last game object interacted with </param>
        public void SetLastUsedGameObjectAndInit(GameObject gameObjectInteractedWith)
        {
            _lastUsedGameObject = gameObjectInteractedWith;
            _isInit = true;
            enabled = true;
            //Maybe start a coroutine here to make it possible to use the same collider after x seconds again.
        }

        /// <summary>
        /// Updates the time to live value in the display when its value has changed
        /// </summary>
        private void UpdateTTL()
        {
            _lemmingTTLDisplay.UpdateTTL();
        }
        #region Getter and setter
        public int GetLemmingId()
        {
            return _lemmingId;
        }

        public float GetYOffset()
        {
            return _yOffset;
        }

        public float GetTimeToLive() => _timeToLive;

        public Color GetLemmingColor()
        {
            return _lemmingColor;
        }

        public void SetColor(Color newColor)
        {
            _lemmingColor = newColor;

            MaterialPropertyBlock props = new MaterialPropertyBlock();
            props.SetColor("_BaseColor", _lemmingColor);
            _renderer.SetPropertyBlock(props);
        }
        #endregion

        #region Unity Callbacks
        private void OnEnable()
        {
            _lemmingManager = LemmingManager.Instance;
            UpdateTTL();
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