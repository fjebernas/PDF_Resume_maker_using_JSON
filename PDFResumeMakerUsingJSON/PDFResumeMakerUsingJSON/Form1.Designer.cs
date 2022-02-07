
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLoadJSON
            // 
            this.btnLoadJSON.Location = new System.Drawing.Point(92, 421);
            this.btnLoadJSON.Name = "btnLoadJSON";
            this.btnLoadJSON.Size = new System.Drawing.Size(142, 58);
            this.btnLoadJSON.TabIndex = 0;
            this.btnLoadJSON.Text = "&Load JSON file";
            this.btnLoadJSON.UseVisualStyleBackColor = true;
            this.btnLoadJSON.Click += new System.EventHandler(this.btnLoadJSON_Click);
            // 
            // btnGeneratePDF
            // 
            this.btnGeneratePDF.Location = new System.Drawing.Point(291, 421);
            this.btnGeneratePDF.Name = "btnGeneratePDF";
            this.btnGeneratePDF.Size = new System.Drawing.Size(148, 58);
            this.btnGeneratePDF.TabIndex = 1;
            this.btnGeneratePDF.Text = "&Generate PDF";
            this.btnGeneratePDF.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.Location = new System.Drawing.Point(38, 27);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(460, 366);
            this.textBox1.TabIndex = 2;
            // 
            // PDFResumeMakerUsingJSON
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 518);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnGeneratePDF);
            this.Controls.Add(this.btnLoadJSON);
            this.Name = "PDFResumeMakerUsingJSON";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF Resume Maker using JSON";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadJSON;
        private System.Windows.Forms.Button btnGeneratePDF;
        private System.Windows.Forms.TextBox textBox1;
    }
}

