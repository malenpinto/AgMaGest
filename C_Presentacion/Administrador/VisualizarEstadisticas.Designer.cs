namespace AgMaGest.C_Presentacion.Administrador
{
    partial class VisualizarEstadisticas
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartVendedor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.CBFiltroVendedor = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartVendedor)).BeginInit();
            this.SuspendLayout();
            // 
            // chartVendedor
            // 
            chartArea1.Name = "ChartArea1";
            this.chartVendedor.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartVendedor.Legends.Add(legend1);
            this.chartVendedor.Location = new System.Drawing.Point(166, 157);
            this.chartVendedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartVendedor.Name = "chartVendedor";
            this.chartVendedor.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Empleado 1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Empleado 2";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Empleado 3";
            this.chartVendedor.Series.Add(series1);
            this.chartVendedor.Series.Add(series2);
            this.chartVendedor.Series.Add(series3);
            this.chartVendedor.Size = new System.Drawing.Size(513, 369);
            this.chartVendedor.TabIndex = 0;
            this.chartVendedor.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(141)))), ((int)(((byte)(25)))));
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.GhostWhite;
            this.label1.Location = new System.Drawing.Point(160, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vendedor del Mes";
            // 
            // CBFiltroVendedor
            // 
            this.CBFiltroVendedor.FormattingEnabled = true;
            this.CBFiltroVendedor.Location = new System.Drawing.Point(416, 116);
            this.CBFiltroVendedor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CBFiltroVendedor.Name = "CBFiltroVendedor";
            this.CBFiltroVendedor.Size = new System.Drawing.Size(263, 24);
            this.CBFiltroVendedor.TabIndex = 2;
            // 
            // VisualizarEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(200)))), ((int)(((byte)(145)))));
            this.ClientSize = new System.Drawing.Size(1100, 706);
            this.Controls.Add(this.CBFiltroVendedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartVendedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "VisualizarEstadisticas";
            this.Text = "VisualizarEstadisticas";
            ((System.ComponentModel.ISupportInitialize)(this.chartVendedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartVendedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBFiltroVendedor;
    }
}