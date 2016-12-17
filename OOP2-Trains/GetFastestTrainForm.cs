using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OOP2_Trains
{
    public partial class GetFastestTrainForm : Form
    {
        private TrainNet _trainNet;

        public GetFastestTrainForm()
        {
            InitializeComponent();
        }

        public GetFastestTrainForm(TrainNet _trainNet, List<string> sStation = null, List<string> eStation = null) 
            : this()
        {
            this._trainNet = _trainNet;
            //if sStation and eStation are not passed initialize them to empty List<string>
            sStation = sStation ?? new List<string>();
            eStation = eStation ?? new List<string>();

            textBox1.AutoCompleteCustomSource.AddRange(sStation.ToArray());
            textBox2.AutoCompleteCustomSource.AddRange(eStation.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                KindTrain train = _trainNet.GetFastestTrain(textBox1.Text, textBox2.Text);
                if (train == null)
                {
                    MessageBox.Show("Няма намерен влак");
                }
                else
                {
                    DisplayData ddf = new DisplayData(new List<KindTrain>() {train});
                    ddf.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Моля въведете необходимите данни!");
            }
        }
    }
}
