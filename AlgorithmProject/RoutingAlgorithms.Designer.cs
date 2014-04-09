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
            this.textBoxIteration = new System.Windows.Forms.TextBox();
            this.textBoxBellmanDisplay = new System.Windows.Forms.TextBox();
            this.btnBellman = new System.Windows.Forms.Button();
            this.tabPageDijkstra = new System.Windows.Forms.TabPage();
            this.textBoxDijkstraDisplay = new System.Windows.Forms.TextBox();
            this.btnDijkstra = new System.Windows.Forms.Button();
            this.comboBoxDijkstra = new System.Windows.Forms.ComboBox();
            this.tabControl.SuspendLayout();
            this.tabPageNetwork.SuspendLayout();
            this.tabPageBellmanFord.SuspendLayout();
            this.tabPageDijkstra.SuspendLayout();
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
            this.tabPageBellmanFord.Controls.Add(this.textBoxIteration);
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
            // textBoxIteration
            // 
            this.textBoxIteration.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxIteration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxIteration.Location = new System.Drawing.Point(69, 147);
            this.textBoxIteration.Name = "textBoxIteration";
            this.textBoxIteration.Size = new System.Drawing.Size(55, 20);
            this.textBoxIteration.TabIndex = 2;
            // 
            // textBoxBellmanDisplay
            // 
            this.textBoxBellmanDisplay.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxBellmanDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBellmanDisplay.Location = new System.Drawing.Point(29, 17);
            this.textBoxBellmanDisplay.Multiline = true;
            this.textBoxBellmanDisplay.Name = "textBoxBellmanDisplay";
            this.textBoxBellmanDisplay.Size = new System.Drawing.Size(134, 124);
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
            this.btnBellman.Click += btnBellman_Click;
            // 
            // tabPageDijkstra
            // 
            this.tabPageDijkstra.Controls.Add(this.comboBoxDijkstra);
            this.tabPageDijkstra.Controls.Add(this.textBoxDijkstraDisplay);
            this.tabPageDijkstra.Controls.Add(this.btnDijkstra);
            this.tabPageDijkstra.Location = new System.Drawing.Point(4, 25);
            this.tabPageDijkstra.Name = "tabPageDijkstra";
            this.tabPageDijkstra.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDijkstra.Size = new System.Drawing.Size(812, 399);
            this.tabPageDijkstra.TabIndex = 2;
            this.tabPageDijkstra.Text = "Dijkstra";
            this.tabPageDijkstra.UseVisualStyleBackColor = true;
            // 
            // textBoxDijkstraDisplay
            // 
            this.textBoxDijkstraDisplay.Location = new System.Drawing.Point(8, 6);
            this.textBoxDijkstraDisplay.Multiline = true;
            this.textBoxDijkstraDisplay.Name = "textBoxDijkstraDisplay";
            this.textBoxDijkstraDisplay.Size = new System.Drawing.Size(327, 313);
            this.textBoxDijkstraDisplay.TabIndex = 2;
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
            this.btnDijkstra.Click += btnDijkstra_Click;
            // 
            // comboBoxDijkstra
            // 
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
            this.comboBoxDijkstra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.tabPageDijkstra.ResumeLayout(false);
            this.tabPageDijkstra.PerformLayout();
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
        private System.Windows.Forms.TextBox textBoxIteration;
        private System.Windows.Forms.Button btnDijkstra;
        private System.Windows.Forms.TextBox textBoxDijkstraDisplay;
        private System.Windows.Forms.ComboBox comboBoxDijkstra;
    }
}

