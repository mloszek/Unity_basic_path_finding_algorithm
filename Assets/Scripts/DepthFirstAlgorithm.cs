using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthFirstAlgorithm
{
	public List<CustomNode> results;

	private CustomNode[][] vertices;
	private Queue<CustomNode> queue;
	private CustomNode startNode;
	private CustomNode endNode;
    private bool IsSearching;

    private delegate bool IsFastEnd();
    private static event IsFastEnd Conditions;

    public DepthFirstAlgorithm()
    {
        InitializeAlgorithm();
        Conditions += IsQueueCountPositive;
    }

    public DepthFirstAlgorithm(bool fastEnd)
    {
        InitializeAlgorithm();
        Conditions += IsQueueCountPositive;
        Conditions += IsStillSeatching;
    }

    private void InitializeAlgorithm()
    {
        vertices = new CustomNode[MapProperties.height][];
        queue = new Queue<CustomNode>();
        results = new List<CustomNode>();
        IsSearching = true;
    }

    public bool IsQueueCountPositive()
    {
        return queue.Count > 0;
    }

    public bool IsStillSeatching()
    {
        return IsSearching;
    }

    public void CreateGrid ()
	{
		for (int i = 0; i < MapProperties.height; i++) {
			
			vertices [i] = new CustomNode[MapProperties.width];

			for (int j = 0; j < MapProperties.width; j++) {
				
				vertices [i] [j] = new CustomNode (i, j);

				if (MapGenerator.gridArray [i] [j].name != "o") {
					vertices [i] [j].isWalkable = true;
				}

				if (MapGenerator.gridArray [i] [j].name == "s")
					startNode = vertices [i] [j];

				if (MapGenerator.gridArray [i] [j].name == "e")
					endNode = vertices [i] [j];
			}
		}
	}

	public void Search ()
	{
		queue.Enqueue (startNode);
		CheckVicinity ();
	}

	private void CheckVicinity ()
	{
		if (Conditions()) 
		{
			CustomNode node = queue.Dequeue();

            MapGenerator.gridArray[node.x][node.y].GetComponent<Renderer>()
                .material.color = new Color(0.8f, 1f, 0.8f, 1);

            List<CustomNode> neighbours = GetNeighbors (node);
			if (neighbours.Count > 0) {
				foreach (CustomNode n in neighbours) 
				{
                    MapGenerator.gridArray[n.x][n.y].GetComponent<Renderer>().material.color = new Color(0, 1f, 0.2f, 1);
                    n.isVisited = true;	
					n.parent = node;
					if (n == endNode) {
                        IsSearching = false;
						Rewind (n.parent);
					} else {
						queue.Enqueue (n);				
					}
				}
			}
			CheckVicinity ();
		}
	}

	public List<CustomNode> GetNeighbors (CustomNode node)
	{
		int x = node.x;
		int y = node.y;

        List<CustomNode> neighbors = new List<CustomNode> ();

		if (y > 0 && vertices [x] [y - 1].isWalkable) {
            if (!vertices[x][y - 1].isVisited)
            {
                neighbors.Add(vertices[x][y - 1]);
            }			
		}
		if (x < vertices.Length - 1 && vertices [x + 1] [y].isWalkable) {
            if (!vertices[x + 1][y].isVisited)
            {
                neighbors.Add(vertices[x + 1][y]);
            }
        }
		if (y < vertices [x].Length - 1 && vertices [x] [y + 1].isWalkable) {
            if (!vertices[x][y + 1].isVisited)
            {
                neighbors.Add(vertices[x][y + 1]);
            }
        }
		if (x > 0 && vertices [x - 1] [y].isWalkable && !vertices [x - 1] [y].isVisited) {
            if (!vertices[x - 1][y].isVisited)
            {
                neighbors.Add(vertices[x - 1][y]);
            }
        }
		return neighbors;
	}

	private void Rewind(CustomNode node)
	{		
		results.Add (node);
		if (node.parent != startNode)
		{				
			Rewind (node.parent);
		}
	}

	public void ShowPath()
	{
		foreach(CustomNode n in results)
		{
            MapGenerator.gridArray[n.x][n.y].GetComponent<Renderer>().material.color = new Color(1, 0.4f, 0.4f, 1);
		}
        MapGenerator.gridArray[startNode.x][startNode.y].GetComponent<Renderer>()
            .material.color = Color.yellow;
        MapGenerator.gridArray[endNode.x][endNode.y].GetComponent<Renderer>()
            .material.color = Color.blue;
    }
}
