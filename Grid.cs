using System;
using System.Collections.Generic;
using System.IO;

namespace _24DH113630_Lã_Minh_Trí
{
    internal class Grid
    {
        private int n;
        private int m;
        private int[,] matrix;

        public int N { get { return n; } set { n = value; } }
        public int M { get { return m; } set { m = value; } }
        public int[,] Matrix { get { return matrix; } set { matrix = value; } }

        public Grid() { }
        public Grid(int n, int m)
        {
            matrix = new int[n + 1, m + 1];
        }

        public void ReadGridFromFile(string fileIn, out int startX, out int startY, out int endX, out int endY)
        {
            StreamReader sr = new StreamReader(fileIn);
            string line1 = sr.ReadLine();
            string[] arr = line1.Trim().Split(' ');
            n = int.Parse(arr[0]);
            m = int.Parse(arr[1]);
            matrix = new int[n + 1, m + 1];

            string line2 = sr.ReadLine();
            arr = line2.Trim().Split(' ');
            startX = int.Parse(arr[0]);
            startY = int.Parse(arr[1]);
            endX = int.Parse(arr[2]);
            endY = int.Parse(arr[3]);

            while (sr.EndOfStream == false)
            {
                string line;
                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    line = sr.ReadLine();
                    arr = line.Trim().Split(' ');
                    for (int j = 1; j < matrix.GetLength(1); j++)
                        matrix[i, j] = int.Parse(arr[j - 1]);
                }
            }
            sr.Close();
        }

        public void PrintGrid()
        {
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public List<Tuple<int, int>> BFS_Grid(int startX, int startY, ref bool[,] visited, ref Tuple<int, int>[,] pre)
        {
            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
            List<Tuple<int, int>> lstCacDinhDaDuyet = new List<Tuple<int, int>>();

            visited[startX, startY] = true;
            q.Enqueue(new Tuple<int, int>(startX, startY));
            lstCacDinhDaDuyet.Add(new Tuple<int, int>(startX, startY));
            pre[startX, startY] = new Tuple<int, int>(-1, -1);

            while (q.Count != 0)
            {
                Tuple<int, int> u = q.Dequeue();

                int[] dx = { -1, 1, 0, 0 };
                int[] dy = { 0, 0, -1, 1 };

                for (int i = 0; i < 4; i++)
                {
                    int keX = u.Item1 + dx[i];
                    int keY = u.Item2 + dy[i];

                    if (keX < 1 || keX > n || keY < 1 || keY > m) continue;
                    if (visited[keX, keY] == true || matrix[keX, keY] == 0) continue;
                    else
                    {
                        visited[keX, keY] = true;
                        q.Enqueue(new Tuple<int, int>(keX, keY));
                        lstCacDinhDaDuyet.Add(new Tuple<int, int>(keX, keY));
                        pre[keX, keY] = new Tuple<int, int>(u.Item1, u.Item2);
                    }
                }
            }
            return lstCacDinhDaDuyet;
        }

        public void In_BFS_Grid(string fileIn, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut);
            int startX, startY, endX, endY;
            ReadGridFromFile(fileIn, out startX, out startY, out endX, out endY);

            bool[,] visited = new bool[n + 1, m + 1];
            Tuple<int, int>[,] pre = new Tuple<int, int>[n + 1, m + 1];
            for (int i = 0; i < pre.GetLength(0); i++)
                for (int j = 0; j < pre.GetLength(1); j++)
                    pre[i, j] = new Tuple<int, int>(-1, -1);

            BFS_Grid(startX, startY, ref visited, ref pre);

            LinkedList<Tuple<int, int>> path = new LinkedList<Tuple<int, int>>();
            Tuple<int, int> curr = new Tuple<int, int>(endX, endY);

            if (visited[endX, endY])
            {
                while (curr.Item1 != -1 && curr.Item2 != -1)
                {
                    path.AddFirst(curr);
                    curr = pre[curr.Item1, curr.Item2];
                }

                sw.WriteLine(path.Count);
                Console.WriteLine(path.Count);
                foreach (Tuple<int, int> t in path)
                {
                    Console.WriteLine(t.Item1 + " " + t.Item2);
                    sw.WriteLine(t.Item1 + " " + t.Item2);
                }
            }
            else
            {
                sw.WriteLine("-1");
                Console.WriteLine("-1");
            }
            sw.Close();
        }

        public void In_Bai4_Buoi6(string fileIn, string fileOut)
        {
            StreamReader sr = new StreamReader(fileIn);
            string[] line1 = sr.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(line1[0]); 
            int m = int.Parse(line1[1]);
            int startX = int.Parse(line1[2]); 
            int startY = int.Parse(line1[3]); 

            int[,] a = new int[n + 1, m + 1];
            for (int i = 1; i <= n; i++)
            {
                string[] row = sr.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 1; j <= m; j++)
                {
                    a[i, j] = int.Parse(row[j - 1]);
                }
            }
            sr.Close();

            int[,] dist = new int[n + 1, m + 1];
            bool[,] processed = new bool[n + 1, m + 1];

            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= m; j++)
                    dist[i, j] = int.MaxValue;

            dist[startX, startY] = a[startX, startY];

            List<Tuple<int, int>> tapDinhActive = new List<Tuple<int, int>>();
            tapDinhActive.Add(new Tuple<int, int>(startX, startY));

            int[] dx = { -1, 1, 0, 0 }; 
            int[] dy = { 0, 0, -1, 1 }; 
            int minCost = int.MaxValue;

            while (tapDinhActive.Count > 0)
            {

                int minIndex = 0;
                int minD = dist[tapDinhActive[0].Item1, tapDinhActive[0].Item2];

                for (int i = 1; i < tapDinhActive.Count; i++)
                {
                    int currentD = dist[tapDinhActive[i].Item1, tapDinhActive[i].Item2];
                    if (currentD < minD)
                    {
                        minD = currentD;
                        minIndex = i;
                    }
                }

                int ux = tapDinhActive[minIndex].Item1;
                int uy = tapDinhActive[minIndex].Item2;
                tapDinhActive.RemoveAt(minIndex);

                if (processed[ux, uy]) continue;
                processed[ux, uy] = true;
            
                if (ux == 1 || ux == n || uy == 1 || uy == m)
                {
                    minCost = dist[ux, uy];
                    break; 
                }

                for (int i = 0; i < 4; i++)
                {
                    int vx = ux + dx[i];
                    int vy = uy + dy[i];

                    if (vx >= 1 && vx <= n && vy >= 1 && vy <= m)
                    {
                        if (processed[vx, vy] == false && dist[vx, vy] > dist[ux, uy] + a[vx, vy])
                        {
                            dist[vx, vy] = dist[ux, uy] + a[vx, vy];
                            tapDinhActive.Add(new Tuple<int, int>(vx, vy));
                        }
                    }
                }
            }

            StreamWriter sw = new StreamWriter(fileOut);
            Console.WriteLine(minCost);
            sw.WriteLine(minCost);
            sw.Close();
        }
    }
}