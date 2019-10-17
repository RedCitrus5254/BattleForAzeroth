using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleForAzeroth
{
    public partial class SelectCaracters : Form
    {
        private int beginMoney = 100;
        private const int lightInfantryCost = 1;
        private const int heavyInfantryCost = 2;
        private const int archerCost = 3;
        private const int healerCost = 4;
        private const int wizardCost = 5;

        private int firstArmyCost = 0;
        private int secondArmyCost = 0;
        public SelectCaracters()
        {
            InitializeComponent();
        }

        private void UpdateFirstArmyCost()
        {
            decimal firstArmy = lightInfantryFirstTeamNumeric.Value * lightInfantryCost
                + heavyInfantryFirstTeamNumeric.Value * heavyInfantryCost
                + archerFirstTeamNumeric.Value * archerCost
                + healerFirstTeamNumeric.Value * healerCost
                + wizardFirstTeamNumeric.Value * wizardCost;
            firstArmyCost = (int)firstArmy;

            firstArmyCostLabel.Text = $@"{firstArmyCost}/{beginMoney}";
        }
        private void UpdateSecondArmyCost()
        {
            decimal secondArmy = lightInfantrySecondTeamNumeric.Value * lightInfantryCost
                + heavyInfantrySecondTeamNumeric.Value * heavyInfantryCost
                + archerSecondTeamNumeric.Value * archerCost
                + healerSecondTeamNumeric.Value * healerCost
                + wizardSecondTeamNumeric.Value * wizardCost;
            secondArmyCost = (int)secondArmy;

            secondArmyCostLabel.Text = $@"{secondArmyCost}/{beginMoney}";
        }

        private void LightInfantryFirstTeamNumeric_ValueChanged(object sender, EventArgs e)
        {
            UpdateFirstArmyCost();
        }

        private void HeavyInfantryFirstTeamNumeric_ValueChanged(object sender, EventArgs e)
        {
            UpdateFirstArmyCost();
        }

        private void ArcherFirstTeamNumeric_ValueChanged(object sender, EventArgs e)
        {
            UpdateFirstArmyCost();
        }

        private void HealerFirstTeamNumeric_ValueChanged(object sender, EventArgs e)
        {
            UpdateFirstArmyCost();
        }

        private void WizardFirstTeamNumeric_ValueChanged(object sender, EventArgs e)
        {
            UpdateFirstArmyCost();
        }

        private void LightInfantrySecondTeamNumeric_ValueChanged(object sender, EventArgs e)
        {
            UpdateSecondArmyCost();
        }

        private void HeavyInfantrySecondTeamNumeric_ValueChanged(object sender, EventArgs e)
        {
            UpdateSecondArmyCost();
        }

        private void ArcherSecondTeamNumeric_ValueChanged(object sender, EventArgs e)
        {
            UpdateSecondArmyCost();
        }

        private void HealerSecondTeamNumeric_ValueChanged(object sender, EventArgs e)
        {
            UpdateSecondArmyCost();
        }

        private void WizardSecondTeamNumeric_ValueChanged(object sender, EventArgs e)
        {
            UpdateSecondArmyCost();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (firstArmyCost <= 100 && secondArmyCost <= 100)
            {
                MessageBox.Show("Cool");
                //wizardFirstTeamNumeric.Dispose();
                //this.Refresh();
                acceptButton.Hide();

                int[] firstArmy = new int[5];
                firstArmy[0] = (int)lightInfantryFirstTeamNumeric.Value;
                firstArmy[1] = (int)heavyInfantryFirstTeamNumeric.Value;
                firstArmy[2] = (int)archerFirstTeamNumeric.Value;
                firstArmy[3] = (int)healerFirstTeamNumeric.Value;
                firstArmy[4] = (int)wizardFirstTeamNumeric.Value;

                int[] secondArmy = new int[5];
                secondArmy[0] = (int)lightInfantrySecondTeamNumeric.Value;
                secondArmy[1] = (int)heavyInfantrySecondTeamNumeric.Value;
                secondArmy[2] = (int)archerSecondTeamNumeric.Value;
                secondArmy[3] = (int)healerSecondTeamNumeric.Value;
                secondArmy[4] = (int)wizardSecondTeamNumeric.Value;

                BattleField bf = new BattleField(firstArmy, secondArmy);
                //this.Close();
                bf.Show();
            }
            else
            {
                MessageBox.Show("Соберите армию подешевле");
            }
        }
    }
}
