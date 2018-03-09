using System;
using System.Collections.Generic;

public static class AStarFinder
{
    public static List<GridPos> FindPath(ParamBase parameter)
    {
        object lo = new object();
        var openList = new Queue<Node>();
        var startNode = parameter.StartNode;
        var endNode = parameter.EndNode;
        var grid = parameter.SearchGrid;

        startNode.startToCurNodeLen = 0;
        startNode.heuristicStartToEndLen = 0;

        openList.Enqueue(startNode);
        startNode.isOpened = true;

        while (openList.Count != 0)
        {
            var node = openList.Dequeue();
            node.isClosed = true;

            if (node == endNode)
            {
                return Node.Backtrace(endNode);
            }

            var neighbors = grid.GetNeighbors(node);

            foreach (var neighbor in neighbors)
            {
                if (!neighbor.isClosed)
                {
                    var x = neighbor.x;
                    var y = neighbor.y;
                    float ng = node.startToCurNodeLen + (float)((x - node.x == 0 || y - node.y == 0) ? 1 : Math.Sqrt(2));

                    if (!neighbor.isOpened || ng < neighbor.startToCurNodeLen)
                    {
                        neighbor.startToCurNodeLen = ng;
                        if (neighbor.heuristicCurNodeToEndLen == null)
                        {
                            neighbor.heuristicCurNodeToEndLen = Euclidean(Math.Abs(x - endNode.x), Math.Abs(y - endNode.y));
                        }
                        neighbor.heuristicStartToEndLen = neighbor.startToCurNodeLen + neighbor.heuristicCurNodeToEndLen.Value;
                        neighbor.parent = node;
                        if (!neighbor.isOpened)
                        {
                            lock (lo)
                            {
                                openList.Enqueue(neighbor);
                            }
                            neighbor.isOpened = true;
                        }
                    }
                }
            }
        }
        return new List<GridPos>();
    }

    public static float Euclidean(int x, int y)
    {
        float eucX = (float) x;
        float eucY = (float) y;

        return (float) Math.Sqrt((double)(eucX * eucX + eucY * eucY));
    }
}