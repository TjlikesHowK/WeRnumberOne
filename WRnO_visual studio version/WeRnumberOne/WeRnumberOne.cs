using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using FANNCSharp;
#if FANN_FIXED
using FANNCSharp.Fixed;
using DataType = System.Int32;
#elif FANN_DOUBLE
using FANNCSharp.Double;
using DataType = System.Double;
#else
using FANNCSharp.Float;
using DataType = System.Single;
#endif

namespace WeRnumberOne
{
    public partial class WeRnumberOne : Form
    {
        public WeRnumberOne()
        {
            InitializeComponent();
        }

        NeuralNet net;
        Graphics graphics;

        Bitmap map = new Bitmap(220, 220);
        ArrayPoints arrayPoints = new ArrayPoints(2);
        Pen pen = new Pen(Color.Black, 11f);

        int picSize = 20 * 20, UserNumToAdd, FilesCount;
        string standartPath = AppDomain.CurrentDomain.BaseDirectory;
        float[] input = new float[400];
        bool paint = false;

        //-----------------------------------------------------------------------------------------------------------//     WeRnumberOne_Action

        private void WeRnumberOne_Load(object sender, EventArgs e)
        {
            set_but(btnUserNumAdd, Properties.Resources.btnAdd);
            set_but(btnTraining, Properties.Resources.btnTeach);
            set_but(btnResult, Properties.Resources.btnRes);

            graphics = Graphics.FromImage(map);

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            BackgroundImage = Properties.Resources.workFon;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);

            UserNum.BackColor = Color.White;
            img_red(true);

            Mario.Image = Properties.Resources.mario;
            Mario.SizeMode = PictureBoxSizeMode.StretchImage;
            MarioMove();

            btnEraser.FlatAppearance.BorderSize = 0;
            btnEraser.FlatStyle = FlatStyle.Flat;
            btnEraser.BackColor = Color.Transparent;

            pb_lnr.Minimum = 0;
            pb_lnr.Maximum = 100;
        }

        private void WeRnumberOne_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //-----------------------------------------------------------------------------------------------------------//     UsserNum_Action

