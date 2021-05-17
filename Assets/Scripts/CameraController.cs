using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    [Header("Movement values:")]

    [SerializeField] private float _normalSpeed = 1.5f;
    [SerializeField] private float _fastSpeed = 3f;

    [SerializeField] private float _movementSpeed = 1f;
    [SerializeField] private float _movementTime = 5f;

    [SerializeField] private float _rotationAmount = 15f;

    [SerializeField] private float _mouseZoomSensivity = 25f;
    [SerializeField] private float _mouseRotationSensivity = 15f;

    [Header("Movement keys:")]

    [SerializeField] private KeyCode _holdFastKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode _forward = KeyCode.W;
    [SerializeField] private KeyCode _backwards = KeyCode.S;
    [SerializeField] private KeyCode _left = KeyCode.A;
    [SerializeField] private KeyCode _right = KeyCode.D;
    [SerializeField] private KeyCode _resetCamera = KeyCode.Z;

    private Vector3 _rotateStartPosition;
    private Vector3 _rotateCurrentPosition;

    private Vector3 _zoomAmount = new Vector3(0, -1, 1);

    private bool _isLerpingBack = false;
    private Vector3 _startPoint;
    private Quaternion _startRotation;
    private Vector3 _startLocalCameraPosition;

    private readonly float _minY = 0f;
    private float _maxY = 100f;

    private Vector3 _position;
    private Quaternion _rotation;
    private Vector3 _zoom;

    private void Start()
    {
        _startPoint = transform.position;
        _startRotation = transform.rotation;
        _startLocalCameraPosition = _cameraTransform.localPosition;
    }

    private void Update()
    {
        SetCameraValues();

        UserInput();

        ClampValues();

        UpdateCameraValues();
    }

    private void SetCameraValues()
    {
        _position = transform.position;
        _rotation = transform.rotation;
        _zoom = _cameraTransform.localPosition;
    }

    private void UserInput()
    {
        if (_isLerpingBack)
        {
            if (LerpingBackFinished())
            {
                _isLerpingBack = false;
            }
            else
            {
                _position = _startPoint;
                _rotation = _startRotation;
                _zoom = _startLocalCameraPosition;
            }
        }
        else
        {
            ToggleFast();
            Move();
            RotateYAxis();
            Zoom();
            SetOriginalCamera();
        }
    }

    private bool LerpingBackFinished()
    {
        return _position == _startPoint && _zoom == _startLocalCameraPosition;
    }

    private void ToggleFast()
    {
        if (Input.GetKey(_holdFastKey))
        {
            _movementSpeed = _fastSpeed;
        }
        else
        {
            _movementSpeed = _normalSpeed;
        }
    }
    private void Move()
    {
        if (Input.GetKey(_forward))
        {
            _position += transform.forward * _movementSpeed;
        }
        if (Input.GetKey(_backwards))
        {
            _position += transform.forward * -_movementSpeed;
        }
        if (Input.GetKey(_left))
        {
            _position += transform.right * -_movementSpeed;
        }
        if (Input.GetKey(_right))
        {
            _position += transform.right * _movementSpeed;
        }
    }
    private void RotateYAxis()
    {
        if (Input.GetMouseButtonDown(2))
        {
            _rotateStartPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(2))
        {
            _rotateCurrentPosition = Input.mousePosition;

            Vector3 difference = _rotateStartPosition - _rotateCurrentPosition;

            _rotateStartPosition = _rotateCurrentPosition;

            _rotation *= Quaternion.Euler(Vector3.up * (-difference.x * _mouseRotationSensivity / _rotationAmount));
        }
    }
    private void Zoom()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            _zoom += Input.mouseScrollDelta.y * _zoomAmount * _mouseZoomSensivity;
        }
    }
    private void SetOriginalCamera()
    {
        if (Input.GetKeyDown(_resetCamera))
        {
            _position = _startPoint;
            _rotation = _startRotation;
            _zoom = _startLocalCameraPosition;
            _isLerpingBack = true;
        }
    }

    private void ClampValues()
    {
        _zoom.y = Mathf.Clamp(_zoom.y, _minY, _maxY);
        _zoom.z = Mathf.Clamp(_zoom.z, -(_maxY), -(_minY));
    }
    private void UpdateCameraValues()
    {
        transform.position = Vector3.Lerp(transform.position, _position, Time.unscaledDeltaTime * _movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rotation, Time.unscaledDeltaTime * _movementTime);
        _cameraTransform.localPosition = Vector3.Lerp(_cameraTransform.localPosition, _zoom, Time.unscaledDeltaTime * _movementTime);
    }
}
