using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool[] step = { true, true, true, true, true, true, true, true };
        string rootPath = @"C:\temp", path1, path2;
        string[] file1, file2, file3;
        private void button1_Click(object sender, EventArgs e)
        {
            if (step[0])
            {
                path1 = ($@"\{textBox1.Text}");
                path2 = ($@"\{textBox2.Text}");
                if (path1 == "\\" || path2 == "\\")
                {
                    richTextBox1.Text = "Ошибка: Одно или оба навазния папок пустое.";
                }
                else if (path1 == path2)
                {
                    richTextBox1.Text = "Ошибка: Вы указали одинаковое название папкам.";
                }
                else
                {
                    richTextBox1.Text = ($"Выполлнен шаг 1: \n\t В папке С:\\temp создайте папки К1 и К2.");
                    Directory.CreateDirectory($@"{rootPath}{path1}");
                    Directory.CreateDirectory($@"{rootPath}{path2}");
                    step[0] = false;
                }
            }
            else
            {
                richTextBox1.Text = ($"Шаг один уже выполнел. Иди дальше путник.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (step[0])
            {
                richTextBox1.Text = ($"Один из предыдущих шагов не выполнен.");
            }
           else if (step[1])
            {
                File.WriteAllText($@"{rootPath}{path1}\t1.txt", "Иванов Иван Иванович, 1965 года рождения, место жительства г. Саратов");
                File.WriteAllText($@"{rootPath}{path1}\t2.txt", "Петров Сергей Федорович, 1966 года рождения, место жительства г.Энгельс");
                richTextBox1.Text = ($"Выполлнен шаг 2: \n\t В папке К1:\n\t\ta) создайте файл t1.txt, в который запишите следующий текст:\n\"Иванов Иван Иванович, 1965 года рождения, место жительства г. Саратов\"\n\n\t\tb) создайте файл t2.txt,  в который запишите следующий текст:\n\"Петров Сергей Федорович, 1966 года рождения, место жительства г.Энгельс\".");
                step[1] = false;
            }
            else
            {
                richTextBox1.Text = ($"Шаг два уже выполнел. Иди дальше путник.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (step[1])
            {
                richTextBox1.Text = ($"Один из предыдущих шагов не выполнен.");
            }
           else if (step[2])
            {
                file1 = File.ReadAllLines($@"{rootPath}{path1}\t1.txt");
                file2 = File.ReadAllLines($@"{rootPath}{path1}\t2.txt");
                for (int i = 0; i < file1.Length; i++)
                {
                    File.WriteAllText($@"{rootPath}{path2}\t3.txt", file1[i]);
                }

                for (int i = 0; i < file2.Length; i++)
                {
                    File.AppendAllText($@"{rootPath}{path2}\t3.txt", $"\n{file2[i]}");
                }

                file3 = File.ReadAllLines($@"{rootPath}{path2}\t3.txt");
                richTextBox1.Text = ($"Выполлнен шаг 3: \n\t В папке К2 создайте файл t3.txt, в который перепишите вначале текст из файла t1.txt, а затем из t2.txt.");
                step[2] = false;
            }
            else
            {
                richTextBox1.Text = ($"Шаг три уже выполнел. Иди дальше путник.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (step[2])
            {
                richTextBox1.Text = ($"Один из предыдущих шагов не выполнен.");
            }
            else if (step[3])
            {
                richTextBox1.Text = ($"Выполлнен шаг 4: \n\t Выведите развернутую информацию о созданных файлах.\n");
                richTextBox1.Text += ($"\n\nТекст первого файла:");
                for (int i = 0; i < file1.Length; i++)
                {
                    richTextBox1.Text += ($"\n\t {file1[i]}");
                }

                richTextBox1.Text += ($"\n\nТекст второго файла: ");
                for (int i = 0; i < file2.Length; i++)
                {
                    richTextBox1.Text += ($"\n\t {file2[i]}");
                }
                richTextBox1.Text += ($"\n\nТекст третьего файла:");
                for (int i = 0; i < file3.Length; i++)
                {
                    richTextBox1.Text += ($"\n\t {file3[i]}");
                }
                step[3] = false;
            }
            else
            {
                richTextBox1.Text = ($"Шаг четыре уже выполнел. Иди дальше путник.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (step[3])
            {
                richTextBox1.Text = ($"Один из предыдущих шагов не выполнен.");
            }
            else if (step[4])
            {
                richTextBox1.Text = ($"Выполлнен шаг 5: \n\t Файл t2.txt перенесите в папку K2.");
                Directory.Move($@"{rootPath}{path1}\t2.txt", $@"{rootPath}{path2}\t2.txt");
                step[4] = false;
            }
            else
            {
                richTextBox1.Text = ($"Шаг пять уже выполнел. Иди дальше путник.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (step[4])
            {
                richTextBox1.Text = ($"Один из предыдущих шагов не выполнен.");
            }
            else if (step[5])
            {
                File.Copy($@"{rootPath}{path1}\t1.txt", $@"{rootPath}{path2}\t1.txt");
                richTextBox1.Text = ($" Выполлнен шаг 6: \n\t Файл  t1.txt скопируйте в папку K2.");
                step[5] = false;
            }
            else
            {
                richTextBox1.Text = ($"Шаг шесть уже выполнел. Иди дальше путник.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (step[5])
            {
                richTextBox1.Text = ($"Один из предыдущих шагов не выполнен.");
            }
            else if (System.IO.Directory.Exists($@"{rootPath}\ALL"))
            {
                MessageBox.Show(
                         "Перед тем как выполнить шаг 7 рекомендуется удалить папку all (кнопка слева есть)",
                         "Предупреждение",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Warning,
                         MessageBoxDefaultButton.Button3);

            }
            else if (step[6])
            {
                Directory.Move($@"{rootPath}{path2}", $@"{rootPath}\ALL");
                Directory.Delete($@"{rootPath}{path1}", true);
                richTextBox1.Text = ($"Выполлнен шаг 7: \n\t Папку K2 переименуйте в ALL, а папку K1 удалите.");
                step[6] = false;
            }
            else
            {
                richTextBox1.Text = ($"Шаг семь уже выполнел. Иди дальше путник.");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (step[6])
            {
                richTextBox1.Text = ($"Один из предыдущих шагов не выполнен.");
            }
            else if (step[7])
            {
                richTextBox1.Text = ($"Выполлнен шаг 8: \n\t Вывести полную информацию о файлах папки All.");
                DirectoryInfo dinf = new DirectoryInfo("c:\\temp\\ALL");
                string[] FileAllDirectory = Directory.GetFiles($@"{rootPath}\ALL");
                foreach (string filename in FileAllDirectory)
                {
                    richTextBox1.Text += ($"\n{filename}");
                }
                step[7] = false;

                MessageBox.Show(
                         "Т.к. это был последний шаг, я обнулю все шаги, можно начать с первого. \n Не забудьте удалить папку all.",
                         "ВНИМАНИЕ",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Warning,
                         MessageBoxDefaultButton.Button3);
                for (int i = 0; i < step.Length; i++)
                {
                    step[i] = true;
                }
            }
        }

        private void butOpen_Click(object sender, EventArgs e)
        {
            Process.Start("c:\\temp\\");
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists($@"{rootPath}\ALL"))
            {
                MessageBox.Show(
                           "Удалено.",
                           "Выполнено",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information,
                           MessageBoxDefaultButton.Button3);
                Directory.Delete($@"{rootPath}\ALL", true);
            }
            else
            {
                MessageBox.Show(
                           "Нечего удалять, все пусто.",
                           "Выполнено",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information,
                           MessageBoxDefaultButton.Button3);
            }
        }
    }
}