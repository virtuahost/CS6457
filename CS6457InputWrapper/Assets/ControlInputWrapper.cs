﻿using UnityEngine;
using System.Collections;

//Class to handle mapping of different controllers in Unity over different OS(Windows and Mac Os X primarily). As of now coding for XBox 360 controller
public static class ControlInputWrapper{
    //Enums to handle all possible inputs on a controller. 3 Broad categories "Buttons", "Triggers" and "Axis". 
    //PS3 stuff yet to come. A,B,X and Y will map to corresponding buttons on PS3
    //A -> Square
    //B -> X
    //X -> Circle
    //Y -> Triangle
    public enum Axis { LeftStickY, LeftStickX, RightStickY, RightStickX, DPadY, DPadX};
    public enum Buttons {A, B, X, Y, RightBumper, LeftBumper, Back, Start, LeftStickCLick, RightStickClick };
    public enum Triggers {RightTrigger, LeftTrigger };
    private static string LEFT_OSX_TRIGGER = "LeftOSXTrigger";
    private static string LEFT_LINUX_TRIGGER = "LeftLinuxTrigger";
    private static string LEFT_WIN_TRIGGER = "LeftWinTrigger";
    private static string RIGHT_OSX_TRIGGER = "RightOSXTrigger";
    private static string RIGHT_LINUX_TRIGGER = "RightLinuxTrigger";
    private static string RIGHT_WIN_TRIGGER = "RightWinTrigger";
    private static string RIGHT_OSX_STICK_Y = "RightOSXStickY";
    private static string RIGHT_WIN_STICK_Y = "RightWinStickY";
    private static string RIGHT_OSX_STICK_X = "RightOSXStickX";
    private static string RIGHT_WIN_STICK_X = "RightWinStickX";
    private static string LEFT_STICK_Y = "Horizontal";
    private static string LEFT_STICK_X = "Vertical";
    private static string DPAD_WIN_STICK_Y = "DpadWinStickY";
    private static string DPAD_WIN_STICK_X = "DpadWinStickX";

    private static float GetAxisData(string axisName, bool rawInput = false)
    {
        if (rawInput)
            return Input.GetAxisRaw(axisName);
        else
            return Input.GetAxis(axisName);
    }

    public static bool GetButtonDown(Buttons btn,int joyStickNumber = 0)
    {
        KeyCode btnKeyCode = GetKeyCode(btn, joyStickNumber);
        return Input.GetKeyDown(btnKeyCode);
    }

    public static bool GetButtonUp(Buttons btn, int joyStickNumber = 0)
    {
        KeyCode btnKeyCode = GetKeyCode(btn, joyStickNumber);
        return Input.GetKeyUp(btnKeyCode);
    }

    public static bool GetButton(Buttons btn, int joyStickNumber = 0)
    {
        KeyCode btnKeyCode = GetKeyCode(btn, joyStickNumber);
        return Input.GetKey(btnKeyCode);
    }

    public static float GetAxis(Axis axisName,bool rawInput = false)
    {
        float result = 0;
        switch (axisName)
        {
            case Axis.RightStickY:
                switch (Application.platform)
                {
                    case RuntimePlatform.OSXDashboardPlayer:
                    case RuntimePlatform.OSXEditor:
                    case RuntimePlatform.OSXPlayer:
                    case RuntimePlatform.OSXWebPlayer:
                        result = GetAxisData(RIGHT_OSX_STICK_Y, rawInput);
                        break;
                    case RuntimePlatform.LinuxPlayer:
                    default:
                        result = GetAxisData(RIGHT_WIN_STICK_Y, rawInput);
                        break;
                }
                break;
            case Axis.RightStickX:
                switch (Application.platform)
                {
                    case RuntimePlatform.OSXDashboardPlayer:
                    case RuntimePlatform.OSXEditor:
                    case RuntimePlatform.OSXPlayer:
                    case RuntimePlatform.OSXWebPlayer:
                        result = GetAxisData(RIGHT_OSX_STICK_X, rawInput);
                        break;
                    case RuntimePlatform.LinuxPlayer:
                    default:
                        result = GetAxisData(RIGHT_WIN_STICK_X, rawInput);
                        break;
                }
                break;
            case Axis.LeftStickY:
                switch (Application.platform)
                {
                    case RuntimePlatform.OSXDashboardPlayer:
                    case RuntimePlatform.OSXEditor:
                    case RuntimePlatform.OSXPlayer:
                    case RuntimePlatform.OSXWebPlayer:
                    case RuntimePlatform.LinuxPlayer:
                    default:
                        result = GetAxisData(LEFT_STICK_Y, rawInput);
                        break;
                }
                break;
            case Axis.LeftStickX:
                switch (Application.platform)
                {
                    case RuntimePlatform.OSXDashboardPlayer:
                    case RuntimePlatform.OSXEditor:
                    case RuntimePlatform.OSXPlayer:
                    case RuntimePlatform.OSXWebPlayer:
                    case RuntimePlatform.LinuxPlayer:
                    default:
                        result = GetAxisData(LEFT_STICK_X, rawInput);
                        break;
                }
                break;
            case Axis.DPadY:
                switch (Application.platform)
                {
                    case RuntimePlatform.OSXDashboardPlayer:
                    case RuntimePlatform.OSXEditor:
                    case RuntimePlatform.OSXPlayer:
                    case RuntimePlatform.OSXWebPlayer:
                    default:
                        result = GetAxisData(DPAD_WIN_STICK_X, rawInput);
                        break;
                }
                break;
            case Axis.DPadX:
                switch (Application.platform)
                {
                    case RuntimePlatform.OSXDashboardPlayer:
                    case RuntimePlatform.OSXEditor:
                    case RuntimePlatform.OSXPlayer:
                    case RuntimePlatform.OSXWebPlayer:
                    default:
                        result = GetAxisData(DPAD_WIN_STICK_Y, rawInput);
                        break;
                }
                break;
        }
        return result;
    }
    
