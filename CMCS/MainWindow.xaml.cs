using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace CMCS
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Claim> Claims { get; set; } = new ObservableCollection<Claim>();

        public MainWindow()
        {
            InitializeComponent();
            ClaimsGrid.ItemsSource = Claims;
        }

        private void SubmitClaim_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string month = MonthInput.Text.Trim();
                int hours = int.Parse(HoursInput.Text.Trim());
                decimal rate = decimal.Parse(RateInput.Text.Trim());

                var claim = new Claim
                {
                    ClaimID = Claims.Count + 1,
                    Month = month,
                    HoursWorked = hours,
                    HourlyRate = rate,
                    Status = "Submitted"
                };

                Claims.Add(claim);

                // Clear inputs
                MonthInput.Text = "";
                HoursInput.Text = "";
                RateInput.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid numeric values for Hours and Rate.");
            }
        }
    }

    public class Claim
    {
        public int ClaimID { get; set; }
        public string Month { get; set; }
        public int HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TotalAmount => HoursWorked * HourlyRate;
        public string Status { get; set; }
    }
}