        private void UserNum_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
        }           

        private void UserNum_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
            arrayPoints.ResetPoint();
        }             

        private void UserNum_MouseMove(object sender, MouseEventArgs e)
        {
            if (!paint) 
            { 
                return; 
            }

            arrayPoints.SetPoint(e.X, e.Y);

            if (arrayPoints.GetCountPoints() >= 2)
            {
                graphics.DrawLines(pen, arrayPoints.GetPoints());
                UserNum.Image = map;
                arrayPoints.SetPoint(e.X, e.Y);
            }  
        }

        //-----------------------------------------------------------------------------------------------------------//     btnTraining_Action

        private void btnTraining_MouseEnter(object sender, EventArgs e)
        {
            btnTraining.Image = Properties.Resources.btnTeachOn;
        }

        private void btnTraining_MouseLeave(object sender, EventArgs e)
        {
            btnTraining.Image = Properties.Resources.btnTeach;
        }

        private void btnTraining_Click(object sender, EventArgs e)
        {
            Thread PT = new Thread(Training);
            Writing();
            PT.Start();
        }

        //-----------------------------------------------------------------------------------------------------------//     Mario_Action

        private void Mario_Click(object sender, EventArgs e)
        {
            Form startForm = Application.OpenForms[0];
            startForm.Show();
            this.Dispose();
        }

        //-----------------------------------------------------------------------------------------------------------//     btnNewUserNum_Action

        private void btnNewUserNum_Click(object sender, EventArgs e)
        {
            graphics.Clear(UserNum.BackColor);
            UserNum.Image = map;
        }

        private void btnNewUserNum_MouseEnter(object sender, EventArgs e)
        {
            btnEraser.BackgroundImage = Properties.Resources.eraser;
        }

        private void btnNewUserNum_MouseLeave(object sender, EventArgs e)
        {
            btnEraser.BackgroundImage = Properties.Resources.eraserMouseOn;
        }

        //-----------------------------------------------------------------------------------------------------------//     btnUserNumAdd_Action

        private void btnUserNumAdd_Click(object sender, EventArgs e)
        {
            img_red(false);
        }

        private void btnUserNumAdd_MouseEnter(object sender, EventArgs e)
        {
            btnUserNumAdd.Image = Properties.Resources.btnAddOn;
        }

        private void btnUserNumAdd_MouseLeave(object sender, EventArgs e)
        {
            btnUserNumAdd.Image = Properties.Resources.btnAdd;
        }

        //-----------------------------------------------------------------------------------------------------------//     btnResult_Action

        private void btnResult_Click(object sender, EventArgs e)
        {
            using (TrainingData data = new TrainingData())
            {
                using (var low_png = new Bitmap(Shakaling(UserNum.Image.TrimOnBottom())))
                {
                    if (File.Exists("nums_float.net"))
                    {
                        net = new NeuralNet("nums_float.net");

                        img_scaM(low_png, null, false);

                        float[] calc_out = net.Run(input);

                        for (int i = 0; i < calc_out.Length; i++)
                        {
                            if (calc_out[i] == calc_out.Max())
                            {
                                Bitmap res_num = new Bitmap(standartPath + $@"digits\fin_num\{i}.gif");

                                pbRes.SizeMode = PictureBoxSizeMode.StretchImage;
                                pbRes.Image = res_num;
                            }
                        }
                    }
                }
            }
        }

        private void btnResult_MouseEnter(object sender, EventArgs e)
        {
            btnResult.Image = Properties.Resources.btnResOn;
        }

        private void btnResult_MouseLeave(object sender, EventArgs e)
        {
            btnResult.Image = Properties.Resources.btnRes;
        }

        //-----------------------------------------------------------------------------------------------------------//     txtUserNumAdd_Action

        private void txtUserNumAdd_TextChanged(object sender, EventArgs e)
        {
            string s = txtUserNumAdd.Text;

            foreach (char x in s)
            {
                if (!Char.IsDigit(x))
                {
                    txtUserNumAdd.Text = "";

                    MessageBox.Show("Только цифры от 0 до 9", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (s.Length > 1)
            {
                s = s.Substring(1);
                txtUserNumAdd.Text = s;
                txtUserNumAdd.SelectionStart = txtUserNumAdd.Text.Length;
            }
        }

        //-----------------------------------------------------------------------------------------------------------//     Methods

        private void set_but(Button btn, Image img)
        {
            btn.Image = img;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.Transparent;
            btn.BackgroundImage = Properties.Resources.btnFon;
            btn.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void img_red(bool CS)
        {
            pbRes.SizeMode = PictureBoxSizeMode.StretchImage;

            if (CS)
            {
                pbRes.Image = null;
            }
            else if (!txtUserNumAdd.Text.Equals(""))
            {
                using (var low_png = new Bitmap(Shakaling(UserNum.Image.TrimOnBottom())))
                {
                    UserNumToAdd = Convert.ToInt32(txtUserNumAdd.Text);
                    FilesCount = Directory.GetFiles(standartPath + $@"digits\{UserNumToAdd}").Length + 1;

                    low_png.Save(standartPath + $@"digits\{UserNumToAdd}\{UserNumToAdd}_{FilesCount}.png", System.Drawing.Imaging.ImageFormat.Png);

                    MessageBox.Show($@"Новый пример цифры {txtUserNumAdd.Text} был успешно добавлен!", "Добавлено", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtUserNumAdd.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Для добавления необходимо указать цифру от 0 до 9", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            graphics.Clear(UserNum.BackColor);
            UserNum.Image = map;
        }

        private void img_scaM(Bitmap png, StreamWriter output, bool join_read)
        {
            int realistic = 0;

            Color[,] pixels = new Color[png.Width, png.Height];

            for (int i = 0; i < png.Width; ++i)
            {
                for (int j = 0; j < png.Height; ++j)
                {
                    pixels[j, i] = png.GetPixel(j, i);

                    if (join_read)
                    {
                        if (pixels[j, i].ToArgb() == -16777216)
                        {
                            output.Write("1");
                        }
                        else
                        {
                            output.Write("0");
                        }

                        if (!(j == png.Height - 1 && i == png.Width - 1))
                        {
                            output.Write(" ");
                        }
                    }
                    else
                    {
                        if (pixels[j, i].ToArgb() == -16777216)
                        {
                            input[realistic] = 1;
                        }
                        else
                        {
                            input[realistic] = 0;
                        }
                    }

                    realistic++;
                }
            }
        }

        private void Writing()
        {
            FilesCount = 0;

            for (int i = 0; i < 10; i++)
            {
                FilesCount += Directory.GetFiles(standartPath + $@"digits\{i}").Length;
            }

            lrn_lbl.Text = "Идёт обучение, пожалуйста, подождите...";

            using (StreamWriter output = new StreamWriter(standartPath + @"nums.data", false, Encoding.Default))
            {
                output.Write($"{FilesCount} {picSize} 10\r\n");

                for (int k = 0; k < 10; k++)
                {
                    for (int l = 1; l < Directory.GetFiles(standartPath + $@"digits\{k}").Length + 1; l++)
                    {
                        Bitmap png = new Bitmap(standartPath + $@"digits\{k}\{k}_{l}.png");

                        img_scaM(png, output, true);

                        output.Write("\r\n");

                        for (int j = 0; j < 10; j++)
                        {
                            if (j == k)
                            {
                                output.Write("1");
                            }
                            else
                            {
                                output.Write("0");
                            }

                            if (j != 9)
                            {
                                output.Write(" ");
                            }
                        }

                        output.Write("\r\n");
                    }
                }

                output.Close();
            }
        }

        private void Training()
        {
            uint num_input = 400;
            uint num_out = 10;
            uint num_hidden = 401;
            uint num_layer = 3;
            float num_error = 0.01f;
            uint max_epochs = 1000;
            uint epochs_between = 100;

            net = new NeuralNet(NetworkType.LAYER, num_layer, num_input, num_hidden, num_out);

            using (net)
            {
                net.ActivationFunctionHidden = ActivationFunction.SIGMOID_SYMMETRIC;
                net.ActivationFunctionOutput = ActivationFunction.SIGMOID_SYMMETRIC;

                pb_lnr.Invoke(new Action(() => pb_lnr.Value += 40));
                lrn_lbl.Invoke(new Action(() => lrn_lbl.Text = "Идёт обучение, пожалуйста, подождите..."));
                btnTraining.Invoke(new Action(() => btnTraining.Enabled = false));

                net.TrainOnFile("nums.data", max_epochs, epochs_between, num_error);

                pb_lnr.Invoke(new Action(() => pb_lnr.Value += 50));

                net.Save("nums_float.net");

                pb_lnr.Invoke(new Action(() => pb_lnr.Value += 10));
                lrn_lbl.Invoke(new Action(() => lrn_lbl.Text = "Обучение завершено!"));
                btnTraining.Invoke(new Action(() => btnTraining.Enabled = true));
                pb_lnr.Invoke(new Action(() => pb_lnr.Value = 0));
            }
        }

        async private void MarioMove()
        {
            while (Mario.Location.X < 670)
            {
                Mario.Location = new Point(Mario.Location.X + 1, Mario.Location.Y);
                await Task.Delay(5);
                if (Mario.Location.X == 670)
                {
                    Mario.Location = new Point(218, 283);
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------//     Functions

        private Image Shakaling(Image png)
        {
            Bitmap res = new Bitmap(20, 20);
            using (Graphics g = Graphics.FromImage(res))
                g.DrawImage(png, 0, 0, res.Width, res.Height);
            return res;
        }
    }

    //---------------------------------------------------------------------------------------------------------------//     Helper_Classes

    public static class ImageUtilities
    {
        public static Image TrimOnBottom(this Image image, Color? backgroundColor = null, int margin = 0)
        {
            var bitmap = (Bitmap)image;
            int foundContentOnRowTop = -1;
            int foundContentOnColumnTop = -1;
            int foundContentOnRowBottom = -1;
            int foundContentOnColumnBottom = -1;

            var backColor = backgroundColor ?? Color.White;

            for (int y = bitmap.Height - 1; y >= 0; y--)
            {
                for (int x = bitmap.Width - 1; x >= 0; x--)
                {
                    Color color = bitmap.GetPixel(x, y);
                    if (color.R != backColor.R || color.G != backColor.G || color.B != backColor.B)
                    {
                        foundContentOnRowBottom = y;
                        break;
                    }
                }
                if (foundContentOnRowBottom > -1)
                {
                    break;
                }
            }

            for (int x = bitmap.Width - 1; x >= 0; x--)
            {
                for (int y = bitmap.Height - 1; y >= 0; y--)
                {
                    Color color = bitmap.GetPixel(x, y);
                    if (color.R != backColor.R || color.G != backColor.G || color.B != backColor.B)
                    {
                        foundContentOnColumnBottom = x;
                        break;
                    }
                }
                if (foundContentOnColumnBottom > -1)
                {
                    break;
                }
            }

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color color = bitmap.GetPixel(x, y);
                    if (color.R != backColor.R || color.G != backColor.G || color.B != backColor.B)
                    {
                        foundContentOnRowTop = y;


                        break;
                    }
                }


                if (foundContentOnRowTop > -1)
                {
                    break;
                }
            }

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color color = bitmap.GetPixel(x, y);
                    if (color.R != backColor.R || color.G != backColor.G || color.B != backColor.B)
                    {
                        foundContentOnColumnTop = x;
                        break;
                    }
                }
                if (foundContentOnColumnTop > -1)
                {
                    break;
                }
            }


            if (foundContentOnRowTop > -1 && foundContentOnColumnTop > -1 && foundContentOnRowBottom > -1 && foundContentOnColumnBottom > -1)
            {
                int proposedHeightTop = foundContentOnRowTop + margin;
                int proposedWidthTop = foundContentOnColumnTop + margin;
                int proposedHeightBottom = foundContentOnRowBottom + margin;
                int proposedWidthBottom = foundContentOnColumnBottom + margin;

                if (proposedHeightTop < bitmap.Height && proposedWidthTop < bitmap.Width)
                {
                    return CropImage(image, proposedWidthTop, proposedHeightTop, proposedWidthBottom, proposedHeightBottom);
                }
            }

            return image;
        }

        private static Image CropImage(Image image, int widthTop, int heightTop, int widthBottom, int heightBottom)
        {
            Rectangle cropArea = new Rectangle(widthTop, heightTop, widthBottom - widthTop, heightBottom - heightTop);
            Bitmap bitmap = new Bitmap(image);
            return bitmap.Clone(cropArea, bitmap.PixelFormat);
        }
    }

    public class ArrayPoints
    {
        private int index = 0;
        private Point[] points;

        public ArrayPoints(int size)
        {
            if (size <= 0) { size = 2; }
            points = new Point[size];
        }

        public void SetPoint(int x, int y)
        {
            if (index >= points.Length)
            {
                index = 0;
            }
            points[index] = new Point(x, y);
            index++;
        }

        public void ResetPoint()
        {
            index = 0;
        }

        public int GetCountPoints()
        {
            return index;
        }

        public Point[] GetPoints()
        {
            return points;
        }
    }
}