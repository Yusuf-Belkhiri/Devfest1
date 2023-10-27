using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerController _controller;
    private float _horizontalInput;
    private bool _jump;

    
    private void Start()
    {
        _controller = GetComponent<PlayerController>();
    }
    
    // INPUT
    void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))    // can be replaced with getButton
        {
            _jump = true;
        }
    }
    
    private void FixedUpdate()
    {
        _controller.Move(_horizontalInput, _jump);
        _jump = false;
    }
}
