using System.Collections.Generic;
using BehaviourTree.Nodes;

public class Rotate : Node
{
    //float rotateAngle
    public Rotate( List<Node> childrenNodes) : base("Rotate", childrenNodes)
    {
    }

    public override void OnEnd()
    {
    }
}