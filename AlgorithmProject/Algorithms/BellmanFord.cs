using System;
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
        public int iterationCount;
        private List<Queue<int>> _Path;

        public BellmanFord()
        {
            this.ListOfCost = new List<int[]>();
            this.ListOfDistance = new List<int[]>();
            this.ListOfUpdate = new List<int[]>();
            this.ListOfMatrix = new List<String>();
            this.Path = new List<Queue<int>>();
        }

        public List<Queue<int>> Path
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
            InitiateBellmanFord(this.ListOfDistance);
            PathToString();
        }

        public void InitiateBellmanFord(List<int[]> distance)
        {
            for (int i = 0; i < distance.Count; i++)
            {
                this.Path.Add(new Queue<int>());
                int[] cost = this.ListOfCost[i];
                for (int j = 0; j < distance.Count; j++)
                {
                    int x = FindMin(cost, DistanceMatrixColumn(distance, j), i);                    
                    int[] temp = this.ListOfUpdate[i];
                    this.ListOfUpdate[i][j] = x;

                    temp[j] = x;
                    this.ListOfUpdate[i] = temp;
                }//end of inner loop

            }//end of outer loop
            MatrixIterationToString(this.ListOfUpdate);
            iterationCount++;
            //checking if matrix contains infinity
            for (int i = 0; i < ListOfUpdate.Count; i++)
            {
                if (ListOfUpdate[i].Contains(999))
                    InitiateBellmanFord(this.ListOfUpdate);
            }//end of for loop
            if (!CheckForChange(distance, ListOfUpdate))
                InitiateBellmanFord(this.ListOfUpdate);
            return;
        }//end of InitiateBellmanFord

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

        public int[] DistanceMatrixColumn(List<int[]> distance, int column)
        {
            int[] temp = new int[distance[0].Count()];

            for (int i = 0; i < distance[0].Count(); i++)
            {
                temp[i] = distance[i][column];
            }
            return temp;
        }//end of DistanceMatrixColumn

        public int FindMin(int[] cost, int[] distance, int node)
        {
            int x = cost[0] + distance[0];

            for (int i = 1; i < cost.Length; i++)
            {
                if (cost[i] + distance[i] < x)
                {
                    x = cost[i] + distance[i];
                    this.Path[node].Enqueue(i - 1);
                }
                else
                    this.Path[node].Enqueue(-1);
                    this.Path[node].Enqueue(i + 1);
            }//end of loop
            return x;
        }//end of FindMin

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

        public void PathToString()
        {
            String s = "";
            foreach (Queue<int> x in this.Path)
            {
                x.Reverse();
                foreach (int i in x)
                {
                    s += " " + i.ToString() + " ";
                }
                s += Environment.NewLine + Environment.NewLine;
            }
            System.Windows.Forms.MessageBox.Show(s);
        }

    }//end of class BellmanFord
}//end of Namespace
