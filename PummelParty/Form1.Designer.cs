namespace PummelParty
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStart = new System.Windows.Forms.Button();
            this.rollButon = new System.Windows.Forms.Button();
            this.labelWin = new System.Windows.Forms.Label();
            this.labelCountSteps = new System.Windows.Forms.Label();
            this.dicePictureBox = new System.Windows.Forms.PictureBox();
            this.labelName = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.Pause = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dicePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.SystemColors.Control;
            this.buttonStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStart.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.buttonStart.FlatAppearance.BorderSize = 2;
            this.buttonStart.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonStart.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonStart.Location = new System.Drawing.Point(549, 431);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(120, 40);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // rollButon
            // 
            this.rollButon.BackColor = System.Drawing.Color.BlueViolet;
            this.rollButon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.rollButon.FlatAppearance.BorderSize = 2;
            this.rollButon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.rollButon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rollButon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rollButon.ForeColor = System.Drawing.SystemColors.Control;
            this.rollButon.Location = new System.Drawing.Point(526, 583);
            this.rollButon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rollButon.Name = "rollButon";
            this.rollButon.Size = new System.Drawing.Size(134, 65);
            this.rollButon.TabIndex = 1;
            this.rollButon.Text = "Roll the dice";
            this.rollButon.UseVisualStyleBackColor = false;
            this.rollButon.Click += new System.EventHandler(this.rollButon_Click);
            // 
            // labelWin
            // 
            this.labelWin.AutoSize = true;
            this.labelWin.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelWin.Location = new System.Drawing.Point(509, 277);
            this.labelWin.Name = "labelWin";
            this.labelWin.Padding = new System.Windows.Forms.Padding(34, 40, 34, 40);
            this.labelWin.Size = new System.Drawing.Size(247, 126);
            this.labelWin.TabIndex = 2;
            this.labelWin.Text = "game over";
            // 
            // labelCountSteps
            // 
            this.labelCountSteps.AutoSize = true;
            this.labelCountSteps.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCountSteps.Location = new System.Drawing.Point(695, 508);
            this.labelCountSteps.Name = "labelCountSteps";
            this.labelCountSteps.Size = new System.Drawing.Size(109, 46);
            this.labelCountSteps.TabIndex = 3;
            this.labelCountSteps.Text = "label1";
            // 
            // dicePictureBox
            // 
            this.dicePictureBox.Location = new System.Drawing.Point(526, 489);
            this.dicePictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dicePictureBox.Name = "dicePictureBox";
            this.dicePictureBox.Size = new System.Drawing.Size(144, 85);
            this.dicePictureBox.TabIndex = 4;
            this.dicePictureBox.TabStop = false;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelName.Location = new System.Drawing.Point(526, 239);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(151, 25);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Enter your name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameTextBox.Location = new System.Drawing.Point(526, 277);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.PlaceholderText = "Name";
            this.nameTextBox.Size = new System.Drawing.Size(151, 32);
            this.nameTextBox.TabIndex = 6;
            // 
            // Pause
            // 
            this.Pause.Enabled = false;
            this.Pause.Location = new System.Drawing.Point(751, 459);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(97, 46);
            this.Pause.TabIndex = 7;
            this.Pause.Text = "Pause";
            this.Pause.UseVisualStyleBackColor = true;
            this.Pause.Visible = false;
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 849);
            this.Controls.Add(this.Pause);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.dicePictureBox);
            this.Controls.Add(this.labelCountSteps);
            this.Controls.Add(this.labelWin);
            this.Controls.Add(this.rollButon);
            this.Controls.Add(this.buttonStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dicePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonStart;
        private Button rollButon;
        private Label labelWin;
        private Label labelCountSteps;
        private PictureBox dicePictureBox;
        private Label labelName;
        private TextBox nameTextBox;
        private Button Pause;
    }
}