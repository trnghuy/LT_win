namespace btvn
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
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "1",
            "Nv1",
            "Teo"}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "2",
            "Nv2",
            "Ty"}, -1);
            this.lvBT2 = new System.Windows.Forms.ListView();
            this.clnSTT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnMa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSTT = new System.Windows.Forms.TextBox();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvBT2
            // 
            this.lvBT2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnSTT,
            this.clnMa,
            this.clnTen});
            this.lvBT2.FullRowSelect = true;
            this.lvBT2.GridLines = true;
            this.lvBT2.HideSelection = false;
            listViewItem5.StateImageIndex = 0;
            listViewItem5.UseItemStyleForSubItems = false;
            listViewItem6.StateImageIndex = 0;
            this.lvBT2.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem5,
            listViewItem6});
            this.lvBT2.Location = new System.Drawing.Point(35, 171);
            this.lvBT2.Name = "lvBT2";
            this.lvBT2.Size = new System.Drawing.Size(246, 226);
            this.lvBT2.TabIndex = 0;
            this.lvBT2.UseCompatibleStateImageBehavior = false;
            this.lvBT2.View = System.Windows.Forms.View.Details;
            this.lvBT2.SelectedIndexChanged += new System.EventHandler(this.lvNhanVien_ColumnClick);
            // 
            // clnSTT
            // 
            this.clnSTT.Text = "STT";
            // 
            // clnMa
            // 
            this.clnMa.Text = "Ma";
            // 
            // clnTen
            // 
            this.clnTen.Text = "Ten";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "STT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(385, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ma";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(385, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ten";
            // 
            // txtSTT
            // 
            this.txtSTT.Location = new System.Drawing.Point(450, 159);
            this.txtSTT.Name = "txtSTT";
            this.txtSTT.Size = new System.Drawing.Size(143, 20);
            this.txtSTT.TabIndex = 4;
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(450, 212);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(143, 20);
            this.txtMa.TabIndex = 5;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(450, 262);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(143, 20);
            this.txtTen.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(665, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 38);
            this.button1.TabIndex = 7;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(665, 282);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(102, 39);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(665, 356);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(102, 32);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.txtSTT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvBT2);
            this.Name = "Form1";
            this.Text = "S";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvBT2;
        private System.Windows.Forms.ColumnHeader clnSTT;
        private System.Windows.Forms.ColumnHeader clnMa;
        private System.Windows.Forms.ColumnHeader clnTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSTT;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
    }
}

