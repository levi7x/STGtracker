using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STGtracker
{
    public partial class Form1 : Form
    {

        

        public Form1()
        {
            InitializeComponent();
        }

        Collection<int> Games = new Collection<int>();
        private double STAKE = 1.50;
        private double PROFIT = 0;
        private int WIN = 0;
        private int LOSES = 0;
        private int GAMES = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "SESSION";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void msg()
        {
            MessageBox.Show("Score has been added", "Success!");
        }

        private void LOSE_Click(object sender, EventArgs e)
        {
            this.Games.Add(1);
            //this.msg();
            GAMES++;
            this.CalculateStats();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Games.Add(0);
            //this.msg();
            GAMES++;
            this.CalculateStats();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Games.Add(2);
            //this.msg();
            GAMES++;
            this.CalculateStats();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private double CalculateProfit()
        {
            double profit = 0;
            this.WIN = 0;
            this.LOSES = 0;
            foreach (var v in this.Games)
            {
                if (v == 1)
                {
                    this.WIN += 1;
                    profit += 5.46;
                }
                if (v == 2)
                {
                    this.WIN += 1;
                    profit += 2.94;
                }
                if (v == 0)
                {
                    this.LOSES += 1;
                }
                profit += -1.5;
            }
            return profit;
        }

        private void CalculateStats()
        {
            this.PROFIT = CalculateProfit();
            double rake = this.Games.Count * this.STAKE / 15;
            double roi = PROFIT / this.Games.Count * this.STAKE;
            double avg_profit = PROFIT / this.Games.Count;
            double bi_total = this.Games.Count * this.STAKE;
            this.textBox1.Text = this.Games.Count.ToString();
            this.textBox2.Text = rake.ToString();
            this.textBox3.Text = roi.ToString() + "%";
            this.textBox4.Text = avg_profit.ToString();
            this.label7.Text = this.PROFIT.ToString() + "$";
            this.label9.Text = this.WIN.ToString();
            this.label10.Text = this.LOSES.ToString();
            this.label11.Text = bi_total.ToString() + "$";

            chart1.Series["PROFIT"].Points.AddXY(GAMES, this.PROFIT);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Games.Clear();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
