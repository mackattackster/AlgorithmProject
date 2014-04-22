using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgorithmProject.Algorithms;
using AlgorithmProject.Objects;

namespace AlgorithmProject
{
    public partial class RoutingAlgorithms : Form
    {
        int R1_R2, R1_R3, R1_R4, R2_R6, R3_R4, R3_R5, R4_R6, R5_R6;

        public RoutingAlgorithms()
        {
            InitializeComponent();
        }

        public void GetInput()
        {
            R1_R2 = Int32.Parse(textBoxR1_R2.Text);
            R1_R3 = Int32.Parse(textBoxR1_R3.Text);
            R1_R4 = Int32.Parse(textBoxR1_R4.Text);
            R2_R6 = Int32.Parse(textBoxR2_R6.Text);
            R3_R4 = Int32.Parse(textBoxR3_R4.Text);
            R3_R5 = Int32.Parse(textBoxR3_R5.Text);
            R4_R6 = Int32.Parse(textBoxR4_R6.Text);
            R5_R6 = Int32.Parse(textBoxR5_R6.Text);
        }


        private void btnDijkstra_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GetInput();
            String n = comboBoxDijkstra.Text;
            //nodes
            Objects.Node R1 = new Objects.Node("R1");
            Objects.Node R2 = new Objects.Node("R2");
            Objects.Node R3 = new Objects.Node("R3");
            Objects.Node R4 = new Objects.Node("R4");
            Objects.Node R5 = new Objects.Node("R5");
            Objects.Node R6 = new Objects.Node("R6");

            //R1 Edges
            Objects.Edge EdgeR1toR3 = new Objects.Edge(R3, R1_R3);
            Objects.Edge EdgeR1toR2 = new Objects.Edge(R2, R1_R2);
            Objects.Edge EdgeR1toR4 = new Objects.Edge(R4, R1_R4);
            R1.AddEdge(EdgeR1toR3);
            R1.AddEdge(EdgeR1toR2);
            R1.AddEdge(EdgeR1toR4);

            //R2 Edges
            Objects.Edge EdgeR2toR1 = new Objects.Edge(R1, R1_R2);
            Objects.Edge EdgeR2toR6 = new Objects.Edge(R6, R2_R6);
            R2.AddEdge(EdgeR2toR1);
            R2.AddEdge(EdgeR2toR6);

            //R3 Edges
            Objects.Edge EdgeR3toR1 = new Objects.Edge(R1, R1_R3);
            Objects.Edge EdgeR3toR4 = new Objects.Edge(R4, R3_R4);
            Objects.Edge EdgeR3toR5 = new Objects.Edge(R5, R3_R5);
            R3.AddEdge(EdgeR3toR1);
            R3.AddEdge(EdgeR3toR4);
            R3.AddEdge(EdgeR3toR5);

            //R4 Edges
            Objects.Edge EdgeR4toR1 = new Objects.Edge(R1, R1_R4);
            Objects.Edge EdgeR4toR3 = new Objects.Edge(R3, R3_R4);
            Objects.Edge EdgeR4toR6 = new Objects.Edge(R6, R4_R6);
            R4.AddEdge(EdgeR4toR1);
            R4.AddEdge(EdgeR4toR3);
            R4.AddEdge(EdgeR4toR6);

            //R5 Edges
            Objects.Edge EdgeR5toR6 = new Objects.Edge(R6, R5_R6);
            Objects.Edge EdgeR5toR3 = new Objects.Edge(R3, R3_R5);
            R5.AddEdge(EdgeR5toR3);
            R5.AddEdge(EdgeR5toR6);

            //R6 Edges
            Objects.Edge EdgeR6toR2 = new Objects.Edge(R2, R2_R6);
            Objects.Edge EdgeR6toR4 = new Objects.Edge(R4, R4_R6);
            Objects.Edge EdgeR6toR5 = new Objects.Edge(R5, R5_R6);
            R6.AddEdge(EdgeR6toR2);
            R6.AddEdge(EdgeR6toR4);
            R6.AddEdge(EdgeR6toR5);

            Objects.Node x = new Objects.Node("");

            switch (n)
            {
                case "R1":
                    x = R1;
                    break;
                case "R2":
                    x = R2;
                    break;
                case "R3":
                    x = R3;
                    break;
                case "R4":
                    x = R4;
                    break;
                case "R5":
                    x = R5;
                    break;
                case "R6":
                    x = R6;
                    break;
                case "":
                    MessageBox.Show("You did not select a node", "Missing Node", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }



            //MessageBox.Show("R1: " + R1.NodeValue + "");
            //MessageBox.Show("R2: " + R2.NodeValue + "");
            //MessageBox.Show("R3: " + R3.NodeValue + "");
            //MessageBox.Show("R4: " + R4.NodeValue + "");
            //MessageBox.Show("R5: " + R5.NodeValue + "");
            //MessageBox.Show("R6: " + R6.NodeValue + "");

            //List<String> s = DF.Routes;
            //String temp = "";
            //foreach (String route in s)
            //{
            //    temp += route + Environment.NewLine;
            //}
            //this.textBoxDijkstraDisplay.Clear();
            //this.textBoxDijkstraDisplay.Text += temp;

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            Dijkstra DF = new Dijkstra(x);
            sw.Stop();

            for (int i = 0; i < DF.BeenThereListOfNodes.Count; i++)
            {
                List<String> s = DF.Routes;
                string nextHop = s[i];
                
                this.dataGridView1.Rows.Insert(i, new string[] {
        DF.BeenThereListOfNodes[i].NodeName,
     DF.BeenThereListOfNodes[i].NodeValue.ToString(), nextHop.Substring(5,4) ,
    s[i].ToString(),
    DF.iterations.ToString(),
    sw.Elapsed.ToString()
});
            }


        }

