using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace perceptron1Couche
{
    public partial class Form1 : Form
    {
        Graphics g;
        simplePerceptron sP;
        string doublePrecision = "0.0000";
        Pen pen1 = new Pen(Color.Blue, 2.0f);
        Pen pen2 = new Pen(Color.Red, 2.0f);
        Pen penLine = new Pen(Color.Black, 1.0f);
        double minX ;
        double maxX ;
        double minY ;
        double maxY ;
        double ratioX, ratioY,offsetX,offsetY;
        public List<List<double>> data;
        public Form1()
        {
            InitializeComponent();
            data = new List<List<double>>();
            data.Add(new List<double>());
            data.Add(new List<double>());

            sP = new simplePerceptron(3);
            pBox.Image = new Bitmap(pBox.Width, pBox.Height);
            g = Graphics.FromImage(pBox.Image);
            Pen pen = new Pen(Color.White, 1);
            g.FillRectangle(pen.Brush, 0, 0, pBox.Width, pBox.Width);
           
        }
        private void drawData()
        {
            g.Clear(Color.White);
            for (int i = 0; i < data[0].Count; i += 2)
            {
                Point p1 = toPixel(data[0][i], data[0][i + 1]);
                Point p2 = toPixel(data[1][i], data[1][i + 1]);
                g.DrawEllipse(pen1, p1.X, p1.Y, 4, 4);
                g.DrawEllipse(pen2, p2.X, p2.Y, 4, 4);
            }
            //calcule de f(min) et f(max) en fonction des poids
            //equation de la droite :
            //w1x+w2y+w3 = 0;
            //f(x) = (-w1x-w3)/w2
            double fmin = (-sP.getWeightEntry(0) * minX - sP.getWeightEntry(2)) / sP.getWeightEntry(1);
            double fmax = (-sP.getWeightEntry(0) * maxX - sP.getWeightEntry(2)) / sP.getWeightEntry(1);
            g.DrawLine(penLine, toPixel(minX, fmin), toPixel(maxX, fmax));
            pBox.Refresh();
        }
        private void learnFromData()
        {
            int nbError = 1;
            int totalErr = 0;
            int totalTest = 0;
            int count = 0;
            int cste = 1;
            double w1 = sP.getWeightEntry(0);
            double w2 = sP.getWeightEntry(1);
            double w3 = sP.getWeightEntry(2);
            while (nbError != 0 && ++count<1000000)
            {
                nbError = 0;
                for (int i = 0; i < data[0].Count; i+=2)
                {
                    totalTest++;
                    double sA = sP.calculOut(data[0][i], data[0][i + 1], cste);
                    double sB = sP.calculOut(data[1][i], data[1][i + 1], cste);
                    if (sA < 1 )
                    {
                        sP.addWeightEntry(0, data[0][i]);
                        sP.addWeightEntry(1, data[0][i+1]);
                        sP.addWeightEntry(2, cste);
                        nbError++;
                    } 
                    if (sB > 0)
                    {
                        sP.addWeightEntry(0, -data[1][i]);
                        sP.addWeightEntry(1, -data[1][i+1]);
                        sP.addWeightEntry(2, -cste);
                        nbError++;
                    }
                }
                drawData();
                totalErr += nbError;
            }
            lRes.Text = "\r\nLearning\r\nNb Error : " + totalErr + "/"+totalTest+"\r\nNb iterations : " + count;
            lRes.Text +=    "\r\nW1 = " + w1.ToString(doublePrecision) + " -> " + sP.getWeightEntry(0).ToString(doublePrecision) +
                            "\r\nW2 = " + w2.ToString(doublePrecision) + " -> " + sP.getWeightEntry(1).ToString(doublePrecision) +
                            "\r\nW3 = " + w3.ToString(doublePrecision) + " -> " + sP.getWeightEntry(2).ToString(doublePrecision);
            double test1 = sP.calculOut(data[0][0], data[0][1], cste);
            double test2 = sP.calculOut(data[1][0], data[1][ 1], cste);
        }
        public Point toPixel(double x, double y)
        {
            Point p = new Point();
            p.X = Convert.ToInt32(Math.Round((x - offsetX) * ratioX));
            p.Y = pBox.Height-1-Convert.ToInt32(Math.Round((y - offsetY) * ratioY));
            return p;
        }
        private void openD_Click(object sender, EventArgs e)
        {


            minX = double.PositiveInfinity;
            maxX = double.NegativeInfinity;
            minY = double.PositiveInfinity;
            maxY = double.NegativeInfinity;

            data[0].Clear();
            data[1].Clear();
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            short d = -1;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog.FileName);
            string[] dataS = { "", "" };

            while ((line = file.ReadLine()) != null)
            {
                string[] res = line.Split(null);
                double x;// = Convert.ToDouble(res[0]);
                double y;// = Convert.ToDouble(res[1]);
                bool isNumeric = double.TryParse(res[0], out x);
                isNumeric = isNumeric | double.TryParse(res[1], out y);
                if (!isNumeric)
                {
                    ++d;
                    dataS[d] = line;
                    if (d > 1)
                        break;
                    continue;
                }
                minX = Math.Min(x, minX);
                minY = Math.Min(y, minY);
                maxX = Math.Max(x, maxX);
                maxY = Math.Max(y, maxY);
                data[d].Add(x);
                data[d].Add(y);
            }
            ratioX =(pBox.Width-1) / (maxX - minX);
            ratioY = (pBox.Height-1) / (maxY - minY);
            offsetX = minX;
            offsetY = minY;
            tbLabel.Text = dataS[0]+"\t\t\t"+dataS[1]+"\r\n";

            for (int i = 0; i < data[0].Count; i+=2)
                tbLabel.Text += data[0][i].ToString(doublePrecision) + "\t" + data[0][i + 1].ToString(doublePrecision) + "\t\t" + data[1][i].ToString(doublePrecision) + "\t" + data[1][i + 1].ToString(doublePrecision) + "\r\n"; 
           
            file.Close();
            learnFromData();
            drawData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            sP = new simplePerceptron(3);
            lRes.Text = "\r\nW1 = "  + sP.getWeightEntry(0).ToString(doublePrecision) +
                            "\r\nW2 = " + sP.getWeightEntry(1).ToString(doublePrecision) +
                            "\r\nW3 = " +  sP.getWeightEntry(2).ToString(doublePrecision);
        }
    }
}
