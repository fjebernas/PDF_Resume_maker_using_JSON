
namespace PDFResumeMakerUsingJSON
{
    partial class PDFResumeMakerUsingJSON
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
            this.btnLoadJSON = new System.Windows.Forms.Button();
            this.btnGeneratePDF = new System.Windows.Forms.Button();
            this.displayTxtBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoadJSON
            // 
            this.btnLoadJSON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(114)))), ((int)(((byte)(159)))));
            this.btnLoadJSON.FlatAppearance.BorderSize = 0;
            this.btnLoadJSON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadJSON.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadJSON.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(224)))), ((int)(((byte)(229)))));
            this.btnLoadJSON.Location = new System.Drawing.Point(40, 511);
            this.btnLoadJSON.Name = "btnLoadJSON";
            this.btnLoadJSON.Size = new System.Drawing.Size(142, 39);
            this.btnLoadJSON.TabIndex = 0;
            this.btnLoadJSON.Text = "&Load JSON file";
            this.btnLoadJSON.UseVisualStyleBackColor = false;
            this.btnLoadJSON.Click += new System.EventHandler(this.btnLoadJSON_Click);
            // 
            // btnGeneratePDF
            // 
            this.btnGeneratePDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(114)))), ((int)(((byte)(159)))));
            this.btnGeneratePDF.FlatAppearance.BorderSize = 0;
            this.btnGeneratePDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneratePDF.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneratePDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(224)))), ((int)(((byte)(229)))));
            this.btnGeneratePDF.Location = new System.Drawing.Point(339, 511);
            this.btnGeneratePDF.Name = "btnGeneratePDF";
            this.btnGeneratePDF.Size = new System.Drawing.Size(148, 39);
            this.btnGeneratePDF.TabIndex = 1;
            this.btnGeneratePDF.Text = "&Generate PDF";
            this.btnGeneratePDF.UseVisualStyleBackColor = false;
            this.btnGeneratePDF.Click += new System.EventHandler(this.btnGeneratePDF_Click);
            // 
            // displayTxtBox
            // 
            this.displayTxtBox.AcceptsReturn = true;
            this.displayTxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.displayTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.displayTxtBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.displayTxtBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayTxtBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.displayTxtBox.Location = new System.Drawing.Point(40, 87);
            this.displayTxtBox.Multiline = true;
            this.displayTxtBox.Name = "displayTxtBox";
            this.displayTxtBox.ReadOnly = true;
            this.displayTxtBox.Size = new System.Drawing.Size(447, 399);
            this.displayTxtBox.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(114)))), ((int)(((byte)(159)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(224)))), ((int)(((byte)(229)))));
            this.button1.Location = new System.Drawing.Point(204, 511);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "&Write to JSON";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(224)))), ((int)(((byte)(229)))));
            this.label1.Location = new System.Drawing.Point(49, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "PDF Resume Generator using JSON";
            // 
            // PDFResumeMakerUsingJSON
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(68)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(523, 587);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.displayTxtBox);
            this.Controls.Add(this.btnGeneratePDF);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLoadJSON);
            this.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.Name = "PDFResumeMakerUsingJSON";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF Resume Maker using JSON";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadJSON;
        private System.Windows.Forms.Button btnGeneratePDF;
        private System.Windows.Forms.TextBox displayTxtBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

