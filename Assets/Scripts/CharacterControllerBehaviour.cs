using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(CharacterController))] //Creates and adds a CharacterController Component if there is none
public class CharacterControllerBehaviour : MonoBehaviour {

    private CharacterController _characterController;

	void Start () {
        _characterController = GetComponent<CharacterController>();

#if DEBUG
        //if (_characterController == null)
        //    Debug.LogError("DEPENDENCY ERROR: CharacterControllerBehaviour needs a CharacterControllerComponent");
        Assert.IsNotNull(_characterController, "DEPENDENCY ERROR: CharacterControllerBehaviour needs a CharacterControllerComponent");
#endif
    }

    void Update () {
		
	}
}
