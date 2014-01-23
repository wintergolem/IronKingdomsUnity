using UnityEngine;
using System.Collections;

public class TurnActions
{
	public bool moved;
	public bool attacked;
	public bool quickActioned;

	public void Reset() 
	{
		moved = false;
		attacked = false;
		quickActioned = false;
	}
}

public class CharacterClass : MonoBehaviour {

	public Blackboard blackBoard;
	WeaponClass current;
	Stats stats;
	Featpoints feats;
	public NavMeshAgent navMeshAgent;
	public bool myTurn; //controlled by gameflow


	//movement variables
	Vector3 old;
	float traveled;

	//turn flow
	TurnActions turnActions;
	// Use this for initialization
	void Start () {
		current = new WeaponClass();  current.Init(0.5f,0,3,true);
		feats = new Featpoints();
		stats = new Stats();	stats.Init(); stats.Human();
		current = new WeaponClass();

		//movement
		old = new Vector3();

		//turn flow
		turnActions = new TurnActions();
	}
	
	// Update is called once per frame
	void Update () {
		Movement();
		//Attack (1);
	}

	public void Attack(int targetID)
	{
		if( blackBoard.CheckInRange(current.RNG , transform.position, targetID) )
		{
			//target in range; now attack
			int attack = CalculateAttack();
			if ( blackBoard.CheckHit(attack,targetID ))
			{
				//attack landed; now damage
				int damage = current.POW + DieRoll.d6(2);
				if(current.melee) damage += stats.STR;
				if(blackBoard.SendDamage(damage,targetID ))
				{
					//target killed; gain featpoint
					feats.Gain();
				}
			}


		}
	}

	int CalculateAttack()
	{
		int attack = current.RATMAT; //+ skill;
		if( current.melee)
		{
			attack += stats.PRW;
		}
		else
		{
			attack += stats.POI;
		}
		return attack;
	}

	void Movement()
	{
		if(old.x == 0 && old.y == 0) old = transform.position;
		if(Input.GetMouseButton(0) )
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast( ray, out hit) )
			{
				if(hit.collider.tag == "ground")
				{
					navMeshAgent.SetDestination( hit.point );
				}
			}
			
		}
		else
		{
			traveled += Vector3.Distance(old, transform.position);
			old = transform.position;
			if( traveled >= stats.SPD)
			{
				navMeshAgent.Stop();
			}
		}
	}

}
