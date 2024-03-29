﻿using System.Collections.Generic;

namespace BattleForAzeroth
{
    partial class BattleField
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private List<System.Windows.Forms.Label> firstTeamLabels = new List<System.Windows.Forms.Label>();
        private List<System.Windows.Forms.Label> secondTeamLabels = new List<System.Windows.Forms.Label>();

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
            this.blackLineImagePictureBox = new System.Windows.Forms.PictureBox();
            this.firstArmyPanel = new System.Windows.Forms.Panel();
            this.secondArmyPanel = new System.Windows.Forms.Panel();
            this.stepButton = new System.Windows.Forms.Button();
            this.subscribeButton = new System.Windows.Forms.Button();
            this.strategyGroupBox = new System.Windows.Forms.GroupBox();
            this.allToAllRadioButton = new System.Windows.Forms.RadioButton();
            this.ThreeToThreeRadioButton = new System.Windows.Forms.RadioButton();
            this.oneToOneRadioButton = new System.Windows.Forms.RadioButton();
            this.undoButton = new System.Windows.Forms.Button();
            this.redoButton = new System.Windows.Forms.Button();
            this.hordeLabel = new System.Windows.Forms.Label();
            this.allianceLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.blackLineImagePictureBox)).BeginInit();
            this.strategyGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // blackLineImagePictureBox
            // 
            this.blackLineImagePictureBox.Location = new System.Drawing.Point(656, 7);
            this.blackLineImagePictureBox.Name = "blackLineImagePictureBox";
            this.blackLineImagePictureBox.Size = new System.Drawing.Size(21, 505);
            this.blackLineImagePictureBox.TabIndex = 0;
            this.blackLineImagePictureBox.TabStop = false;
            // 
            // firstArmyPanel
            // 
            this.firstArmyPanel.AutoScroll = true;
            this.firstArmyPanel.Location = new System.Drawing.Point(12, 36);
            this.firstArmyPanel.Name = "firstArmyPanel";
            this.firstArmyPanel.Size = new System.Drawing.Size(638, 476);
            this.firstArmyPanel.TabIndex = 2;
            // 
            // secondArmyPanel
            // 
            this.secondArmyPanel.AutoScroll = true;
            this.secondArmyPanel.Location = new System.Drawing.Point(683, 36);
            this.secondArmyPanel.Name = "secondArmyPanel";
            this.secondArmyPanel.Size = new System.Drawing.Size(638, 476);
            this.secondArmyPanel.TabIndex = 3;
            // 
            // stepButton
            // 
            this.stepButton.Location = new System.Drawing.Point(630, 533);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(75, 23);
            this.stepButton.TabIndex = 4;
            this.stepButton.Text = "Ход";
            this.stepButton.UseVisualStyleBackColor = true;
            this.stepButton.Click += new System.EventHandler(this.StepButton_Click);
            // 
            // subscribeButton
            // 
            this.subscribeButton.Location = new System.Drawing.Point(873, 533);
            this.subscribeButton.Name = "subscribeButton";
            this.subscribeButton.Size = new System.Drawing.Size(113, 23);
            this.subscribeButton.TabIndex = 5;
            this.subscribeButton.Text = "Фанфары: OFF";
            this.subscribeButton.UseVisualStyleBackColor = true;
            this.subscribeButton.Click += new System.EventHandler(this.SubscribeButton_Click);
            // 
            // strategyGroupBox
            // 
            this.strategyGroupBox.Controls.Add(this.allToAllRadioButton);
            this.strategyGroupBox.Controls.Add(this.ThreeToThreeRadioButton);
            this.strategyGroupBox.Controls.Add(this.oneToOneRadioButton);
            this.strategyGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.strategyGroupBox.Location = new System.Drawing.Point(268, 533);
            this.strategyGroupBox.Name = "strategyGroupBox";
            this.strategyGroupBox.Size = new System.Drawing.Size(153, 105);
            this.strategyGroupBox.TabIndex = 7;
            this.strategyGroupBox.TabStop = false;
            this.strategyGroupBox.Text = "Стратегия";
            // 
            // allToAllRadioButton
            // 
            this.allToAllRadioButton.AutoSize = true;
            this.allToAllRadioButton.Location = new System.Drawing.Point(6, 77);
            this.allToAllRadioButton.Name = "allToAllRadioButton";
            this.allToAllRadioButton.Size = new System.Drawing.Size(139, 22);
            this.allToAllRadioButton.TabIndex = 2;
            this.allToAllRadioButton.Text = "Все против всех";
            this.allToAllRadioButton.UseVisualStyleBackColor = true;
            this.allToAllRadioButton.CheckedChanged += new System.EventHandler(this.AllToAllRadioButton_CheckedChanged);
            // 
            // ThreeToThreeRadioButton
            // 
            this.ThreeToThreeRadioButton.AutoSize = true;
            this.ThreeToThreeRadioButton.Location = new System.Drawing.Point(6, 51);
            this.ThreeToThreeRadioButton.Name = "ThreeToThreeRadioButton";
            this.ThreeToThreeRadioButton.Size = new System.Drawing.Size(98, 22);
            this.ThreeToThreeRadioButton.TabIndex = 1;
            this.ThreeToThreeRadioButton.Text = "Три на три";
            this.ThreeToThreeRadioButton.UseVisualStyleBackColor = true;
            this.ThreeToThreeRadioButton.CheckedChanged += new System.EventHandler(this.ThreeToThreeRadioButton_CheckedChanged);
            // 
            // oneToOneRadioButton
            // 
            this.oneToOneRadioButton.AutoSize = true;
            this.oneToOneRadioButton.Checked = true;
            this.oneToOneRadioButton.Location = new System.Drawing.Point(6, 23);
            this.oneToOneRadioButton.Name = "oneToOneRadioButton";
            this.oneToOneRadioButton.Size = new System.Drawing.Size(121, 22);
            this.oneToOneRadioButton.TabIndex = 0;
            this.oneToOneRadioButton.TabStop = true;
            this.oneToOneRadioButton.Text = "Один на один";
            this.oneToOneRadioButton.UseVisualStyleBackColor = true;
            this.oneToOneRadioButton.CheckedChanged += new System.EventHandler(this.OneToOneRadioButton_CheckedChanged);
            // 
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(1075, 533);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(75, 23);
            this.undoButton.TabIndex = 8;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.Location = new System.Drawing.Point(1178, 533);
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(75, 23);
            this.redoButton.TabIndex = 9;
            this.redoButton.Text = "Redo";
            this.redoButton.UseVisualStyleBackColor = true;
            this.redoButton.Click += new System.EventHandler(this.RedoButton_Click);
            // 
            // hordeLabel
            // 
            this.hordeLabel.AutoSize = true;
            this.hordeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hordeLabel.Location = new System.Drawing.Point(683, 7);
            this.hordeLabel.Name = "hordeLabel";
            this.hordeLabel.Size = new System.Drawing.Size(92, 26);
            this.hordeLabel.TabIndex = 10;
            this.hordeLabel.Text = "HORDE";
            // 
            // allianceLabel
            // 
            this.allianceLabel.AutoSize = true;
            this.allianceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.allianceLabel.Location = new System.Drawing.Point(531, 7);
            this.allianceLabel.Name = "allianceLabel";
            this.allianceLabel.Size = new System.Drawing.Size(119, 26);
            this.allianceLabel.TabIndex = 11;
            this.allianceLabel.Text = "ALLIANCE";
            // 
            // BattleField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1328, 662);
            this.Controls.Add(this.allianceLabel);
            this.Controls.Add(this.hordeLabel);
            this.Controls.Add(this.redoButton);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.strategyGroupBox);
            this.Controls.Add(this.subscribeButton);
            this.Controls.Add(this.stepButton);
            this.Controls.Add(this.secondArmyPanel);
            this.Controls.Add(this.firstArmyPanel);
            this.Controls.Add(this.blackLineImagePictureBox);
            this.Name = "BattleField";
            this.Text = "BattleField";
            ((System.ComponentModel.ISupportInitialize)(this.blackLineImagePictureBox)).EndInit();
            this.strategyGroupBox.ResumeLayout(false);
            this.strategyGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox blackLineImagePictureBox;
        private System.Windows.Forms.Panel firstArmyPanel;
        private System.Windows.Forms.Panel secondArmyPanel;
        private System.Windows.Forms.Button stepButton;
        private System.Windows.Forms.Button subscribeButton;
        private System.Windows.Forms.GroupBox strategyGroupBox;
        private System.Windows.Forms.RadioButton oneToOneRadioButton;
        private System.Windows.Forms.RadioButton allToAllRadioButton;
        private System.Windows.Forms.RadioButton ThreeToThreeRadioButton;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Button redoButton;
        private System.Windows.Forms.Label hordeLabel;
        private System.Windows.Forms.Label allianceLabel;
    }
}