using System;
using System.Windows.Forms;

namespace OOP2_Trains
{
    public partial class GetAverageSpeedForm : Form
    {
        private TrainNet _trainNet;

        public GetAverageSpeedForm()
        {
            InitializeComponent();
        }

        public GetAverageSpeedForm(TrainNet _trainNet) : this()
        {
            this._trainNet = _trainNet;
            var some = Enum.GetValues(typeof(TrainKind));
            comboBox1.DataSource = some;
            //comboBox1.SelectedItem = TrainKind.Express;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            comboBox1.SelectedItem = TrainKind.Express;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrainKind kind = (TrainKind)comboBox1.SelectedItem;
            double speed = _trainNet.GetAverageSpeed(kind);
            if (speed == 0)
            {
                MessageBox.Show("Няма намерени влакове");
            }
            else
            {
                MessageBox.Show(string.Format("Средна скорост на влак тип {0} : {1}", kind, speed.ToString()));
            }
        }
    }
}
