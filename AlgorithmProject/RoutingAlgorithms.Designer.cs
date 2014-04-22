namespace AlgorithmProject
{
    partial class RoutingAlgorithms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoutingAlgorithms));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageNetwork = new System.Windows.Forms.TabPage();
            this.textBoxR4_R6 = new System.Windows.Forms.TextBox();
            this.textBoxR2_R6 = new System.Windows.Forms.TextBox();
            this.textBoxR1_R2 = new System.Windows.Forms.TextBox();
            this.textBoxR3_R4 = new System.Windows.Forms.TextBox();
            this.textBoxR1_R4 = new System.Windows.Forms.TextBox();
            this.textBoxR5_R6 = new System.Windows.Forms.TextBox();
            this.textBoxR3_R5 = new System.Windows.Forms.TextBox();
            this.textBoxR1_R3 = new System.Windows.Forms.TextBox();
            this.tabPageBellmanFord = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.textBoxBellmanDisplay = new System.Windows.Forms.TextBox();
            this.btnBellman = new System.Windows.Forms.Button();
            this.tabPageDijkstra = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBoxDijkstra = new System.Windows.Forms.ComboBox();
            this.btnDijkstra = new System.Windows.Forms.Button();
            this.NodeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextHop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Route = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iterations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NodeNameBF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextNodeBF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostBF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RouteBF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IterationsBF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeBF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl.SuspendLayout();
            this.tabPageNetwork.SuspendLayout();
            this.tabPageBellmanFord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPageDijkstra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.tabPageNetwork);
            this.tabControl.Controls.Add(this.tabPageBellmanFord);
            this.tabControl.Controls.Add(this.tabPageDijkstra);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(820, 428);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageNetwork
            // 
            this.tabPageNetwork.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPageNetwork.BackgroundImage")));
            this.tabPageNetwork.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPageNetwork.Controls.Add(this.textBoxR4_R6);
            this.tabPageNetwork.Controls.Add(this.textBoxR2_R6);
            this.tabPageNetwork.Controls.Add(this.textBoxR1_R2);
            this.tabPageNetwork.Controls.Add(this.textBoxR3_R4);
            this.tabPageNetwork.Controls.Add(this.textBoxR1_R4);
            this.tabPageNetwork.Controls.Add(this.textBoxR5_R6);
            this.tabPageNetwork.Controls.Add(this.textBoxR3_R5);
            this.tabPageNetwork.Controls.Add(this.textBoxR1_R3);
            this.tabPageNetwork.Location = new System.Drawing.Point(4, 25);
            this.tabPageNetwork.Name = "tabPageNetwork";
            this.tabPageNetwork.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNetwork.Size = new System.Drawing.Size(812, 399);
            this.tabPageNetwork.TabIndex = 0;
            this.tabPageNetwork.Text = "Network";
            this.tabPageNetwork.UseVisualStyleBackColor = true;
            // 
            // textBoxR4_R6
            // 
            this.textBoxR4_R6.Location = new System.Drawing.Point(557, 270);
            this.textBoxR4_R6.MaxLength = 3;
            this.textBoxR4_R6.Name = "textBoxR4_R6";
            this.textBoxR4_R6.Size = new System.Drawing.Size(26, 20);
            this.textBoxR4_R6.TabIndex = 7;
            this.textBoxR4_R6.Text = "2";
            this.textBoxR4_R6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxR2_R6
            // 
            this.textBoxR2_R6.Location = new System.Drawing.Point(384, 304);
            this.textBoxR2_R6.MaxLength = 3;
            this.textBoxR2_R6.Name = "textBoxR2_R6";
            this.textBoxR2_R6.Size = new System.Drawing.Size(26, 20);
            this.textBoxR2_R6.TabIndex = 6;
            this.textBoxR2_R6.Text = "4";
            this.textBoxR2_R6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxR1_R2
            // 
            this.textBoxR1_R2.Location = new System.Drawing.Point(100, 197);
            this.textBoxR1_R2.MaxLength = 3;
            this.textBoxR1_R2.Name = "textBoxR1_R2";
            this.textBoxR1_R2.Size = new System.Drawing.Size(26, 20);
            this.textBoxR1_R2.TabIndex = 5;
            this.textBoxR1_R2.Text = "2";
            this.textBoxR1_R2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxR3_R4
            // 
            this.textBoxR3_R4.Location = new System.Drawing.Point(457, 142);
            this.textBoxR3_R4.MaxLength = 3;
            this.textBoxR3_R4.Name = "textBoxR3_R4";
            this.textBoxR3_R4.Size = new System.Drawing.Size(26, 20);
            this.textBoxR3_R4.TabIndex = 4;
            this.textBoxR3_R4.Text = "2";
            this.textBoxR3_R4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxR1_R4
            // 
            this.textBoxR1_R4.Location = new System.Drawing.Point(288, 159);
            this.textBoxR1_R4.MaxLength = 3;
            this.textBoxR1_R4.Name = "textBoxR1_R4";
            this.textBoxR1_R4.Size = new System.Drawing.Size(26, 20);
            this.textBoxR1_R4.TabIndex = 3;
            this.textBoxR1_R4.Text = "1";
            this.textBoxR1_R4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxR5_R6
            // 
            this.textBoxR5_R6.Location = new System.Drawing.Point(677, 270);
            this.textBoxR5_R6.MaxLength = 3;
            this.textBoxR5_R6.Name = "textBoxR5_R6";
            this.textBoxR5_R6.Size = new System.Drawing.Size(26, 20);
            this.textBoxR5_R6.TabIndex = 2;
            this.textBoxR5_R6.Text = "3";
            this.textBoxR5_R6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxR3_R5
            // 
            this.textBoxR3_R5.Location = new System.Drawing.Point(594, 142);
            this.textBoxR3_R5.MaxLength = 3;
            this.textBoxR3_R5.Name = "textBoxR3_R5";
            this.textBoxR3_R5.Size = new System.Drawing.Size(26, 20);
            this.textBoxR3_R5.TabIndex = 1;
            this.textBoxR3_R5.Text = "4";
            this.textBoxR3_R5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxR1_R3
            // 
            this.textBoxR1_R3.Location = new System.Drawing.Point(318, 70);
            this.textBoxR1_R3.MaxLength = 3;
            this.textBoxR1_R3.Name = "textBoxR1_R3";
            this.textBoxR1_R3.Size = new System.Drawing.Size(26, 20);
            this.textBoxR1_R3.TabIndex = 0;
            this.textBoxR1_R3.Text = "4";
            this.textBoxR1_R3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabPageBellmanFord
            // 
            this.tabPageBellmanFord.Controls.Add(this.dataGridView2);
            this.tabPageBellmanFord.Controls.Add(this.textBoxBellmanDisplay);
            this.tabPageBellmanFord.Controls.Add(this.btnBellman);
            this.tabPageBellmanFord.Location = new System.Drawing.Point(4, 25);
            this.tabPageBellmanFord.Name = "tabPageBellmanFord";
            this.tabPageBellmanFord.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBellmanFord.Size = new System.Drawing.Size(812, 399);
            this.tabPageBellmanFord.TabIndex = 1;
            this.tabPageBellmanFord.Text = "Bellman-Ford";
            this.tabPageBellmanFord.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NodeNameBF,
            this.NextNodeBF,
            this.CostBF,
            this.RouteBF,
            this.IterationsBF,
            this.TimeBF});
            this.dataGridView2.Location = new System.Drawing.Point(8, 155);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(796, 191);
            this.dataGridView2.TabIndex = 3;
            // 
            // textBoxBellmanDisplay
            // 
            this.textBoxBellmanDisplay.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxBellmanDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBellmanDisplay.Location = new System.Drawing.Point(357, 27);
            this.textBoxBellmanDisplay.Multiline = true;
            this.textBoxBellmanDisplay.Name = "textBoxBellmanDisplay";
            this.textBoxBellmanDisplay.Size = new System.Drawing.Size(128, 106);
            this.textBoxBellmanDisplay.TabIndex = 1;
            // 
            // btnBellman
            // 
            this.btnBellman.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBellman.Location = new System.Drawing.Point(3, 352);
            this.btnBellman.Name = "btnBellman";
            this.btnBellman.Size = new System.Drawing.Size(806, 44);
            this.btnBellman.TabIndex = 0;
            this.btnBellman.Text = "Calculate";
            this.btnBellman.UseVisualStyleBackColor = true;
            this.btnBellman.Click += new System.EventHandler(this.btnBellman_Click_1);
            // 
            // tabPageDijkstra
            // 
            this.tabPageDijkstra.Controls.Add(this.dataGridView1);
            this.tabPageDijkstra.Controls.Add(this.comboBoxDijkstra);
            this.tabPageDijkstra.Controls.Add(this.btnDijkstra);
            this.tabPageDijkstra.Location = new System.Drawing.Point(4, 25);
            this.tabPageDijkstra.Name = "tabPageDijkstra";
            this.tabPageDijkstra.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDijkstra.Size = new System.Drawing.Size(812, 399);
            this.tabPageDijkstra.TabIndex = 2;
            this.tabPageDijkstra.Text = "Dijkstra";
            this.tabPageDijkstra.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NodeName,
            this.Cost,
            this.NextHop,
            this.Route,
            this.Iterations,
            this.Time});
            this.dataGridView1.Location = new System.Drawing.Point(8, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(796, 178);
            this.dataGridView1.TabIndex = 4;
            // 
            // comboBoxDijkstra
            // 
            this.comboBoxDijkstra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDijkstra.FormattingEnabled = true;
            this.comboBoxDijkstra.Items.AddRange(new object[] {
            "R1",
            "R2",
            "R3",
            "R4",
            "R5",
            "R6"});
            this.comboBoxDijkstra.Location = new System.Drawing.Point(353, 6);
            this.comboBoxDijkstra.Name = "comboBoxDijkstra";
            this.comboBoxDijkstra.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDijkstra.TabIndex = 3;
            // 
            // btnDijkstra
            // 
            this.btnDijkstra.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDijkstra.Location = new System.Drawing.Point(3, 352);
            this.btnDijkstra.Name = "btnDijkstra";
            this.btnDijkstra.Size = new System.Drawing.Size(806, 44);
            this.btnDijkstra.TabIndex = 1;
            this.btnDijkstra.Text = "Calculate";
            this.btnDijkstra.UseVisualStyleBackColor = true;
            this.btnDijkstra.Click += new System.EventHandler(this.btnDijkstra_Click_1);
            // 
            // NodeName
            // 
            this.NodeName.HeaderText = "Node Name";
            this.NodeName.Name = "NodeName";
            this.NodeName.Width = 50;
            // 
            // Cost
            // 
            this.Cost.HeaderText = "Cost";
            this.Cost.Name = "Cost";
            this.Cost.Width = 50;
            // 
            // NextHop
            // 
            this.NextHop.HeaderText = "Next Hop";
            this.NextHop.Name = "NextHop";
            this.NextHop.Width = 75;
            // 
            // Route
            // 
            this.Route.HeaderText = "Route";
            this.Route.Name = "Route";
            this.Route.Width = 400;
            // 
            // Iterations
            // 
            this.Iterations.HeaderText = "Iterations";
            this.Iterations.Name = "Iterations";
            this.Iterations.Width = 60;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.Width = 115;
            // 
            // NodeNameBF
            // 
            this.NodeNameBF.HeaderText = "Node Name";
            this.NodeNameBF.Name = "NodeNameBF";
            this.NodeNameBF.Width = 50;
            // 
            // NextNodeBF
            // 
            this.NextNodeBF.HeaderText = "Next Hop";
            this.NextNodeBF.Name = "NextNodeBF";
            this.NextNodeBF.Width = 50;
            // 
            // CostBF
            // 
            this.CostBF.HeaderText = "Cost";
            this.CostBF.Name = "CostBF";
            this.CostBF.Width = 50;
            // 
            // RouteBF
            // 
            this.RouteBF.HeaderText = "Route";
            this.RouteBF.Name = "RouteBF";
            this.RouteBF.Width = 400;
            // 
            // IterationsBF
            // 
            this.IterationsBF.HeaderText = "Iterations";
            this.IterationsBF.Name = "IterationsBF";
            // 
            // TimeBF
            // 
            this.TimeBF.HeaderText = "Time";
            this.TimeBF.Name = "TimeBF";
            // 
            // RoutingAlgorithms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 428);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RoutingAlgorithms";
            this.Text = "Routing Algorithms";
            this.tabControl.ResumeLayout(false);
            this.tabPageNetwork.ResumeLayout(false);
            this.tabPageNetwork.PerformLayout();
            this.tabPageBellmanFord.ResumeLayout(false);
            this.tabPageBellmanFord.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPageDijkstra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageNetwork;
        private System.Windows.Forms.TabPage tabPageBellmanFord;
        private System.Windows.Forms.TabPage tabPageDijkstra;
        private System.Windows.Forms.TextBox textBoxR1_R3;
        private System.Windows.Forms.TextBox textBoxR4_R6;
        private System.Windows.Forms.TextBox textBoxR2_R6;
        private System.Windows.Forms.TextBox textBoxR1_R2;
        private System.Windows.Forms.TextBox textBoxR3_R4;
        private System.Windows.Forms.TextBox textBoxR1_R4;
        private System.Windows.Forms.TextBox textBoxR5_R6;
        private System.Windows.Forms.TextBox textBoxR3_R5;
        private System.Windows.Forms.Button btnBellman;
        private System.Windows.Forms.TextBox textBoxBellmanDisplay;
        private System.Windows.Forms.Button btnDijkstra;
        private System.Windows.Forms.ComboBox comboBoxDijkstra;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeNameBF;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextNodeBF;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostBF;
        private System.Windows.Forms.DataGridViewTextBoxColumn RouteBF;
        private System.Windows.Forms.DataGridViewTextBoxColumn IterationsBF;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeBF;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextHop;
        private System.Windows.Forms.DataGridViewTextBoxColumn Route;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iterations;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
    }
}

