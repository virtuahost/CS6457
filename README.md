# CS6457

This Repository contains the input manager to make setting up and using game controllers easy to use with Unity in Windows and Mac OSx environment. Linux support has also been added. But Dpad controls are supported only for wired controllers.

1. There is an InputManager.asset file which has to be copied to the following path under <Unity_project>/ProjectSettings.
2. ControlInputWrapper.cs script file needs to be put in your Assets folder.
   ControlInputWrapper is a static class which contains helper functions to get control data from a XBox controller.

   Functions:
   
   a. GetButtonDown
      Given a button name and joystick number returns true or false on key down. Joystick number is optional. Default value is 0 which selects data from All joystick.
      
   b. GetButtonUp
      Given a button name and joystick number returns true or false on key up. Joystick number is optional. Default value is 0 which selects data from All joystick.
      
   c. GetButton
      Given a button name and joystick number returns true or false. Joystick number is optional. Default value is 0 which selects data from All joystick.
      
   d. GetAxis
      Given an axis name returns the float value of that axis. Setting optional parameter rawInput to true allows fetching of data using GetAxisRaw.
      
   e. GetTrigger
      Given a trigger name returns the float value of that axis. Setting optional parameter rawInput to true allows fetching of data using GetAxisRaw.
      
   f. GetKeyCode
      Given a button name and joystick number returns the KeyCode relevant to the operating system.
