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
    public partial class DisplayData : Form
    {
        private List<KindTrain> list;

        public DisplayData()
        {
            InitializeComponent();
        }

        public DisplayData(List<KindTrain> list) : this()
        {
            this.list = list;
        }

        private void DisplayData_Load(object sender, EventArgs e)
        {
            try
            {
                InitTables();
            }
            catch (Exception ex)
            {
                TrainsException.ShowDefault(this, ex);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //Show information (in the second table) about the stops of the train that is selected in the first table
            dataGridView2.DataSource = list[dataGridView1.CurrentRow.Index].Stops.ToList();
        }

        private void InitTables()
        {
            //Table 1 options
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = list;
            dataGridView1.Columns.RemoveAt(0); //"Id"
            dataGridView1.Columns.RemoveAt(dataGridView1.Columns.Count - 1); //"Stops"
            dataGridView1.Columns[0].HeaderText = "Начална гара";
            dataGridView1.Columns[1].HeaderText = "Крайна гара";
            dataGridView1.Columns[2].HeaderText = "Час на тръгване";
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridView1.Columns[3].HeaderText = "Час на пристигане";
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridView1.Columns[4].HeaderText = "Тип на влака";
            dataGridView1.Columns[5].HeaderText = "Дистанция";

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable; //Fixes the center alignment bug
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            //Table 2 options
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Columns[0].HeaderText = "Гара";
            dataGridView2.Columns[1].HeaderText = "Време на пристигане";

            foreach (DataGridViewColumn col in dataGridView2.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable; //Fixes the center alignment bug
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }
    }
}
