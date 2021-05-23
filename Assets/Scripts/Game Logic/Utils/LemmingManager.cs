using System.Collections.Generic;
using UnityEngine;

namespace HypercubesPrototyp.GameLogic.Utils
{
    /// <summary>
    /// Manages basic things for all lemmings (<see cref="Lemming"/>
    /// to avoid performance heavy unity callbacks (in this case update)
    /// on each monobehaviour.
    /// 
    /// Also keeps track of all active lemmings in the scene and has the ability
    /// to delete them.
    /// 
    /// Implementation of the singleton pattern to be available for other classes easily
    /// (<see cref="Lemming"/> <seealso cref="LemmingFactory"/>)
    /// </summary>
    public class LemmingManager : MonoBehaviour
    {
        public static LemmingManager Instance;

        private readonly List<Lemming> _activeLemmings = new List<Lemming>();

        /// <summary>
        /// Adds a new lemming to the manager to track and instruct it.
        /// </summary>
        /// <param name="lemming"> (newly) created lemming </param>
        public void AddLemming(Lemming lemming)
        {
            _activeLemmings.Add(lemming);
        }


        /// <summary>
        /// Removes a lemming from the manager, so that it will be no longer
        /// tracked or instructed.
        /// </summary>
        /// <param name="lemming"> destroyed lemming </param>
        public void RemoveLemming(Lemming lemming)
        {
            _activeLemmings.Remove(lemming);
        }

        /// <summary>
        /// Destroys all lemmings and removes them from the manager.
        /// </summary>
        public void DeleteAllLemmings()
        {
            for (int i = _activeLemmings.Count - 1; i >= 0; i--)
            {
                Lemming lemming = _activeLemmings[i];
                Destroy(lemming.gameObject);
            }
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

        private void FixedUpdate()
        {
            var cachedDeltaTime = Time.deltaTime;

            foreach (Lemming lemming in _activeLemmings)
            {
                lemming.Move();
                lemming.SubtractTimeToLive(cachedDeltaTime);
            }
        }
        #endregion
    }
}