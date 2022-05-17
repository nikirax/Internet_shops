
namespace Internet_shops
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.Question = new System.Windows.Forms.Label();
            this.SellerButton = new System.Windows.Forms.Button();
            this.ShopperButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Question
            // 
            this.Question.AutoSize = true;
            this.Question.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Question.Location = new System.Drawing.Point(118, 9);
            this.Question.Name = "Question";
            this.Question.Size = new System.Drawing.Size(121, 32);
            this.Question.TabIndex = 0;
            this.Question.Text = "Кто вы?";
            // 
            // SellerButton
            // 
            this.SellerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SellerButton.Location = new System.Drawing.Point(12, 53);
            this.SellerButton.Name = "SellerButton";
            this.SellerButton.Size = new System.Drawing.Size(155, 53);
            this.SellerButton.TabIndex = 1;
            this.SellerButton.Text = "Продавец";
            this.SellerButton.UseVisualStyleBackColor = true;
            this.SellerButton.Click += new System.EventHandler(this.Seller_Click);
            // 
            // ShopperButton
            // 
            this.ShopperButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShopperButton.Location = new System.Drawing.Point(173, 53);
            this.ShopperButton.Name = "ShopperButton";
            this.ShopperButton.Size = new System.Drawing.Size(183, 53);
            this.ShopperButton.TabIndex = 2;
            this.ShopperButton.Text = "Покупатель";
            this.ShopperButton.UseVisualStyleBackColor = true;
            this.ShopperButton.Click += new System.EventHandler(this.Shopper_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(368, 118);
            this.Controls.Add(this.ShopperButton);
            this.Controls.Add(this.SellerButton);
            this.Controls.Add(this.Question);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Question;
        private System.Windows.Forms.Button SellerButton;
        private System.Windows.Forms.Button ShopperButton;
    }
}