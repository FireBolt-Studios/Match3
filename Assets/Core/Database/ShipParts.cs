using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ShipParts {

	public Weapon[] weapons;
	public Shield[] shields;
	public Reactor[] reators;
	public Engine[] engines;
	public Armor[] armors;

}

[System.Serializable]
public class Part {

	public string name;
	public float worth;

}

[System.Serializable]
public class Weapon : Part {

	public float damage;
	public List<string> damageTypes = new List<string>();

}

[System.Serializable]
public class Shield : Part {

	public float MaxShieldPoints;

	public float reduction;
	public List<string> reductionTypes = new List<string>();
	public float reflection;
	public List<string> reflectionTypes = new List<string>();

}

[System.Serializable]
public class Reactor : Part {

	public int maxEngineeringPoints;
	public int maxSciencePoints;
	public int maxCombatPoints;

	public float conversion;
	public List<string> conversionTypes = new List<string>();

}
[System.Serializable]
public class Engine : Part {

	public float fuelEfficiency;
	public float maxFuelPoints;
	public List<string> fuelTypes = new List<string>();
	public float speed;

}

[System.Serializable]
public class Armor : Part {

	public float maxHullPoints;

}

