﻿using System;
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
    public partial class GetTrainBeforeDeparture : Form
    {
        private TrainNet _trainNet;

        public GetTrainBeforeDeparture()
        {
            InitializeComponent();
        }

        public GetTrainBeforeDeparture(TrainNet _trainNet, List<string> sStation = null, List<string> eStation = null)
            : this()
        {
            this._trainNet = _trainNet;
            //if sStation and eStation are not passed initialize them to empty List<string>
            sStation = sStation ?? new List<string>();
            eStation = eStation ?? new List<string>();

            textBox3.AutoCompleteCustomSource.AddRange(sStation.ToArray());
            textBox2.AutoCompleteCustomSource.AddRange(eStation.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                try
                {
                    DateTime date = dateTimePicker1.Value;
                    var trains = _trainNet.GetTrainsBeforeDeparture(textBox3.Text, textBox2.Text, date);
                    if (trains == null || !trains.Any())
                    {
                        MessageBox.Show("Няма намерени влакове");
                    }
                    else
                    {
                        DisplayData ddf = new DisplayData(trains.ToList());
                        ddf.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    TrainsException.ShowDefault(this, ex);
                }
            }
            else
            {
                MessageBox.Show("Моля въведете необходимите данни!");
            }
        }
    }
}
