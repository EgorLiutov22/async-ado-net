
namespace WindowsFormsApp3
{
    partial class Form1
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
            this.show = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tbRequest = new System.Windows.Forms.TextBox();
            this.btAsync = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // show
            // 
            this.show.Location = new System.Drawing.Point(591, 44);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(75, 23);
            this.show.TabIndex = 0;
            this.show.Text = "show";
            this.show.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(75, 163);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(477, 247);
            this.dataGridView2.TabIndex = 1;
            // 
            // tbRequest
            // 
            this.tbRequest.Location = new System.Drawing.Point(75, 45);
            this.tbRequest.Name = "tbRequest";
            this.tbRequest.Size = new System.Drawing.Size(477, 22);
            this.tbRequest.TabIndex = 2;
            // 
            // btAsync
            // 
            this.btAsync.Location = new System.Drawing.Point(702, 43);
            this.btAsync.Name = "btAsync";
            this.btAsync.Size = new System.Drawing.Size(75, 23);
            this.btAsync.TabIndex = 3;
            this.btAsync.Text = "Async callback";
            this.btAsync.UseVisualStyleBackColor = true;
            this.btAsync.Click += new System.EventHandler(this.btAsync_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(853, 470);
            this.Controls.Add(this.btAsync);
            this.Controls.Add(this.tbRequest);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.show);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button show;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox tbRequest;
        private System.Windows.Forms.Button btAsync;
    }
}

