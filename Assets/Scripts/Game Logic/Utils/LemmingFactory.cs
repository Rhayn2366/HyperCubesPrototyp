using System.Collections.Generic;
using System;
using UnityEngine;

namespace HypercubesPrototyp.GameLogic.Utils
{
    public class LemmingFactory : MonoBehaviour
    {
        public static LemmingFactory Instance;
        [SerializeField] private List<GameObject> _lemmingPrefabs;
        [SerializeField] private Transform _lemmingParent;

        private LemmingManager _lemmingManager;

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

        public Lemming CreateLemming(int id, Vector3 position, Color color)
        {
            //Might want to think about object pooling
            Lemming instancedLemming = null;
            if (_lemmingPrefabs == null || _lemmingPrefabs.Count == 0)
            {
                throw new ArgumentOutOfRangeException("The prefab list is not initialized!");
            }
            else if (_lemmingPrefabs.Count > id)
            {
                var instancedLemmingGO = Instantiate(_lemmingPrefabs[id], position, Quaternion.identity);
                instancedLemmingGO.transform.parent = _lemmingParent;

                instancedLemming = instancedLemmingGO.GetComponent<Lemming>();
                instancedLemmingGO.transform.position += Vector3.up * instancedLemming.GetYOffset();
                instancedLemming.SetColor(color);

                _lemmingManager.AddLemming(instancedLemming);
            }
            return instancedLemming;
        }

        public Lemming CreateLemming(int id, Vector3 position, Color color, float yRotationInDegrees)
        {
            Lemming instancedLemming = CreateLemming(id, position, color);
            instancedLemming.SetRotationOnY(yRotationInDegrees);
            return instancedLemming;
        }
    }
}