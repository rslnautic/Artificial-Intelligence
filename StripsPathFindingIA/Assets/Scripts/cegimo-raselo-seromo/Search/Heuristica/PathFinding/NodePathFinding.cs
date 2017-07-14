using System.Collections.Generic;
using Assets.Scripts;


public class NodePathFinding : Node<NodePathFinding>
{
    public override NodePathFinding Padre { get; set; }

    private float _gCost = 0f;
    private float _hCost = 0f;

    public float FCost {
        get {
            return _gCost + _hCost;
        }
    }

    public NodePathFinding(Estado e, NodePathFinding padre) : base(e, padre) {}

    public override List<NodePathFinding> Expandir(){
        List<Estado> estadosDerivados = Estado.Expandir();
        List<NodePathFinding> nodosExpandidos = new List<NodePathFinding>();
        foreach (var estado in estadosDerivados){
            if (Padre != null){
                NodePathFinding node = new NodePathFinding(estado, this);
                node._gCost = Padre._gCost + 1;
                node._hCost = Distance.EuclideanDistance(estado.Position, PathFinding.final.Estado.Position);
                nodosExpandidos.Add(node);
            }else{
                NodePathFinding node = new NodePathFinding(estado, this);
                node._gCost += 1;
                node._hCost = Distance.EuclideanDistance(estado.Position, PathFinding.final.Estado.Position);
                nodosExpandidos.Add(node);
            }
        }
        return nodosExpandidos;
    }
}