using UnityEngine;
using System.Collections;

public class Blackboard : MonoBehaviour {

	public GameObject enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public bool CheckInRange(float rng,Vector3 pos, int targetID)
	{
		if( CheckDistance(pos, targetID) <= rng) return true;
		return false;
	}
	public bool CheckHit(int attack, int targetID)
	{
		//find target
		//compare attack with targetID's def
		//return if hit successful

		//example

		return true;
	}
	public bool SendDamage(int damage, int targetID)
	{
		//re-find target
		//compare damage against targetID's arm
		//return if killed
		return true;
	}
	int CheckDistance(Vector3 pos, int targetID)
	{
		//use targetID to find target location
		//compare distance from caller to target
		//convert distance to "inches" if nessecary
		return 0;
	}
}
