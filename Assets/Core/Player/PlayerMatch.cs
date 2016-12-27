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
		//DebugEquipShip();
	}


//	public void DebugEquipShip ()
//	{
//		PlayerShip.Weapons[0] = GameObject.FindObjectOfType<Database>().ShipObjects.Weapons[0];
//		PlayerShip.Weapons[1] = GameObject.FindObjectOfType<Database>().ShipObjects.Weapons[0];
//		PlayerShip.Reactor = GameObject.FindObjectOfType<Database>().ShipObjects.Reactors[0];
//		PlayerShip.Shield = GameObject.FindObjectOfType<Database>().ShipObjects.Shields[0];
//		PlayerShip.Armor = GameObject.FindObjectOfType<Database>().ShipObjects.Armors[0];
//		PlayerShip.Engine = GameObject.FindObjectOfType<Database>().ShipObjects.Engines[0];
//		PlayerShip.Rooms[0] = GameObject.FindObjectOfType<Database>().ShipObjects.Rooms[0];
//		PlayerShip.Rooms[1] = GameObject.FindObjectOfType<Database>().ShipObjects.Rooms[1];
//		PlayerShip.Rooms[2] = GameObject.FindObjectOfType<Database>().ShipObjects.Rooms[2];
//
//		PlayerShip.shipStats.CalcStats();
//	}

	public void AddPoints (string type,int amount)
	{
		if (type == "Engineering")
		{
			engPoints += amount;
			engText.text = engPoints.ToString();
		}
		if (type == "Science")
		{
			sciPoints += amount;
			sciText.text = sciPoints.ToString();
		}
		if (type == "Combat")
		{
			comPoints += amount;
			comText.text = comPoints.ToString();
		}

	}
}