    public static float GetTrigger(Triggers trgName,bool rawInput = false)
    {
        float result = 0;
        switch (trgName)
        {
            case Triggers.LeftTrigger:
                switch (Application.platform)
                {
                    case RuntimePlatform.OSXDashboardPlayer:
                    case RuntimePlatform.OSXEditor:
                    case RuntimePlatform.OSXPlayer:
                    case RuntimePlatform.OSXWebPlayer:                        
                        result = GetAxisData(LEFT_OSX_TRIGGER,rawInput);
                        break;
                    case RuntimePlatform.LinuxPlayer:
                        result = GetAxisData(LEFT_LINUX_TRIGGER,rawInput);
                        break;
                    default:
                        result = GetAxisData(LEFT_WIN_TRIGGER,rawInput);
                        break;
                }
                break;
            case Triggers.RightTrigger:
                switch (Application.platform)
                {
                    case RuntimePlatform.OSXDashboardPlayer:
                    case RuntimePlatform.OSXEditor:
                    case RuntimePlatform.OSXPlayer:
                    case RuntimePlatform.OSXWebPlayer:
                        result = GetAxisData(RIGHT_OSX_TRIGGER,rawInput);
                        break;
                    case RuntimePlatform.LinuxPlayer:
                        result = GetAxisData(RIGHT_LINUX_TRIGGER,rawInput);
                        break;
                    default:
                        result = GetAxisData(RIGHT_WIN_TRIGGER,rawInput);
                        break;
                }
                break;
        }
        return result;
    }

