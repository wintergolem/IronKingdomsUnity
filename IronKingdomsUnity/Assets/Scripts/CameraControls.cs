using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {

	bool bLockCamera = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Screen.lockCursor = bLockCamera;
		if( Input.GetKey( KeyCode.W ) )
		{
			transform.Translate(transform.forward * 10 * Time.deltaTime, Space.World);
		}
		if( Input.GetKey( KeyCode.S ) )
		{
			transform.Translate(-transform.forward * 10 * Time.deltaTime, Space.World);
		}
		if( Input.GetKey( KeyCode.D ) )
		{
			transform.Translate(transform.right * 10 * Time.deltaTime, Space.World);
		}
		if( Input.GetKey( KeyCode.A ) )
		{
			transform.Translate(-transform.right * 10 * Time.deltaTime, Space.World);
		}
		if( Input.GetKey( KeyCode.Q ) )
		{
			transform.Translate(Vector3.up * 10 * Time.deltaTime);
		}
		if( Input.GetKey( KeyCode.E ) )
		{
			transform.Translate(-Vector3.up * 10 * Time.deltaTime);
		}
		if(Input.GetKey ( KeyCode.Escape ) )
		{
			bLockCamera = false;
		}


	}
}
