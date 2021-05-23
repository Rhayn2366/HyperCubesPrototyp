using TMPro;
using UnityEngine;

namespace HypercubesPrototyp.GameLogic
{
    /// <summary>
    /// This class adds a display to give the player information about the time
    /// to live value of a lemming. The time to live will be displayed through a text
    /// and rotate towards the camera.
    /// </summary>
    public class LemmingTimeToLiveDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _timeToLiveLabel;
        [SerializeField] private Lemming _lemming;
        private Transform _cameraTransform;

        /// <summary>
        /// This method updates the time to live (TTL) display value of the lemming
        /// and makes sure that the text (always) faces the camera.
        /// </summary>
        public void UpdateTTL()
        {
            _timeToLiveLabel.text = _lemming.GetTimeToLive().ToString("##");
            FaceCamera();
        }

        /// <summary>
        /// Rotate self towards camera.
        /// </summary>
        private void FaceCamera()
        {
            transform.rotation = Quaternion.LookRotation(_cameraTransform.forward, _cameraTransform.up);
        }

        #region Unity_callbacks
        private void Awake()
        {
            _cameraTransform = Camera.main.transform;
        }
        #endregion
    }
}