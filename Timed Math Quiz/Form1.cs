using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timed_Math_Quiz
{
    public partial class Form1 : Form
    {
        //Create a random object called randomizer to generate random numbers.
        Random randomizer = new Random();

        //Variables to store numbers for the addition problem.
        int addend1;
        int addend2;

        //Variables for subtraction problem 
        int minued;
        int subtrahend;

        //Integer for multiplication problem.
        int multiplicand;
        int multiplier;

        //Integer for division problem.
        int dividend;
        int divisor;


        //Variable to keep track of the time remaining.
        int timeLeft;

        public Form1()
        {
            InitializeComponent();
        }

        public void StartTheQuiz()
        {
            //Filling in Addition problem.
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //Display those random numbers to the form.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            sum.Value = 0;

            //Filling and displaying random numbers for subtraction problem.
            minued = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minued);
            minusLeftLabel.Text = minued.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            //Filling out and displaying random numbers for multiplication problem.
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            //Filling out and displaying numbers for division.
            dividend = randomizer.Next(2, 11);
            divisor = randomizer.Next(2, 11);
            divideLeftLabel.Text = dividend.ToString();
            divideRightLabel.Text = divisor.ToString();
            quotient.Value = 0;


            //Start the timer
            timeLeft = 60;
            timeLabel.Text = "60 seconds";
            timer1.Start();

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckAnswer())
            {
                //If the check answer returns true , then the user got it right 
                //stop the timer and show a message box.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                //Stops the timer, displays a message, and shows the answers.
                timer1.Stop();
                timeLabel.Text = "Times up!";
                MessageBox.Show("You didn't finish in time.", " Sorry! ");
                sum.Value = addend1 + addend2;
                difference.Value = minued - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
            
            
        }
        private bool CheckAnswer()
        {
            if((addend1 + addend2 == sum.Value) 
                && (minued - subtrahend == difference.Value) 
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }

}
