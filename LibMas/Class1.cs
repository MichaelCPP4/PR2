using System;
using Microsoft.Win32;
using System.Data;
using System.IO;

namespace LibMas_1
{
    public static class ArrayMetod
    {

        /// <summary>
        /// Метод заполняет массив рандомными числами
        /// </summary>
        /// <param name="n"></param>
        /// <param name="firsLimit"></param>
        /// <param name="lastLimit"></param>
        /// <returns></returns>
        public static int[] RandomMas(int n, int firsLimit, int lastLimit)
        {
            int[] array = new int[n];
            Random random = new Random();
            lastLimit++;
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(firsLimit, lastLimit);
            return array;
        }

        /// <summary>
        ///  Метод заполняет массив рандомными числами
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[] RandomMas(int n)
        {
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(1, 101);
            return array;
        }

        /// <summary>
        /// Метод очищает массив
        /// </summary>
        /// <param name="array"></param>
        public static void Clear(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }

        /// <summary>
        /// Метод сохраняет массив в файл .txt
        /// </summary>
        /// <param name="array"></param>
        public static void SaveArr(ref int[] array)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Текстовые файлы(*.txt)|*.txt|Все файлы(*.*)|*.*";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";

            if (save.ShowDialog() == true)
            {
                StreamWriter file = new StreamWriter(save.FileName);

                file.WriteLine(array.Length);

                for (int i = 0; i < array.Length; i++)
                {
                    file.WriteLine(array[i]);
                }

                file.Close();
            }
        }

        /// <summary>
        /// Метод открывает файл .txt и записывает данные в массив
        /// </summary>
        /// <param name="array"></param>
        public static void OpenArr(ref int[] array)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Текстовые файлы(*.txt)|*.txt|Все файлы(*.*)|*.*";
            open.FilterIndex = 2;
            open.Title = "Gjhdfyyst";

            if (open.ShowDialog() == true)
            {
                StreamReader file = new StreamReader(open.FileName);

                int length = Convert.ToInt32(file.ReadLine());

                array = new int[length];

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = Convert.ToInt32(file.ReadLine());
                }

                file.Close();
            }
        }
    }
}