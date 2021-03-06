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
    public partial class GetTrainsForm : Form
    {
        private TrainNet _trainNet;
        public GetTrainsForm()
        {
            InitializeComponent();
        }
        public GetTrainsForm(TrainNet trainNet, List<string> sStation = null, List<string> eStation = null)
            :this()
        {
            _trainNet = trainNet;
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
                var trains = _trainNet.GetTrains(textBox1.Text, textBox2.Text);
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
            else
            {
                MessageBox.Show("Моля въведете необходимите данни!");
            }
        }
    }
}
