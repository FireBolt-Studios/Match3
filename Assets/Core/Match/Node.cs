using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {

	public MatchManager mm;
	public int posX;
	public int posY;
	public Gem gem;

	public void SpawnGem ()
	{
		int random = Random.Range(0,mm.gems.Length);
		GameObject newGem = Instantiate(mm.gems[random].gem,new Vector2(posX,posY),Quaternion.identity) as GameObject;
		newGem.GetComponent<SpriteRenderer>().enabled = false;
		gem = newGem.GetComponent<Gem>();
		newGem.GetComponent<Gem>().mm = mm;
		newGem.GetComponent<Gem>().type = mm.gems[random].name;
		newGem.GetComponent<SpriteRenderer>().color = mm.gems[random].color;
	}

	void Update ()
	{
		if (posY == mm.size)
		{
			if (gem == null)
			{
				SpawnGem();
			}
		}

//		if (gem != null)
//		{
//			GetComponent<SpriteRenderer>().color = gem.GetComponent<SpriteRenderer>().color - new Color(0,0,0,0.75f);
//		}
	}
}
