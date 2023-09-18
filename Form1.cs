using System;
using System.Drawing;
using System.Windows.Forms;

namespace TimedMathQuiz
{
    public partial class Form1 : Form
    {
        // Create a Random object called randomizer
        // to generate random numbers. 
        Random randomizer = new Random();

        // variables for the addition operation
        int addend1;
        int addend2;

        // variables for the substraction operation
        int minued;
        int subtrahend;

        // variables for the multiplication operation 
        int multiplicand;
        int multiplier;

        // varialbes for the division operation
        int dividend;
        int divisor;

        int timeLeft;

       

     

        public void StartTheQuiz()
        {
         
            // get random numbers for the addition
            // convert to string 
            // set in the text Labels and sum

            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            sum.Value = 0;

          
       
            // get random numbers for the substraction
            // convert to string 
            // set in the text Labels and calculate the difference

            minued = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minued);

            minusLeftLabel.Text = minued.ToString();
            minusRightLabel.Text = subtrahend.ToString();

            difference.Value = 0;

            // get random numbers for the multiplication
            // convert to string 
            // set in the text Labels and get the product

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);

            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();

            product.Value = 0;

            // get random numbers for the division
            // convert to string 
            // set in the text Labels and quotient 
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;


            // Reset styles
            sum.BackColor = Color.White;
            difference.BackColor = Color.White;
            product.BackColor = Color.White;
            quotient.BackColor = Color.White;
            timeLabel.BackColor = Color.White;

            // Start the timer.
            timeLeft = 30;
            timeLabel.Text = "30 seconds";

            timer1.Start();
           
        }

        private bool CheckTheAnswer()
        // Check the answers and return true 
        // if the user  answered correctly

        {
            if ((addend1 + addend2 == sum.Value)
                && (minued - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else return false;
        }


        private void formStyles()
        {
            // Class intended to keep and change the 
            // values of the colors throughout the form depending
            // on the time and answered 
           timeLabel.BackColor = Color.Black;
           timeLabel.ForeColor = Color.White;

            if (timeLeft < 5)
            {
                timeLabel.BackColor = Color.Red; 
            }
            
        }

        public Form1()
        {
            InitializeComponent();
            currentTime.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false; 
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right.");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
                formStyles();
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up";
               
                sum.Value =  addend1 + addend2;
                difference.Value = minued - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
                
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


        private void correct_Answer(object sender, EventArgs e)
        {
            NumericUpDown inputBox = sender as NumericUpDown;
                
            if (inputBox != null)
            {
                inputBox.BackColor = Color.White;
            }
        }

        private void currentTime_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
