namespace AgMaGest.C_Presentacion.Vendedor
{
    partial class VisualizarEstadisticaTrimestral
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
            this.chartEstTrim = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartEstTrim)).BeginInit();
            this.SuspendLayout();
            // 
            // chartEstTrim
            // 
            chartArea1.Name = "ChartArea1";
            this.chartEstTrim.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartEstTrim.Legends.Add(legend1);
            this.chartEstTrim.Location = new System.Drawing.Point(120, 90);
            this.chartEstTrim.Name = "chartEstTrim";
            this.chartEstTrim.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartEstTrim.Series.Add(series1);
            this.chartEstTrim.Size = new System.Drawing.Size(571, 382);
            this.chartEstTrim.TabIndex = 0;
            // 
            // VisualizarEstadisticaTrimestral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1100, 706);
            this.Controls.Add(this.chartEstTrim);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VisualizarEstadisticaTrimestral";
            this.Text = "VisualizarEstadisticaTrimestral";
            ((System.ComponentModel.ISupportInitialize)(this.chartEstTrim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartEstTrim;
    }
}