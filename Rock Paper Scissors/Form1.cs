using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rock_Paper_Scissors
{
    public partial class Form1 : Form
    {
        int rounds = 3;
        int timerPerRound = 6;

        bool gameover = false;

        string[] Player2ChoiceList = { "rock", "paper", "scissor" };

        Random rnd = new Random();

        string Player2Choice;

        string playerChoice;

        int playerwins;
        int AIwins;


        public Form1()
        {
            InitializeComponent();
            countDownTimer.Enabled = true;
            playerChoice = "";
            txtTime.Text = "5";
        }

        private void btnPlayer1_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.rock;
            playerChoice = "rock";
        }

        private void btnPlayer2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(playerChoice))
            {
                MessageBox.Show("Player1 should play first");
            }
            else
            {
                int index = rnd.Next(Player2ChoiceList.Count());
                Player2Choice = Player2ChoiceList[index];
                picPlayer2.Image = (Image)Properties.Resources.ResourceManager.GetObject(Player2ChoiceList[index]);
                CheckChoices();
            }
        }

        private void CheckChoices()
        {
            switch (Player2Choice)
            {
                case "rock":
                    picPlayer2.Image = Properties.Resources.rock;
                    break;
                case "paper":
                    picPlayer2.Image = Properties.Resources.paper;
                    break;
                case "scissor":
                    picPlayer2.Image = Properties.Resources.scissor;
                    break;
            }


            if (rounds > 0)
            {
                checkGame();
            }
            else
            {
                CheckWinner();
            }
        }
        private void CheckWinner()
        {
            if (playerwins > AIwins)
            {
                MessageBox.Show("Player1 Wins This Game");
            }
            else
            {
                MessageBox.Show("Player2 Wins This Game");
            }

            gameover = true;
        }
        private void countDownTimer_Tick(object sender, EventArgs e)
        {
            timerPerRound -= 1;
           
            txtTime.Text = timerPerRound.ToString();
            roundsText.Text = "Rounds: " + rounds;
           
            if (timerPerRound < 1)
            {
                countDownTimer.Enabled = false;
                timerPerRound = 5;
           
           //     CheckChoices();
           
            }
        }


        private void checkGame()
        {
            roundsText.Text = "Rounds: " + rounds;

            // AI and player win rules

            if (playerChoice == "rock" && Player2Choice == "paper")
            {

                AIwins += 1;

                rounds -= 1;

                MessageBox.Show("Player2 Wins, Paper Covers Rocks");

            }
            else if (playerChoice == "scissor" && Player2Choice == "rock")
            {
                AIwins += 1;

                rounds -= 1;

                MessageBox.Show("Player2 Wins, Rock Breaks Scissors");
            }
            else if (playerChoice == "paper" && Player2Choice == "scissor")
            {

                AIwins += 1;

                rounds -= 1;

                MessageBox.Show("Player2 Wins, Scissor cuts paper");

            }
            else if (playerChoice == "rock" && Player2Choice == "scissor")
            {

                playerwins += 1;

                rounds -= 1;

                MessageBox.Show("Player1 Wins, Rock Breaks Scissors");

            }
            else if (playerChoice == "paper" && Player2Choice == "rock")
            {

                playerwins += 1;

                rounds -= 1;

                MessageBox.Show("Player1 Wins, Paper Covers Rocks");

            }
            else if (playerChoice == "scissor" && Player2Choice == "paper")
            {
                playerwins += 1;

                rounds -= 1;

                MessageBox.Show("Player1 Wins, Scissor cuts paper");

            }
            else if (playerChoice == "")
            {
                MessageBox.Show("Make your Choice");
            }
            else
            {
                MessageBox.Show("Draw");

            }


            startNextRound();
        }

        public void startNextRound()
        {
            txtMessage.Text = "Player1: " + playerwins + " - " + "Player2: " + AIwins;
            if (rounds == 0)
                CheckWinner();

            if (gameover)
            {
                return;
            }


            playerChoice = "";

            countDownTimer.Enabled = true;

            picPlayer.Image = Properties.Resources.qq;
            picPlayer2.Image = Properties.Resources.qq;
        }

        private void restartGame(object sender, EventArgs e)
        {
            playerwins = 0;
            AIwins = 0;
            rounds = 3;
            txtMessage.Text = "Player1: " + playerwins + " - " + "Player2: " + AIwins;

            playerChoice = "";
            txtTime.Text = "5";

            countDownTimer.Enabled = true;

            picPlayer.Image = Properties.Resources.qq;
            picPlayer2.Image = Properties.Resources.qq;

            gameover = false;
        }
    }
}
