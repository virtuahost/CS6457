using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestScript : MonoBehaviour {

    //Button text
    public Text btnText;

    //Axis Text and Name
    public Text axisText;
    public Text axisName;

    //Trigger Text and Name    
    public Text trgText;
    public Text trgName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        btnText.text = "";
        trgName.text = "";
        trgText.text = "";
        axisName.text = "";
        axisText.text = "";

        if (ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.A))
            btnText.text = "A";
        if (ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.B))
            btnText.text = "B";
        if (ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.Back))
            btnText.text = "Back";
        if (ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.LeftBumper))
            btnText.text = "Left Bumper";
        if (ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.RightBumper))
            btnText.text = "Right Bumper";
        if (ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.LeftStickClick))
            btnText.text = "Left Stick Clicked";
        if (ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.RightStickClick))
            btnText.text = "Right Stick Click";
        if (ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.Start))
            btnText.text = "Start";
        if (ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.X))
            btnText.text = "X";
        if (ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.Y))
            btnText.text = "Y";

        if (ControlInputWrapper.GetTrigger(ControlInputWrapper.Triggers.LeftTrigger) != 0)
        {
            trgName.text = "Left Trigger";
            trgText.text = ControlInputWrapper.GetTrigger(ControlInputWrapper.Triggers.LeftTrigger).ToString();
        }
        if (ControlInputWrapper.GetTrigger(ControlInputWrapper.Triggers.RightTrigger) != 0)
        {
            trgName.text = "Right Trigger";
            trgText.text = ControlInputWrapper.GetTrigger(ControlInputWrapper.Triggers.RightTrigger).ToString();
        }

        if (ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.RightStickY) > 0)
        {
            axisName.text = "Right Stick Down";
            axisText.text = ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.RightStickY).ToString();
        }
        else if (ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.RightStickY) < 0)
        {
            axisName.text = "Right Stick Up";
            axisText.text = ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.RightStickY).ToString();
        }
        if (ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.RightStickX) > 0)
        {
            axisName.text = "Right Stick right";
            axisText.text = ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.RightStickX).ToString();
        }
        else if (ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.RightStickX) < 0)
        {
            axisName.text = "Right Stick left";
            axisText.text = ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.LeftStickY).ToString();
        }

        if (ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.LeftStickY) > 0)
        {
            axisName.text = "Left Stick Down";
            axisText.text = ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.LeftStickY).ToString();
        }
        else if (ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.LeftStickY) < 0)
        {
            axisName.text = "Left Stick Up";
            axisText.text = ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.LeftStickY).ToString();
        }
        if (ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.LeftStickX) > 0)
        {
            axisName.text = "Left Stick right";
            axisText.text = ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.LeftStickX).ToString();
        }
        else if (ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.LeftStickX) < 0)
        {
            axisName.text = "Left Stick left";
            axisText.text = ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.LeftStickX).ToString();
        }

        if (ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.DPadY) > 0)
        {
            axisName.text = "Dpad Down";
            axisText.text = ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.DPadY).ToString();
        }
        else if (ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.DPadY) < 0)
        {
            axisName.text = "Dpad Up";
            axisText.text = ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.DPadY).ToString();
        }
        if (ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.DPadX) > 0)
        {
            axisName.text = "Dpad right";
            axisText.text = ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.DPadX).ToString();
        }
        else if (ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.DPadX) < 0)
        {
            axisName.text = "Dpad left";
            axisText.text = ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.DPadX).ToString();
        }
    }
}
