
namespace WeRnumberOne
{
    partial class WeRnumberOne
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeRnumberOne));
            this.btnTraining = new System.Windows.Forms.Button();
            this.btnResult = new System.Windows.Forms.Button();
            this.txtUserNumAdd = new System.Windows.Forms.TextBox();
            this.btnUserNumAdd = new System.Windows.Forms.Button();
            this.Mario = new System.Windows.Forms.PictureBox();
            this.pbRes = new System.Windows.Forms.PictureBox();
            this.btnEraser = new System.Windows.Forms.Button();
            this.UserNum = new System.Windows.Forms.PictureBox();
            this.lrn_lbl = new System.Windows.Forms.Label();
            this.pb_lnr = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.Mario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNum)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTraining
            // 
            this.btnTraining.FlatAppearance.BorderSize = 0;
            this.btnTraining.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnTraining.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTraining.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnTraining.Location = new System.Drawing.Point(275, 158);
            this.btnTraining.Name = "btnTraining";
            this.btnTraining.Size = new System.Drawing.Size(200, 80);
            this.btnTraining.TabIndex = 6;
            this.btnTraining.UseVisualStyleBackColor = true;
            this.btnTraining.Click += new System.EventHandler(this.btnTraining_Click);
            this.btnTraining.MouseEnter += new System.EventHandler(this.btnTraining_MouseEnter);
            this.btnTraining.MouseLeave += new System.EventHandler(this.btnTraining_MouseLeave);
            // 
            // btnResult
            // 
            this.btnResult.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnResult.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnResult.Location = new System.Drawing.Point(12, 346);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(200, 80);
            this.btnResult.TabIndex = 7;
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            this.btnResult.MouseEnter += new System.EventHandler(this.btnResult_MouseEnter);
            this.btnResult.MouseLeave += new System.EventHandler(this.btnResult_MouseLeave);
            // 
            // txtUserNumAdd
            // 
            this.txtUserNumAdd.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserNumAdd.Location = new System.Drawing.Point(275, 12);
            this.txtUserNumAdd.Name = "txtUserNumAdd";
            this.txtUserNumAdd.Size = new System.Drawing.Size(200, 33);
            this.txtUserNumAdd.TabIndex = 18;
            this.txtUserNumAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUserNumAdd.TextChanged += new System.EventHandler(this.txtUserNumAdd_TextChanged);
            // 
            // btnUserNumAdd
            // 
            this.btnUserNumAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUserNumAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUserNumAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnUserNumAdd.Location = new System.Drawing.Point(275, 59);
            this.btnUserNumAdd.Name = "btnUserNumAdd";
            this.btnUserNumAdd.Size = new System.Drawing.Size(200, 80);
            this.btnUserNumAdd.TabIndex = 19;
            this.btnUserNumAdd.UseVisualStyleBackColor = true;
            this.btnUserNumAdd.Click += new System.EventHandler(this.btnUserNumAdd_Click);
            this.btnUserNumAdd.MouseEnter += new System.EventHandler(this.btnUserNumAdd_MouseEnter);
            this.btnUserNumAdd.MouseLeave += new System.EventHandler(this.btnUserNumAdd_MouseLeave);
            // 
            // Mario
            // 
            this.Mario.BackColor = System.Drawing.Color.Transparent;
            this.Mario.Location = new System.Drawing.Point(218, 283);
            this.Mario.Name = "Mario";
            this.Mario.Size = new System.Drawing.Size(105, 103);
            this.Mario.TabIndex = 24;
            this.Mario.TabStop = false;
            this.Mario.Click += new System.EventHandler(this.Mario_Click);
            // 
            // pbRes
            // 
            this.pbRes.BackColor = System.Drawing.Color.Transparent;
            this.pbRes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbRes.Location = new System.Drawing.Point(518, 12);
            this.pbRes.Name = "pbRes";
            this.pbRes.Size = new System.Drawing.Size(226, 226);
            this.pbRes.TabIndex = 23;
            this.pbRes.TabStop = false;
            // 
            // btnEraser
            // 
            this.btnEraser.BackColor = System.Drawing.Color.Transparent;
            this.btnEraser.BackgroundImage = global::WeRnumberOne.Properties.Resources.eraserMouseOn;
            this.btnEraser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEraser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEraser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEraser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnEraser.Location = new System.Drawing.Point(12, 239);
            this.btnEraser.Name = "btnEraser";
            this.btnEraser.Size = new System.Drawing.Size(200, 80);
            this.btnEraser.TabIndex = 7;
            this.btnEraser.UseVisualStyleBackColor = false;
            this.btnEraser.Click += new System.EventHandler(this.btnNewUserNum_Click);
            this.btnEraser.MouseEnter += new System.EventHandler(this.btnNewUserNum_MouseEnter);
            this.btnEraser.MouseLeave += new System.EventHandler(this.btnNewUserNum_MouseLeave);
            // 
            // UserNum
            // 
            this.UserNum.BackColor = System.Drawing.Color.Snow;
            this.UserNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserNum.Image = ((System.Drawing.Image)(resources.GetObject("UserNum.Image")));
            this.UserNum.Location = new System.Drawing.Point(12, 12);
            this.UserNum.Name = "UserNum";
            this.UserNum.Size = new System.Drawing.Size(200, 200);
            this.UserNum.TabIndex = 3;
            this.UserNum.TabStop = false;
            this.UserNum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserNum_MouseDown);
            this.UserNum.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UserNum_MouseMove);
            this.UserNum.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UserNum_MouseUp);
            // 
            // lrn_lbl
            // 
            this.lrn_lbl.AutoSize = true;
            this.lrn_lbl.BackColor = System.Drawing.Color.Transparent;
            this.lrn_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lrn_lbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lrn_lbl.Location = new System.Drawing.Point(215, 429);
            this.lrn_lbl.Name = "lrn_lbl";
            this.lrn_lbl.Size = new System.Drawing.Size(0, 17);
            this.lrn_lbl.TabIndex = 26;
            // 
            // pb_lnr
            // 
            this.pb_lnr.Location = new System.Drawing.Point(218, 403);
            this.pb_lnr.Name = "pb_lnr";
            this.pb_lnr.Size = new System.Drawing.Size(554, 23);
            this.pb_lnr.TabIndex = 25;
            // 
            // WeRnumberOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 451);
            this.Controls.Add(this.lrn_lbl);
            this.Controls.Add(this.pb_lnr);
            this.Controls.Add(this.Mario);
            this.Controls.Add(this.pbRes);
            this.Controls.Add(this.btnEraser);
            this.Controls.Add(this.btnUserNumAdd);
            this.Controls.Add(this.txtUserNumAdd);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.btnTraining);
            this.Controls.Add(this.UserNum);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WeRnumberOne";
            this.Text = "WeRnumberOne";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WeRnumberOne_FormClosing);
            this.Load += new System.EventHandler(this.WeRnumberOne_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Mario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox UserNum;
        private System.Windows.Forms.Button btnTraining;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.TextBox txtUserNumAdd;
        private System.Windows.Forms.Button btnUserNumAdd;
        private System.Windows.Forms.Button btnEraser;
        private System.Windows.Forms.PictureBox pbRes;
        private System.Windows.Forms.PictureBox Mario;
        private System.Windows.Forms.Label lrn_lbl;
        private System.Windows.Forms.ProgressBar pb_lnr;
    }
}

