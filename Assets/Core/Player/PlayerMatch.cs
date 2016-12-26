using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMatch : MonoBehaviour {

	public int engPoints;
	public int sciPoints;
	public int comPoints;

	public Text engText;
	public Text sciText;
	public Text comText;

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
