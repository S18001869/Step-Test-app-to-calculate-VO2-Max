using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Reflection;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;

namespace StepTest
{
    public partial class Form1 : Form

    {
        SQLiteConnection cn = new SQLiteConnection("Data Source=C:/Users/danie/OneDrive/Documents/Year 2/Applied Programming/Main Program/StepTest.db");

        public User CurrentUser = new User();

        public Form1()
        {
            InitializeComponent();
        }

        // When form loads, do this
        private void Form1_Load(object sender, EventArgs e)
        {
            {
                chart1.Series[0].Points.Clear();
                chart1.Series["Max"].Points.AddXY(10, 210);
                chart1.Series["Max"].Points.AddXY(76, 210);
                chart1.Series["Max"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart1.Series["Max"].BorderWidth = 3;
                chart1.Series["Max"].Color = System.Drawing.Color.Red;
            }

        }
        
        private void InitialsTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(InitialsTextBox.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters"); 
                // Check text in initials textbox is in the correct format
            }
        }

        // When user chooses a gender from the drop down menu, set the gender option to their choice
        private void GenderChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenderChoice.Items.Add("Male");
            GenderChoice.Items.Add("Female");
            {
                string GenderOption;
                if (GenderChoice.SelectedText == "Male")
                    GenderOption = "Male";

                else

                    GenderOption = "Female";
            }
            
        }

        // When the age has been set by the user, then calculate the MaxHR of the user and fill the MaxHR textbox
        private void AgeTextbox_TextChanged_1(object sender, EventArgs e)
        {
            int MaxHRCalc = 220;
            int MaxHRtotalValue = MaxHRCalc - int.Parse(AgeTextbox.Text); //throws an error here

            MaxHRtb.Text = MaxHRtotalValue.ToString();
        }

        // Populate the Step Height textbox with whatever option the user chooses from the drop menu
        private void StepHeighttb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string height = comboBox1.Text;
            switch (height)
            {
                case "15cm":
                    StepHeighttb.Text = "15";
                    break;

                case "20cm":
                    StepHeighttb.Text = "20";
                    break;

                case "25cm":
                    StepHeighttb.Text = "25";
                    break;

                case "30cm":
                    StepHeighttb.Text = "30";
                    break;

                default:
                    MessageBox.Show("Not found.");
                    break;
            }

