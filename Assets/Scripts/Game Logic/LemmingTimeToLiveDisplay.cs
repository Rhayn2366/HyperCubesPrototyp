using TMPro;
using UnityEngine;

namespace HypercubesPrototyp.GameLogic
{
    public class LemmingTimeToLiveDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _timeToLiveLabel;
        private Transform _cameraTransform;

        private void Awake()
        {
            // Calling it to often is wasting ressources
            _cameraTransform = Camera.main.transform;
        }

        public void UpdateTTL(float time)
        {
            _timeToLiveLabel.text = time.ToString("##");
            transform.rotation = Quaternion.LookRotation(_cameraTransform.forward, _cameraTransform.up);
        }
    }
}