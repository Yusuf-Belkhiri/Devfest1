using System;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private Transform _lookAt;   // THE TARGET (CURRENTLY THE PLAYER)
    [SerializeField] private float cameraSpeed = 3;
    [SerializeField] private float threshX = 0.15f;  // SCREEN THRESH X
    [SerializeField] private float threshY = 0.3f;  // SCREEN THRESH Y
    
    // CAMERA SCROLLING LIMITS COORDINATES
    [SerializeField] private Transform _lowerLeftBounds;
    [SerializeField] private  Transform _upperRightBounds;
    

    private Vector3 _delta;
    private float _deltaX;
    private float _deltaY;
    #endregion


    #region METHODS

    private Vector3 _move;
    private void FixedUpdate()
    {
        _delta = Vector3.zero;      // difference between this frame & next frame  (initialise it to 0)

        // HORIZONTAL SCROLL
        _deltaX = Math.Clamp(_lookAt.position.x, _lowerLeftBounds.position.x, _upperRightBounds.position.x) - transform.position.x;    
        if(Mathf.Abs(_deltaX) > threshX)     
        {
            _delta.x = _deltaX - Mathf.Sign(_deltaX) * threshX;
        }
        // VERTICAL SCROLL
        _deltaY = Math.Clamp(_lookAt.position.y, _lowerLeftBounds.position.y, _upperRightBounds.position.y) - transform.position.y;
        if (Mathf.Abs(_deltaY) > threshY)
        {
            _delta.y = _deltaY - Mathf.Sign(_deltaY) * threshY;
        }

        // APPLY SCROLL
        transform.position += _delta * (Time.fixedDeltaTime * cameraSpeed);
    }
    
    #endregion
}
