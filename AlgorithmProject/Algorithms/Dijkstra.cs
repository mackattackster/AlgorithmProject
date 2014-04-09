using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmProject.Objects;

namespace AlgorithmProject.Algorithms
{
    class Dijkstra
    {
        private Node _RootNode;
        private List<Node> _ListOfNodes;
        private List<Node> _BeenThereListOfNodes;
        private List<String> _Routes;
        private List<String> _ListRouteDescription;

        public List<Node> ListOfNodes
        {
            get { return _ListOfNodes; }
            set { _ListOfNodes = value; }
        }

        public List<Node> BeenThereListOfNodes
        {
            get { return _BeenThereListOfNodes; }
            set { _BeenThereListOfNodes = value; }
        }

        public List<String> Routes
        {
            get { return _Routes; }
            set { _Routes = value; }
        }

        public List<String> ListRouteDescription
        {
            get { return _ListRouteDescription; }
            set { _ListRouteDescription = value; }
        }

        public Node RootNode
        {
            get { return _RootNode; }
            set { _RootNode = value; }
        }

        public Dijkstra(Node RootNode)
        {
            this.RootNode = RootNode;
            this.ListOfNodes = new List<Node>();
            this.BeenThereListOfNodes = new List<Node>();
            this.Routes = new List<String>();
            this.ListRouteDescription = new List<String>();
            RootNode.NodeValue = 0;
            this.ListOfNodes.Add(RootNode);
            FindChildrenMap(RootNode);
        }

        public void FindChildrenMap(Node node)
        {
            for (int w = 0; w < node.listEdge.Count; w++)
            {
                Node NextNode = node.listEdge[w].Node;
                // is node already in list?
                if (!IsInBeenThereList(NextNode))
                {
                    // if R5 to R6 remove R6 to R5
                    NextNode.RemoveEdge(node);
                    //add to list
                    this.ListOfNodes.Add(NextNode);
                    this.BeenThereListOfNodes.Add(NextNode);
                }
                Double potentialNodeValue = node.listEdge[w].EdgeLength + node.NodeValue;

                if (NextNode.NodeValue == 0 || node.NodeValue == 0)
                    NextNode.NodeValue = potentialNodeValue;
                else if (NextNode.NodeValue > potentialNodeValue && NextNode.NodeValue != 0)
                {
                    NextNode.NodeValue = potentialNodeValue;
                    DeleteOldEdge(NextNode, node);
                }
                else
                {
                    node.listEdge[w].EdgeLength = -1;
                }
            }
            if (this.ListOfNodes.Count > 0)
            {
                SortListOfNodes();
                this.ListOfNodes.RemoveAt(0);
                if (this.ListOfNodes.Count == 0)
                {
                    this.BeenThereListOfNodes.Insert(0, this.RootNode);
                    for (int i = 0; i < this.BeenThereListOfNodes.Count; i++)
                    {
                        Node n = this.BeenThereListOfNodes[i];
                        n.RemoveAllNegativeEdges();
                    }
                    // Done with child map. Just add parent map and method to call up the tree until its node :)
                    CreateParentEdges();

                    FindRoutesForAllPoints();
                    return;
                }
                Node NewNode = this.ListOfNodes[0];             
                FindChildrenMap(NewNode);
            }
            else
            {
                this.BeenThereListOfNodes.Insert(0, this.RootNode);
                for (int i = 0; i < this.BeenThereListOfNodes.Count; i++)
                {
                    Node n = this.BeenThereListOfNodes[i];
                    n.RemoveAllNegativeEdges();
                }
                // Done with child map. Just add parent map and method to call up the tree until its node :)
                CreateParentEdges();

                FindRoutesForAllPoints();

                return;
            }
        }


        public void CreateParentEdges()
        {
            for (int i = 0; i < this.BeenThereListOfNodes.Count; i++)
            {
                Node n = this.BeenThereListOfNodes[i];

                for (int w = 0; w < n.listEdge.Count; w++)
                {
                    n.listEdge[w].Node.AddParentEdge(new Edge(n, n.listEdge[w].EdgeLength));
                }
            }
        }

        public void DeleteOldEdge(Node nextNode, Node node)
        {
            for (int i = 0; i < this.BeenThereListOfNodes.Count; i++)
            {
                Node n = this.BeenThereListOfNodes[i];

                for (int w = 0; w < n.listEdge.Count; w++)
                {
                    if (n.listEdge[w].Node.NodeName == node.NodeName)
                    {
                        n.RemoveEdge(nextNode);
                    }
                }
            }
        }

        public void FindRoutesForAllPoints()
        {
            for (int i = 0; i < this.BeenThereListOfNodes.Count; i++)
            {
                Node n = this.BeenThereListOfNodes[i];

                findEntireRoute(n);
                this.ListRouteDescription.Add("For " + n.NodeName + Environment.NewLine);
                this.ListRouteDescription.Reverse();
                String CorrectDirectionalRoute = "";
                for (int m = 0; m < this.ListRouteDescription.Count; m++)
                {
                    CorrectDirectionalRoute += this.ListRouteDescription[m];
                }
                Routes.Add(CorrectDirectionalRoute);
                CorrectDirectionalRoute = "";
                this.ListRouteDescription.Clear();
            }
        }

        public void findEntireRoute(Node n)
        {
            if (n.NodeName == this.RootNode.NodeName || n.listParentEdge[0].Node.NodeName == this.RootNode.NodeName)
            {
                if (n.NodeName == this.RootNode.NodeName)
                {
                    this.ListRouteDescription.Add(this.RootNode.NodeName + " connects to " + n.NodeName + ". Length: " + n.NodeValue);
                }
                else
                {
                    this.ListRouteDescription.Add(this.RootNode.NodeName + " connects to " + n.NodeName + ". Length: " + n.listParentEdge[0].EdgeLength + ". " + Environment.NewLine);
                }
                return;
            }
            else
            {
                Node newNode = n.listParentEdge[0].Node;
                this.ListRouteDescription.Add(newNode.NodeName + " connects to " + n.NodeName + ". Length: " + n.listParentEdge[0].EdgeLength + ". " + Environment.NewLine);

                findEntireRoute(newNode);
            }
        }

        public void SortListOfNodes()
        {
            for (int i = 0; i < this.ListOfNodes.Count; i++)
            {
                this.ListOfNodes = ListOfNodes.OrderBy(x => x.NodeValue).ToList();
            }
        }

        public Boolean IsInBeenThereList(Node node)
        {
            for (int i = 0; i < this.BeenThereListOfNodes.Count; i++)
            {
                if (this.BeenThereListOfNodes[i].NodeName.ToString() == node.NodeName.ToString())
                    return true;
            }
            return false;
        }
    }
}
