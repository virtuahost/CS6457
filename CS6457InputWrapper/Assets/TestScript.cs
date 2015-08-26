using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.A))
            Debug.Log("Button A");
        Debug.Log("Button B: " + ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.B));
        Debug.Log("Button Back: " + ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.Back));
        Debug.Log("Button Left Bumper: " + ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.LeftBumper));
        Debug.Log("Button Right Bumper: " + ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.RightBumper));
        Debug.Log("Button Left Stick Click: " + ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.LeftStickClick));
        Debug.Log("Button Right Stick Click: " + ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.RightStickClick));
        Debug.Log("Button Start: " + ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.Start));
        Debug.Log("Button X: " + ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.X));
        Debug.Log("Button Y: " + ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.Y));
        Debug.Log("Trigger Left: " + ControlInputWrapper.GetTrigger(ControlInputWrapper.Triggers.LeftTrigger));
        Debug.Log("Trigger Right: " + ControlInputWrapper.GetTrigger(ControlInputWrapper.Triggers.RightTrigger));
        Debug.Log("Axis Right Stick Y: " + ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.RightStickY));
        Debug.Log("Axis Right Stick X: " + ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.RightStickX));
        Debug.Log("Axis Left Stick Y: " + ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.LeftStickY));
        Debug.Log("Axis Left Stick X: " + ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.LeftStickX));
        Debug.Log("Axis Dpad Y: " + ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.DPadY));
        Debug.Log("Axis Dpad X: " + ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.DPadX));
    }
}
