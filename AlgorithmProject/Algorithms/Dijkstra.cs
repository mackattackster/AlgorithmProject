using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private Node _NextNode;

        public List<Node> ListOfNodes
        {
            get { return _ListOfNodes; }
            set { _ListOfNodes = value; }
        }

        public Node NextNode
        {
            get { return _NextNode; }
            set { _NextNode = value; }
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
            //  this.BeenThereListOfNodes.Add(RootNode);

            FindChildrenMap2(RootNode);
        }

        public void FindChildrenMap2(Node node)
        {
            Node ParentNode = node;

            this.BeenThereListOfNodes.Add(ParentNode);
            this.ListOfNodes.RemoveAt(0);

            for (int w = 0; w < ParentNode.listEdge.Count; w++)
            {
                //Add all new known child nodes to list
                Node ChildNode = ParentNode.listEdge[w].Node;
                bool bNextChildren = this.ListOfNodes.Any(x => x.NodeName == ChildNode.NodeName);
                bool bCheckedChildren = this.BeenThereListOfNodes.Any(x => x.NodeName == ChildNode.NodeName);
                if (!bNextChildren && !bCheckedChildren)
                {
                    this.ListOfNodes.Add(ChildNode);
                    this.ListOfNodes = this.ListOfNodes.OrderBy(x => x.NodeValue).ToList();
                }
                else
                {

                }
                // Remove Child nodes parent.
                ChildNode.RemoveEdge(ParentNode);

                Double ChildNodeValue = ParentNode.listEdge[w].EdgeLength + ParentNode.NodeValue;

                // if the childNode has an existing value, but needs updating.
                if (ChildNode.NodeValue > ChildNodeValue && ChildNode.NodeValue != 0)
                {
                    ChildNode.NodeValue = ChildNodeValue;
                    DeleteOldEdge2(ChildNode, ParentNode);
                }
                else if (ChildNode.NodeValue == 0 || ParentNode.NodeValue == 0)
                {
                    ChildNode.NodeValue = ChildNodeValue;
                    //check if any other beentherelist have connection to it, if yes then delete
                    DeleteOldEdge3(ChildNode, ParentNode);
                }

                else
                {
                    ParentNode.RemoveEdge(ChildNode);
                    //   ParentNode.listEdge[w].EdgeLength = -1;
                }
            }

            if (this.ListOfNodes.Count > 0)
            {
                this.ListOfNodes = this.ListOfNodes.OrderBy(x => x.NodeValue).ToList();
                FindChildrenMap2(this.ListOfNodes[0]);
            }
            else
            {
                for (int i = 0; i < this.BeenThereListOfNodes.Count; i++)
                {
                    Node n = this.BeenThereListOfNodes[i];
                    n.RemoveAllNegativeEdges();
                }

                CreateParentEdges();
                FindRoutesForAllPoints();
                return;
            }
        }

        public void FindChildrenMap(Node nodez)
        {
            // check r3 as parent
            Node nn = nodez;

            for (int w = 0; w < nn.listEdge.Count; w++)
            {
                Node NextNode = nn.listEdge[w].Node;
                // is node already in list?
                if (!IsInBeenThereList(NextNode))
                {
                    // if R5 to R6 remove R6 to R5
                    NextNode.RemoveEdge(nn);
                    //  DeleteOldEdge(NextNode, nn);
                    //add to list
                    this.ListOfNodes.Add(NextNode);
                    this.BeenThereListOfNodes.Add(NextNode);

                }
                else
                {
                    //
                    nn.RemoveEdge(NextNode);
                    //    DeleteOldEdge(NextNode, nn);
                }

                Double potentialNodeValue = nn.listEdge[w].EdgeLength + nn.NodeValue;

                if (NextNode.NodeValue > potentialNodeValue && NextNode.NodeValue != 0)
                {
                    NextNode.NodeValue = potentialNodeValue;
                    DeleteOldEdge(NextNode, nn);
                }
                else if (NextNode.NodeValue == 0 || nn.NodeValue == 0)
                {
                    NextNode.NodeValue = potentialNodeValue;
                }
                else
                {
                    nn.listEdge[w].EdgeLength = -1;
                }
            }

            if (this.ListOfNodes.Count > 0)
            {
                SortListOfNodes();
                this.ListOfNodes.RemoveAt(0);

                if (this.ListOfNodes.Count == 0)
                {
                    // Node NewNode = this.BeenThereListOfNodes[this.BeenThereListOfNodes.Count-1];
                    // FindChildrenMap(NewNode);
                    // this.BeenThereListOfNodes.Insert(0, this.RootNode);
                    for (int i = 0; i < this.BeenThereListOfNodes.Count; i++)
                    {
                        Node n = this.BeenThereListOfNodes[i];
                        n.RemoveAllNegativeEdges();
                    }
                    //CheckDuplicateChildrenChecker();
                    // CreateParentEdges();
                    //FindRoutesForAllPoints();
                    return;
                    // Done with child map. Just add parent map and method to call up the tree until its node :)
                }

                Node NewsNode = this.ListOfNodes[0];
                FindChildrenMap(NewsNode);
            }
            else
            {
                //never get here
                this.BeenThereListOfNodes.Insert(0, this.RootNode);
                for (int i = 0; i < this.BeenThereListOfNodes.Count; i++)
                {
                    Node n = this.BeenThereListOfNodes[i];
                    n.RemoveAllNegativeEdges();
                }
                // Done with child map. Just add parent map and method to call up the tree until its node :)

                // CreateParentEdges();
                //FindRoutesForAllPoints()
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

        public void DeleteOldEdge2(Node ChildNode, Node ParentNode)
        {
            // ParentNode.RemoveEdge(ChildNode);
            for (int i = 0; i < this.BeenThereListOfNodes.Count; i++)
            {
                Node tParentNode = this.BeenThereListOfNodes[i];

                for (int w = 0; w < tParentNode.listEdge.Count; w++)
                {
                    if (tParentNode.listEdge[w].Node.NodeName == ChildNode.NodeName && tParentNode.NodeName != ParentNode.NodeName)
                    {
                        tParentNode.listEdge[w].EdgeLength = -1;
                    }
                }
            }
        }

        public void DeleteOldEdge3(Node ChildNode, Node ParentNode)
        {
            // ParentNode.RemoveEdge(ChildNode);
            for (int i = 0; i < this.BeenThereListOfNodes.Count; i++)
            {
                Node tParentNode = this.BeenThereListOfNodes[i];

                for (int w = 0; w < tParentNode.listEdge.Count; w++)
                {
                    if (tParentNode.listEdge[w].Node.NodeName == ChildNode.NodeName && tParentNode.NodeName != ParentNode.NodeName)
                    {
                        tParentNode.listEdge[w].EdgeLength = -1;
                        ChildNode.RemoveEdge(tParentNode);
                    }
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
                        //int tt = 0;
                        //R5 kills connection to r3? so r3 must kill r5 here
                        this.BeenThereListOfNodes[i].RemoveEdge(nextNode);
                        //n.RemoveEdge(nextNode);
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