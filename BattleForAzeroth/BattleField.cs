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
    public partial class BattleField : Form, IFanfare
    {
        private CommandHistory history = new CommandHistory();
        private bool isSubscribed = false;
        Fabrica fabrica = new Fabrica();
        public BattleField(int[] firstArmy, int[] secondArmy)
        {
            InitializeComponent();
            //string pathtoBlackLineImage = @"C:\Users\Dmitrii\Pictures\game\blackLine.png";
            blackLineImagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            blackLineImagePictureBox.Image = new Bitmap(@"C:\Users\Dmitrii\Pictures\game\blackLine.png");

            fabrica.CreateTwoArmys(firstArmy, secondArmy); //создаём армии

            CreateUnitLabels(fabrica.GetCountOfFirstTeam(), fabrica.GetCountOfSecondTeam());
            ChangeLabelsLocationOneToOne();
            UpdateLabels(fabrica.firstTeam, fabrica.secondTeam);
            
            this.Refresh();
        }

        public void UpdateUnitsInfo(IUnit unit)
        {
            Console.WriteLine($"ПОМЯНЕМ {unit.Name}");
            Console.Beep();
        }

        private int CreateUnitLabels(int numOfFirstArmyUnits, int numOfSecondArmyUnits)
        {
            if (numOfFirstArmyUnits > firstTeamLabels.Count)
            {
                for (int i = firstTeamLabels.Count; i < numOfFirstArmyUnits; i++)
                {
                    //System.Windows.Forms.Label l = new System.Windows.Forms.Label();

                    firstTeamLabels.Add(new System.Windows.Forms.Label());

                    //firstTeamLabels[i].AutoSize = true;
                    firstTeamLabels[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    //firstTeamLabels[i].Location = new System.Drawing.Point(posX - 150 * (i + 1), 20);
                    firstTeamLabels[i].Size = new System.Drawing.Size(150, 120);
                    firstTeamLabels[i].TabIndex = 0;
                    firstTeamLabels[i].AutoEllipsis = true;
                    //firstTeamLabels[i].Text = $"Heavy Infantry {i} \nsffs \nsdsf \nsdf";
                    firstArmyPanel.Controls.Add(firstTeamLabels[i]);
                }
            }
            else if(numOfFirstArmyUnits < firstTeamLabels.Count)
            {
                int numOfUnits = firstTeamLabels.Count - numOfFirstArmyUnits;
                for(int i = 0; i < numOfUnits; i++)
                {
                    try
                    {
                        Console.WriteLine("Удалён ЛЭЙБЛ 1 команды");
                        firstArmyPanel.Controls.RemoveAt(firstTeamLabels.Count - 1);
                        firstTeamLabels.RemoveAt(firstTeamLabels.Count - 1);
                    }
                    catch
                    {
                        MessageBox.Show("Что-то не так с удалением лэйблов в 1 списке");
                    }
                }
            }

            if (numOfSecondArmyUnits > secondTeamLabels.Count)
            {
                int numOfUnits = numOfSecondArmyUnits - secondTeamLabels.Count;
                for (int i = secondTeamLabels.Count; i < numOfSecondArmyUnits; i++)
                {
                    secondTeamLabels.Add(new System.Windows.Forms.Label());

                    secondTeamLabels[i].AutoSize = true;
                    secondTeamLabels[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    //secondTeamLabels[i].Location = new System.Drawing.Point(posX +offset + 150 * i, 20);
                    secondTeamLabels[i].Size = new System.Drawing.Size(150, 120);
                    secondTeamLabels[i].TabIndex = 0;
                    //secondTeamLabels[i].Text = $"Light Infantry {i} \nsffs \nsdsf \nsdf";
                    secondArmyPanel.Controls.Add(secondTeamLabels[i]);

                }
            }
            else if (numOfSecondArmyUnits < secondTeamLabels.Count)
            {
                int numOfUnits = secondTeamLabels.Count - numOfSecondArmyUnits;
                for (int i = 0; i < numOfUnits; i++)
                {
                    try
                    {
                        Console.WriteLine("Удалён ЛЭЙБЛ 2 команды");
                        secondArmyPanel.Controls.RemoveAt(secondTeamLabels.Count - 1);
                        secondTeamLabels.RemoveAt(secondTeamLabels.Count - 1);
                    }
                    catch
                    {
                        MessageBox.Show("Что-то не так с удалением лэйблов во 2 списке");
                    }
                    
                }
            }
            if (numOfFirstArmyUnits == 0)
            {
                return 1;
            }
            if (numOfSecondArmyUnits == 0)
            {
                return 2;
            }
            return 0;

        }
        public void ChangeLabelsLocationOneToOne()
        {
            int width = firstTeamLabels[0].Width;
            for (int i = 0; i < firstTeamLabels.Count; i++)
            {
                int pos = (firstTeamLabels.Count - 1 - i) * width;
                firstTeamLabels[i].Location = new System.Drawing.Point(pos, 50);
            }
            for(int i = 0; i < secondTeamLabels.Count; i++)
            {
                int pos = i * width;
                secondTeamLabels[i].Location = new System.Drawing.Point(pos, 50);
            }

        }
        public void ChangeLabelsLocationThreeToThree()
        {
            int width = firstTeamLabels[0].Width;
            int height = firstTeamLabels[0].Height;

            for(int i = 0; i < firstTeamLabels.Count; i++)
            {
                int posX = (firstTeamLabels.Count / 3 - i / 3) * width;
                int posY = i % 3 * height;
                firstTeamLabels[i].Location = new System.Drawing.Point(posX, posY);
            }

            for(int i = 0; i < secondTeamLabels.Count; i++)
            {
                int posX = (i / 3) * width;
                int posY = i % 3 * height;
                secondTeamLabels[i].Location = new System.Drawing.Point(posX, posY);
            }
        }
        public void ChangeLabelsLocationAllToAll()
        {
            int width = firstArmyPanel.Width - firstTeamLabels[0].Width;
            int height = firstTeamLabels[0].Height;
            for(int i = 0; i < firstTeamLabels.Count; i++)
            {
                int posY = i * height;
                firstTeamLabels[i].Location = new System.Drawing.Point(width, posY);
            }

            for (int i = 0; i < secondTeamLabels.Count; i++)
            {
                int posY = i * height;
                secondTeamLabels[i].Location = new System.Drawing.Point(0, posY);
            }
        }

        public void UpdateLabels(List<IUnit> firstArmy, List<IUnit> secondArmy)
        {
            for(int i=0; i < firstArmy.Count; i++)
            {
                firstTeamLabels[i].Text = firstArmy[i].ToString();
            }
            for (int i = 0; i < secondArmy.Count; i++)
            {
                secondTeamLabels[i].Text = secondArmy[i].ToString();
            }
        }

        private void StepButton_Click(object sender, EventArgs e)
        {
            stepButton.Enabled = false;

            NextStep nextStep = new NextStep(fabrica);
            nextStep.Execute();
            history.ClearRedoHistory();
            history.Push(nextStep);

            //fabrica.NextStep();

            UpdateLabelsInfoAndLocation();

            stepButton.Enabled = true;
        }

        private void UpdateLabelsInfoAndLocation()
        {
            int result = CreateUnitLabels(fabrica.GetCountOfFirstTeam(), fabrica.GetCountOfSecondTeam());
            if (result == 0)
            {
                if (oneToOneRadioButton.Checked)
                {
                    ChangeLabelsLocationOneToOne();
                }
                else if (ThreeToThreeRadioButton.Checked)
                {
                    ChangeLabelsLocationThreeToThree();
                }
                else if (allToAllRadioButton.Checked)
                {
                    ChangeLabelsLocationAllToAll();
                }
            }
            else if (result == 1)
            {
                MessageBox.Show("HORDE WIN!!!");
            }
            else if (result == 2)
            {
                MessageBox.Show("ALLIANCE WIN");
            }


            UpdateLabels(fabrica.firstTeam, fabrica.secondTeam);


            this.Refresh();
        }

        private void ThreeToThreeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangeLabelsLocationThreeToThree();
            fabrica.SetThreeToThreeStrategy();
        }

        private void OneToOneRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangeLabelsLocationOneToOne();
            fabrica.SetOneToOneStrategy();
        }

        private void AllToAllRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangeLabelsLocationAllToAll();
            fabrica.SetAllToAllStrategy();
        }

        private void SubscribeButton_Click(object sender, EventArgs e)
        {
            if (isSubscribed)
            {
                isSubscribed = false;
                fabrica.UnSubscribe(this);
                subscribeButton.Text = "Фанфары: OFF";
            }
            else
            {
                isSubscribed = true;
                fabrica.Subscribe(this);
                subscribeButton.Text = "Фанфары: ON";
            }
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            history.PopUndo();

            UpdateLabelsInfoAndLocation();
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            history.PopRedo();
            UpdateLabelsInfoAndLocation();
        }
    }
}
