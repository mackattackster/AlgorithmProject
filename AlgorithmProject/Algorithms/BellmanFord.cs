using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmProject.Objects;

namespace AlgorithmProject.Algorithms
{
    class BellmanFord
    {
        private Node _RootNode, _NextNode;
        private List<Node> _ListOfNodes, _BeenThereListOfNodes;
        private List<String> _Routes, _ListRouteDescription, _ListOfMatrix;
        private List<int[]> _ListOfCost, _ListOfDistance, _ListOfUpdate;
        public int iterationCount;       

        public BellmanFord(Node RootNode)
        {
            this.ListOfCost = new List<int[]>();
            this.ListOfDistance = new List<int[]>();
            this.ListOfUpdate = new List<int[]>();
            this.ListOfMatrix = new List<String>();
            //
            this.RootNode = RootNode;
            this.ListOfNodes = new List<Node>();
            this.BeenThereListOfNodes = new List<Node>();
            this.Routes = new List<String>();
            this.ListRouteDescription = new List<String>();
            RootNode.NodeValue = 0;
            this.ListOfNodes.Add(RootNode);
            //
            ChildrenMapping2(RootNode);
        }

        public void StartBellmanFord()
        {
            iterationCount = 0;
            InitiateDistanceMatrix();
            InitiateUpdateMatrix();
            SolveBellmanFord(this.ListOfDistance);
        }

        public void SolveBellmanFord(List<int[]> distance)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            //i is the Cost Matrix row and the Distance Matrix starting column
            for (int i = 0; i < this.ListOfCost.Count; i++)
            {
                //j is the change in ListOfCost column and Distance Matrix row
                for (int j = 0; j < distance[i].Length; j++)
                {
                    //sets temp to the sum of the ListOfCost and Distance Matrix
                    //should be the distance you are trying to find the minimum of.
                    int temp = this.ListOfCost[i][j] + distance[j][i];
                    for (int k = 0; k < distance[i].Length; k++)
                    {
                        //checking if other sums of ListOfCost row and Distance 
                        //column are minimum distance
                        if (this.ListOfCost[i][k] + distance[k][j] < temp)
                        {
                            temp = this.ListOfCost[i][k] + distance[k][j];
                        }
                    }
                    this.ListOfUpdate[i][j] = temp;
                }
            }
            MatrixIterationToString(this.ListOfUpdate);
            iterationCount++;

            for (int i = 0; i < ListOfUpdate.Count; i++)
            {
                if (ListOfUpdate[i].Contains(999))
                {
                    SolveBellmanFord(this.ListOfUpdate);
                    //iterationCount++;
                }
            }
            if (!CheckForChange(distance, ListOfUpdate))
            {
                SolveBellmanFord(this.ListOfUpdate);
                //iterationCount++;
            }
            sw.Stop();
            string stopwatch = sw.Elapsed.ToString();
            return;
        }

        public bool CheckForChange(List<int[]> distance, List<int[]> LoU)
        {
            for (int i = 0; i < distance.Count(); i++)
            {
                for (int j = 0; j < distance.Count(); j++)
                {
                    if (distance[i][j] != LoU[i][j])
                        return false;
                }
            }
            return true;
        }

        public void InitiateDistanceMatrix()
        {
            int x = this.ListOfCost.Count();

            for (int i = 0; i < x; i++)
            {
                int[] temp = new int[x];

                for (int j = 0; j < x; j++)
                {
                    if (i == j)
                        temp[j] = 0;
                    else
                        temp[j] = 999;
                }//end of inner loop
                this.ListOfDistance.Add(temp);
            }//end of outer loop
        }//end of InitiateDistanceMatrix()

        public void InitiateUpdateMatrix()
        {
            int x = this.ListOfCost.Count();

            for (int i = 0; i < x; i++)
            {
                int[] temp = new int[x];

                for (int j = 0; j < x; j++)
                {
                    if (i == j)
                        temp[j] = 0;
                    else
                        temp[j] = 999;
                }//end of inner loop
                this.ListOfUpdate.Add(temp);
            }//end of outer loop
        }//end of InitiateUpdateMatrix

