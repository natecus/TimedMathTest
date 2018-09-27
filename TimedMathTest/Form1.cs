using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using WMPLib;

namespace TimedMathTest
{
    
    public partial class Form1 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        Random randomizer = new Random();
        int addend1, addend2, sub1, sub2, mult1, mult2, 
            div1, div2, timeLeft, addRight,subRight,
            multRight, divRight;

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckAnswer()) {
                timer1.Stop();
                MessageBox.Show("Congratulations! You did it!");
                startButton.Text = "Let's do it again!";
                startButton.Enabled = true;

            }
            else if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up";
                sum.Value = addRight;
                dif.Value = subRight;
                prod.Value = multRight;
                quotient.Value = divRight;
                System.Media.SystemSounds.Asterisk.Play();
                MessageBox.Show("You didn't finish in time.");
                startButton.Text = "Try Again?";
                startButton.Enabled = true;

            }
            if (timeLeft <= 5)
            {
                timeLabel.BackColor = Color.Red;
            }
        }

        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(0,50);
            addend2 = randomizer.Next(0,50);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;
            addRight = addend1 + addend2;

            sub1 = randomizer.Next(0, 50);
            sub2 = randomizer.Next(sub1, 50);
            subRightLabel.Text = sub1.ToString();
            subLeftLabel.Text = sub2.ToString();
            dif.Value = 0;
            subRight = sub2 - sub1;

            mult1 = randomizer.Next(0, 10);
            mult2 = randomizer.Next(0, 10);
            multLeftLabel.Text = mult1.ToString();
            multRightLabel.Text = mult2.ToString();
            prod.Value = 0;
            multRight = mult1 * mult2;

            div2 = randomizer.Next(1, 10);
            div1 = div2 * randomizer.Next(0, 10);
            divLeftLabel.Text = div1.ToString();
            divRightLabel.Text = div2.ToString();
            quotient.Value = 0;
            divRight = div1 / div2;

            timeLeft = 30;
            timeLabel.Text = timeLeft + " seconds";
            timer1.Start();
        }
        public bool CheckAnswer()
        {
            if(addRight == sum.Value&& subRight == dif.Value &&
               multRight == prod.Value && divRight == quotient.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            player.URL = "music.mp3";
            player.controls.play();
            StartTheQuiz();
            startButton.Enabled = false;
        }
    }
}
