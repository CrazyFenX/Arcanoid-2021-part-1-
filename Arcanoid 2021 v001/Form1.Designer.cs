
namespace Arcanoid_2021_v001
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
            this.pnGame = new Arcanoid_2021_v001.Control.GamePanel();
            this.SuspendLayout();
            // 
            // pnGame
            // 
            this.pnGame.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnGame.Location = new System.Drawing.Point(88, 49);
            this.pnGame.Name = "pnGame";
            this.pnGame.Size = new System.Drawing.Size(773, 418);
            this.pnGame.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Arcanoid_2021_v001.Properties.Resources.Back2;
            this.ClientSize = new System.Drawing.Size(958, 547);
            this.Controls.Add(this.pnGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Control.GamePanel pnGame;
    }
}

