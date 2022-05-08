
Prerequisites:
- Unity 2020.33f1
- Unity Vuforia Engine
- Visual Studio 8.10.22 (build 11)
- ultrasound probe model
- human torso model with 3D scanning file
- markers for recoginizing the two objects: 
  - markers_1: two flat markers;
  - multi: two cube targets;
  - coka: cylinder targets;
- tracking: 
  - use translation and rotation martrix (with quaternion)
  - use Euclidien matrices

Process for building tracking project:
Install Vuforia engine in a untiy project. Import the ultrasound probe
model and human torso model as GameObjects. Add two markers and set the
two objects as their child independently.
Add C# scripts to game component and run the game.