        private void btnBellman_Click_1(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            GetInput();

            Objects.Node R1 = new Objects.Node("R1");
            Objects.Node R2 = new Objects.Node("R2");
            Objects.Node R3 = new Objects.Node("R3");
            Objects.Node R4 = new Objects.Node("R4");
            Objects.Node R5 = new Objects.Node("R5");
            Objects.Node R6 = new Objects.Node("R6");

            //R1 Edges
            Objects.Edge EdgeR1toR3 = new Objects.Edge(R3, R1_R3);
            Objects.Edge EdgeR1toR2 = new Objects.Edge(R2, R1_R2);
            Objects.Edge EdgeR1toR4 = new Objects.Edge(R4, R1_R4);
            R1.AddEdge(EdgeR1toR3);
            R1.AddEdge(EdgeR1toR2);
            R1.AddEdge(EdgeR1toR4);

            //R2 Edges
            Objects.Edge EdgeR2toR1 = new Objects.Edge(R1, R1_R2);
            Objects.Edge EdgeR2toR6 = new Objects.Edge(R6, R2_R6);
            R2.AddEdge(EdgeR2toR1);
            R2.AddEdge(EdgeR2toR6);

            //R3 Edges
            Objects.Edge EdgeR3toR1 = new Objects.Edge(R1, R1_R3);
            Objects.Edge EdgeR3toR4 = new Objects.Edge(R4, R3_R4);
            Objects.Edge EdgeR3toR5 = new Objects.Edge(R5, R3_R5);
            R3.AddEdge(EdgeR3toR1);
            R3.AddEdge(EdgeR3toR4);
            R3.AddEdge(EdgeR3toR5);

            //R4 Edges
            Objects.Edge EdgeR4toR1 = new Objects.Edge(R1, R1_R4);
            Objects.Edge EdgeR4toR3 = new Objects.Edge(R3, R3_R4);
            Objects.Edge EdgeR4toR6 = new Objects.Edge(R6, R4_R6);
            R4.AddEdge(EdgeR4toR1);
            R4.AddEdge(EdgeR4toR3);
            R4.AddEdge(EdgeR4toR6);

            //R5 Edges
            Objects.Edge EdgeR5toR6 = new Objects.Edge(R6, R5_R6);
            Objects.Edge EdgeR5toR3 = new Objects.Edge(R3, R3_R5);
            R5.AddEdge(EdgeR5toR3);
            R5.AddEdge(EdgeR5toR6);

            //R6 Edges
            Objects.Edge EdgeR6toR2 = new Objects.Edge(R2, R2_R6);
            Objects.Edge EdgeR6toR4 = new Objects.Edge(R4, R4_R6);
            Objects.Edge EdgeR6toR5 = new Objects.Edge(R5, R5_R6);
            R6.AddEdge(EdgeR6toR2);
            R6.AddEdge(EdgeR6toR4);
            R6.AddEdge(EdgeR6toR5);

            int i = 999;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            BellmanFord BF = new BellmanFord(R5);

            BF.AddArray(new[] { 0, R1_R2, R1_R3, R1_R4, i, i });
            BF.AddArray(new[] { R1_R2, 0, i, i, i, R2_R6 });
            BF.AddArray(new[] { R1_R3, i, 0, R3_R4, R3_R5, i });
            BF.AddArray(new[] { R1_R4, i, R3_R4, 0, i, R4_R6 });
            BF.AddArray(new[] { i, i, R3_R5, i, 0, R5_R6 });
            BF.AddArray(new[] { i, R2_R6, i, R4_R6, R5_R6, 0 });

            
            
            BF.StartBellmanFord();
            sw.Stop();
            this.textBoxBellmanDisplay.Text = BF.ListOfMatrix.Last();           
            //this.textBoxIteration.Text = BF.iterationCount.ToString();

            for (int j = 0; j < BF.BeenThereListOfNodes.Count; j++)
            {
                List<String> s = BF.Routes;
                string nextHop = s[j];

                this.dataGridView2.Rows.Insert(j, new string[] {
        BF.BeenThereListOfNodes[j].NodeName,
     BF.BeenThereListOfNodes[j].NodeValue.ToString(), nextHop.Substring(5,4) ,
    s[j].ToString(),
    BF.iterationCount.ToString(),
    sw.Elapsed.ToString()
});
            }

        }
    }
}
