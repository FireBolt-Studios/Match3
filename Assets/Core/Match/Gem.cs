using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour {

	public MatchManager mm;
	public string type;

	public int x;
	public int y;

	public bool isMoving;

	void Awake ()
	{
		SetData();
	}

	void OnMouseDown ()
	{
		mm.SelectGem(this);
	}

	public void SetData ()
	{
		x = (int)transform.position.x;
		y = (int)transform.position.y;
		isMoving = false;
	}

	IEnumerator DropGem (Vector3 start, Vector3 target, float time)
	{
		mm.isSettled = false;
		isMoving = true;
		float timer = 0;
	
		while (timer < time)
		{
			transform.position = Vector3.Lerp(start, target, (timer / time));
			timer += Time.deltaTime;
			yield return null;
		}
		transform.position = target;
		SetData();
		mm.nodes[x,y+1].gem = null;
		mm.nodes[x,y].gem = this;
		mm.isSettled = true;
	}

	public IEnumerator SwapGem (Gem thisGem, Gem otherGem, float time)
	{
		mm.isSettled = false;
		isMoving = true;
		float timer = 0;

		Vector3 otherPos = new Vector3(otherGem.x,otherGem.y,0);
		Vector3 thisPos = new Vector3(thisGem.x,thisGem.y,0);

		while (timer < time)
		{
			transform.position = Vector3.Lerp(thisPos, otherPos, (timer / time));
			otherGem.transform.position = Vector3.Lerp(otherPos, thisPos, (timer / time));

			timer += Time.deltaTime;
			yield return null;
		}
		transform.position = otherPos;
		otherGem.transform.position = thisPos;
		SetData();
		otherGem.SetData();
		mm.nodes[x,y].gem = thisGem;
		mm.nodes[otherGem.x,otherGem.y].gem = otherGem;
		mm.isSettled = true;
	}

	void Update ()
	{
		if (y == mm.size)
		{
			//print("HIDDEN GEM!!!");
			GetComponent<SpriteRenderer>().enabled = false;
		}
		else
		{
			GetComponent<SpriteRenderer>().enabled = true;
		}

		if (isMoving == false)
		{
			if (y > 0)
			{
				if (mm.nodes[x,y-1].gem == null)
				{
					StartCoroutine(DropGem(transform.position,mm.nodes[x,y-1].transform.position,0.1f));
				}
			}
		}
	}

}
