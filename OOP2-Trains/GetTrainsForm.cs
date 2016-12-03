using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2_Trains
{
    public partial class GetTrainsForm : Form
    {
        private TrainNet _trainNet;
        public GetTrainsForm(TrainNet trainNet)
        {
            _trainNet = trainNet;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                var trains = _trainNet.GetTrains(textBox1.Text, textBox2.Text);
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
        }
    }
}
