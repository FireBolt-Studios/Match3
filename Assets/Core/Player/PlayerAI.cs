using UnityEngine;
using System.Collections;

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
		print("Trying to find match.");
		foreach (Node node in mm.nodes)
		{
			if (node.gem != null)
			{
				if (FindGemToMatch(node.gem))
				{
					return;
				}
			}
		}

		playerMatch.turnTrue = false;
		return;
	}

	public bool FindGemToMatch (Gem gem)
	{
		// CHECK MATCH 2 HORIZONTAL
		if (gem.x < (mm.size-2))
		{
			if (gem.x > 0)
			{
				if (gem.y < (mm.size-1))
				{
					if (gem.y > 0)
					{
						// CHECK MATCH 2 MIDDLE SPACE
						if (mm.nodes[gem.x+2,gem.y].gem.type == gem.type)
						{
							// CHECK MIDDLE UP IS OF TYPE
							if (mm.nodes[gem.x+1,gem.y+1].gem.type == gem.type)
							{
								print("Found possible match middle up.");
								// SWAP LEFT UP GEM WITH GEM BELOW
								StartCoroutine(mm.nodes[gem.x+1,gem.y+1].gem.SwapGem(mm.nodes[gem.x+1,gem.y+1].gem,mm.nodes[gem.x+1,gem.y].gem,0.25f));
								mm.EndTurn();
								return true;
							}
							// CHECK MIDDLE DOWN IS OF TYPE
							if (mm.nodes[gem.x+1,gem.y-1].gem.type == gem.type)
							{
								print("Found possible match middle down.");
								// SWAP LEFT UP GEM WITH GEM BELOW
								StartCoroutine(mm.nodes[gem.x+1,gem.y-1].gem.SwapGem(mm.nodes[gem.x+1,gem.y-1].gem,mm.nodes[gem.x+1,gem.y].gem,0.25f));
								mm.EndTurn();
								return true;
							}
						}

						// CHECK MATCH 2 SIDE BY SIDE
						if (mm.nodes[gem.x+1,gem.y].gem.type == gem.type)
						{
							// CHECK LEFT UP IS OF TYPE
							if (mm.nodes[gem.x-1,gem.y+1].gem.type == gem.type)
							{
								print("Found possible match left up.");
								// SWAP LEFT UP GEM WITH GEM BELOW
								StartCoroutine(mm.nodes[gem.x-1,gem.y+1].gem.SwapGem(mm.nodes[gem.x-1,gem.y+1].gem,mm.nodes[gem.x-1,gem.y].gem,0.25f));
								mm.EndTurn();
								return true;
							}
							// CHECK LEFT DOWN IS OF TYPE
							if (mm.nodes[gem.x-1,gem.y-1].gem.type == gem.type)
							{
								print("Found possible match left down.");
								StartCoroutine(mm.nodes[gem.x-1,gem.y-1].gem.SwapGem(mm.nodes[gem.x-1,gem.y-1].gem,mm.nodes[gem.x-1,gem.y].gem,0.25f));
								mm.EndTurn();
								return true;
							}
							// CHECK RIGHT UP IS OF TYPE
							if (mm.nodes[gem.x+2,gem.y+1].gem.type == gem.type)
							{
								print("Found possible match right up.");
								StartCoroutine(mm.nodes[gem.x+2,gem.y+1].gem.SwapGem(mm.nodes[gem.x+2,gem.y+1].gem,mm.nodes[gem.x+2,gem.y].gem,0.25f));
								mm.EndTurn();
								return true;
							}
							// CHECK RIGHT DOWN IS OF TYPE
							if (mm.nodes[gem.x+2,gem.y-1].gem.type == gem.type)
							{
								print("Found possible match right down.");
								StartCoroutine(mm.nodes[gem.x+2,gem.y-1].gem.SwapGem(mm.nodes[gem.x+2,gem.y-1].gem,mm.nodes[gem.x+2,gem.y].gem,0.25f));
								mm.EndTurn();
								return true;
							}	
						}
					}
				}
			}
		}
		return false;
	}

}