    //Function to return Keycode of a particular button based on OS and joystick number. Joystick number 0 is considered for "Any" joystick.
    public static KeyCode GetKeyCode(Buttons btn,int joyStickNumber = 0)
    {
        switch (joyStickNumber)
        {
            case 1:
                switch (btn)
                {
                    case Buttons.A:
                        switch(Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick1Button16;
                            default:
                                return KeyCode.Joystick1Button0;
                        }
                    case Buttons.B:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick1Button17;
                            default:
                                return KeyCode.Joystick1Button1;
                        }
                    case Buttons.X:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick1Button18;
                            default:
                                return KeyCode.Joystick1Button2;
                        }
                    case Buttons.Y:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick1Button19;
                            default:
                                return KeyCode.Joystick1Button3;
                        }
                    case Buttons.RightBumper:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                                return KeyCode.Joystick1Button14;
                            case RuntimePlatform.OSXEditor:
                                return KeyCode.Joystick1Button14;
                            case RuntimePlatform.OSXPlayer:
                                return KeyCode.Joystick1Button14;
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick1Button14;
                            default:
                                return KeyCode.Joystick1Button5;
                        }
                    case Buttons.LeftBumper:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick1Button13;
                            default:
                                return KeyCode.Joystick1Button4;
                        }
                    case Buttons.Back:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick1Button10;
                            default:
                                return KeyCode.Joystick1Button6;
                        }
                    case Buttons.Start:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick1Button9;
                            default:
                                return KeyCode.Joystick1Button7;
                        }
                    case Buttons.RightStickClick:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick1Button12;
                            case RuntimePlatform.LinuxPlayer:
                                return KeyCode.Joystick1Button10;
                            default:
                                return KeyCode.Joystick1Button9;
                        }
                    case Buttons.LeftStickCLick:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick1Button11;
                            case RuntimePlatform.LinuxPlayer:
                                return KeyCode.Joystick1Button9;
                            default:
                                return KeyCode.Joystick1Button8;
                        }
                }
                break;
            case 2:
                switch (btn)
                {
                    case Buttons.A:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick2Button16;
                            default:
                                return KeyCode.Joystick2Button0;
                        }
                    case Buttons.B:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick2Button17;
                            default:
                                return KeyCode.Joystick2Button1;
                        }
                    case Buttons.X:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick2Button18;
                            default:
                                return KeyCode.Joystick2Button2;
                        }
                    case Buttons.Y:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick2Button19;
                            default:
                                return KeyCode.Joystick2Button3;
                        }
                    case Buttons.RightBumper:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick2Button14;
                            default:
                                return KeyCode.Joystick2Button5;
                        }
                    case Buttons.LeftBumper:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick2Button13;
                            default:
                                return KeyCode.Joystick2Button4;
                        }
                    case Buttons.Back:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick2Button10;
                            default:
                                return KeyCode.Joystick2Button6;
                        }
                    case Buttons.Start:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick2Button9;
                            default:
                                return KeyCode.Joystick2Button7;
                        }
                    case Buttons.RightStickClick:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick2Button12;
                            case RuntimePlatform.LinuxPlayer:
                                return KeyCode.Joystick2Button10;
                            default:
                                return KeyCode.Joystick2Button9;
                        }
                    case Buttons.LeftStickCLick:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick2Button11;
                            case RuntimePlatform.LinuxPlayer:
                                return KeyCode.Joystick2Button9;
                            default:
                                return KeyCode.Joystick2Button8;
                        }
                }
                break;
            case 3:
                switch (btn)
                {
                    case Buttons.A:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick3Button16;
                            default:
                                return KeyCode.Joystick3Button0;
                        }
                    case Buttons.B:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick3Button17;
                            default:
                                return KeyCode.Joystick3Button1;
                        }
                    case Buttons.X:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick3Button18;
                            default:
                                return KeyCode.Joystick3Button2;
                        }
                    case Buttons.Y:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick3Button19;
                            default:
                                return KeyCode.Joystick3Button3;
                        }
                    case Buttons.RightBumper:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick3Button14;
                            default:
                                return KeyCode.Joystick3Button5;
                        }
                    case Buttons.LeftBumper:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick3Button13;
                            default:
                                return KeyCode.Joystick3Button4;
                        }
                    case Buttons.Back:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick3Button10;
                            default:
                                return KeyCode.Joystick3Button6;
                        }
                    case Buttons.Start:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick3Button9;
                            default:
                                return KeyCode.Joystick3Button7;
                        }
                    case Buttons.RightStickClick:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick3Button12;
                            case RuntimePlatform.LinuxPlayer:
                                return KeyCode.Joystick3Button10;
                            default:
                                return KeyCode.Joystick3Button9;
                        }
                    case Buttons.LeftStickCLick:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick3Button11;
                            case RuntimePlatform.LinuxPlayer:
                                return KeyCode.Joystick3Button9;
                            default:
                                return KeyCode.Joystick3Button8;
                        }
                }
                break;
            case 4:
                switch (btn)
                {
                    case Buttons.A:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick4Button16;
                            default:
                                return KeyCode.Joystick4Button0;
                        }
                    case Buttons.B:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick4Button17;
                            default:
                                return KeyCode.Joystick4Button1;
                        }
                    case Buttons.X:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick4Button18;
                            default:
                                return KeyCode.Joystick4Button2;
                        }
                    case Buttons.Y:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                                return KeyCode.Joystick4Button19;
                            case RuntimePlatform.OSXEditor:
                                return KeyCode.Joystick4Button19;
                            case RuntimePlatform.OSXPlayer:
                                return KeyCode.Joystick4Button19;
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick4Button19;
                            default:
                                return KeyCode.Joystick4Button3;
                        }
                    case Buttons.RightBumper:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick4Button14;
                            default:
                                return KeyCode.Joystick4Button5;
                        }
                    case Buttons.LeftBumper:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick4Button13;
                            default:
                                return KeyCode.Joystick4Button4;
                        }
                    case Buttons.Back:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick4Button10;
                            default:
                                return KeyCode.Joystick4Button6;
                        }
                    case Buttons.Start:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick4Button9;
                            default:
                                return KeyCode.Joystick4Button7;
                        }
                    case Buttons.RightStickClick:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick4Button12;
                            case RuntimePlatform.LinuxPlayer:
                                return KeyCode.Joystick4Button10;
                            default:
                                return KeyCode.Joystick4Button9;
                        }
                    case Buttons.LeftStickCLick:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick4Button11;
                            case RuntimePlatform.LinuxPlayer:
                                return KeyCode.Joystick4Button9;
                            default:
                                return KeyCode.Joystick4Button8;
                        }
                }
                break;
            case 5:
                switch (btn)
                {
                    case Buttons.A:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick5Button16;
                            default:
                                return KeyCode.Joystick5Button0;
                        }
                    case Buttons.B:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick5Button17;
                            default:
                                return KeyCode.Joystick5Button1;
                        }
                    case Buttons.X:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick5Button18;
                            default:
                                return KeyCode.Joystick5Button2;
                        }
                    case Buttons.Y:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick5Button19;
                            default:
                                return KeyCode.Joystick5Button3;
                        }
                    case Buttons.RightBumper:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick5Button14;
                            default:
                                return KeyCode.Joystick5Button5;
                        }
                    case Buttons.LeftBumper:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:                                
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick5Button13;
                            default:
                                return KeyCode.Joystick5Button4;
                        }
                    case Buttons.Back:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick5Button10;
                            default:
                                return KeyCode.Joystick5Button6;
                        }
                    case Buttons.Start:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick5Button9;
                            default:
                                return KeyCode.Joystick5Button7;
                        }
                    case Buttons.RightStickClick:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick5Button12;
                            case RuntimePlatform.LinuxPlayer:
                                return KeyCode.Joystick5Button10;
                            default:
                                return KeyCode.Joystick5Button9;
                        }
                    case Buttons.LeftStickCLick:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick5Button11;
                            case RuntimePlatform.LinuxPlayer:
                                return KeyCode.Joystick5Button9;
                            default:
                                return KeyCode.Joystick5Button8;
                        }
                }
                break;
            case 6:
                switch (btn)
                {
                    case Buttons.A:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick6Button16;
                            default:
                                return KeyCode.Joystick6Button0;
                        }
                    case Buttons.B:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick6Button17;
                            default:
                                return KeyCode.Joystick6Button1;
                        }
                    case Buttons.X:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick6Button18;
                            default:
                                return KeyCode.Joystick6Button2;
                        }
                    case Buttons.Y:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick6Button19;
                            default:
                                return KeyCode.Joystick6Button3;
                        }
                    case Buttons.RightBumper:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick6Button14;
                            default:
                                return KeyCode.Joystick6Button5;
                        }
                    case Buttons.LeftBumper:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick6Button13;
                            default:
                                return KeyCode.Joystick6Button4;
                        }
                    case Buttons.Back:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick6Button10;
                            default:
                                return KeyCode.Joystick6Button6;
                        }
                    case Buttons.Start:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                                return KeyCode.Joystick6Button9;
                            case RuntimePlatform.OSXEditor:
                                return KeyCode.Joystick6Button9;
                            case RuntimePlatform.OSXPlayer:
                                return KeyCode.Joystick6Button9;
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick6Button9;
                            default:
                                return KeyCode.Joystick6Button7;
                        }
                    case Buttons.RightStickClick:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick6Button12;
                            case RuntimePlatform.LinuxPlayer:
                                return KeyCode.Joystick6Button10;
                            default:
                                return KeyCode.Joystick6Button9;
                        }
                    case Buttons.LeftStickCLick:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick6Button11;
                            case RuntimePlatform.LinuxPlayer:
                                return KeyCode.Joystick6Button9;
                            default:
                                return KeyCode.Joystick6Button8;
                        }
                }
                break;
            case 7:
                switch (btn)
                {
                    case Buttons.A:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick7Button16;
                            default:
                                return KeyCode.Joystick7Button0;
                        }
                    case Buttons.B:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick7Button17;
                            default:
                                return KeyCode.Joystick7Button1;
                        }
                    case Buttons.X:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick7Button18;
                            default:
                                return KeyCode.Joystick7Button2;
                        }
                    case Buttons.Y:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick7Button19;
                            default:
                                return KeyCode.Joystick7Button3;
                        }
                    case Buttons.RightBumper:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick7Button14;
                            default:
                                return KeyCode.Joystick7Button5;
                        }
                    case Buttons.LeftBumper:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick7Button13;
                            default:
                                return KeyCode.Joystick7Button4;
                        }
                    case Buttons.Back:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick7Button10;
                            default:
                                return KeyCode.Joystick7Button6;
                        }
                    case Buttons.Start:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick7Button9;
                            default:
                                return KeyCode.Joystick7Button7;
                        }
                    case Buttons.RightStickClick:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick7Button12;
                            case RuntimePlatform.LinuxPlayer:
                                return KeyCode.Joystick7Button10;
                            default:
                                return KeyCode.Joystick7Button9;
                        }
                    case Buttons.LeftStickCLick:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick7Button11;
                            case RuntimePlatform.LinuxPlayer:
                                return KeyCode.Joystick7Button9;
                            default:
                                return KeyCode.Joystick7Button8;
                        }
                }
                break;
            case 8:
                switch (btn)
                {
                    case Buttons.A:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick8Button16;
                            default:
                                return KeyCode.Joystick8Button0;
                        }
                    case Buttons.B:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick8Button17;
                            default:
                                return KeyCode.Joystick8Button1;
                        }
                    case Buttons.X:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick8Button18;
                            default:
                                return KeyCode.Joystick8Button2;
                        }
                    case Buttons.Y:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick8Button19;
                            default:
                                return KeyCode.Joystick8Button3;
                        }
                    case Buttons.RightBumper:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick8Button14;
                            default:
                                return KeyCode.Joystick8Button5;
                        }
                    case Buttons.LeftBumper:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick8Button13;
                            default:
                                return KeyCode.Joystick8Button4;
                        }
                    case Buttons.Back:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick8Button10;
                            default:
                                return KeyCode.Joystick8Button6;
                        }
                    case Buttons.Start:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick8Button9;
                            default:
                                return KeyCode.Joystick8Button7;
                        }
                    case Buttons.RightStickClick:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick8Button12;
                            case RuntimePlatform.LinuxPlayer:
                                return KeyCode.Joystick8Button10;
                            default:
                                return KeyCode.Joystick8Button9;
                        }
                    case Buttons.LeftStickCLick:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.Joystick8Button11;
                            case RuntimePlatform.LinuxPlayer:
                                return KeyCode.Joystick8Button9;
                            default:
                                return KeyCode.Joystick8Button8;
                        }
                }
                break;
            default:
                switch (btn)
                {
                    case Buttons.A:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.JoystickButton16;
                            default:
                                return KeyCode.JoystickButton0;
                        }
                    case Buttons.B:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.JoystickButton17;
                            default:
                                return KeyCode.JoystickButton1;
                        }
                    case Buttons.X:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.JoystickButton18;
                            default:
                                return KeyCode.JoystickButton2;
                        }
                    case Buttons.Y:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.JoystickButton19;
                            default:
                                return KeyCode.JoystickButton3;
                        }
                    case Buttons.RightBumper:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.JoystickButton14;
                            default:
                                return KeyCode.JoystickButton5;
                        }
                    case Buttons.LeftBumper:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.JoystickButton13;
                            default:
                                return KeyCode.JoystickButton4;
                        }
                    case Buttons.Back:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.JoystickButton10;
                            default:
                                return KeyCode.JoystickButton6;
                        }
                    case Buttons.Start:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.JoystickButton9;
                            default:
                                return KeyCode.JoystickButton7;
                        }
                    case Buttons.RightStickClick:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.JoystickButton12;
                            case RuntimePlatform.LinuxPlayer:
                                return KeyCode.JoystickButton10;
                            default:
                                return KeyCode.JoystickButton9;
                        }
                    case Buttons.LeftStickCLick:
                        switch (Application.platform)
                        {
                            case RuntimePlatform.OSXDashboardPlayer:
                            case RuntimePlatform.OSXEditor:
                            case RuntimePlatform.OSXPlayer:
                            case RuntimePlatform.OSXWebPlayer:
                                return KeyCode.JoystickButton11;
                            case RuntimePlatform.LinuxPlayer:
                                return KeyCode.JoystickButton9;
                            default:
                                return KeyCode.JoystickButton8;
                        }
                }
                break;
        }
        return KeyCode.None;
    }
}
