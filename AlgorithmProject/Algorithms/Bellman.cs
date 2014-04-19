using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmProject.Objects;

namespace AlgorithmProject.Algorithms
{
    class Bellman
    {
        private Node _RootNode, _NextNode;
        private List<Node> _ListOfNodes , _BeenThereListOfNodes;
        private List<String> _Routes, _ListRouteDescription, _ListOfMatrix;
        private List<int[]> _ListOfCost, _ListOfDistance, _ListOfUpdate;
        private int iterationCount;

        public Bellman()
        {
            this.ListOfCost = new List<int[]>();
            this.ListOfDistance = new List<int[]>();
            this.ListOfUpdate = new List<int[]>();
            this.ListOfMatrix = new List<String>();
        }

        public void SolveBellmanFord()
        {
            iterationCount = 1;
            InitiateDistanceMatrix();
            InitiateUpdateMatrix();
            SolveBellmanFord(this.ListOfDistance);
        }

        public void SolveBellmanFord(List<int[]> distance)
        {
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
                    SolveBellmanFord(this.ListOfUpdate);
            }
            if (!CheckForChange(distance, ListOfUpdate))
                SolveBellmanFord(this.ListOfUpdate);
            return;
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

        #region Objects
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
        #endregion

    }
}
