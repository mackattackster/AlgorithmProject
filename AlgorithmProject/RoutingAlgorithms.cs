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

namespace AlgorithmProject
{
    public partial class RoutingAlgorithms : Form
    {
        public RoutingAlgorithms()
        {
            InitializeComponent();
        }

        private void btnBellman_Click(object sender, EventArgs e)
        {
            int i = 999;
            BellmanFord BF = new BellmanFord();
            int R1_R2 = Int32.Parse(textBoxR1_R2.Text);
            int R1_R3 = Int32.Parse(textBoxR1_R3.Text);
            int R1_R4 = Int32.Parse(textBoxR1_R4.Text);
            int R2_R6 = Int32.Parse(textBoxR2_R6.Text);
            int R3_R4 = Int32.Parse(textBoxR3_R4.Text);
            int R3_R5 = Int32.Parse(textBoxR3_R5.Text);
            int R4_R6 = Int32.Parse(textBoxR4_R6.Text);
            int R5_R6 = Int32.Parse(textBoxR5_R6.Text);

            BF.AddArray(new[] { 0, R1_R2, R1_R3, R1_R4, i, i });
            BF.AddArray(new[] { R1_R2, 0, i, i, i, R2_R6 });
            BF.AddArray(new[] { R1_R3, i, 0, R3_R4, R3_R5, i });
            BF.AddArray(new[] { R1_R4, i, R3_R4, 0, i, R4_R6 });
            BF.AddArray(new[] { i, i, R3_R5, i, 0, R5_R6 });
            BF.AddArray(new[] { i, R2_R6, i, R4_R6, R5_R6, 0 });

            BF.StartBellmanFord();
            this.textBoxBellmanDisplay.Text = BF.ListOfMatrix[1];

            this.textBoxIteration.Text = BF.iterationCount.ToString();
        }

        private void btnDijkstra_Click(object sender, EventArgs e)
        {            
            int R1_R2 = Int32.Parse(textBoxR1_R2.Text);
            int R1_R3 = Int32.Parse(textBoxR1_R3.Text);
            int R1_R4 = Int32.Parse(textBoxR1_R4.Text);
            int R2_R6 = Int32.Parse(textBoxR2_R6.Text);
            int R3_R4 = Int32.Parse(textBoxR3_R4.Text);
            int R3_R5 = Int32.Parse(textBoxR3_R5.Text);
            int R4_R6 = Int32.Parse(textBoxR4_R6.Text);
            int R5_R6 = Int32.Parse(textBoxR5_R6.Text);

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

            Dijkstra DF = new Dijkstra(R5);

            MessageBox.Show("R1: " + R1.NodeValue + "");
            MessageBox.Show("R2: " + R2.NodeValue + "");
            MessageBox.Show("R3: " + R3.NodeValue + "");
            MessageBox.Show("R4: " + R4.NodeValue + "");
            MessageBox.Show("R5: " + R5.NodeValue + "");
            MessageBox.Show("R6: " + R6.NodeValue + "");

            List<String> s = DF.Routes;
            for (int i = 0; i < s.Count; i++)
                MessageBox.Show(s[i]);
        }
        
    }
}
