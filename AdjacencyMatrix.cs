using System;
using System.IO;
using System.Collections.Generic;

namespace _24DH113630_Lã_Minh_Trí
{
    internal class AdjacencyMatrix
    {
        private int n;
        private int[,] e;

        public int N { get { return n; } set { n = value; } }
        public int[,] E { get { return e; } set { e = value; } }

        public AdjacencyMatrix() { }

        public AdjacencyMatrix(int n)
        {
            this.n = n;
            this.e = new int[n + 1, n + 1];
        }

        public void ReadMaxtrix(string fileIn)
        {
            StreamReader sr = new StreamReader(fileIn);
            this.n = int.Parse(sr.ReadLine());
            this.e = new int[n + 1, n + 1];
            while (sr.EndOfStream == false)
            {
                for (int i = 1; i < this.e.GetLength(0); i++)
                {
                    string line = sr.ReadLine();
                    string[] arr = line.Split(' ');
                    for (int j = 1; j < this.e.GetLength(1); j++)
                    {
                        this.e[i, j] = int.Parse(arr[j - 1]);
                    }
                }
            }
            sr.Close();
        }


        public void PrintMatrix(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut); sw.WriteLine(this.n);
            for (int i = 1; i <= n; i++) { for (int j = 1; j <= n; j++) { Console.Write(e[i, j] + " "); sw.Write(e[i, j] + " "); } Console.WriteLine(); sw.WriteLine(); }
            sw.Close();
        }
        public void Print_Degree_of_Matrix(string f) { }
        public void Print_Degree_of_Directed_Matrix(string f) { }
        public void Convert_From_AdjacencyMatrix_To_AdjacencyList(string fi, string fo) { }
        public void Convert_From_AdjacencyMatrix_To_EdgeList(string fi, string fo) { }

        public void TimBacVaoBacRa(out int[] countBacVao, out int[] countBacRa)
        {
            countBacVao = new int[n + 1];
            countBacRa = new int[n + 1];

            for (int dinh = 1; dinh < e.GetLength(0); dinh++)
            {
                for (int r = 1; r < e.GetLength(0); r++)
                {
                    if (e[r, dinh] == 1)
                        countBacVao[dinh]++;
                }

                for (int c = 1; c < e.GetLength(1); c++)
                {
                    if (e[dinh, c] == 1)
                        countBacRa[dinh]++;
                }
            }
        }

        public void InBonChua(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            List<int> dsDinhBonChua = new List<int>();
            int[] countBacVao;
            int[] countBacRa;

            TimBacVaoBacRa(out countBacVao, out countBacRa);

            for (int dinh = 1; dinh < e.GetLength(0); dinh++)
            {
                if (countBacVao[dinh] > 0 && countBacRa[dinh] == 0)
                    dsDinhBonChua.Add(dinh);
            }

            sw.WriteLine(dsDinhBonChua.Count);
            Console.WriteLine(dsDinhBonChua.Count);

            for (int i = 0; i < dsDinhBonChua.Count; i++)
            {
                Console.Write(dsDinhBonChua[i] + " ");
                sw.Write(dsDinhBonChua[i] + " ");
            }
            Console.WriteLine();
            sw.Close();
        }

        public void In_Bai3_Buoi6(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            ReadMaxtrix(fileIn);

            int[,] dist = new int[n + 1, n + 1];
            int[,] pre = new int[n + 1, n + 1];

            Floyd_Warshall(dist, pre);

            Console.WriteLine(n);
            sw.WriteLine(n);
            for (int i = 1; i < dist.GetLength(0); i++)
            {
                for (int j = 1; j < dist.GetLength(1); j++)
                {
                    Console.Write(dist[i, j] + " ");
                    sw.Write(dist[i, j] + " ");
                }
                Console.WriteLine();
                sw.WriteLine();
            }
            sw.Close();
        }

        public void Floyd_Warshall(int[,] dist, int[,] pre)
        {
            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    if (e[i, j] != 0)
                        dist[i, j] = e[i, j];
                    else
                        dist[i, j] = int.MaxValue;
                    pre[i, j] = i;
                }
                dist[i, i] = 0;
            }


            for (int k = 1; k < n + 1; k++)
            {
                for (int i = 1; i < n + 1; i++)
                {
                    for (int j = 1; j < n + 1; j++)
                    {
                        if (dist[i, j] > dist[i, k] + dist[k, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                            pre[i, j] = pre[k, j];
                        }
                    }
                }
            }
        }

        public void In_Bai5_Buoi6(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
        
            ReadMaxtrix(fileIn);

            int[,] dist = new int[n + 1, n + 1];
            int[,] pre = new int[n + 1, n + 1];

            Floyd_Warshall(dist, pre);

            int minMaxDist = int.MaxValue;
            int bestCity = -1;
         
            for (int i = 1; i <= n; i++)
            {
                int maxDistForCityI = 0;
                for (int j = 1; j <= n; j++)
                {                 
                    if (i != j && dist[i, j] > maxDistForCityI && dist[i, j] != int.MaxValue)
                    {
                        maxDistForCityI = dist[i, j];
                    }
                }
         
                if (maxDistForCityI < minMaxDist)
                {
                    minMaxDist = maxDistForCityI;
                    bestCity = i;
                }
            }

            Console.WriteLine(bestCity);
            Console.WriteLine(minMaxDist);

            sw.WriteLine(bestCity);
            sw.WriteLine(minMaxDist);

            sw.Close();
        }
    }
}