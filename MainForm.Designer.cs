
namespace PortKiller
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.PortNameDisplay = new System.Windows.Forms.Label();
            this.PortInput = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.KillBtn = new System.Windows.Forms.Button();
            this.BindDataGridView = new System.Windows.Forms.DataGridView();
            this.indexHead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskIdHead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exeHead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FillSpaceHead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.BindDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PortNameDisplay
            // 
            this.PortNameDisplay.AutoSize = true;
            this.PortNameDisplay.Font = new System.Drawing.Font("微软雅黑", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PortNameDisplay.Location = new System.Drawing.Point(41, 37);
            this.PortNameDisplay.Name = "PortNameDisplay";
            this.PortNameDisplay.Size = new System.Drawing.Size(47, 17);
            this.PortNameDisplay.TabIndex = 0;
            this.PortNameDisplay.Text = "端口号:";
            // 
            // PortInput
            // 
            this.PortInput.Font = new System.Drawing.Font("微软雅黑", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PortInput.Location = new System.Drawing.Point(94, 34);
            this.PortInput.MaxLength = 5;
            this.PortInput.Name = "PortInput";
            this.PortInput.Size = new System.Drawing.Size(100, 24);
            this.PortInput.TabIndex = 1;
            this.PortInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PortInput_KeyPress);
            // 
            // SearchBtn
            // 
            this.SearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SearchBtn.Font = new System.Drawing.Font("微软雅黑", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SearchBtn.Location = new System.Drawing.Point(296, 37);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(75, 23);
            this.SearchBtn.TabIndex = 2;
            this.SearchBtn.Text = "查询";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // KillBtn
            // 
            this.KillBtn.Font = new System.Drawing.Font("微软雅黑", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KillBtn.Location = new System.Drawing.Point(391, 37);
            this.KillBtn.Name = "KillBtn";
            this.KillBtn.Size = new System.Drawing.Size(75, 23);
            this.KillBtn.TabIndex = 3;
            this.KillBtn.Text = "杀死";
            this.KillBtn.UseVisualStyleBackColor = true;
            this.KillBtn.Click += new System.EventHandler(this.KillBtn_Click);
            // 
            // BindDataGridView
            // 
            this.BindDataGridView.AllowUserToAddRows = false;
            this.BindDataGridView.AllowUserToDeleteRows = false;
            this.BindDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BindDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.indexHead,
            this.taskIdHead,
            this.exeHead,
            this.FillSpaceHead});
            this.BindDataGridView.Location = new System.Drawing.Point(44, 101);
            this.BindDataGridView.Name = "BindDataGridView";
            this.BindDataGridView.ReadOnly = true;
            this.BindDataGridView.RowTemplate.Height = 26;
            this.BindDataGridView.Size = new System.Drawing.Size(422, 131);
            this.BindDataGridView.TabIndex = 4;
            // 
            // indexHead
            // 
            this.indexHead.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.indexHead.FillWeight = 49.44012F;
            this.indexHead.HeaderText = "序号";
            this.indexHead.MinimumWidth = 20;
            this.indexHead.Name = "indexHead";
            this.indexHead.ReadOnly = true;
            this.indexHead.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.indexHead.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // taskIdHead
            // 
            this.taskIdHead.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.taskIdHead.FillWeight = 65.02857F;
            this.taskIdHead.HeaderText = "进程PID";
            this.taskIdHead.MinimumWidth = 20;
            this.taskIdHead.Name = "taskIdHead";
            this.taskIdHead.ReadOnly = true;
            this.taskIdHead.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.taskIdHead.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // exeHead
            // 
            this.exeHead.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.exeHead.FillWeight = 194.1608F;
            this.exeHead.HeaderText = "程序";
            this.exeHead.MinimumWidth = 50;
            this.exeHead.Name = "exeHead";
            this.exeHead.ReadOnly = true;
            this.exeHead.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.exeHead.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FillSpaceHead
            // 
            this.FillSpaceHead.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FillSpaceHead.FillWeight = 91.37057F;
            this.FillSpaceHead.HeaderText = "空间占用";
            this.FillSpaceHead.MinimumWidth = 30;
            this.FillSpaceHead.Name = "FillSpaceHead";
            this.FillSpaceHead.ReadOnly = true;
            this.FillSpaceHead.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FillSpaceHead.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(508, 251);
            this.Controls.Add(this.BindDataGridView);
            this.Controls.Add(this.KillBtn);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.PortInput);
            this.Controls.Add(this.PortNameDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PortKiller v1.0 @niushuai233";
            ((System.ComponentModel.ISupportInitialize)(this.BindDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PortNameDisplay;
        private System.Windows.Forms.TextBox PortInput;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Button KillBtn;
        private System.Windows.Forms.DataGridView BindDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn indexHead;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskIdHead;
        private System.Windows.Forms.DataGridViewTextBoxColumn exeHead;
        private System.Windows.Forms.DataGridViewTextBoxColumn FillSpaceHead;
    }
}

