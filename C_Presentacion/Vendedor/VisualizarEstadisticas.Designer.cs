namespace AgMaGest.C_Presentacion.Vendedor
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
            this.chartEstMen = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartEstMen)).BeginInit();
            this.SuspendLayout();
            // 
            // chartEstMen
            // 
            chartArea1.Name = "ChartArea1";
            this.chartEstMen.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartEstMen.Legends.Add(legend1);
            this.chartEstMen.Location = new System.Drawing.Point(120, 90);
            this.chartEstMen.Name = "chartEstMen";
            this.chartEstMen.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartEstMen.Series.Add(series1);
            this.chartEstMen.Size = new System.Drawing.Size(571, 382);
            this.chartEstMen.TabIndex = 0;
            // 
            // VisualizarEstadisticaMensual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1100, 706);
            this.Controls.Add(this.chartEstMen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VisualizarEstadisticaMensual";
            this.Text = "VisualizarEstadisticaMensual";
            ((System.ComponentModel.ISupportInitialize)(this.chartEstMen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartEstMen;
    }
}