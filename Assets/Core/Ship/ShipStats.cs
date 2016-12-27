using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ShipStats {

	public Ship ship;

	// Combat
	public float Damage;
	public string[] DamageTypes;

	// Science
	public float MaxEngineeringPoints;
	public float MaxSciencePoints;
	public float MaxCombatPoints;
	public string[] ConversionTypes;
	public float ConversionPower;
	public string[] ReductionTypes;
	public float ReductionPower;
	public string[] ReflectionTypes;
	public float ReflectionPower;

	// Engineering
	public string[] FuelTypes;
	public float FuelEfficiency;
	public float Speed;
	public float HullPoints;

	//Crew
	public float CrewHappinessMod;
	public float CrewSustenanceMod;
	public float CrewHealthMod;

//	public void CalcStats ()
//	{
//		//Combat
//		Damage = 0;
//		List<string> dTypes = new List<string>();  
//		foreach (Weapon weapon in ship.Weapons)
//		{
//			Damage += weapon.damageMod;
//			foreach (string type in weapon.damageType)
//			{
//				if (!dTypes.Contains("type"))
//				{
//					dTypes.Add(type);
//				}
//			}
//		}
//		DamageTypes = dTypes.ToArray();
//
//		//Science 
//		MaxEngineeringPoints = 15;
//		MaxSciencePoints = 15;
//		MaxCombatPoints = 15;
//		foreach (string ipType in ship.Reactor.typeInfulencePoints)
//		{
//			if (ipType == "Engineering")
//			{
//				MaxEngineeringPoints += ship.Reactor.maxInfluencePointMod;
//			}
//			if (ipType == "Science")
//			{
//				MaxSciencePoints += ship.Reactor.maxInfluencePointMod;
//			}
//			if (ipType == "Combat")
//			{
//				MaxCombatPoints += ship.Reactor.maxInfluencePointMod;
//			}
//		}
//
//		ReductionPower = ship.Shield.damageReductionMod;
//		ReductionTypes = ship.Shield.typeDamageReduction;
//		ReflectionPower = ship.Shield.typeReflectionMod;
//		ReflectionTypes = ship.Shield.typeReflection;
//
//		// Engineering
//		FuelTypes = ship.Engine.typeFuel;
//		FuelEfficiency = ship.Engine.fuelEffciencyMod;
//		Speed = ship.Engine.shipSpeedMod;
//		HullPoints = ship.Armor.maxHPMod;
//
//		// Crew
//		CrewHappinessMod = 0;
//		CrewHealthMod = 0;
//		CrewSustenanceMod = 0;
//
//		foreach(Room room in ship.Rooms)
//		{
//			CrewHappinessMod += room.crewHappinessMod;
//			CrewHealthMod += room.crewHealthMod;
//			CrewSustenanceMod += room.crewSustenanceMod;
//		}
//
//	}

}
