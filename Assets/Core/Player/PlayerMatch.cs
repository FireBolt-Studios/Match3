using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMatch : MonoBehaviour {

	public Ship PlayerShip;

	public bool turnTrue;

	public int Credits;
	public int Research;

	void Awake ()
	{
		DebugEquipShip();
	}


	public void DebugEquipShip ()
	{
		PlayerShip.weapon1 = GameObject.FindObjectOfType<Database>().shipParts.weapons[0];
		PlayerShip.weapon2 = GameObject.FindObjectOfType<Database>().shipParts.weapons[0];
		PlayerShip.reactor = GameObject.FindObjectOfType<Database>().shipParts.reators[0];
		PlayerShip.shield = GameObject.FindObjectOfType<Database>().shipParts.shields[0];
		PlayerShip.armor = GameObject.FindObjectOfType<Database>().shipParts.armors[0];
		PlayerShip.engine = GameObject.FindObjectOfType<Database>().shipParts.engines[0];

		PlayerShip.InitializeShip();
	}

	public void DealDamage (PlayerMatch target,int amount)
	{
		float damage = amount + (PlayerShip.weapon1.damage + PlayerShip.weapon2.damage);

		if (target.PlayerShip.curShieldPoints <= 0)
		{
			target.PlayerShip.curHullPoints -= damage;
		}
		else
		{
			target.PlayerShip.curShieldPoints -= damage;
		}
	}

	public void AddPoints (string type,int amount)
	{
		if (type == "Credit")
		{
			Credits += amount;
		}
		if (type == "Research")
		{
			Research += amount;
		}
		if (type == "Engineering")
		{
			PlayerShip.curEngineeringPoints += amount;
			if (PlayerShip.curEngineeringPoints > PlayerShip.reactor.maxEngineeringPoints)
			{
				PlayerShip.curEngineeringPoints = PlayerShip.reactor.maxEngineeringPoints;
			}
		}
		if (type == "Science")
		{
			PlayerShip.curSciencePoints += amount;
			if (PlayerShip.curSciencePoints > PlayerShip.reactor.maxSciencePoints)
			{
				PlayerShip.curSciencePoints = PlayerShip.reactor.maxSciencePoints;
			}
		}
		if (type == "Combat")
		{
			PlayerShip.curCombatPoints += amount;
			if (PlayerShip.curCombatPoints > PlayerShip.reactor.maxCombatPoints)
			{
				PlayerShip.curCombatPoints = PlayerShip.reactor.maxCombatPoints;
			}
		}

	}
}
