
using System.Windows.Forms;

namespace K_R
{
    partial class Main_Window
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Window));
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_All_Delete = new System.Windows.Forms.Button();
            this.btn_Vertex = new System.Windows.Forms.Button();
            this.btn_Edge = new System.Windows.Forms.Button();
            this.sheet = new System.Windows.Forms.PictureBox();
            this.btn_Adj = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_Grandi = new System.Windows.Forms.Button();
            this.btn_Paint = new System.Windows.Forms.Button();
            this.btn_Cursor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.White;
            this.btn_Delete.BackgroundImage = global::K_R.Properties.Resources.close;
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Delete.Location = new System.Drawing.Point(14, 405);
            this.btn_Delete.Margin = new System.Windows.Forms.Padding(5, 3, 3, 10);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(118, 118);
            this.btn_Delete.TabIndex = 7;
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_All_Delete
            // 
            this.btn_All_Delete.BackColor = System.Drawing.Color.White;
            this.btn_All_Delete.BackgroundImage = global::K_R.Properties.Resources.trash_96;
            this.btn_All_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_All_Delete.Location = new System.Drawing.Point(12, 541);
            this.btn_All_Delete.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.btn_All_Delete.Name = "btn_All_Delete";
            this.btn_All_Delete.Size = new System.Drawing.Size(118, 118);
            this.btn_All_Delete.TabIndex = 6;
            this.btn_All_Delete.UseVisualStyleBackColor = false;
            this.btn_All_Delete.Click += new System.EventHandler(this.btn_All_Delete_Click);
            // 
            // btn_Vertex
            // 
            this.btn_Vertex.BackColor = System.Drawing.Color.White;
            this.btn_Vertex.BackgroundImage = global::K_R.Properties.Resources.Vertex_96x;
            this.btn_Vertex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Vertex.Location = new System.Drawing.Point(14, 143);
            this.btn_Vertex.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btn_Vertex.Name = "btn_Vertex";
            this.btn_Vertex.Size = new System.Drawing.Size(118, 118);
            this.btn_Vertex.TabIndex = 5;
            this.btn_Vertex.UseVisualStyleBackColor = false;
            this.btn_Vertex.Click += new System.EventHandler(this.btn_Vertex_Click);
            // 
            // btn_Edge
            // 
            this.btn_Edge.BackColor = System.Drawing.Color.White;
            this.btn_Edge.BackgroundImage = global::K_R.Properties.Resources.Edge;
            this.btn_Edge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Edge.Location = new System.Drawing.Point(12, 274);
            this.btn_Edge.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btn_Edge.Name = "btn_Edge";
            this.btn_Edge.Size = new System.Drawing.Size(118, 118);
            this.btn_Edge.TabIndex = 1;
            this.btn_Edge.UseVisualStyleBackColor = false;
            this.btn_Edge.Click += new System.EventHandler(this.btn_Edge_Click);
            // 
            // sheet
            // 
            this.sheet.BackColor = System.Drawing.Color.White;
            this.sheet.Location = new System.Drawing.Point(152, 12);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(845, 649);
            this.sheet.TabIndex = 0;
            this.sheet.TabStop = false;
            this.sheet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseClick);
            // 
            // btn_Adj
            // 
            this.btn_Adj.BackColor = System.Drawing.Color.White;
            this.btn_Adj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Adj.Location = new System.Drawing.Point(1003, 12);
            this.btn_Adj.Name = "btn_Adj";
            this.btn_Adj.Size = new System.Drawing.Size(107, 74);
            this.btn_Adj.TabIndex = 8;
            this.btn_Adj.Text = "Матрица смежности";
            this.btn_Adj.UseVisualStyleBackColor = false;
            this.btn_Adj.Click += new System.EventHandler(this.btn_Adj_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Location = new System.Drawing.Point(1003, 119);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(247, 232);
            this.listBox1.TabIndex = 9;
            // 
            // btn_Grandi
            // 
            this.btn_Grandi.BackColor = System.Drawing.Color.White;
            this.btn_Grandi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Grandi.Location = new System.Drawing.Point(1143, 12);
            this.btn_Grandi.Name = "btn_Grandi";
            this.btn_Grandi.Size = new System.Drawing.Size(107, 74);
            this.btn_Grandi.TabIndex = 10;
            this.btn_Grandi.Text = "Функция Гранди";
            this.btn_Grandi.UseVisualStyleBackColor = false;
            this.btn_Grandi.Click += new System.EventHandler(this.btn_Grandi_Click);
            // 
            // btn_Paint
            // 
            this.btn_Paint.BackColor = System.Drawing.Color.White;
            this.btn_Paint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Paint.Location = new System.Drawing.Point(1143, 388);
            this.btn_Paint.Name = "btn_Paint";
            this.btn_Paint.Size = new System.Drawing.Size(107, 74);
            this.btn_Paint.TabIndex = 11;
            this.btn_Paint.Text = "Раскраска графа";
            this.btn_Paint.UseVisualStyleBackColor = false;
            this.btn_Paint.Click += new System.EventHandler(this.btn_Pait_Click);
            // 
            // btn_Cursor
            // 
            this.btn_Cursor.BackColor = System.Drawing.Color.White;
            this.btn_Cursor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Cursor.BackgroundImage")));
            this.btn_Cursor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cursor.Location = new System.Drawing.Point(14, 12);
            this.btn_Cursor.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btn_Cursor.Name = "btn_Cursor";
            this.btn_Cursor.Size = new System.Drawing.Size(118, 118);
            this.btn_Cursor.TabIndex = 12;
            this.btn_Cursor.UseVisualStyleBackColor = false;
            this.btn_Cursor.Click += new System.EventHandler(this.btn_Cursor_Click);
            // 
            // Main_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.btn_Cursor);
            this.Controls.Add(this.btn_Paint);
            this.Controls.Add(this.btn_Grandi);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btn_Adj);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_All_Delete);
            this.Controls.Add(this.btn_Vertex);
            this.Controls.Add(this.btn_Edge);
            this.Controls.Add(this.sheet);
            this.Name = "Main_Window";
            this.Text = "Функция Гранди";
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox sheet;
        private System.Windows.Forms.Button btn_Edge;
        private System.Windows.Forms.Button btn_Vertex;
        private System.Windows.Forms.Button btn_All_Delete;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Adj;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_Grandi;
        private System.Windows.Forms.Button btn_Paint;
        private System.Windows.Forms.Button btn_Cursor;
    }
}

