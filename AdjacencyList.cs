using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _24DH113630_Lã_Minh_Trí
{
    internal class AdjacencyList
    {
        private int n;
        private LinkedList<int>[] v;

        public int N { get { return n; } set { n = value; } }
        public LinkedList<int>[] V { get { return v; } set { v = value; } }

        public AdjacencyList() { }

        public AdjacencyList(int n)
        {
            this.n = n;
            this.v = new LinkedList<int>[n + 1];
            for (int i = 1; i <= n; i++) this.v[i] = new LinkedList<int>();
        }

        // Buổi 1
        public void Read_AdjacencyList(string fileIn)
        {
            if (!File.Exists(fileIn)) { Console.WriteLine("File not found"); return; }
            StreamReader sr = new StreamReader(fileIn);
            string firstLine = sr.ReadLine();
            if (firstLine != null)
            {
                this.n = int.Parse(firstLine);
                this.v = new LinkedList<int>[n + 1];
                for (int i = 1; i <= n; i++)
                {
                    this.v[i] = new LinkedList<int>();
                    string line = sr.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] arr = line.Trim().Split(' ');
                        foreach (string s in arr) if (s != "") this.v[i].AddLast(int.Parse(s));
                    }
                }
            }
            sr.Close();
        }

        public void Print_AdjacencyList(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            sw.WriteLine(this.n);
            for (int i = 1; i < this.v.Length; i++)
            {
                Console.Write($"{i}: ");
                int j = 0;
                while (j < this.v[i].Count) { Console.Write(this.v[i].ElementAt(j) + " --> "); j++; }
                Console.Write("null\n");
            }
            sw.Close();
        }
        public void Print_Degree_of_AdjacencyList(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            Console.WriteLine(this.N); sw.WriteLine(this.N);
            for (int i = 1; i < this.v.Length; i++) { Console.Write(v[i].Count + " "); sw.Write(v[i].Count + " "); }
            sw.Close();
        }
        // Buổi 2
        public void Print_AdjacencyList_To_File(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            Console.WriteLine(this.N); sw.WriteLine(this.N);
            for (int i = 1; i < this.v.Length; i++)
            {
                LinkedList<int> lst = v[i];
                for (int j = 0; j < lst.Count; j++) { Console.Write(lst.ElementAt(j) + " "); sw.Write(lst.ElementAt(j) + " "); }
                Console.WriteLine(); sw.WriteLine();
            }
            sw.Close();
        }
        public void Convert_From_AdjacencyList_To_EdgeList(string fileIn, string fileOut)
        {
            Read_AdjacencyList(fileIn);
            EdgeList edgeList = new EdgeList(); edgeList.SoDinh = this.n;
            for (int i = 1; i < this.v.Length; i++)
            {
                LinkedList<int> ds = v[i];
                for (int j = 0; j < ds.Count; j++)
                {
                    int dinh1 = i; int dinh2 = ds.ElementAt(j);
                    Tuple<int, int> c = new Tuple<int, int>(dinh1, dinh2);
                    if (!edgeList.KiemTraCanh(c)) edgeList.E.AddLast(c);
                }
            }
            edgeList.SoCanh = edgeList.E.Count;
            Print_AdjacencyList(fileOut); edgeList.Print_EdgeList_ToFile(fileOut);
        }
        public AdjacencyList ReverseGraph_AdjacencyList(string fileIn, string fileOut)
        {
            Read_AdjacencyList(fileIn);
            AdjacencyList rev = new AdjacencyList(this.n);
            for (int i = 1; i < rev.V.Length; i++) rev.V[i] = new LinkedList<int>();
            for (int i = 1; i < this.v.Length; i++)
            {
                LinkedList<int> ds = this.v[i];
                if (ds != null) foreach (int d in ds) rev.V[d].AddLast(i);
            }
            this.Print_AdjacencyList_To_File(fileOut); rev.Print_AdjacencyList_To_File(fileOut);
            return rev;
        }

        // Buổi 3
        public List<int> BFS(int start, ref bool[] visited)
        {
            Queue<int> q = new Queue<int>(); List<int> lst = new List<int>();
            if (start > n || start < 1) return lst;
            visited[start] = true; q.Enqueue(start); lst.Add(start);
            while (q.Count > 0)
            {
                int u = q.Dequeue();
                foreach (int ke in v[u]) if (!visited[ke]) { visited[ke] = true; q.Enqueue(ke); lst.Add(ke); }
            }
            return lst;
        }
        public void Print_BFS(int s, string f)
        {
            StreamWriter sw = new StreamWriter(f); bool[] visited = new bool[n + 1];
            List<int> l = BFS(s, ref visited);
            foreach (int i in l) { Console.Write(i + " "); sw.Write(i + " "); }
            Console.WriteLine(); sw.Close();
        }

        public void Read_AdjacencyList_Bai2_Buoi3(string fileIn, out int dinhBatDau)
        {
            if (!File.Exists(fileIn)) { Console.WriteLine("File not found"); dinhBatDau = 0; return; }
            StreamReader sr = new StreamReader(fileIn);
            string line = sr.ReadLine();
            if (line == null) { dinhBatDau = 0; return; }
            string[] arr = line.Split(' ');
            this.n = int.Parse(arr[0]); dinhBatDau = int.Parse(arr[1]);
            this.v = new LinkedList<int>[n + 1];

            while (!sr.EndOfStream)
            {
                for (int i = 1; i <= n; i++)
                {
                    this.v[i] = new LinkedList<int>();
                    line = sr.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    arr = line.Trim().Split(' ');
                    foreach (string s in arr) if (s != "") this.v[i].AddLast(int.Parse(s));
                }
            }
            sr.Close();
        }
        public void InCacDinhLienThongVoi_S(string fi, string fo)
        {
            int s; Read_AdjacencyList_Bai2_Buoi3(fi, out s);
            StreamWriter sw = new StreamWriter(fo); bool[] visited = new bool[n + 1];
            List<int> l = BFS(s, ref visited);
            sw.WriteLine(l.Count - 1); Console.WriteLine(l.Count - 1);
            foreach (int i in l) if (i != s) { Console.Write(i + " "); sw.Write(i + " "); }
            sw.Close();
        }

        public void Read_AdjacencyList_Bai3_Buoi3(string fileIn, out int dinhBatDau, out int dinhKetThuc)
        {
            if (!File.Exists(fileIn)) { Console.WriteLine("File not found"); dinhBatDau = 0; dinhKetThuc = 0; return; }
            StreamReader sr = new StreamReader(fileIn);
            string line = sr.ReadLine();
            if (line == null) { dinhBatDau = 0; dinhKetThuc = 0; return; }
            string[] arr = line.Split(' ');
            this.n = int.Parse(arr[0]); dinhBatDau = int.Parse(arr[1]); dinhKetThuc = int.Parse(arr[2]);
            this.v = new LinkedList<int>[n + 1];

            while (!sr.EndOfStream)
            {
                for (int i = 1; i <= n; i++)
                {
                    this.v[i] = new LinkedList<int>();
                    line = sr.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    arr = line.Trim().Split(' ');
                    foreach (string s in arr) if (s != "") this.v[i].AddLast(int.Parse(s));
                }
            }
            sr.Close();
        }
        public List<int> BFS(int start, ref bool[] visited, ref int[] pre)
        {
            Queue<int> q = new Queue<int>(); List<int> lst = new List<int>();
            if (start > n || start < 1) return lst;
            visited[start] = true; q.Enqueue(start); lst.Add(start); pre[start] = -1;
            while (q.Count > 0)
            {
                int u = q.Dequeue();
                foreach (int ke in v[u]) if (!visited[ke]) { visited[ke] = true; q.Enqueue(ke); lst.Add(ke); pre[ke] = u; }
            }
            return lst;
        }
        public void InDuongDi_Tu_X_Den_Y(string fi, string fo)
        {
            int s, e; Read_AdjacencyList_Bai3_Buoi3(fi, out s, out e);
            StreamWriter sw = new StreamWriter(fo); bool[] visited = new bool[n + 1]; int[] pre = new int[n + 1];
            BFS(s, ref visited, ref pre);
            LinkedList<int> path = new LinkedList<int>();
            for (int i = e; i != -1; i = pre[i]) path.AddFirst(i);
            Console.WriteLine(path.Count); sw.WriteLine(path.Count);
            foreach (int i in path) { Console.Write(i + " "); sw.Write(i + " "); }
            sw.Close();
        }
        public void KiemTraDoThiLienThong_BFS(string fi, string fo)
        {
            Read_AdjacencyList(fi); StreamWriter sw = new StreamWriter(fo);
            bool[] visited = new bool[n + 1]; BFS(1, ref visited);
            bool lt = true; for (int i = 1; i <= n; i++) if (!visited[i]) lt = false;
            if (lt) { Console.WriteLine("YES"); sw.WriteLine("YES"); } else { Console.WriteLine("NO"); sw.WriteLine("NO"); }
            sw.Close();
        }
        public void DemSoMienLienThong(string fi, string fo)
        {
            Read_AdjacencyList(fi); StreamWriter sw = new StreamWriter(fo);
            bool[] visited = new bool[n + 1]; int count = 0;
            for (int i = 1; i <= n; i++) if (!visited[i]) { count++; BFS(i, ref visited); }
            Console.WriteLine(count); sw.WriteLine(count); sw.Close();
        }

        // Buổi 4
        public List<List<int>> LietKeMienLienThong(string fileIn)
        {
            List<List<int>> dsCacMienLienThong = new List<List<int>>();
            Read_AdjacencyList(fileIn);
            bool[] visited = new bool[n + 1];
            for (int i = 1; i < this.v.Length; i++)
            {
                if (visited[i] == false)
                {
                    List<int> cacDinhLienThong = BFS(i, ref visited);
                    dsCacMienLienThong.Add(cacDinhLienThong);
                }
            }
            return dsCacMienLienThong;
        }

        public void InDanhSachCacMienLienThong(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            List<List<int>> dsCacMienLienThong = LietKeMienLienThong(fileIn);
            Console.WriteLine(dsCacMienLienThong.Count);
            sw.WriteLine(dsCacMienLienThong.Count);
            for (int i = 0; i < dsCacMienLienThong.Count; i++)
            {
                List<int> dsCon = dsCacMienLienThong[i];
                dsCon.Sort();
                for (int j = 0; j < dsCon.Count; j++)
                {
                    Console.Write(dsCon[j] + " ");
                    sw.Write(dsCon[j] + " ");
                }
                Console.WriteLine();
                sw.WriteLine();
            }
            sw.Close();
        }

        public int DemSoMienLienThong(int boDinh = -1)
        {
            int count = 0;
            bool[] visited = new bool[n + 1];
            if (boDinh != -1) visited[boDinh] = true;
            for (int i = 1; i <= n; i++)
            {
                if (!visited[i])
                {
                    count++;
                    Queue<int> q = new Queue<int>();
                    visited[i] = true;
                    q.Enqueue(i);
                    while (q.Count > 0)
                    {
                        int u = q.Dequeue();
                        foreach (int v_ke in v[u])
                        {
                            if (!visited[v_ke])
                            {
                                visited[v_ke] = true;
                                q.Enqueue(v_ke);
                            }
                        }
                    }
                }
            }
            return count;
        }

        public bool KiemTraCanhCau(string fileIn)
        {
            int dinhBatDauCuaCanhXoa, dinhKetThucCuaCanhXoa;
            Read_AdjacencyList_Bai3_Buoi3(fileIn, out dinhBatDauCuaCanhXoa, out dinhKetThucCuaCanhXoa);
            int countBD = DemSoMienLienThong();
            v[dinhBatDauCuaCanhXoa].Remove(dinhKetThucCuaCanhXoa);
            v[dinhKetThucCuaCanhXoa].Remove(dinhBatDauCuaCanhXoa);
            int countSauKhiXoa = DemSoMienLienThong();
            if (countSauKhiXoa > countBD)
            {
                v[dinhBatDauCuaCanhXoa].AddLast(dinhKetThucCuaCanhXoa);
                v[dinhKetThucCuaCanhXoa].AddLast(dinhBatDauCuaCanhXoa);
                return true;
            }
            else
            {
                v[dinhBatDauCuaCanhXoa].AddLast(dinhKetThucCuaCanhXoa);
                v[dinhKetThucCuaCanhXoa].AddLast(dinhBatDauCuaCanhXoa);
                return false;
            }
        }

        public void InKiemTraCanhCau(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            bool kqKT = KiemTraCanhCau(fileIn);
            if (kqKT == true)
            {
                Console.WriteLine("YES");
                sw.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
                sw.WriteLine("NO");
            }
            sw.Close();
        }

        public bool KiemTraDinhKhop(string fileIN)
        {
            int dinhCanKiemTra;
            Read_AdjacencyList_Bai2_Buoi3(fileIN, out dinhCanKiemTra);
            int countBD = DemSoMienLienThong();
            int countSauKhiXoa = DemSoMienLienThong(dinhCanKiemTra);
            if (countSauKhiXoa >= countBD + 1)
                return true;
            else
                return false;
        }

        public void InKiemTraDinhKhop(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            bool kqKT = KiemTraDinhKhop(fileIn);
            if (kqKT == true)
            {
                sw.WriteLine("YES");
                Console.WriteLine("YES");
            }
            else
            {
                sw.WriteLine("NO");
                Console.WriteLine("NO");
            }
            sw.Close();
        }

        //Buổi 5         
        public void In_DFS_DeQuy(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            Read_AdjacencyList(fileIn);
            bool[] visited = new bool[n + 1];
            List<int> dsCacDinhDaDuyet = new List<int>();
            DFS_DeQuy(1, ref visited, dsCacDinhDaDuyet);
            for (int i = 0; i < dsCacDinhDaDuyet.Count; i++)
            {
                Console.Write(dsCacDinhDaDuyet[i] + " ");
                sw.Write(dsCacDinhDaDuyet[i] + " ");
            }
            sw.Close();
        }

        public void DFS_DeQuy(int s, ref bool[] visited, List<int> dsCacDinhDaDuyet)
        {
            if (visited[s] == true)
            {
                return;
            }          
            else
            {             
                visited[s] = true;             
                dsCacDinhDaDuyet.Add(s);             
                foreach (int ke in v[s])
                {
                    if (visited[ke] == false)
                    {
                        DFS_DeQuy(ke, ref visited, dsCacDinhDaDuyet);
                    }
                }
            }
        }
        public void In_DFS_Stack(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            Read_AdjacencyList(fileIn);
            bool[] visited = new bool[n + 1];
            List<int> dsCacDinhDaDuyet = new List<int>();
            DFS_Stack(1, ref visited, dsCacDinhDaDuyet);
            for (int i = 0; i < dsCacDinhDaDuyet.Count; i++)
            {
                Console.Write(dsCacDinhDaDuyet[i] + " ");
                sw.Write(dsCacDinhDaDuyet[i] + " ");
            }
            sw.Close();
        }

        public void DFS_Stack(int s, ref bool[] visited, List<int> dsCacDinhDaDuyet)
        {
            Stack<int> stack = new Stack<int>();

            visited[s] = true;
            stack.Push(s);
            while (stack.Count > 0)
            {
                int u = stack.Pop();
                dsCacDinhDaDuyet.Add(u);
                for (int i = v[u].Count - 1; i >= 0; i--)
                {
                    int ke = v[u].ElementAt(i);
                    if (visited[ke] == false)
                    {
                        visited[ke] = true;                      
                        stack.Push(ke);
                    }
                }
            }
        }

        public void In_Bai1_Buoi5(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            int dinhBD;
            Read_AdjacencyList_Bai2_Buoi3(fileIn, out dinhBD);
            bool[] visited = new bool[n + 1];
            List<int> ds_DFS_DQ = new List<int>();
            DFS_DeQuy(dinhBD, ref visited, ds_DFS_DQ);
            Console.WriteLine("Duyệt bằng DFS (đệ quy): ");
            for (int i = 0; i < ds_DFS_DQ.Count; i++)
            {
                Console.Write(ds_DFS_DQ[i] + " ");
            }

            Console.WriteLine("\n---");
            visited = new bool[n + 1];
            List<int> ds_DFS_Stack = new List<int>();
            DFS_Stack(dinhBD, ref visited, ds_DFS_Stack);
            Console.WriteLine("Duyệt bằng DFS (Stack): ");
            for (int i = 0; i < ds_DFS_Stack.Count; i++)
            {
                Console.Write(ds_DFS_Stack[i] + " ");
            }
            sw.WriteLine(ds_DFS_Stack.Count - 1);
            for (int i = 0; i < ds_DFS_Stack.Count; i++)
            {
                if (ds_DFS_Stack[i] != dinhBD)
                    sw.Write(ds_DFS_Stack[i] + " ");
            }
            sw.Close();
        }

        public void In_Bai2_Buoi5(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            int dinhBD, dinhKT;
            Read_AdjacencyList_Bai3_Buoi3(fileIn, out dinhBD, out dinhKT);

            bool[] visited = new bool[n + 1];
            List<int> dsCacDinhDaDuyet = new List<int>();
            int[] pre = new int[n + 1];
            for (int i = 0; i < pre.Length; i++)
                pre[i] = -1;

            DFS_DeQuy_Bai2_Buoi5(dinhBD, ref visited, ref pre, dsCacDinhDaDuyet);

            LinkedList<int> path = new LinkedList<int>();
            for (int k = dinhKT; k != -1; k = pre[k])
                path.AddFirst(k);

            sw.WriteLine(path.Count);
            for (int i = 0; i < path.Count; i++)
            {
                Console.Write(path.ElementAt(i) + " ");
                sw.Write(path.ElementAt(i) + " ");
            }
            sw.Close();
        }

        public void DFS_DeQuy_Bai2_Buoi5(int s, ref bool[] visited, ref int[] pre, List<int> dsCacDinhDaDuyet)
        {
            if (visited[s] == true)
                return;
            else
            {
                visited[s] = true;        
                dsCacDinhDaDuyet.Add(s);

                foreach (int ke in v[s])
                {
                    if (visited[ke] == false)
                    {
                        pre[ke] = s;
                        DFS_DeQuy_Bai2_Buoi5(ke, ref visited, ref pre, dsCacDinhDaDuyet);
                    }
                }
            }
        }
      
        public void In_Bai3_Buoi5(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            Read_AdjacencyList(fileIn);

            bool[] visited = new bool[n + 1];
            List<int> dsDinhDaDuyet = new List<int>();
            string[] colors = new string[n + 1];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = "NoColor";
            }

            int dinhBD = 1;
            colors[dinhBD] = "RED";

            DFS_DeQuy_Colors(dinhBD, ref visited, ref colors, dsDinhDaDuyet);

            bool kqKT = IsBipartiteGraph(colors);
            if (kqKT == true)
            {
                Console.WriteLine("YES");
                sw.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
                sw.WriteLine("NO");
            }
            sw.Close();
        }

        public void DFS_DeQuy_Colors(int s, ref bool[] visited, ref string[] colors, List<int> dsCacDinhDaDuyet)
        {
            if (visited[s] == true)
                return;          
            else
            {
                visited[s] = true;             
                dsCacDinhDaDuyet.Add(s);

                foreach (int ke in v[s])
                {
                    if (visited[ke] == false)
                    {
                        if (colors[s] == "RED")
                            colors[ke] = "GREEN";
                        else if (colors[s] == "GREEN")
                            colors[ke] = "RED";
                        DFS_DeQuy_Colors(ke, ref visited, ref colors, dsCacDinhDaDuyet);
                    }
                }
            }
        }

        public bool IsBipartiteGraph(string[] colors)
        {
            for (int i = 1; i < v.Length; i++)
            {
                LinkedList<int> ds = v[i];
                for (int j = 0; j < ds.Count; j++)
                {
                    int ke = ds.ElementAt(j);                  
                    if (colors[i] == colors[ke])
                        return false;
                }
            }
            return true;
        }

        public void In_Bai4_Buoi5(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            Read_AdjacencyList(fileIn);
         
            int[] visited = new int[n + 1];
            List<int> dsDinhDaDuyet = new List<int>();
            bool isCycle = false;

            for (int dinh = 1; dinh < v.Length; dinh++)
            {
                if (visited[dinh] == 0)
                    DFS_DeQuy_IsCycle(1, ref visited, dsDinhDaDuyet, ref isCycle);
            }

            if (isCycle == true)
            {
                Console.WriteLine("YES");
                sw.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
                sw.WriteLine("NO");
            }
            sw.Close();
        }

        public void DFS_DeQuy_IsCycle(int s, ref int[] visited, List<int> dsCacDinhDaDuyet, ref bool isCycle)
        {
            if (visited[s] == 1)
                return;
            else
            {
                visited[s] = 1;

                dsCacDinhDaDuyet.Add(s);

                foreach (int ke in v[s])
                {
                    if (visited[ke] == 0)
                        DFS_DeQuy_IsCycle(ke, ref visited, dsCacDinhDaDuyet, ref isCycle);
                    else if (visited[ke] == 1) 
                        isCycle = true;
                }
                visited[s] = 2;
            }
        }
       
        public void In_Bai5_Buoi5(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            Read_AdjacencyList(fileIn);         
            int[] visited_IsCycle = new int[n + 1];
            List<int> dsDinhDaDuyet = new List<int>();
            bool isCycle = false;

            DFS_DeQuy_IsCycle(1, ref visited_IsCycle, dsDinhDaDuyet, ref isCycle);
            Stack<int> stack = new Stack<int>();

            if (isCycle == false)
            {
                bool[] visited = new bool[n + 1];
                dsDinhDaDuyet = new List<int>();

                for (int dinh = 1; dinh < v.Length; dinh++)
                {
                  
                    if (visited[dinh] == false)
                    {
                        DFS_DeQuy_TopoSort(dinh, ref visited, dsDinhDaDuyet, stack);
                    }
                }
                
                while (stack.Count > 0)
                {
                    int outItem = stack.Pop();
                    Console.Write(outItem + " ");
                    sw.Write(outItem + " ");
                }
            }
            sw.Close();
        }

        public void DFS_DeQuy_TopoSort(int s, ref bool[] visited, List<int> dsCacDinhDaDuyet, Stack<int> stack)
        {
            if (visited[s] == true)
                return;
           
            else
            {
              
                visited[s] = true;
                dsCacDinhDaDuyet.Add(s);

                foreach (int ke in v[s])
                {
                    if (visited[ke] == false)
                    {
                        DFS_DeQuy_TopoSort(ke, ref visited, dsCacDinhDaDuyet, stack);
                    }
                }
                stack.Push(s);
            }
        }
    }
}