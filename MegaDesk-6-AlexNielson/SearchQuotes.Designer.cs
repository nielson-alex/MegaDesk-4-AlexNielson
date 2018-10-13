namespace MegaDesk_6_AlexNielson
{
    partial class SearchQuotes
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
            this.pnlQuotes = new System.Windows.Forms.Panel();
            this.lbQuotes = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ddlMaterials = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlQuotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlQuotes
            // 
            this.pnlQuotes.Controls.Add(this.lbQuotes);
            this.pnlQuotes.Location = new System.Drawing.Point(17, 70);
            this.pnlQuotes.Name = "pnlQuotes";
            this.pnlQuotes.Size = new System.Drawing.Size(1165, 336);
            this.pnlQuotes.TabIndex = 72;
            // 
            // lbQuotes
            // 
            this.lbQuotes.FormattingEnabled = true;
            this.lbQuotes.Location = new System.Drawing.Point(3, 4);
            this.lbQuotes.Name = "lbQuotes";
            this.lbQuotes.Size = new System.Drawing.Size(1158, 329);
            this.lbQuotes.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = true;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(399, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 39);
            this.btnSearch.TabIndex = 71;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ddlMaterials
            // 
            this.ddlMaterials.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlMaterials.FormattingEnabled = true;
            this.ddlMaterials.Location = new System.Drawing.Point(17, 21);
            this.ddlMaterials.Name = "ddlMaterials";
            this.ddlMaterials.Size = new System.Drawing.Size(352, 37);
            this.ddlMaterials.TabIndex = 70;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(509, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 39);
            this.btnCancel.TabIndex = 73;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SearchQuotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 418);
            this.Controls.Add(this.pnlQuotes);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.ddlMaterials);
            this.Controls.Add(this.btnCancel);
            this.Name = "SearchQuotes";
            this.Text = "SearchQuotes";
            this.pnlQuotes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlQuotes;
        private System.Windows.Forms.ListBox lbQuotes;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox ddlMaterials;
        private System.Windows.Forms.Button btnCancel;
    }
}