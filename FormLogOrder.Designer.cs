namespace EQ2MapTools
{
    partial class FormLogOrder
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
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            buttonOk = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.AllowDrop = true;
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listView1.Location = new Point(12, 42);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.OwnerDraw = true;
            listView1.Size = new Size(517, 129);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.DrawColumnHeader += listView1_DrawColumnHeader;
            listView1.DrawItem += listView1_DrawItem;
            listView1.ItemDrag += listView1_ItemDrag;
            listView1.DragDrop += listView1_DragDrop;
            listView1.DragEnter += listView1_DragEnter;
            listView1.DragOver += listView1_DragOver;
            listView1.DragLeave += listView1_DragLeave;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "File";
            // 
            // buttonOk
            // 
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonOk.Location = new Point(230, 180);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(81, 23);
            buttonOk.TabIndex = 1;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.Size = new Size(342, 15);
            label1.TabIndex = 2;
            label1.Text = "Drag and drop the files into the order they should be processed.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 24);
            label2.Name = "label2";
            label2.Size = new Size(314, 15);
            label2.TabIndex = 3;
            label2.Text = "The order can affect things like line color and map groups.";
            // 
            // FormLogOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(541, 215);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonOk);
            Controls.Add(listView1);
            Name = "FormLogOrder";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Log File Processing Order";
            Load += FormLogOrder_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private Button buttonOk;
        private Label label1;
        private Label label2;
        private ColumnHeader columnHeader1;
    }
}