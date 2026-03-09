using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _24DH113630_Lã_Minh_Trí
{
    internal class EdgeList
    {
        private int soDinh;
        private int soCanh;
        private LinkedList<Tuple<int, int>> e;

        public int SoDinh { get { return soDinh; } set { soDinh = value; } }
        public int SoCanh { get { return soCanh; } set { soCanh = value; } }
        public LinkedList<Tuple<int, int>> E { get { return e; } set { e = value; } }

        public EdgeList()
        {
            this.soDinh = 0;
            this.soCanh = 0;
            this.e = new LinkedList<Tuple<int, int>>();
        }

        public EdgeList(int soDinh, int soCanh, LinkedList<Tuple<int, int>> e)
        {
            this.soDinh = soDinh;
            this.soCanh = soCanh;
            this.e = new LinkedList<Tuple<int, int>>();
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
                if (!string.IsNullOrWhiteSpace(line))
                {
                    arr = line.Split(' ');
                    e.AddLast(new Tuple<int, int>(int.Parse(arr[0]), int.Parse(arr[1])));
                }
            }
            sr.Close();
        }

        public void Print_EdgeList(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            sw.WriteLine(soDinh);
            for (int i = 0; i < e.Count; i++)
            {
                Tuple<int, int> t = e.ElementAt(i);
                Console.WriteLine($"({t.Item1}, {t.Item2})");
                sw.WriteLine($"({t.Item1}, {t.Item2})");
            }
            sw.Close();
        }

        public void Print_Degree_of_EdgeList(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            Console.WriteLine(this.soDinh);
            sw.WriteLine(this.soDinh);
            int[] count = new int[soDinh + 1];

            foreach (Tuple<int, int> t in e)
            {
                int dinh = t.Item1;
                count[dinh]++;
                dinh = t.Item2;
                count[dinh]++;
            }

            for (int i = 1; i < count.Length; i++)
            {
                Console.Write(count[i] + " ");
                sw.Write(count[i] + " ");
            }
            sw.Close();
        }
        // Buổi 2
        public void Print_EdgeList_ToFile(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            Console.WriteLine(this.soDinh + " " + this.soCanh);
            sw.WriteLine(this.soDinh + " " + this.soCanh);
            for (int i = 0; i < e.Count; i++)
            {
                Tuple<int, int> t = e.ElementAt(i);
                Console.WriteLine($"{t.Item1} {t.Item2}");
                sw.WriteLine($"{t.Item1} {t.Item2}");
            }
            sw.Close();
        }

        public bool KiemTraCanh(Tuple<int, int> canhCanKiemTra)
        {
            for (int i = 0; i < this.e.Count; i++)
            {
                Tuple<int, int> t = e.ElementAt(i);
                if ((t.Item1 == canhCanKiemTra.Item1 && t.Item2 == canhCanKiemTra.Item2) ||
                    (t.Item1 == canhCanKiemTra.Item2 && t.Item2 == canhCanKiemTra.Item1))
                    return true;
            }
            return false;
        }

        public void Convert_From_EdgeList_To_AdjacencyList(string fileIn, string fileOut)
        {
            Read_EdgeList(fileIn);
            int soDinh_DSKe = this.SoDinh;
            AdjacencyList adjList = new AdjacencyList(soDinh_DSKe);

            for (int i = 0; i < adjList.V.Length; i++)
            {
                adjList.V[i] = new LinkedList<int>();
            }

            foreach (Tuple<int, int> t in e)
            {
                int dinh1 = t.Item1;
                int dinh2 = t.Item2;
                adjList.V[dinh1].AddLast(dinh2);
                adjList.V[dinh2].AddLast(dinh1);
            }

            Console.WriteLine("Danh sach CANH TRUOC CHUYEN DOI ");
            Print_EdgeList(fileOut);
            Console.WriteLine("\n------Danh sach KE SAU CHUYEN DOI ");
            adjList.Print_AdjacencyList_To_File(fileOut);
        }
    }
}