        public void MatrixIterationToString(List<int[]> iteration)
        {
            int count = iteration.Count();
            string s = "";

            foreach (int[] row in iteration)
            {
                for (int i = 0; i < row.Length; i++)
                {
                    if (i == 0)
                        s += "[ " + row[i];
                    else if (i == row.Length - 1)
                        s += " " + row[i] + " ]" + Environment.NewLine;
                    else
                        s += " " + row[i];
                }//end of inner loop
            }//end of foreach loop
            this.ListOfMatrix.Add(s);
        }//end of MatrixIterationToString

        #region PathHelper

        public void ChildrenMapping2(Node node)
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
                    RemoveBadEdge2(ChildNode, ParentNode);
                }
                else if (ChildNode.NodeValue == 0 || ParentNode.NodeValue == 0)
                {
                    ChildNode.NodeValue = ChildNodeValue;
                    //check if any other beentherelist have connection to it, if yes then delete
                    RemoveBadEdge3(ChildNode, ParentNode);
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
                ChildrenMapping2(this.ListOfNodes[0]);
            }
            else
            {
                for (int i = 0; i < this.BeenThereListOfNodes.Count; i++)
                {
                    Node n = this.BeenThereListOfNodes[i];
                    n.RemoveAllNegativeEdges();
                }

                AddParentEdges();
                FindEachNodeRoute();
                return;
            }
        }

        public void ChildrenMapping(Node nodez)
        {
            // check r3 as parent
            Node nn = nodez;

            for (int w = 0; w < nn.listEdge.Count; w++)
            {
                Node NextNode = nn.listEdge[w].Node;
                // is node already in list?
                if (!BeenThereAlready(NextNode))
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
                    RemoveBadEdge(NextNode, nn);
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
                SortNodeList();
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
                ChildrenMapping(NewsNode);
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

        public void AddParentEdges()
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

        public void RemoveBadEdge2(Node ChildNode, Node ParentNode)
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

        public void RemoveBadEdge3(Node ChildNode, Node ParentNode)
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

        public void RemoveBadEdge(Node nextNode, Node node)
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

        public void FindEachNodeRoute()
        {
            for (int i = 0; i < this.BeenThereListOfNodes.Count; i++)
            {
                Node n = this.BeenThereListOfNodes[i];

                FindEveryRoute(n);
                //this.ListRouteDescription.Add("For " + n.NodeName + Environment.NewLine);
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


        public void FindEveryRoute(Node n)
        {
            if (n.NodeName == this.RootNode.NodeName || n.listParentEdge[0].Node.NodeName == this.RootNode.NodeName)
            {
                if (n.NodeName == this.RootNode.NodeName)
                {
                    this.ListRouteDescription.Add(this.RootNode.NodeName + " => " + n.NodeName + ". Length: " + n.NodeValue);
                }
                else
                {
                    this.ListRouteDescription.Add(this.RootNode.NodeName + " => " + n.NodeName + ". Length: " + n.listParentEdge[0].EdgeLength + ". " + Environment.NewLine);
                }
                return;
            }
            else
            {
                Node newNode = n.listParentEdge[0].Node;
                this.ListRouteDescription.Add(newNode.NodeName + " => " + n.NodeName + ". Length: " + n.listParentEdge[0].EdgeLength + ". " + Environment.NewLine);

                FindEveryRoute(newNode);
            }
        }

        public void SortNodeList()
        {
            for (int i = 0; i < this.ListOfNodes.Count; i++)
            {
                this.ListOfNodes = ListOfNodes.OrderBy(x => x.NodeValue).ToList();
            }
        }

        public Boolean BeenThereAlready(Node node)
        {
            for (int i = 0; i < this.BeenThereListOfNodes.Count; i++)
            {
                if (this.BeenThereListOfNodes[i].NodeName.ToString() == node.NodeName.ToString())
                    return true;
            }
            return false;
        }
        #endregion

        #region Getters/Setters
        public List<String> ListOfMatrix
        {
            get { return _ListOfMatrix; }
            set { _ListOfMatrix = value; }
        }

        public List<int[]> ListOfUpdate
        {
            get { return _ListOfUpdate; }
            set { _ListOfUpdate = value; }
        }

        public List<int[]> ListOfCost
        {
            get { return _ListOfCost; }
            set { _ListOfCost = value; }
        }

        public List<int[]> ListOfDistance
        {
            get { return _ListOfDistance; }
            set { _ListOfDistance = value; }
        }

        public void AddArray(int[] cost)
        {
            this.ListOfCost.Add(cost);
        }

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
        #endregion

    }//end of class BellmanFord
}//end of Namespace

