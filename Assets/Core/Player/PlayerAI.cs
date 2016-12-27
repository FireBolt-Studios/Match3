using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAI : MonoBehaviour {

	public PlayerMatch playerMatch;
	public MatchManager mm;

	void Update ()
	{
		if (playerMatch.turnTrue)
		{
			if (mm.CheckMovement() == true)
			{
				FindMatch();
			}
		}
	}

	public void FindMatch ()
	{
		List<Gem> matchTwoGems = GetAllHorizontalMatchTwo();

		foreach (Gem gem in matchTwoGems)
		{
			Gem[] gemsToSwap = null;

			gemsToSwap = MatchHorizontalLeftDown(gem);
			gemsToSwap = MatchHorizontalLeftMiddle(gem);
			gemsToSwap = MatchHorizontalLeftUp(gem);
			gemsToSwap = MatchHorizontalRightDown(gem);
			gemsToSwap = MatchHorizontalRightMiddle(gem);
			gemsToSwap = MatchHorizontalRightUp(gem);

			if (gemsToSwap != null)
			{
				print("Swapping: " + gemsToSwap[0].type + " with " + gemsToSwap[1].type);
				StartCoroutine(gemsToSwap[0].SwapGem(gemsToSwap[0],gemsToSwap[1],0.25f));
				mm.EndTurn();
			}
		}
	}

	public List<Gem> GetAllHorizontalMatchTwo ()
	{
		List<Gem> matchTwos = new List<Gem>();
		for (int x = 0; x < mm.size-1; x++)
		{
			for (int y = 0; y < mm.size; y++)
			{
				if (mm.nodes[x,y].gem.type == mm.nodes[x+1,y].gem.type)
				{
					matchTwos.Add(mm.nodes[x,y].gem);
				}
			}
		}

		return matchTwos;
	}

	public Gem[] MatchHorizontalLeftUp (Gem gem)
	{
		if (gem.x > 0)
		{
			if (gem.y < mm.size-1)
			{
				if (mm.nodes[gem.x-1,gem.y+1].gem.type == gem.type)
				{
					return new Gem[2] {mm.nodes[gem.x-1,gem.y].gem,mm.nodes[gem.x-1,gem.y+1].gem};
				}
			}
		}

		return null;
	}

	public Gem[] MatchHorizontalLeftDown (Gem gem)
	{
		if (gem.x > 0)
		{
			if (gem.y > 0)
			{
				if (mm.nodes[gem.x-1,gem.y-1].gem.type == gem.type)
				{
					return new Gem[2] {mm.nodes[gem.x-1,gem.y].gem,mm.nodes[gem.x-1,gem.y-1].gem};
				}
			}
		}

		return null;
	}

	public Gem[] MatchHorizontalLeftMiddle (Gem gem)
	{
		if (gem.x > 1)
		{
			if (mm.nodes[gem.x-2,gem.y].gem.type == gem.type)
			{
				return new Gem[2] {mm.nodes[gem.x-1,gem.y].gem,mm.nodes[gem.x-2,gem.y].gem};
			}
		}

		return null;
	}

	public Gem[] MatchHorizontalRightUp (Gem gem)
	{
		if (gem.x < mm.size-2)
		{
			if (gem.y < mm.size-1)
			{
				if (mm.nodes[gem.x+2,gem.y+1].gem.type == gem.type)
				{
					return new Gem[2] {mm.nodes[gem.x+2,gem.y].gem,mm.nodes[gem.x+2,gem.y+1].gem};
				}
			}
		}

		return null;
	}

	public Gem[] MatchHorizontalRightDown (Gem gem)
	{
		if (gem.x < mm.size-2)
		{
			if (gem.y > 0)
			{
				if (mm.nodes[gem.x+2,gem.y-1].gem.type == gem.type)
				{
					return new Gem[2] {mm.nodes[gem.x+2,gem.y].gem,mm.nodes[gem.x+2,gem.y-1].gem};
				}
			}
		}

		return null;
	}

	public Gem[] MatchHorizontalRightMiddle (Gem gem)
	{
		if (gem.x < mm.size-3)
		{
			if (mm.nodes[gem.x+3,gem.y].gem.type == gem.type)
			{
				return new Gem[2] {mm.nodes[gem.x+3,gem.y].gem,mm.nodes[gem.x+2,gem.y].gem};
			}
		}

		return null;
	}
}
