# VR Shooter Game
A virtual reality shooter game developed as a project and learning experience. This game allows players to fire bullets at target dummies, experience VR hand animations, and see score updates in real-time. The game uses Unity's XR Interaction Toolkit, making it accessible both with an external VR headset or using the XR Simulator for users without VR hardware.

# Video Demo
https://drive.google.com/file/d/1OkDkTG34KlT1_yiCNfqP_umUE7S-8MUZ/view?usp=sharing

### Table of Contents
- Features
- Getting Started
- Requirements
- Assets
- Installation
- How to Play
- Environment
- Scripts Overview
- Using the XR Simulator
- External Packages
- Contributing



### Features
VR Bullet Shooting: Players can shoot bullets, which play a sound effect upon firing.
Interactive Target Dummies: Dummies activate when the player enters a trigger zone, allowing for target practice.
Hand Animations: VR hand grip and trigger animations based on player input.
Score Display: Real-time score updates displayed on screen as targets are hit.
XR Simulator Support: Provides VR-like controls for users without VR hardware.
Getting Started
This project is ideal for those learning VR development with Unity and wanting to understand basic VR interactions.

### Requirements
**Unity:** Version 2021.3 or newer
**VR Headset:** Oculus, HTC Vive, or other Unity-compatible VR headset (optional if using the XR Simulator)
**Git:** For cloning the repository
Installation
**Clone the Repository:**
bash
Copy code
git clone https://github.com/yourusername/vr-shooter-game.git
**Open Project in Unity:**
Open Unity Hub, select the cloned project folder, and open it.
**Configure XR Settings:**
Go to Edit > Project Settings > XR Plug-in Management and enable the VR platform relevant to your headset (e.g., Oculus or OpenXR).

### Assets
This project includes assets from the Unity Asset Store and custom assets for VR hand interactions.

**Polygon Starter Pack:** A versatile collection of 3D models and prefabs that provide the basic environment setup, including:

**Environment Elements:** House, door, land, mountain, floor, and boxes.
**Weapons:** Guns, swords, and other interactive elements for gameplay.
**VR Hands: **Custom VR hand assets, including prefabs and animations for both left and right hands. These assets can be downloaded from the following link:
https://drive.google.com/file/d/1Fnli8Tbq7NeTw8pSTwjiZcSbE7UB3rL1/view

### How to Play
Movement: Use the VR controller joystick (or simulator controls) to move around.
Shooting: Aim with the VR controller and press the trigger to fire bullets at target dummies.
Scoring: Points are added to the score whenever a target dummy is hit.
Environment
The game environment includes basic structures like a ground plane, target dummies, and lighting configurations using an Area Light to create a visually immersive experience. The setup aims to create an effective learning and testing environment for VR mechanics.

### Scripts Overview
The project includes several scripts, each contributing to core game functionality:

**DummyTrigger.cs:** Detects when the player enters a trigger zone and activates target dummies.
**Fire.cs:** Handles bullet instantiation, direction, speed, and plays a firing sound.
**HandsAnimation.cs:** Animates the player’s VR hands based on grip and trigger input actions.
**ScoreManager.cs:** Manages and displays the player’s score on-screen.
**TargetDummy.cs:** Represents the target dummy objects that the player can shoot at.

### Using the XR Simulator
If you don't have a VR headset, you can use the XR Simulator to play the game with simulated VR controls.

Enabling the XR Simulator
Install the XR Interaction Toolkit:
Go to Window > Package Manager, search for XR Interaction Toolkit, and install it if it’s not already installed.
Add the XR Device Simulator:
Go to Window > XR > XR Device Simulator and enable it in the scene.
Configure Controls:
Movement: Use W, A, S, D for forward, left, backward, and right movement.
Camera Rotation: Hold the right mouse button and move the mouse to simulate looking around.
Simulated Hand Controls: Use Q and E to toggle between hands, R and F to simulate grip actions, and T and G for trigger actions.
The XR Simulator makes it possible to develop and test VR mechanics without requiring an actual headset.

External Packages
This project requires the following Unity packages for VR support:

XR Interaction Toolkit:
Provides VR components for interaction and movement.
Install: Go to Window > Package Manager, search for XR Interaction Toolkit, and install it.
XR Plug-in Management:
Manages VR headset compatibility and simulator functionality.
Install: In Project Settings > XR Plug-in Management, install the plugin and select your VR platform (e.g., OpenXR for cross-platform compatibility).
Contributing
Contributions are welcome! Feel free to improve the game or add new features. To contribute:

Fork the repository.
Create a new branch (git checkout -b feature-name).
Commit your changes (git commit -m "Add feature").
Push to the branch (git push origin feature-name).
Open a pull request.
