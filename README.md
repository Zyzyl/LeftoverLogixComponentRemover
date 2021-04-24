# LeftoverLogixComponentRemover

This is a very simple plugin which adds a component which can batch remove LogixInterfaceProxy and LogixReference components from a target slot hierarchy in NeosVR.

**Who is this for?**

People who know what LogixInterfaceProxy and LogixReference components are and who wish to remove redundant ones from their creations.

**Who is this not for?**

Anyone not bothered by harmless residual components on their creations. This is also explicitly **not** intended for new users and others should **not** encourage them to use it to 'optimize' things. Plugins _can_ pose potential security risks and I believe people should be very careful in using them unless they're confident they know what they're doing.

**How to use**

1) Download the `LeftoverLogixComponentRemover.dll` file from this repository and place it in the 'Libraries' subfolder wherever NeosVR is installed on your PC.
2) Start Neos via the `NeosLauncher.exe` and make sure that the `LeftoverLogixComponentRemover.dll` option is checked.
3) In a world where you have 'Builder' permissions, create an empty slot and attach the `LeftoverLogixComponentRemoverWizard` component from the 'Wizards' category. This will create a new UI panel with a slot reference field and two buttons.
4) Drag and drop a reference to whatever slot hierarchy you'd like to cleanup into the reference field and use the buttons to remove the relevant components.
