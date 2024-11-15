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
            this.chartPedidos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // chartPedidos
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPedidos.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPedidos.Legends.Add(legend1);
            this.chartPedidos.Location = new System.Drawing.Point(135, 112);
            this.chartPedidos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chartPedidos.Name = "chartPedidos";
            this.chartPedidos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartPedidos.Series.Add(series1);
            this.chartPedidos.Size = new System.Drawing.Size(642, 478);
            this.chartPedidos.TabIndex = 0;
            // 
            // VisualizarEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1238, 882);
            this.Controls.Add(this.chartPedidos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "VisualizarEstadisticas";
            this.Text = "VisualizarEstadisticaMensual";
            ((System.ComponentModel.ISupportInitialize)(this.chartPedidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPedidos;
    }
}