using System.Collections.Generic;
using System;
using UnityEngine;

namespace HypercubesPrototyp.GameLogic.Utils
{
    /// <summary>
    /// Creates new lemmings with specified parameters and adds them to the manager.
    /// Returns the instantiated lemming to whomever called it, so the caller can
    /// do things with the new lemming as well.
    /// 
    /// Implementation of the singleton pattern to be available for other classes easily
    /// (<see cref="HyperCubeLogic.LemmingSpawnCube"/> <seealso cref="HyperCubeLogic.SplitCube"/>)
    /// </summary>
    public class LemmingFactory : MonoBehaviour
    {
        public static LemmingFactory Instance;
        [SerializeField] private List<GameObject> _lemmingPrefabs;
        [SerializeField] private Transform _lemmingParent;

        private LemmingManager _lemmingManager;

        /// <summary>
        /// Instatiates a new lemming from the <paramref name="id"/> at a given <paramref name="position"/>.
        /// The id will be looked up in a list of lemming gameobjects.
        /// 
        /// Note:
        /// This creation method is private to ensure that the color and time to live
        /// of a lemming are always initialized.
        /// </summary>
        /// <param name="id"> position in prefab list </param>
        /// <param name="position"> position in unity world space </param>
        /// <returns> newly created lemming </returns>
        private Lemming CreateLemming(LemmingModel id, Vector3 position)
        {
            //Might want to think about object pooling
            Lemming instancedLemming = null;
            if (_lemmingPrefabs == null || _lemmingPrefabs.Count == 0)
            {
                throw new ArgumentOutOfRangeException("CRITICAL ERROR: the prefab list is not initialized!");
            }
            else if (_lemmingPrefabs.Count > (int) id)
            {
                var instancedLemmingGO = Instantiate(_lemmingPrefabs[(int) id], position, Quaternion.identity);
                instancedLemmingGO.transform.parent = _lemmingParent;

                instancedLemming = instancedLemmingGO.GetComponent<Lemming>();
                instancedLemmingGO.transform.position += Vector3.up * instancedLemming.GetYOffset();

                _lemmingManager.AddLemming(instancedLemming);
            }
            return instancedLemming;
        }

        /// <summary>
        /// Default lemming creation method.
        /// 
        /// Instatiates a new lemming from the <paramref name="id"/> at a given <paramref name="position"/>.
        /// The id will be looked up in a list of lemming gameobjects.
        /// 
        /// Will add a <paramref name="color"/> and <paramref name="timeToLive"/> to the lemming before
        /// returning it.
        /// </summary>
        /// <param name="id"> id of the lemming for list lookup </param>
        /// <param name="position"> position in unity world space </param>
        /// <param name="color"> specified color for the lemming </param>
        /// <param name="timeToLive"> specified time to live for the lemming </param>
        /// <returns> newly created lemming </returns>
        public Lemming CreateLemming(LemmingModel id, Vector3 position, LemmingColor color, float timeToLive)
        {
            Lemming instancedLemming = CreateLemming(id, position);
            instancedLemming.SetColor(color);
            instancedLemming.AddTimeToLive(timeToLive);
            return instancedLemming;
        }

        /// <summary>
        /// Will create a new lemming and also define its rotation on the y-axis with thee <paramref name="yRotationInDegrees"/>.
        /// </summary>
        /// <param name="id"> id of the lemming for list lookup  </param>
        /// <param name="position"> position in unity world space </param>
        /// <param name="color"> specified color for the lemming </param>
        /// <param name="timeToLive"> specified time to live for the lemming </param>
        /// <param name="yRotationInDegrees"> specified rotation on the y axis in degrees for the lemming </param>
        /// <returns> newly created lemming </returns>
        public Lemming CreateLemming(LemmingModel id, Vector3 position, LemmingColor color, float timeToLive, float yRotationInDegrees)
        {
            Lemming instancedLemming = CreateLemming(id, position, color, timeToLive);
            instancedLemming.SetRotationOnY(yRotationInDegrees);
            return instancedLemming;
        }

        #region Unity_callbacks
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _lemmingManager = LemmingManager.Instance;
        }
        #endregion
    }
}