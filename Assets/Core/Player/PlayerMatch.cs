using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMatch : MonoBehaviour {

	public Ship PlayerShip;

	public int engPoints;
	public int sciPoints;
	public int comPoints;

	public Text engText;
	public Text sciText;
	public Text comText;

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
	}

	public void AddPoints (string type,int amount)
	{
		if (type == "Engineering")
		{
			PlayerShip.reactor.curEngineeringPoints += amount;
			if (PlayerShip.reactor.curEngineeringPoints > PlayerShip.reactor.maxEngineeringPoints)
			{
				PlayerShip.reactor.curEngineeringPoints = PlayerShip.reactor.maxEngineeringPoints;
			}
			engText.text = engPoints.ToString();
		}
		if (type == "Science")
		{
			PlayerShip.reactor.curSciencePoints += amount;
			if (PlayerShip.reactor.curSciencePoints > PlayerShip.reactor.maxSciencePoints)
			{
				PlayerShip.reactor.curSciencePoints = PlayerShip.reactor.maxSciencePoints;
			}
			sciText.text = sciPoints.ToString();
		}
		if (type == "Combat")
		{
			PlayerShip.reactor.curCombatPoints += amount;
			if (PlayerShip.reactor.curCombatPoints > PlayerShip.reactor.maxCombatPoints)
			{
				PlayerShip.reactor.curCombatPoints = PlayerShip.reactor.maxCombatPoints;
			}
			comText.text = comPoints.ToString();
		}

	}
}
