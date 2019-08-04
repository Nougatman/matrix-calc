using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Matrix_calc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12);
            this.dataGridView2.DefaultCellStyle.Font = new Font("Arial", 12);
            this.dataGridView3.DefaultCellStyle.Font = new Font("Arial", 12);
            //Макс. размерность матрицы -5х5;
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("4");
            comboBox1.Items.Add("5");
            //По умолчанию кол-во столбцов = 2 (индекс = 1);
            comboBox1.SelectedIndex = 1;

            //Макс. размерность матрицы - 5х5;
            comboBox2.Items.Add("1");
            comboBox2.Items.Add("2");
            comboBox2.Items.Add("3");
            comboBox2.Items.Add("4");
            comboBox2.Items.Add("5");
            //По умолчанию кол-во столбцов = 2 (индекс = 1);
            comboBox2.SelectedIndex = 1;

            //Макс. размерность матрицы - 5х5;
            comboBox3.Items.Add("1");
            comboBox3.Items.Add("2");
            comboBox3.Items.Add("3");
            comboBox3.Items.Add("4");
            comboBox3.Items.Add("5");
            //По умолчанию кол-во столбцов = 2 (индекс = 1);
            comboBox3.SelectedIndex = 1;

            //Макс. размерность матрицы - 5х5;
            comboBox4.Items.Add("1");
            comboBox4.Items.Add("2");
            comboBox4.Items.Add("3");
            comboBox4.Items.Add("4");
            comboBox4.Items.Add("5");
            //По умолчанию кол-во столбцов = 2 (индекс = 1);
            comboBox4.SelectedIndex = 1;

            dataGridView1.RowCount = 2;
            dataGridView2.RowCount = 2;
            dataGridView1.ColumnCount = 2;
            dataGridView2.ColumnCount = 2;
            textBox1.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            textBox1.Size = new Size(50, 25);
        }

        int count_of_columns = 2;
        int count_of_rows = 2;
        double det_1 = 0;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Очистка первой матрицы (заполнение нулями)
        private void matrix_of_zeros1()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    dataGridView1.Rows[i].Cells[j].Value = "0";
        }

        //Очистка второй матрицы(заполнение нулями)
        private void matrix_of_zeros2()
        {
            for (int i = 0; i < dataGridView2.RowCount; i++)
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    dataGridView2.Rows[i].Cells[j].Value = "0";
        }
        //Разметка по строкам;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 1;
            count_of_columns = int.Parse(comboBox1.Text);
            dataGridView1.ColumnCount = count_of_columns;
            matrix_of_zeros1();
        }

        //Разметка по столбцам;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 1;
            count_of_rows = int.Parse(comboBox2.Text);
            dataGridView1.RowCount = count_of_rows;
            matrix_of_zeros1();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.ColumnCount = 1;
            count_of_columns = int.Parse(comboBox3.Text);
            dataGridView2.ColumnCount = count_of_columns;
            matrix_of_zeros2();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.RowCount = 1;
            count_of_rows = int.Parse(comboBox4.Text);
            dataGridView2.RowCount = count_of_rows;
            matrix_of_zeros2();
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }
        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) && !(Char.IsDigit(e.KeyChar) || (e.KeyChar == ',') || (e.KeyChar == '-')))
            {
                string s = dataGridView1.CurrentCell.Value.ToString();
                if (s.Contains("-") == true || s.Contains(",") == true)
                    SystemSounds.Beep.Play();
                    e.Handled = true;
            }
        }


        //Принудительная очистка матрицы 1
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    dataGridView1.Rows[i].Cells[j].Value = "0";
        }

        //Принудительная очистка матрицы 2
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.RowCount; i++)
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    dataGridView2.Rows[i].Cells[j].Value = "0";
        }

        private void операцииС1МатрицейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(545, 750);
            dataGridView2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            X1.Visible = false;
            button2.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            textBox1.Visible = true;
            button3.Visible = true;
            downmixing_matrices();
        }

        private void операцииС2МатрицамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1297, 750);
            dataGridView2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = true;
            X1.Visible = true;
            button2.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            textBox1.Visible = false;
            button3.Visible = false;
            downmixing_matrices();
        }

        private void downmixing_matrices()
        {
            dataGridView1.ColumnCount = 2;
            dataGridView1.RowCount = 2;
            dataGridView2.ColumnCount = 2;
            dataGridView2.RowCount = 2;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = "0";
                    dataGridView2.Rows[i].Cells[j].Value = "0";
                }
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 1;
            comboBox3.SelectedIndex = 1;
            comboBox4.SelectedIndex = 1;
        }
        
        //Умножение матрицы 1 на число
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = true;
            if ((textBox1.Text != string.Empty) && (textBox1.Text != "-"))
            {
                dataGridView3.ColumnCount = dataGridView1.ColumnCount;
                dataGridView3.RowCount = dataGridView1.RowCount;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        dataGridView3.Rows[i].Cells[j].Value = Convert.ToString((Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value)) * Convert.ToDouble(textBox1.Text));
            }
            else
                MessageBox.Show("Поле ввода множителя пустое.", "Ошибка");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Определитель матрицы 1 (вывод значения)
        private void button4_Click(object sender, EventArgs e)
        {

            if (dataGridView1.RowCount == dataGridView1.ColumnCount)
            {
                dataGridView3.RowCount = 1;
                dataGridView3.ColumnCount = 1;
                dataGridView3.Rows[0].Cells[0].Value = Math.Round(det(), 4);
                dataGridView3.Visible = true;
            }
            else
            {
                DialogResult = MessageBox.Show("Размерность матрицы не ZхZ.", "Ошибка");
            }
        }

        //Вычисление определителя матрицы 1
        private double det()
        {
            double temp, b, det = 1;
            int z;
            bool f;

            double[,] M = new double[dataGridView1.RowCount, dataGridView1.RowCount];
            for (int i = 0; i < dataGridView1.RowCount; i++)
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    M[i, j] = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);
                }
            //Методом приведения к треугольному виду;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = i + 1; j < dataGridView1.RowCount; j++)
                {
                    if (M[i, i] == 0)
                    {
                        z = i + 1;
                        f = true;
                        while (z != dataGridView1.RowCount && f == true)
                        {
                            if (M[z, j - 1] == 0) z++;
                            else f = false;
                        }
                        if (z != dataGridView1.RowCount)
                        {
                            for (int k = i; k < dataGridView1.RowCount; k++)
                            {
                                temp = M[i, k];
                                M[i, k] = M[z, k];
                                M[z, k] = temp;
                            }
                            det = -1 * det;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    b = M[j, i] / M[i, i];
                    for (int k = i; k < dataGridView1.RowCount; k++)
                        M[j, k] -= M[i, k] * b;
                }
                //Перемножаем значения главной диагонали;
                det *= M[i, i];
                det_1 = Math.Round(det, 11);
            }
            return det;
        }

        //Транспонирование матрицы 1 (меняем столбцы и строки местами)
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView3.ColumnCount = dataGridView1.RowCount;
            dataGridView3.RowCount = dataGridView1.ColumnCount;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView3.Rows[j].Cells[i].Value = dataGridView1.Rows[i].Cells[j].Value;

                }
            }
            dataGridView3.Visible = true;
        }

        //Нахождение обратной матрицы для матрицы 1
        private void button6_Click(object sender, EventArgs e)
        {
            int K = 0, F;
            double temp;
            bool check;
            double[,] Mat = new double[dataGridView1.RowCount, dataGridView1.ColumnCount * 2];

            if (dataGridView1.RowCount == dataGridView1.ColumnCount)
            {
                if (det() == 0)
                {
                    DialogResult = MessageBox.Show("Определитель матрицы равен 0. Невозможно найти обратную матрицу.", "Ошибка");
                    return;
                }
                else
                {
                    dataGridView3.RowCount = dataGridView1.RowCount;
                    dataGridView3.ColumnCount = dataGridView1.RowCount;

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView1.ColumnCount * 2 / 2; j++)
                        {
                            Mat[i, j] = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);
                        }
                        Mat[i, dataGridView1.ColumnCount * 2 / 2 + K] = 1;
                        K++;
                    }

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (Mat[i, i] == 0)
                        {
                            F = i + 1;
                            check = true;
                            while (F != dataGridView1.RowCount && check == true)
                            {
                                if (Mat[F, i] == 0) F++;
                                else check = false;
                            }
                            if (F != dataGridView1.RowCount)
                            {
                                for (K = i; K < dataGridView1.ColumnCount * 2; K++)
                                {
                                    temp = Mat[i, K];
                                    Mat[i, K] = Mat[F, K];
                                    Mat[F, K] = temp;
                                }
                            }
                        }
                        temp = Mat[i, i];
                        for (int j = i; j < dataGridView1.ColumnCount * 2; j++)
                        {
                            Mat[i, j] = Mat[i, j] / temp;
                        }
                        for (K = 0; K < dataGridView1.RowCount; K++)
                        {
                            if (K != i)
                            {
                                temp = Mat[K, i];
                                for (int j = i; j < dataGridView1.ColumnCount * 2; j++)
                                {
                                    Mat[K, j] -= temp * Mat[i, j];
                                }
                            }
                        }
                    }

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                        for (int j = 0; j < dataGridView1.ColumnCount * 2 / 2; j++)
                        {
                            dataGridView3.Rows[i].Cells[j].Value = Mat[i, j + dataGridView1.ColumnCount * 2 / 2];
                        }
                }
            }
            else
            {
                DialogResult = MessageBox.Show("Размерность матрицы должна быть равной ZxZ.", "Ошибка");
            }
            dataGridView3.Visible = true;
        }

        //Перемножение матриц 1 и 2
        private void button7_Click(object sender, EventArgs e)
        {
            double p = 0;
            if (dataGridView1.ColumnCount == dataGridView2.RowCount)
            {
                dataGridView3.RowCount = dataGridView1.RowCount;
                dataGridView3.ColumnCount = dataGridView2.ColumnCount;
                for (int i = 0; i < dataGridView3.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView3.ColumnCount; j++)
                    {
                        for (int k = 0; k < dataGridView1.ColumnCount; k++)
                        {
                            p = p + Convert.ToDouble(dataGridView1.Rows[i].Cells[k].Value) * Convert.ToDouble(dataGridView2.Rows[k].Cells[j].Value);

                        }
                        dataGridView3.Rows[i].Cells[j].Value = Convert.ToDouble(p);
                        p = 0;

                    }
                }
                dataGridView3.Visible = true;
            }
            else
            {
                DialogResult q = MessageBox.Show("Количество столбцов 1-ой матрицы не равно количеству строк 2-ой матрицы.", "Ошибка");
            }
        }

        //Сумма матриц 1 и 2
        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = true;
            int i, j;
            if ((comboBox2.Text == comboBox1.Text) && (comboBox3.Text == comboBox4.Text))
            {
                dataGridView3.RowCount = int.Parse(comboBox1.Text);
                dataGridView3.ColumnCount = int.Parse(comboBox4.Text);
                for (i = 0; i < int.Parse(comboBox2.Text); i++)
                {
                    for (j = 0; j < int.Parse(comboBox3.Text); j++)
                    {
                        dataGridView3.Rows[i].Cells[j].Value = Convert.ToString(Convert.ToDouble(dataGridView2.Rows[i].Cells[j].Value) + Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value));
                    }
                }
            }
            else
            {
                DialogResult q = MessageBox.Show("Матрица А и В имеют разную размерность.", "Ошибка");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.Focus();
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) || (ch == (char)Keys.Back) || (ch == '-') || (ch == '.'))
                e.Handled = true;
            if (ch == '.')
            {
                textBox1.Focus();
                if (textBox1.Text.Length < 5)
                {
                    if (textBox1.Text == string.Empty)
                        textBox1.Text = "0,";
                    else
                        if (textBox1.Text.Contains(",") == false)
                        textBox1.Text = textBox1.Text + ",";
                }
            }
            if ((ch == '-') && (textBox1.Text == string.Empty))
            {
                textBox1.Text = "-";
            }
            if ((ch == (char)Keys.Back) && (textBox1.Text.Length != 0))
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double P;
            try
            {
                if (Double.TryParse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out P) == false)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
            catch (NullReferenceException)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
            }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double P;
            try
            {
                if (Double.TryParse(dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out P) == false)
                {
                    dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
            catch (NullReferenceException)
            {
                dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
            }
        }
    }
}
