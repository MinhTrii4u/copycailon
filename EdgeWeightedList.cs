using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24DH113630_Lã_Minh_Trí
// Buổi 2
{
    internal class EdgeWeightedList
    {
        private int soDinh;
        private int soCanh;
        private LinkedList<Tuple<int, int, int>> e;

        public int SoDinh { get { return soDinh; } set { soDinh = value; } }
        public int SoCanh { get { return soCanh; } set { soCanh = value; } }
        public LinkedList<Tuple<int, int, int>> E { get { return e; } set { e = value; } }

        public EdgeWeightedList()
        {
            this.soDinh = 0;
            this.soCanh = 0;
            this.e = new LinkedList<Tuple<int, int, int>>();
        }

        public EdgeWeightedList(int soDinh, int soCanh, LinkedList<Tuple<int, int, int>> e)
        {
            this.soDinh = soDinh;
            this.soCanh = soCanh;
            this.e = e;
        }

        public void Read_EdgeList(string fileIn)
        {
            StreamReader sr = new StreamReader(fileIn);
            string line = sr.ReadLine();
            string[] arr = line.Split(' ');
            soDinh = int.Parse(arr[0]);
            soCanh = int.Parse(arr[1]);

            while (sr.EndOfStream == false)
            {
                line = sr.ReadLine();
                arr = line.Split(' ');
                int dinh1 = int.Parse(arr[0]);
                int dinh2 = int.Parse(arr[1]);
                int trongSo = int.Parse(arr[2]);
                e.AddLast(new Tuple<int, int, int>(dinh1, dinh2, trongSo));
            }
            sr.Close();
        }

        public void Print_EdgeList(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            Console.WriteLine(this.soDinh + " " + this.soCanh);
            sw.WriteLine(this.soDinh + " " + this.soCanh);
            for (int i = 0; i < e.Count; i++)
            {
                Tuple<int, int, int> t = e.ElementAt(i);
                Console.WriteLine($"{t.Item1} {t.Item2} {t.Item3}");
                sw.WriteLine($"{t.Item1} {t.Item2} {t.Item3}");
            }
            sw.Close();
        }

        public double TinhTrungBinhCong_TrongSo()
        {
            double sum = 0.0;
            foreach (Tuple<int, int, int> t in e)
            {
                sum += t.Item3;
            }
            return sum / this.soCanh;
        }

        public int TimTrongSoLonNhat()
        {
            int max = this.e.ElementAt(0).Item3;
            foreach (Tuple<int, int, int> t in e)
            {
                if (t.Item3 > max)
                    max = t.Item3;
            }
            return max;
        }

        public void In_Do_Dai_Trung_Binh_Cua_Canh(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            Console.WriteLine($"{TinhTrungBinhCong_TrongSo():0.00}");
            sw.WriteLine($"{TinhTrungBinhCong_TrongSo():0.00}");

            LinkedList<Tuple<int, int, int>> dsMax = new LinkedList<Tuple<int, int, int>>();
            int max = TimTrongSoLonNhat();
            foreach (Tuple<int, int, int> t in e)
            {
                if (t.Item3 == max)
                    dsMax.AddLast(t);
            }

            Console.WriteLine(dsMax.Count);
            sw.WriteLine(dsMax.Count);

            foreach (Tuple<int, int, int> t in dsMax)
            {
                Console.WriteLine($"{t.Item1} {t.Item2} {t.Item3}");
                sw.WriteLine($"{t.Item1} {t.Item2} {t.Item3}");
            }
            sw.Close();
        }   
        //Buổi 6        
        public void Read_Bai1_Buoi6(string fileIn, out int dinhBD, out int dinhKT)
        {
            StreamReader sr = new StreamReader(fileIn);
            string line1 = sr.ReadLine();
            string[] arr = line1.Trim().Split(' ');
            soDinh = int.Parse(arr[0]);
            soCanh = int.Parse(arr[1]);
            dinhBD = int.Parse(arr[2]);
            dinhKT = int.Parse(arr[3]);

            while (sr.EndOfStream == false)
            {
                string line = sr.ReadLine();
                arr = line.Trim().Split(' ');
                int dinh1 = int.Parse(arr[0]);
                int dinh2 = int.Parse(arr[1]);
                int trongSo = int.Parse(arr[2]);

                e.AddLast(new Tuple<int, int, int>(dinh1, dinh2, trongSo));
            }
            sr.Close();
        }

        public void In_Bai1_Buoi6(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            int dinhBD, dinhKT;
            Read_Bai1_Buoi6(fileIn, out dinhBD, out dinhKT);

            int[] dist = new int[soDinh + 1]; 
            bool[] processed = new bool[soDinh + 1]; 
            int[] pre = new int[soDinh + 1]; 
       
            Dijkstra(dinhBD, dist, processed, pre);

            LinkedList<int> path = new LinkedList<int>();
            for (int k = dinhKT; k != -1; k = pre[k])
            {
                path.AddFirst(k);
            }

            Console.WriteLine(dist[dinhKT]);
            sw.WriteLine(dist[dinhKT]);
            for (int i = 0; i < path.Count; i++)
            {
                Console.Write(path.ElementAt(i) + " ");
                sw.Write(path.ElementAt(i) + " ");
            }
            sw.Close();
        }

        public void Dijkstra(int dinhBD, int[] dist, bool[] processed, int[] pre)
        {          

            for (int i = 0; i < soDinh + 1; i++)
            {
                dist[i] = int.MaxValue;
                processed[i] = false;
                pre[i] = -1;
            }

            dist[dinhBD] = 0;

            for (int dinh = 1; dinh < soDinh + 1; dinh++)
            {
                int a = TimDinh_Co_Dist_NhoNhat(dist, processed);
              
                if (a != -1) processed[a] = true;               

                foreach (Tuple<int, int, int> t in e)
                {
                    int dinh1 = t.Item1;
                    int dinh2 = t.Item2;
                    int trongSo = t.Item3;
                 
                    if (dinh1 == a)
                    {
                        int b = dinh2;
                        int w_a_b = trongSo;

                        if (dist[b] > dist[a] + w_a_b && processed[b] == false && dist[a] != int.MaxValue)
                        {
                            dist[b] = dist[a] + w_a_b;
                            pre[b] = a;
                        }
                    }

                    if (dinh2 == a)
                    {
                        int b = dinh1;
                        int w_a_b = trongSo;

                        if (dist[b] > dist[a] + w_a_b && processed[b] == false && dist[a] != int.MaxValue)
                        {
                            dist[b] = dist[a] + w_a_b;
                            pre[b] = a;
                        }
                    }
                }
            }
        }
   
        public int TimDinh_Co_Dist_NhoNhat(int[] dist, bool[] processed)
        {
            int minValue = int.MaxValue; 
            int minIndex = -1; 

            for (int i = 1; i < dist.Length; i++)
            {
                if (dist[i] <= minValue && processed[i] == false)
                {
                    minValue = dist[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }
    
        public void Read_Bai2_Buoi6(string fileIn, out int dinhBD, out int dinhKT, out int dinhTG)
        {
            StreamReader sr = new StreamReader(fileIn);
            string line1 = sr.ReadLine();
            string[] arr = line1.Trim().Split(' ');
            soDinh = int.Parse(arr[0]);
            soCanh = int.Parse(arr[1]);
            dinhBD = int.Parse(arr[2]);
            dinhKT = int.Parse(arr[3]);
            dinhTG = int.Parse(arr[4]);

            while (sr.EndOfStream == false)
            {
                string line = sr.ReadLine();
                arr = line.Trim().Split(' ');
                int dinh1 = int.Parse(arr[0]);
                int dinh2 = int.Parse(arr[1]);
                int trongSo = int.Parse(arr[2]);

                e.AddLast(new Tuple<int, int, int>(dinh1, dinh2, trongSo));
            }
            sr.Close();
        }

        public void In_Bai2_Buoi6(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            int dinhBD, dinhKT, dinhTG;
            Read_Bai2_Buoi6(fileIn, out dinhBD, out dinhKT, out dinhTG);
            int[] dist = new int[soDinh + 1]; 
            bool[] processed = new bool[soDinh + 1]; 
            int[] pre = new int[soDinh + 1]; 

            int tong = 0;       
            Dijkstra(dinhBD, dist, processed, pre);
            tong += dist[dinhTG];

            LinkedList<int> path1 = new LinkedList<int>();
            LinkedList<int> path2 = new LinkedList<int>();
            for (int k = dinhTG; k != -1; k = pre[k])
            {
                path1.AddFirst(k);
            }
         
            Dijkstra(dinhTG, dist, processed, pre);         
            tong += dist[dinhKT];
            for (int k = dinhKT; k != dinhTG; k = pre[k])
            {
                path2.AddFirst(k);
            }

            for (int i = 0; i < path2.Count; i++)
                path1.AddLast(path2.ElementAt(i));

            Console.WriteLine(tong);
            sw.WriteLine(tong);
            for (int i = 0; i < path1.Count; i++)
            {
                Console.Write(path1.ElementAt(i) + " ");
                sw.Write(path1.ElementAt(i) + " ");
            }
            sw.Close();
        }
    }
}