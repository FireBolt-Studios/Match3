using System.Collections;

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
	public string[] damageTypes;

}

[System.Serializable]
public class Shield : Part {

	public float MaxShieldPoints;
	public float CurShieldPoints;

	public float reduction;
	public string[] reductionTypes;
	public float reflection;
	public string[] reflectionTypes;

}

[System.Serializable]
public class Reactor : Part {

	public int maxEngineeringPoints;
	public int curEngineeringPoints;
	public int maxSciencePoints;
	public int curSciencePoints;
	public int maxCombatPoints;
	public int curCombatPoints;

	public float conversion;
	public string[] conversionTypes;

}
[System.Serializable]
public class Engine : Part {

	public float fuelEfficiency;
	public string[] fuelTypes;
	public float speed;

}

[System.Serializable]
public class Armor : Part {

	public float maxHullPoints;
	public float curHullPoints;

}

