using System;
using System.Linq;
using System.Windows.Forms;

namespace OOP2_Trains
{
    public partial class GetTrainsBeforeArrivalForm : Form
    {
        private TrainNet _trainNet;
        public GetTrainsBeforeArrivalForm(TrainNet trainNet)
        {
            _trainNet = trainNet;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                try
                {
                    var date = Convert.ToDateTime(textBox1.Text);
                    var trains = _trainNet.GetTrainsBeforeArrival(textBox3.Text, textBox2.Text, date);
                    if (trains == null || !trains.Any())
                    {
                        MessageBox.Show("Няма намерени влакове");
                    }
                    else
                    {
                        foreach (var train in trains)
                        {
                            train.Print();
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Невалиден час");
                }

            }
        }
    }
}
