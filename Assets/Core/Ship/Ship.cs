using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	public string shipName;
	public int shipWorth;

	public Reactor reactor;
	public Shield shield;
	public Engine engine;
	public Armor armor;
	public Weapon weapon1;
	public Weapon weapon2;

	//Dynamic Properties

	public float curEngineeringPoints;
	public float curSciencePoints;
	public float curCombatPoints;

	public float curHullPoints;
	public float curShieldPoints;

	public float curFuelPoints;

	public void InitializeShip ()
	{
		curHullPoints = armor.maxHullPoints;
		curShieldPoints = shield.MaxShieldPoints;
	}

}
