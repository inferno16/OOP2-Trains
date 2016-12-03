using System;
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

        public GetFastestTrainForm(TrainNet _trainNet) : this()
        {
            this._trainNet = _trainNet;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                Train train = _trainNet.GetFastestTrain(textBox1.Text, textBox2.Text);
                if (train == null)
                {
                    MessageBox.Show("Няма намерен влак");
                }
                else
                {
                    train.Print();
                }
            }
        }
    }
}
