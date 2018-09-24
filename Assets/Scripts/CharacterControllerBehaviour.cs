using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(CharacterController))] // Creates and adds a CharacterController Component if there is none
public class CharacterControllerBehaviour : MonoBehaviour {

    private CharacterController _characterController;
    private Vector3 _velocity = Vector3.zero; // [m/s]

	void Start () {
        _characterController = GetComponent<CharacterController>();

#if DEBUG
        //if (_characterController == null)
        //    Debug.LogError("DEPENDENCY ERROR: CharacterControllerBehaviour needs a CharacterControllerComponent");
        Assert.IsNotNull(_characterController, "DEPENDENCY ERROR: CharacterControllerBehaviour needs a CharacterControllerComponent");
#endif
    }

    void Update() {
        if (!_characterController.isGrounded)
        {
            _velocity += Physics.gravity * Time.deltaTime;
        }
        Vector3 movement = _velocity * Time.deltaTime;

        _characterController.Move(movement);
    }
}
