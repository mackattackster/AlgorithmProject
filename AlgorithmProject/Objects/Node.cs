using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProject.Objects
{
    class Node
    {
        private List<Edge> _listEdge;
        private List<Edge> _listParentEdge;
        private List<Node> _DoNotGoToNodes;
        private String _NodeName;
        private Double _NodeValue;

        public String NodeName
        {
            get { return _NodeName; }
            set { _NodeName = value; }
        }

        public List<Node> DoNotGoToNodes
        {
            get { return _DoNotGoToNodes; }
            set { _DoNotGoToNodes = value; }
        }

        public Double NodeValue
        {
            get { return _NodeValue; }
            set { _NodeValue = value; }
        }

        public List<Edge> listEdge
        {
            get { return _listEdge; }
            set { _listEdge = value; }
        }

        public List<Edge> listParentEdge
        {
            get { return _listParentEdge; }
            set { _listParentEdge = value; }
        }

        public Node(String NodeName)
        {
            this.NodeName = NodeName;
            this.listEdge = new List<Edge>();
            this.listParentEdge = new List<Edge>();
            this.NodeValue = 0.0;
            this.DoNotGoToNodes = new List<Node>();
            this.DoNotGoToNodes.Add(this);
        }

        public void AddEdge(Edge e)
        {
            this.listEdge.Add(e);
            SortEdges();
        }

        public void AddParentEdge(Edge e)
        {
            this.listParentEdge.Add(e);
        }

        public void RemoveEdge(Node n)
        {
            this.listEdge.RemoveAll(x => x.Node.NodeName == n.NodeName);
        }

        public void RemoveAllNegativeEdges()
        {
            this.listEdge.RemoveAll(x => x.EdgeLength == -1);
        }

        public void SortEdges()
        {
            for (int i = 0; i < this.listEdge.Count; i++)
            {
                this.listEdge = listEdge.OrderBy(x => x.EdgeLength).ToList();
            }
        }

        public String PrintNodeDetails()
        {
            String NodeSummary = "";
            for (int i = 0; i < this.listEdge.Count; i++)
                NodeSummary += "Node " + this.NodeName + "  child is  " + this.listEdge[i].Node.NodeName.ToString() + " and length of child is " + this.listEdge[i].EdgeLength.ToString() + ". " + Environment.NewLine;

            if (this.listEdge.Count == 0)
            {
                NodeSummary += "Node " + this.NodeName + " has no children.";
            }

            for (int i = 0; i < this.listParentEdge.Count; i++)
                NodeSummary += "Node " + this.NodeName + "'s parent is " + this.listParentEdge[i].Node.NodeName.ToString() + " and length of parent is " + this.listParentEdge[i].EdgeLength.ToString() + Environment.NewLine;

            return NodeSummary;
        }
    }
}
