using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OOP2_Trains
{
    public partial class GetTrainsBeforeArrivalForm : Form
    {
        private TrainNet _trainNet;
        public GetTrainsBeforeArrivalForm()
        {
            InitializeComponent();
        }
        public GetTrainsBeforeArrivalForm(TrainNet trainNet, List<string> sStation = null, List<string> eStation = null)
             :this()
        {
            _trainNet = trainNet;
            //if sStation and eStation are not passed initialize them to empty List<string>
            sStation = sStation ?? new List<string>();
            eStation = eStation ?? new List<string>();

            textBox3.AutoCompleteCustomSource.AddRange(sStation.ToArray());
            textBox2.AutoCompleteCustomSource.AddRange(eStation.ToArray());
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