            string StepHeight = StepHeighttb.Text;


        }

        // When the "Apply" button is clicked, the users Initials, Age and Gender are saved in the UserDetails database on SQL server
        private void Applybtn_Click(object sender, EventArgs e)
        {
            string UserInitials;
            UserInitials = InitialsTextBox.Text;
            // User Initials variable has been set.

            int AgeNumber;
            AgeNumber = int.Parse(AgeTextbox.Text);
            // The Age variable has been set.

            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\LocalDBStepTest;Initial Catalog=UserDetails;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into UserDetails(initials, age, gender) values ('" + InitialsTextBox.Text + "','" + AgeTextbox.Text + "','" + GenderChoice.Text + "')", con);
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("error");
            }
            con.Close();

        }
        
        private void MaxHRCalc1(Object sender, EventArgs e)
        {
            int MaxHRCalc = 220;
            int MaxHR = MaxHRCalc - int.Parse(Variables.AgeNumber);
            MaxHRtb.Text = MaxHR.ToString();

            // Calculates the Maximum HR of the client based on the age entered.
        }


        private void HR80(Object sender, EventArgs e)
        {
            double HR80Calc = 0.8;

            int HR80 = int.Parse(Variables.MaxHR) * Convert.ToInt32(HR80Calc);

            HR80tb.Text = Variables.HR80;

            // Calculates 80% of the user's Maximum Heart Rate and stores it as a variable.
        }

        private void HR50(Object sender, EventArgs e)
        {
            double HR50Calc = 0.5;

            int HR50 = int.Parse(Variables.MaxHR) * Convert.ToInt32(HR50Calc);

            HR50tb.Text = Variables.HR50;

            // Calculates 50% of the user's Maximum Heart Rate and stores it as a variable.
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\LocalDBStepTest;Initial Catalog=UserDetails;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into UserPreviousResults(initials, Date_of_Test, Chosen_Step_Height, Max_HR, Eighty_Percent_of_Max_HR, Fifty_Percent_of_Max_HR, HR_stage_1_reading, HR_stage_2_reading, HR_stage_3_reading, HR_stage_4_reading, HR_stage_5_reading, Aerobic_Capacity, Fitness_Rating) values ('" + InitialsTextBox.Text + "','" + DoTtb.Text + "','" + StepHeighttb.Text + "','" + MaxHRtb.Text + "','" + HR80tb.Text + "','" + HR50tb.Text + "','" + HRreading1.Text + "','" + HRreading2.Text + "','" + HRreading3.Text + ",'" + HRreading4.Text + ",'" + HRreading5.Text + ",'" + AerobicCapacitytb.Text + ",'" + FitnessRatingtb.Text + "')", con);
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("error");
            }
            con.Close();
        } // Saves the current test results to the 'UserPreviousResults' db

        public void NextUserButton_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);
        }

        private void ViewDatabase_Click(object sender, EventArgs e)
        {
            
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        public int MaxHRCalculation(int Total)
        {
            int MaxHRCalc = 220;
            int MaxHRtotalValue;
            int AgeNum = int.Parse(AgeTextbox.Text);
            MaxHRtotalValue = MaxHRCalc - AgeNum; //throws an error here

            return MaxHRtotalValue;
        }

        private void MaxHRtb_TextChanged(object sender, EventArgs e)
        {
            double MaxHR80Calc = 0.8;
            double MaxHR80totalValue;
            MaxHR80totalValue = int.Parse(MaxHRtb.Text) * MaxHR80Calc; //throws an error here

            HR80tb.Text = MaxHR80totalValue.ToString();
        }

        private void HR80tb_TextChanged(object sender, EventArgs e)
        {
            double MaxHR50Calc = 0.5;
            double MaxHR50totalValue;
            MaxHR50totalValue = int.Parse(MaxHRtb.Text) * MaxHR50Calc; //throws an error here

            HR50tb.Text = MaxHR50totalValue.ToString();
        }

        private void HR50tb_TextChanged(object sender, EventArgs e)
        {
            DoTtb.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        

        public void GetResultButton_Click(object sender, EventArgs e)
        {
           

            int HR1 = int.Parse(HRreading1.Text);
            int HR2 = int.Parse(HRreading2.Text);
            int HR3 = int.Parse(HRreading3.Text);
            int HR4 = int.Parse(HRreading4.Text);
            int HR5 = int.Parse(HRreading5.Text);
            // Convert the HR readings from string into int variables, ready to be added to the array

            double[] ACarray = { HR1, HR2, HR3, HR4, HR5 };
            // Created an array to store the 5 HR readings which will be used for the plot

            double MaxHR80totalValue;
            MaxHR80totalValue = (int.Parse(MaxHRtb.Text));

            double MaxHRTotalValue = (int.Parse(MaxHRtb.Text));

            // ------------------------------------------------------------------------

            // Line of Best Fit - Least Squares Regression
            // Y = B(0) + B(1)x
            // B(0) is the y-intercept, B(1) is the slope

            // Find values for B(o) and B(1)
            // Part 1 get value for b1

            // For each point, multiply each x and the y value.
            double xypoint1 = 11 * HR1;
            double xypoint2 = 14 * HR2;
            double xypoint3 = 18 * HR3;
            double xypoint4 = 21 * HR4;
            double xypoint5 = 25 * HR5;

            // Then add them all together.
            double b1calc1 = xypoint1 + xypoint2 + xypoint3 + xypoint4 + xypoint5;
            // Correct up to here

            // Add up all the X values
            double xtotal = 11 + 14 + 18 + 21 + 25;

            // Add up all the Y values
            double ytotal = HR1 + HR2 + HR3 + HR4 + HR5;
            // Times sum of X-values and sum of Y-values, then divide by n
            double b1calc2 = (xtotal * ytotal) / 5;

            // Conduct first part of b1 calculation
            double b1Part1 = b1calc1 - b1calc2;

            // First part of b1 Calculation done


            // Part 2 of b1 calculation

            // Square all the X values and add them up
            double b1calc3 = (Math.Round(Math.Sqrt(11), 2)) + (Math.Round(Math.Sqrt(14), 2)) + (Math.Round(Math.Sqrt(18), 2)) + (Math.Round(Math.Sqrt(21), 2)) + (Math.Round(Math.Sqrt(25), 2));

            // Sum up the X values, square it, divide by n
            double b1calc4 = (Math.Round(Math.Sqrt(xtotal), 2)) / 5;

            // Subtract xtotal5 from SumXValuesSquared
            double b1Part2 = b1calc3 - b1calc4;

            // final b1 calculation
            double b1 = (b1Part1 / b1Part2) / 5;

            // b1 Slope Complete

            // ------------------------------------------------------

            // Part 4 Get value for b0 y-intercept

            // Sum up the y values
            //ytotal = HR1 + HR2 + HR3 + HR4 + HR5;
            // e.g 96 + 105 + 120 + 137 + 150 = 608;

            // b1 times the sum of the x values divided by n
            //double b1timesXtotal = ytotal - (b1 * xtotal);
            // xtotal is 79 so 608 - (4.7 x 89) = 418 / 5 = 83.6
            //double b1timesXtotal2 = b1timesXtotal / 5;

            // Answer divided by n
            //double b0 = Math.Round(b1timesXtotal2);

            double XcoordinatesMean = (11 + 14 + 18 + 21 + 25) / 5;
            double YcoordinatesMean = (HR1 + HR2 + HR3 + HR4 + HR5) / 5;
            double b0 = YcoordinatesMean - (b1 * XcoordinatesMean);

            // ------------------------------------------------------

            

            // Final Value of Y
            double LinearModel = (b0 + b1);
            // Get value for FinalXValue to be used in FinalYValue calculation
            double FinalXValue = (MaxHRTotalValue - b0) / b1;
            // To Use In Plot
            // = predicted aerobic capacity
            double FinalYvalue = b0 + (b1 * FinalXValue);

            // Add line of best fit to plot
            // Add HR readings to the plot
            chart1.Series["MaxHR"].Points.AddXY(28, MaxHRTotalValue);
            chart1.Series["HR"].Points.AddXY(12, HR1);
            chart1.Series["HR"].Points.AddXY(14, HR2);
            chart1.Series["HR"].Points.AddXY(18, HR3);
            chart1.Series["HR"].Points.AddXY(21, HR4);
            chart1.Series["HR"].Points.AddXY(26, HR5);
            chart1.Series["Line of Best Fit"].Points.AddXY(FinalXValue, FinalYvalue);
            chart1.Series["Line of Best Fit"].Points.AddXY(FinalXValue, FinalYvalue);
            chart1.Series["Line of Best Fit"].Points.AddXY(FinalXValue, FinalYvalue);
            chart1.Series["Line of Best Fit"].Points.AddXY(FinalXValue, FinalYvalue);
            chart1.Series["Line of Best Fit"].Points.AddXY(FinalXValue, FinalYvalue);

            double PredictedAerobicCapacity = ((MaxHRTotalValue - b0) / b1);
            string PredictedAerobicCapacityConverted = PredictedAerobicCapacity.ToString("0.00");
            AerobicCapacitytb.Text = PredictedAerobicCapacityConverted;

            // Fill the Slope, y-intercept and AC test boxes
            Slopetestbox.Text = b1.ToString("0.00");
            yintercepttestbox.Text = b0.ToString("0.00");
            ACtb.Text = AerobicCapacitytb.Text;


            // Unable to work out FitnessRating, choose random for now
            String[] FitnessRating = new string[5] { "Excellent", "Good", "Average", "Below Average", "Poor" };

            string inputRating = FitnessRating.ToList().PickRandom();

            FitnessRatingtb.Text = inputRating;
        }
        
    }                   
}


    