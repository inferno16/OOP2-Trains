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

        public GetTrainBeforeDeparture(TrainNet _trainNet) : this()
        {
            this._trainNet = _trainNet;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                try
                {
                    var date = Convert.ToDateTime(textBox1.Text);
                    var trains = _trainNet.GetTrainsBeforeDeparture(textBox3.Text, textBox2.Text, date);
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