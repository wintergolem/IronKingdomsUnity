using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)

[AddComponentMenu("Camera-Control/Space Mouse Look")]

public class SpaceMouseLook : MonoBehaviour
{
	public Camera FPSCamera;
	
	public bool lockCursor;
	
	public enum RotationAxes
	{
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}
	public RotationAxes axes = RotationAxes.MouseXAndY;
	
	public float sensitivityX = 3F;
	public float sensitivityY = 5F;
	
	public float minimumX = -60F;
	public float maximumX = 60F;
	
	public float minimumY = -60F;
	public float maximumY = 60F;
	
	float rotationY = 0F;
	float rotationX = 0F;
	
	void Start ()
	{
		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;
		
		lockCursor = true;
	}

	void Update ()
	{
//		if(Input.GetKey (KeyCode.Escape) && !lockCursor)
//			lockCursor = false;
//		if(lockCursor && Input.GetMouseButton(0) )
//			lockCursor = true;
			
			
		Screen.lockCursor = lockCursor;
		if (axes == RotationAxes.MouseXAndY) {
			transform.Rotate (0, Input.GetAxis ("Mouse X") * sensitivityX, 0, Space.World);
		
			
			rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
		} else if (axes == RotationAxes.MouseX) {
			transform.Rotate (0, Input.GetAxis ("Mouse X") * sensitivityX, 0, Space.World);
		} else {
			rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3 (-rotationY, transform.localEulerAngles.y, 0);
		}
	}
	

}