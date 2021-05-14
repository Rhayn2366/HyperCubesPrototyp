using System.Collections.Generic;
using UnityEngine;

namespace HypercubesPrototyp.GameLogic.Utils
{
    public class LemmingManager : MonoBehaviour
    {
        public static LemmingManager Instance;

        private readonly List<Lemming> _activeLemmings = new List<Lemming>();

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

        public void AddLemming(Lemming lemming)
        {
            _activeLemmings.Add(lemming);
        }

        public void RemoveLemming(Lemming lemming)
        {
            _activeLemmings.Remove(lemming);
        }

        public void DeleteAllLemmings()
        {
            for (int i = _activeLemmings.Count - 1; i >= 0; i--)
            {
                Lemming lemming = _activeLemmings[i];
                Destroy(lemming.gameObject);
            }
        }

        private void FixedUpdate()
        {
            foreach (var lemming in _activeLemmings)
            {
                lemming.Move();
            }
        }
    }
}