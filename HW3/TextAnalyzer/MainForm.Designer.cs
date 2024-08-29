namespace TextAnalyzer
{
    partial class MainForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            buttonsLayoutPanel = new TableLayoutPanel();
            textboxButton = new Button();
            fileButton = new Button();
            inputTextBox = new TextBox();
            analysisTextBox = new TextBox();
            sectionsLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            buttonsLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.375F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.625F));
            tableLayoutPanel1.Controls.Add(buttonsLayoutPanel, 1, 0);
            tableLayoutPanel1.Controls.Add(sectionsLayoutPanel, 1, 1);
            tableLayoutPanel1.Controls.Add(inputTextBox, 0, 0);
            tableLayoutPanel1.Controls.Add(analysisTextBox, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // buttonsLayoutPanel
            // 
            buttonsLayoutPanel.ColumnCount = 1;
            buttonsLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonsLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonsLayoutPanel.Controls.Add(textboxButton, 0, 1);
            buttonsLayoutPanel.Controls.Add(fileButton, 0, 0);
            buttonsLayoutPanel.Dock = DockStyle.Fill;
            buttonsLayoutPanel.Location = new Point(614, 3);
            buttonsLayoutPanel.Name = "buttonsLayoutPanel";
            buttonsLayoutPanel.RowCount = 2;
            buttonsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            buttonsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            buttonsLayoutPanel.Size = new Size(183, 219);
            buttonsLayoutPanel.TabIndex = 4;
            // 
            // textboxButton
            // 
            textboxButton.Location = new Point(3, 112);
            textboxButton.Name = "textboxButton";
            textboxButton.Size = new Size(177, 29);
            textboxButton.TabIndex = 1;
            textboxButton.Text = "in textbox";
            textboxButton.UseVisualStyleBackColor = true;
            // 
            // fileButton
            // 
            fileButton.Dock = DockStyle.Bottom;
            fileButton.Location = new Point(3, 77);
            fileButton.Name = "fileButton";
            fileButton.Size = new Size(177, 29);
            fileButton.TabIndex = 0;
            fileButton.Text = "in file";
            fileButton.UseVisualStyleBackColor = true;
            // 
            // inputTextBox
            // 
            inputTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            inputTextBox.Location = new Point(20, 99);
            inputTextBox.Margin = new Padding(20);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(571, 27);
            inputTextBox.TabIndex = 3;
            inputTextBox.Text = "Enter text";
            // 
            // analysisTextBox
            // 
            analysisTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            analysisTextBox.Location = new Point(20, 324);
            analysisTextBox.Margin = new Padding(20);
            analysisTextBox.Name = "analysisTextBox";
            analysisTextBox.Size = new Size(571, 27);
            analysisTextBox.TabIndex = 1;
            // 
            // sectionsLayoutPanel
            // 
            sectionsLayoutPanel.ColumnCount = 1;
            sectionsLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            sectionsLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            sectionsLayoutPanel.Dock = DockStyle.Fill;
            sectionsLayoutPanel.Location = new Point(614, 228);
            sectionsLayoutPanel.Name = "sectionsLayoutPanel";
            sectionsLayoutPanel.RowCount = 5;
            sectionsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 52.272728F));
            sectionsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 47.727272F));
            sectionsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
            sectionsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            sectionsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            sectionsLayoutPanel.Size = new Size(183, 219);
            sectionsLayoutPanel.TabIndex = 2;
            sectionsLayoutPanel.Paint += sectionsLayoutPanel_Paint;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            buttonsLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel buttonsLayoutPanel;
        private TextBox inputTextBox;
        private TextBox analysisTextBox;
        private TableLayoutPanel sectionsLayoutPanel;
        private Button fileButton;
        private Button textboxButton;
    }
}