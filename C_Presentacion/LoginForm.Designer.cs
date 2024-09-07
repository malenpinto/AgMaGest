using System.Drawing;
using System.Windows.Forms;

namespace AgMaGest.C_Presentacion
{
    partial class LoginForm
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
            this.LUsuario = new System.Windows.Forms.Label();
            this.LContrasenia = new System.Windows.Forms.Label();
            this.TBUsuario = new System.Windows.Forms.TextBox();
            this.TBContrasenia = new System.Windows.Forms.TextBox();
            this.CBRecordar = new System.Windows.Forms.CheckBox();
            this.BIniciarSesion = new System.Windows.Forms.Button();
            this.BSalir = new System.Windows.Forms.Button();
            this.PBBienvenidos = new System.Windows.Forms.PictureBox();
            this.PBPerfil = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PBBienvenidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // LUsuario
            // 
            this.LUsuario.AutoSize = true;
            this.LUsuario.BackColor = System.Drawing.Color.Transparent;
            this.LUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LUsuario.ForeColor = System.Drawing.Color.Black;
            this.LUsuario.Location = new System.Drawing.Point(356, 307);
            this.LUsuario.Name = "LUsuario";
            this.LUsuario.Size = new System.Drawing.Size(66, 21);
            this.LUsuario.TabIndex = 0;
            this.LUsuario.Text = "Usuario";
            // 
            // LContrasenia
            // 
            this.LContrasenia.AutoSize = true;
            this.LContrasenia.BackColor = System.Drawing.Color.Transparent;
            this.LContrasenia.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LContrasenia.Location = new System.Drawing.Point(356, 357);
            this.LContrasenia.Name = "LContrasenia";
            this.LContrasenia.Size = new System.Drawing.Size(103, 21);
            this.LContrasenia.TabIndex = 1;
            this.LContrasenia.Text = "Contraseña";
            // 
            // TBUsuario
            // 
            this.TBUsuario.Location = new System.Drawing.Point(473, 307);
            this.TBUsuario.Name = "TBUsuario";
            this.TBUsuario.Size = new System.Drawing.Size(100, 20);
            this.TBUsuario.TabIndex = 2;
            this.TBUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBUsuario_KeyPress);
            // 
            // TBContrasenia
            // 
            this.TBContrasenia.Location = new System.Drawing.Point(473, 357);
            this.TBContrasenia.Name = "TBContrasenia";
            this.TBContrasenia.Size = new System.Drawing.Size(100, 20);
            this.TBContrasenia.TabIndex = 3;
            // 
            // CBRecordar
            // 
            this.CBRecordar.AutoSize = true;
            this.CBRecordar.BackColor = System.Drawing.Color.Transparent;
            this.CBRecordar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBRecordar.Location = new System.Drawing.Point(360, 402);
            this.CBRecordar.Name = "CBRecordar";
            this.CBRecordar.Size = new System.Drawing.Size(136, 21);
            this.CBRecordar.TabIndex = 7;
            this.CBRecordar.Text = "Recordar usuario";
            this.CBRecordar.UseVisualStyleBackColor = false;
            // 
            // BIniciarSesion
            // 
            this.BIniciarSesion.BackColor = System.Drawing.Color.Gray;
            this.BIniciarSesion.FlatAppearance.BorderSize = 0;
            this.BIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BIniciarSesion.ForeColor = System.Drawing.Color.White;
            this.BIniciarSesion.Location = new System.Drawing.Point(360, 443);
            this.BIniciarSesion.Name = "BIniciarSesion";
            this.BIniciarSesion.Size = new System.Drawing.Size(99, 50);
            this.BIniciarSesion.TabIndex = 8;
            this.BIniciarSesion.Text = "Iniciar Sesion";
            this.BIniciarSesion.UseVisualStyleBackColor = true;
            this.BIniciarSesion.Click += new System.EventHandler(this.BIniciarSesion_Click);
            // 
            // BSalir
            // 
            this.BSalir.BackColor = System.Drawing.Color.Gray;
            this.BSalir.FlatAppearance.BorderSize = 0;
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.ForeColor = System.Drawing.Color.White;
            this.BSalir.Location = new System.Drawing.Point(473, 443);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(100, 50);
            this.BSalir.TabIndex = 9;
            this.BSalir.Text = "Salir";
            this.BSalir.UseVisualStyleBackColor = true;
            this.BSalir.Click += new System.EventHandler(this.BSalir_Click);
            // 
            // PBBienvenidos
            // 
            this.PBBienvenidos.BackColor = System.Drawing.Color.Transparent;
            this.PBBienvenidos.Image = global::AgMaGest.Properties.Resources.BIENVENIDOS__800px_;
            this.PBBienvenidos.Location = new System.Drawing.Point(73, 1);
            this.PBBienvenidos.Name = "PBBienvenidos";
            this.PBBienvenidos.Size = new System.Drawing.Size(786, 176);
            this.PBBienvenidos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PBBienvenidos.TabIndex = 10;
            this.PBBienvenidos.TabStop = false;
            // 
            // PBPerfil
            // 
            this.PBPerfil.BackColor = System.Drawing.Color.Transparent;
            this.PBPerfil.Image = global::AgMaGest.Properties.Resources.avatarUsuario;
            this.PBPerfil.Location = new System.Drawing.Point(418, 184);
            this.PBPerfil.Name = "PBPerfil";
            this.PBPerfil.Size = new System.Drawing.Size(100, 101);
            this.PBPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBPerfil.TabIndex = 6;
            this.PBPerfil.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(936, 533);
            this.ControlBox = false;
            this.Controls.Add(this.PBBienvenidos);
            this.Controls.Add(this.BSalir);
            this.Controls.Add(this.BIniciarSesion);
            this.Controls.Add(this.CBRecordar);
            this.Controls.Add(this.PBPerfil);
            this.Controls.Add(this.TBContrasenia);
            this.Controls.Add(this.TBUsuario);
            this.Controls.Add(this.LContrasenia);
            this.Controls.Add(this.LUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesión";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBBienvenidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBPerfil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Label LUsuario;
        private System.Windows.Forms.Label LContrasenia;
        private System.Windows.Forms.TextBox TBUsuario;
        private System.Windows.Forms.TextBox TBContrasenia;
        private System.Windows.Forms.PictureBox PBPerfil;
        private System.Windows.Forms.CheckBox CBRecordar;
        private Button BIniciarSesion;
        private Button BSalir;
        private PictureBox PBBienvenidos;
    }
}