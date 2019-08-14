namespace PruebaSkyscanner
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblExtraData = new System.Windows.Forms.Label();
            this.listHotels = new System.Windows.Forms.ListBox();
            this.btnLookUpHotels = new System.Windows.Forms.Button();
            this.gridHotels = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridHotels)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(33, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Data!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCity
            // 
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCity.Location = new System.Drawing.Point(33, 29);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(421, 31);
            this.txtCity.TabIndex = 1;
            this.txtCity.TextChanged += new System.EventHandler(this.txtCity_TextChanged);
            // 
            // lblExtraData
            // 
            this.lblExtraData.AutoSize = true;
            this.lblExtraData.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblExtraData.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtraData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblExtraData.Location = new System.Drawing.Point(28, 199);
            this.lblExtraData.Name = "lblExtraData";
            this.lblExtraData.Size = new System.Drawing.Size(65, 29);
            this.lblExtraData.TabIndex = 4;
            this.lblExtraData.Text = "label1";
            // 
            // listHotels
            // 
            this.listHotels.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listHotels.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listHotels.FormattingEnabled = true;
            this.listHotels.Location = new System.Drawing.Point(33, 105);
            this.listHotels.Name = "listHotels";
            this.listHotels.Size = new System.Drawing.Size(426, 91);
            this.listHotels.TabIndex = 2;
            this.listHotels.SelectedIndexChanged += new System.EventHandler(this.listHotels_SelectedIndexChanged);
            // 
            // btnLookUpHotels
            // 
            this.btnLookUpHotels.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLookUpHotels.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnLookUpHotels.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLookUpHotels.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLookUpHotels.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLookUpHotels.Location = new System.Drawing.Point(33, 231);
            this.btnLookUpHotels.Name = "btnLookUpHotels";
            this.btnLookUpHotels.Size = new System.Drawing.Size(208, 49);
            this.btnLookUpHotels.TabIndex = 5;
            this.btnLookUpHotels.Text = "Look Up Hotels";
            this.btnLookUpHotels.UseVisualStyleBackColor = true;
            this.btnLookUpHotels.Click += new System.EventHandler(this.btnLookUpHotels_Click);
            // 
            // gridHotels
            // 
            this.gridHotels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHotels.Location = new System.Drawing.Point(33, 291);
            this.gridHotels.Name = "gridHotels";
            this.gridHotels.Size = new System.Drawing.Size(836, 150);
            this.gridHotels.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 471);
            this.Controls.Add(this.gridHotels);
            this.Controls.Add(this.btnLookUpHotels);
            this.Controls.Add(this.lblExtraData);
            this.Controls.Add(this.listHotels);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridHotels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblExtraData;
        private System.Windows.Forms.ListBox listHotels;
        private System.Windows.Forms.Button btnLookUpHotels;
        private System.Windows.Forms.DataGridView gridHotels;
    }
}

