using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProject.Algorithms
{
    class BellmanFord
    {
        private List<int[]> _ListOfCost;
        private List<int[]> _ListOfDistance;
        private List<int[]> _ListOfUpdate;
        private List<String> _ListOfMatrix;
        private List<List<Queue<int>>> _Path;
        public int iterationCount;
        private string path;

        public BellmanFord()
        {
            this.ListOfCost = new List<int[]>();
            this.ListOfDistance = new List<int[]>();
            this.ListOfUpdate = new List<int[]>();
            this.ListOfMatrix = new List<String>();
            this.Path = new List<List<Queue<int>>>();
        }

        public List<List<Queue<int>>> Path
        {
            get { return _Path; }
            set { _Path = value; }
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

        public void StartBellmanFord()
        {
            iterationCount = 1;
            InitiateDistanceMatrix();
            InitiateUpdateMatrix();
            SolveBellmanFord(this.ListOfDistance);
            path = "";
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
                            AddNodePath(i, k);
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

        public void AddNodePath(int StartNode, int EndNode)
        {
            if (this.Path.Count < 6)
                this.Path.Add(new List<Queue<int>>());
            if (this.Path[StartNode].Count < 6)
                this.Path[StartNode].Add(new Queue<int>());
            if (this.Path[StartNode][EndNode].Count != 0)
            {
                this.Path[StartNode][EndNode].Dequeue();
                this.Path[StartNode][EndNode].Dequeue();
            }

            this.Path[StartNode][EndNode].Enqueue(StartNode);
            this.Path[StartNode][EndNode].Enqueue(EndNode);
        }

        public void NodeShortestPath()
        {
            //trying to get shortest distance for row 1
            for (int i = 0; i < this.ListOfUpdate.Count; i++)
            {
                int x = getDistance(0, i);
                if (x != 0)
                {
                    getPath(0, i, x);
                }
            }
        }

        public void getPath(int x, int y, int distance)
        {
            bool shortestPath = false;
            int isDistance;
            int minValue = 0;
            int nextNode = 0;
            path += x + " ";
            while (shortestPath != true)
            {
                for (int i = 0; i < this.ListOfCost.Count; i++)
                {
                    if (this.ListOfCost[x][i] < distance && this.ListOfCost[x][i] != 0)
                    {
                        minValue = this.ListOfCost[x][i];
                        nextNode = i;
                    }
                }
                path += nextNode + " ";
                
            }
        }

        public int getDistance(int x, int y)
        {
            return this.ListOfUpdate[x][y];
        }
                
    }//end of class BellmanFord
}//end of Namespace

//public void InitiateBellmanFord(List<int[]> distance)
//{
//    for (int i = 0; i < distance.Count; i++)
//    {
//        this.Path.Add(new Queue<int>());
//        int[] cost = this.ListOfCost[i];
//        for (int j = 0; j < distance.Count; j++)
//        {
//            int x = FindMin(cost, DistanceMatrixColumn(distance, j), i);                    
//            int[] temp = this.ListOfUpdate[i];
//            this.ListOfUpdate[i][j] = x;

//            temp[j] = x;
//            this.ListOfUpdate[i] = temp;
//        }//end of inner loop

//    }//end of outer loop
//    MatrixIterationToString(this.ListOfUpdate);
//    iterationCount++;
//    //checking if matrix contains infinity
//    for (int i = 0; i < ListOfUpdate.Count; i++)
//    {
//        if (ListOfUpdate[i].Contains(999))
//            InitiateBellmanFord(this.ListOfUpdate);
//    }//end of for loop
//    if (!CheckForChange(distance, ListOfUpdate))
//        InitiateBellmanFord(this.ListOfUpdate);
//    return;
//}//end of InitiateBellmanFord

//public int[] DistanceMatrixColumn(List<int[]> distance, int column)
//{
//    int[] temp = new int[distance[0].Count()];

//    for (int i = 0; i < distance[0].Count(); i++)
//    {
//        temp[i] = distance[i][column];
//    }
//    return temp;
//}//end of DistanceMatrixColumn

//public int FindMin(int[] cost, int[] distance, int node)
//{
//    int x = cost[0] + distance[0];

//    for (int i = 1; i < cost.Length; i++)
//    {
//        if (cost[i] + distance[i] < x)
//        {
//            x = cost[i] + distance[i];
//            this.Path[node].Enqueue(i - 1);
//        }
//        else
//            this.Path[node].Enqueue(-1);
//            this.Path[node].Enqueue(i + 1);
//    }//end of loop
//    return x;
//}//end of FindMin
