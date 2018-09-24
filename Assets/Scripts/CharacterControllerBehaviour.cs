using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(CharacterController))] // Creates and adds a CharacterController Component if there is none
public class CharacterControllerBehaviour : MonoBehaviour {

    [SerializeField]
    private Transform _absoluteTransform;

    private CharacterController _characterController;

    private Vector3 _velocity = Vector3.zero; // [m/s]
    private Vector3 _inputMovement = Vector3.zero;

	void Start()
    {
        _characterController = GetComponent<CharacterController>();

#if DEBUG
        //if (_characterController == null)
        //    Debug.LogError("DEPENDENCY ERROR: CharacterControllerBehaviour needs a CharacterControllerComponent");
        Assert.IsNotNull(_characterController, "DEPENDENCY ERROR: CharacterControllerBehaviour needs a CharacterControllerComponent");
#endif
    }

    void Update()
    {
        _inputMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        ApplyGround();

        ApplyGravity();

        ApplyMovement();

        DoMovement();
    }

    private void ApplyGround()
    {
        if (_characterController.isGrounded)
        {
            _velocity -= Vector3.Project(_velocity, Physics.gravity);
        }
    }

    private void ApplyGravity()
    {
        if (!_characterController.isGrounded)
        {
            _velocity += Physics.gravity * Time.fixedDeltaTime; // in FixedUpdate(), deltaTime and fixedDeltaTime is the same
        }
    }

    private void ApplyMovement()
    {
        
    }

    private void DoMovement()
    {
        Vector3 displacement = _velocity * Time.deltaTime;

        _characterController.Move(displacement);
    }
}
