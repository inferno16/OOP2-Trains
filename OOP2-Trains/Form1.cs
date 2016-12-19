using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OOP2_Trains
{
    public partial class Form1 : Form
    {
        private TrainNet _trainNet;
        private TrainContext _trainContext;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateDatabase();
        }

        private void UpdateDatabase()
        {
            _trainContext = new TrainContext();
            List<KindTrain> trains = new List<KindTrain>();

            trains = _trainContext.KindTrains.ToList()
                .Select(t => new KindTrain(t.Id, t.TrainKind,
                    t.ArrivalTime.ToUniversalTime().ToLocalTime(),
                    t.Stops.ToDictionary(c => c.Station, c => c.ArrivalTime),
                    t.FirstStation,
                    t.LastStation,
                    t.DepartureTime.ToUniversalTime().ToLocalTime(),
                    t.Distance))
                .ToList();

            _trainNet = new TrainNet(trains);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetTrainsForm trainForm = new GetTrainsForm(_trainNet, GetStartStations(), GetEndStations());
            trainForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetTrainBeforeDeparture trainForm = new GetTrainBeforeDeparture(_trainNet, GetStartStations(), GetEndStations());
            trainForm.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetTrainsBeforeArrivalForm trainForm = new GetTrainsBeforeArrivalForm(_trainNet, GetStartStations(), GetEndStations());
            trainForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetFastestTrainForm trainForm = new GetFastestTrainForm(_trainNet, GetStartStations(), GetEndStations());
            trainForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GetAverageSpeedForm trainForm = new GetAverageSpeedForm(_trainNet);
            trainForm.ShowDialog();
        }

        List<string> GetStartStations()
        {
            return _trainContext.KindTrains.Select(c => c.FirstStation).Distinct().ToList();
        }

        List<string> GetEndStations()
        {
            return _trainContext.KindTrains.Select(c => c.LastStation).Distinct().ToList();
        }

        private void refeshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDatabase();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About form = new About();
            form.ShowDialog();
        }

        private void exitToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
