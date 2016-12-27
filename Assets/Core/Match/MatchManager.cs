using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MatchManager : MonoBehaviour {

	public PlayerMatch pMatch;

	public Node[,] nodes;
	public int size;

	public bool initialized = false;

	public GemType[] gems;
	public GameObject node;

	public Gem firstGem;
	public Gem secondGem;

	public bool isSettled;
	public bool initialMatch;

	public int targetPlayer;
	public int turnPlayer;
	public PlayerMatch[] players;

	void Update ()
	{
		//if (initialMatch == false)
		//{
			if (CheckMovement() == true)
			{
				CheckBoard();
				//initialMatch = true;
			}
		//}
	}

	public bool CheckMovement ()
	{
		for (int x = 0; x < size; x++)
		{
			for (int y = 0; y < size+1; y++)
			{
				if (nodes[x,y].gem != null)
				{
					if (nodes[x,y].gem.isMoving == true)
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}
		}

		return true;
	}

	public void RemoveGems (Gem[] gems)
	{
		if (gems[0].type == "Attack")
		{
			players[turnPlayer].DealDamage(players[targetPlayer],gems.Length);

			foreach (Gem gem in gems)
			{
				if (gem != null)
				{
					nodes[gem.x,gem.y].gem = null;
					print("Removed: " + gem.type);
					Destroy(gem.gameObject);
				}
			}
			return;
		}
		foreach (Gem gem in gems)
		{
			if (gem != null)
			{
				nodes[gem.x,gem.y].gem = null;
				print("Removed: " + gem.type);
				players[turnPlayer].AddPoints(gem.type,1);
				Destroy(gem.gameObject);
			}
		}
	}

	public void CheckMatchX (Gem gem)
	{
		List<Gem> gemsX = new List<Gem>();
		List<Gem> gemsY = new List<Gem>();

		if (gem.x < (size-2))
		{
			gemsX.Add(gem);
			if (nodes[gem.x+1,gem.y].gem.type == gem.type)
			{
				gemsX.Add(nodes[gem.x+1,gem.y].gem);
				if (nodes[gem.x+2,gem.y].gem.type == gem.type)
				{
					gemsX.Add(nodes[gem.x+2,gem.y].gem);
					if (gem.x < (size-3))
					{
						if (nodes[gem.x+3,gem.y].gem.type == gem.type)
						{
							gemsX.Add(nodes[gem.x+3,gem.y].gem);
							if (gem.x < (size-4))
							{
								if (nodes[gem.x+4,gem.y].gem.type == gem.type)
								{
									gemsX.Add(nodes[gem.x+4,gem.y].gem);
									if (gem.x < (size-5))
									{
										if (nodes[gem.x+5,gem.y].gem.type == gem.type)
										{
											gemsX.Add(nodes[gem.x+5,gem.y].gem);
										}
									}
								}
							}
						}
					}
				}
			}
		}

		if (gemsX.Count >= 3)
		{
			Gem[] gemArray = gemsX.ToArray();
			RemoveGems(gemArray);
		}

		if (gem.y < (size-2))
		{
			gemsY.Add(gem);
			if (nodes[gem.x,gem.y+1].gem != null)
			{
				if (nodes[gem.x,gem.y+1].gem.type == gem.type)
				{
					gemsY.Add(nodes[gem.x,gem.y+1].gem);
					if (nodes[gem.x,gem.y+2].gem != null)
					{
						if (nodes[gem.x,gem.y+2].gem.type == gem.type)
						{
							gemsY.Add(nodes[gem.x,gem.y+2].gem);
							if (gem.y < (size-3))
							{
								if (nodes[gem.x,gem.y+3].gem != null)
								{
									if (nodes[gem.x,gem.y+3].gem.type == gem.type)
									{
										gemsY.Add(nodes[gem.x,gem.y+3].gem);
										if (gem.y < (size-4))
										{
											if (nodes[gem.x,gem.y+4].gem != null)
											{
												if (nodes[gem.x,gem.y+4].gem.type == gem.type)
												{
													gemsY.Add(nodes[gem.x,gem.y+4].gem);
													if (gem.y < (size-5))
													{
														if (nodes[gem.x,gem.y+5].gem != null)
														{
															if (nodes[gem.x,gem.y+5].gem.type == gem.type)
															{
																gemsY.Add(nodes[gem.x,gem.y+5].gem);
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		if (gemsY.Count >= 3)
		{
			Gem[] gemArray = gemsY.ToArray();
			RemoveGems(gemArray);
		}
	}

	public void CheckBoard ()
	{
		foreach (Node node in nodes)
		{
			if (node.gem != null)
			{
				CheckMatchX(node.gem);
			}
		}
	}

	public void SelectGem (Gem gem)
	{
		if (firstGem == null)
		{
			firstGem = gem;
		}
		else
		{
			if (Vector3.Distance(firstGem.transform.position,gem.transform.position) < 1.1f)
			{
				if (gem != firstGem)
				{
					secondGem = gem;
					StartCoroutine(firstGem.SwapGem(firstGem,secondGem,0.25f));
					firstGem = null;
					secondGem = null;
				}
				else
				{
					firstGem = null;
				}
			}
			else
			{
				firstGem = null;
			}
		}
	}

	void Awake ()
	{
		nodes = new Node[size,size+1];

		for (int x = 0; x < size; x++)
		{
			for (int y = 0; y < size+1; y++)
			{
				GameObject newNode = Instantiate(node,new Vector2(x,y),Quaternion.identity) as GameObject;
				newNode.GetComponent<Node>().mm = this;
				newNode.GetComponent<Node>().posX = x;
				newNode.GetComponent<Node>().posY = y;
				nodes[x,y] = newNode.GetComponent<Node>();
			}
		}

		initialized = true;

		targetPlayer = Random.Range(0,1);
		if (targetPlayer == 0)
		{
			players[1].turnTrue = true;
			turnPlayer = 1;
		}
		else
		{
			players[0].turnTrue = true;
			turnPlayer = 0;
		}
	}


}

[System.Serializable]
public class GemType {

	public string name;
	public Color color;
	public GameObject gem;

}
