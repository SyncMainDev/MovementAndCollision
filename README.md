# MovementAndCollision

This is a small demo to show off how to move Game Objects with Rigidbody components and allow them to interact with other rigidbodies in Unity's physics system.

If you open the SampleScene, you can see the Player object, which has the Player script attached, the walls, the terrain floor, and the ball. The walls are constrained across all axes and rotations, and the Player is constrained from rotating on X and Y, and from moving along Z. 

The conversion from Quaternion rotation values to Euler can lead to some drift, so in code, when updating the player's rotation, we explicitly set the X and Z rotations back to 0 to account for this, so we can easily adjust the player's rotation around Y based on the turn speed and the key press.