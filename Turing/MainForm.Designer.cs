namespace Turing
{
    partial class MainForm
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
            this.AddState = new System.Windows.Forms.Button();
            this.RemoveState = new System.Windows.Forms.Button();
            this.AlphabetTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.MakeStepButton = new System.Windows.Forms.Button();
            this.InputTable = new System.Windows.Forms.DataGridView();
            this.StateTable = new System.Windows.Forms.DataGridView();
            this.StopButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.InputTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StateTable)).BeginInit();
            this.SuspendLayout();
            // 
            // AddState
            // 
            this.AddState.Location = new System.Drawing.Point(646, 231);
            this.AddState.Margin = new System.Windows.Forms.Padding(4);
            this.AddState.Name = "AddState";
            this.AddState.Size = new System.Drawing.Size(190, 48);
            this.AddState.TabIndex = 1;
            this.AddState.Text = "Добавить состояние";
            this.AddState.UseVisualStyleBackColor = true;
            this.AddState.Click += new System.EventHandler(this.AddState_Click);
            // 
            // RemoveState
            // 
            this.RemoveState.Location = new System.Drawing.Point(646, 287);
            this.RemoveState.Margin = new System.Windows.Forms.Padding(4);
            this.RemoveState.Name = "RemoveState";
            this.RemoveState.Size = new System.Drawing.Size(190, 48);
            this.RemoveState.TabIndex = 2;
            this.RemoveState.Text = "Убрать состояние";
            this.RemoveState.UseVisualStyleBackColor = true;
            this.RemoveState.Click += new System.EventHandler(this.RemoveState_Click);
            // 
            // AlphabetTextBox
            // 
            this.AlphabetTextBox.Location = new System.Drawing.Point(15, 189);
            this.AlphabetTextBox.Name = "AlphabetTextBox";
            this.AlphabetTextBox.Size = new System.Drawing.Size(617, 33);
            this.AlphabetTextBox.TabIndex = 3;
            this.AlphabetTextBox.TextChanged += new System.EventHandler(this.AlphabetTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Алфавит";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(646, 17);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(190, 48);
            this.StartButton.TabIndex = 6;
            this.StartButton.Text = "Запуск";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_ClickAsync);
            // 
            // MakeStepButton
            // 
            this.MakeStepButton.Location = new System.Drawing.Point(646, 71);
            this.MakeStepButton.Name = "MakeStepButton";
            this.MakeStepButton.Size = new System.Drawing.Size(190, 48);
            this.MakeStepButton.TabIndex = 7;
            this.MakeStepButton.Text = "Сделать шаг";
            this.MakeStepButton.UseVisualStyleBackColor = true;
            this.MakeStepButton.Click += new System.EventHandler(this.MakeStepButton_Click);
            // 
            // InputTable
            // 
            this.InputTable.AllowUserToAddRows = false;
            this.InputTable.AllowUserToDeleteRows = false;
            this.InputTable.AllowUserToResizeColumns = false;
            this.InputTable.AllowUserToResizeRows = false;
            this.InputTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.InputTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.InputTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.InputTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InputTable.Location = new System.Drawing.Point(15, 17);
            this.InputTable.Name = "InputTable";
            this.InputTable.RowHeadersVisible = false;
            this.InputTable.RowHeadersWidth = 30;
            this.InputTable.Size = new System.Drawing.Size(617, 84);
            this.InputTable.TabIndex = 24;
            this.InputTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InputTable_CellClick);
            this.InputTable.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.InputTable_CellValidating);
            // 
            // StateTable
            // 
            this.StateTable.AllowUserToAddRows = false;
            this.StateTable.AllowUserToDeleteRows = false;
            this.StateTable.AllowUserToResizeColumns = false;
            this.StateTable.AllowUserToResizeRows = false;
            this.StateTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.StateTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.StateTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.StateTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StateTable.Location = new System.Drawing.Point(15, 231);
            this.StateTable.Name = "StateTable";
            this.StateTable.RowHeadersVisible = false;
            this.StateTable.Size = new System.Drawing.Size(617, 253);
            this.StateTable.TabIndex = 25;
            this.StateTable.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.StateTable_CellValidating);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(646, 125);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(190, 48);
            this.StopButton.TabIndex = 26;
            this.StopButton.Text = "Остановить";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 499);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StateTable);
            this.Controls.Add(this.InputTable);
            this.Controls.Add(this.MakeStepButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AlphabetTextBox);
            this.Controls.Add(this.RemoveState);
            this.Controls.Add(this.AddState);
            this.Font = new System.Drawing.Font("Noto Sans Cond", 14.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Машина Тьюринга";
            ((System.ComponentModel.ISupportInitialize)(this.InputTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StateTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddState;
        private System.Windows.Forms.Button RemoveState;
        private System.Windows.Forms.TextBox AlphabetTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button MakeStepButton;
        private System.Windows.Forms.DataGridView InputTable;
        private System.Windows.Forms.DataGridView StateTable;
        private System.Windows.Forms.Button StopButton;
    }
}

