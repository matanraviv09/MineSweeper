namespace shula_Amokshim
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Master = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.background = new System.Windows.Forms.Label();
            this.mainthread = new System.Windows.Forms.Timer(this.components);
            this.ShowBombs = new System.Windows.Forms.Button();
            this.tLabel = new System.Windows.Forms.Label();
            this.Mode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Master
            // 
            this.Master.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Master.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Master.Location = new System.Drawing.Point(13, 15);
            this.Master.Name = "Master";
            this.Master.Size = new System.Drawing.Size(29, 46);
            this.Master.TabIndex = 0;
            this.Master.Text = "0";
            this.Master.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Niagara Solid", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(8, 7);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 56);
            this.button1.TabIndex = 1;
            this.button1.Text = "New Game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // background
            // 
            this.background.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.background.Location = new System.Drawing.Point(0, 0);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(679, 71);
            this.background.TabIndex = 2;
            // 
            // mainthread
            // 
            this.mainthread.Enabled = true;
            this.mainthread.Interval = 1;
            this.mainthread.Tick += new System.EventHandler(this.mainthread_Tick);
            // 
            // ShowBombs
            // 
            this.ShowBombs.Location = new System.Drawing.Point(517, 5);
            this.ShowBombs.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ShowBombs.Name = "ShowBombs";
            this.ShowBombs.Size = new System.Drawing.Size(144, 56);
            this.ShowBombs.TabIndex = 3;
            this.ShowBombs.Text = "Show Bombs";
            this.ShowBombs.UseVisualStyleBackColor = true;
            this.ShowBombs.Visible = false;
            this.ShowBombs.Click += new System.EventHandler(this.ShowBombs_Click);
            // 
            // tLabel
            // 
            this.tLabel.BackColor = System.Drawing.Color.Black;
            this.tLabel.Font = new System.Drawing.Font("Niagara Solid", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tLabel.ForeColor = System.Drawing.Color.Red;
            this.tLabel.Location = new System.Drawing.Point(131, 7);
            this.tLabel.Name = "tLabel";
            this.tLabel.Size = new System.Drawing.Size(100, 56);
            this.tLabel.TabIndex = 4;
            this.tLabel.Text = "0 0 : 0 0";
            this.tLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mode
            // 
            this.Mode.BackColor = System.Drawing.Color.Black;
            this.Mode.Font = new System.Drawing.Font("Niagara Solid", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Mode.Location = new System.Drawing.Point(248, 7);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(33, 56);
            this.Mode.TabIndex = 5;
            this.Mode.Text = "💣";
            this.Mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mode.Click += new System.EventHandler(this.Mode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 34F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 838);
            this.Controls.Add(this.Mode);
            this.Controls.Add(this.tLabel);
            this.Controls.Add(this.ShowBombs);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Master);
            this.Controls.Add(this.background);
            this.Font = new System.Drawing.Font("Niagara Solid", 16F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "Form1";
            this.Text = "SHULAMOKSHIM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Master;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label background;
        private System.Windows.Forms.Timer mainthread;
        private System.Windows.Forms.Button ShowBombs;
        private System.Windows.Forms.Label tLabel;
        private System.Windows.Forms.Label Mode;
    }
}

