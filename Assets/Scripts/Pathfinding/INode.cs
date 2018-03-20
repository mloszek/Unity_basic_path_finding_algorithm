
public interface INode
{
    int x { get; set; }
    int y { get; set; }
    bool isWalkable { get; set; }
    bool isVisited { get; set; }
    CustomNode parent { get; set; }
}
