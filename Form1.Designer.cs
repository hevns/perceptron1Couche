namespace perceptron1Couche
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openD = new System.Windows.Forms.Button();
            this.lRes = new System.Windows.Forms.Label();
            this.tbLabel = new System.Windows.Forms.TextBox();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // openD
            // 
            this.openD.Location = new System.Drawing.Point(28, 12);
            this.openD.Name = "openD";
            this.openD.Size = new System.Drawing.Size(75, 23);
            this.openD.TabIndex = 1;
            this.openD.Text = "open";
            this.openD.UseVisualStyleBackColor = true;
            this.openD.Click += new System.EventHandler(this.openD_Click);
            // 
            // lRes
            // 
            this.lRes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lRes.Location = new System.Drawing.Point(28, 38);
            this.lRes.Name = "lRes";
            this.lRes.Size = new System.Drawing.Size(223, 119);
            this.lRes.TabIndex = 2;
            // 
            // tbLabel
            // 
            this.tbLabel.Location = new System.Drawing.Point(277, 36);
            this.tbLabel.Multiline = true;
            this.tbLabel.Name = "tbLabel";
            this.tbLabel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLabel.Size = new System.Drawing.Size(402, 121);
            this.tbLabel.TabIndex = 3;
            // 
            // pBox
            // 
            this.pBox.Location = new System.Drawing.Point(28, 163);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(651, 535);
            this.pBox.TabIndex = 4;
            this.pBox.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(109, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 710);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.pBox);
            this.Controls.Add(this.tbLabel);
            this.Controls.Add(this.lRes);
            this.Controls.Add(this.openD);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button openD;
        private System.Windows.Forms.Label lRes;
        private System.Windows.Forms.TextBox tbLabel;
        private System.Windows.Forms.PictureBox pBox;
        private System.Windows.Forms.Button btnReset;
    }
}

