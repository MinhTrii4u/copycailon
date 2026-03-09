using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24DH113630_Lã_Minh_Trí
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            int choice = -1;
            string fileIn = "";
            string fileOut = "";

            do
            {
                Console.WriteLine("\n\n 24dh113630_Lã Minh Trí");
                Console.WriteLine("-------TTDT_Buổi 1-------");
                Console.WriteLine("1. Nhập và xuất ma trận kề đồ thị");
                Console.WriteLine("2. In số bậc của các đỉnh trong ma trận kề đồ thị");
                Console.WriteLine("3. In số bậc VÀO/RA của các đỉnh trong ma trận kề đồ thị (CÓ HƯỚNG)");
                Console.WriteLine("4. Nhập và xuất DANH SÁCH kề đồ thị");
                Console.WriteLine("5. In số bậc của các đỉnh trong DANH SÁCH kề đồ thị");
                Console.WriteLine("6. Nhập và xuất Danh sách CẠNH đồ thị");
                Console.WriteLine("7. In số bậc của các đỉnh trong DANH SÁCH CẠNH đồ thị");
                Console.WriteLine("8. CHUYỂN ĐỔI: Danh sách cạnh --> Danh sách kề");
                Console.WriteLine("9. CHUYỂN ĐỔI: Danh sách KỀ --> Danh sách CẠNH");
                Console.WriteLine("10. CHUYỂN ĐỔI: MA TRẬN KỀ --> Danh sách KỀ");
                Console.WriteLine("11. CHUYỂN ĐỔI: MA TRẬN KỀ --> Danh sách CẠNH");
                Console.WriteLine("12. Đồ thị chuyển vị");
                Console.WriteLine("13. Nhập và xuất danh sách CẠNH (CÓ TRỌNG SỐ)");
                Console.WriteLine("14. Độ dài trung bình của cạnh - (danh sách CẠNH CÓ TRỌNG SỐ)");
                Console.WriteLine("15. Duyệt đồ thị ( Adjacency List) theo BFS");
                Console.WriteLine("16. Liệt kê các đỉnh liên thông với đỉnh s ( BFS)");
                Console.WriteLine("17. Tìm đường (BFS)");
                Console.WriteLine("18. Kiểm tra đồ thị liên thông (BFS)");
                Console.WriteLine("19. Đếm số miền liên thông (BFS)");
                Console.WriteLine("20. Liệt kê các thành phần liên thông (BFS)");
                Console.WriteLine("21. Kiểm tra cạnh cầu");
                Console.WriteLine("22. Kiểm tra đỉnh khớp");
                Console.WriteLine("23. Đọc và In Grid (Lưới)");
                Console.WriteLine("24. Tìm đường đi trên Grid (BFS)");
                Console.WriteLine("25. Tìm Bồn Chứa (Adjacency Matrix)");
                Console.WriteLine("26. DFS (Đệ Quy)");
                Console.WriteLine("27. DFS (Stack)");
                Console.WriteLine("28. Liệt kê các đỉnh liên thông với s (DFS)");
                Console.WriteLine("29. Tìm đường đi (DFS)");
                Console.WriteLine("30. Đồ thị phân đôi (DFS)");
                Console.WriteLine("31. Kiểm tra chu trình (DFS)");
                Console.WriteLine("32. TopoSort (DFS)");
                Console.WriteLine("33. Đường đi ngắn nhất (Dijkstra)");
                Console.WriteLine("34. Đường đi ngắn nhất qua đỉnh trung gian (Dijkstra)");
                Console.WriteLine("35. Đường đi ngắn nhất giữa các cặp đỉnh (Floyd Warshall)");
                Console.WriteLine("36. Đi ra biên");
                Console.WriteLine("37. Chọn thành phố tổ chức họp ");

                Console.WriteLine("0. Thoát");
                Console.Write("\n Nhập lựa chọn: ");

                if (!int.TryParse(Console.ReadLine(), out choice)) continue;

                switch (choice)
                {
                    case 1:
                        {
                            fileIn = @"D:\AdjecencyMaTrix.INP";
                            fileOut = @"D:\AdjecencyMaTrix.OUT";
                            AdjacencyMatrix adjacencyMatrix = new AdjacencyMatrix();
                            adjacencyMatrix.ReadMaxtrix(fileIn);
                            adjacencyMatrix.PrintMatrix(fileOut);
                        }
                        break;
                    case 2:
                        {
                            fileIn = @"D:\AdjecencyMaTrix.INP";
                            fileOut = @"D:\AdjecencyMatrix.OUT";
                            AdjacencyMatrix adjacencyMatrix = new AdjacencyMatrix();
                            adjacencyMatrix.ReadMaxtrix(fileIn);
                            adjacencyMatrix.Print_Degree_of_Matrix(fileOut);
                        }
                        break;
                    case 3:
                        {
                            fileIn = @"D:\BacVaoRa.INP";
                            fileOut = @"D:\BacVaoRa.OUT";
                            AdjacencyMatrix adjacencyMatrix = new AdjacencyMatrix();
                            adjacencyMatrix.ReadMaxtrix(fileIn);
                            adjacencyMatrix.Print_Degree_of_Directed_Matrix(fileOut);
                        }
                        break;
                    case 4:
                        {
                            fileIn = @"D:\AdjecencyList.INP";
                            fileOut = @"D:\AdjecencyList.OUT";
                            AdjacencyList adjacencyList = new AdjacencyList();
                            adjacencyList.Read_AdjacencyList(fileIn);
                            adjacencyList.Print_AdjacencyList(fileOut);
                        }
                        break;
                    case 5:
                        {
                            fileIn = @"D:\AdjecencyList.INP";
                            fileOut = @"D:\AdjecencyList.OUT";
                            AdjacencyList adjacencyList = new AdjacencyList();
                            adjacencyList.Read_AdjacencyList(fileIn);
                            adjacencyList.Print_Degree_of_AdjacencyList(fileOut);
                        }
                        break;
                    case 6:
                        {
                            fileIn = @"D:\EdgeList.INP";
                            fileOut = @"D:\EdgeList.OUT";
                            EdgeList edgeList = new EdgeList();
                            edgeList.Read_EdgeList(fileIn);
                            edgeList.Print_EdgeList(fileOut);
                        }
                        break;
                    case 7:
                        {
                            fileIn = @"D:\EdgeList.INP";
                            fileOut = @"D:\EdgeList.OUT";
                            EdgeList edgeList = new EdgeList();
                            edgeList.Read_EdgeList(fileIn);
                            edgeList.Print_Degree_of_EdgeList(fileOut);
                        }
                        break;
                    case 8:
                        {
                            fileIn = @"D:\Canh2Ke.INP";
                            fileOut = @"D:\Canh2Ke.OUT";
                            EdgeList edgeList = new EdgeList();
                            edgeList.Convert_From_EdgeList_To_AdjacencyList(fileIn, fileOut);
                        }
                        break;
                    case 9:
                        {
                            fileIn = @"D:\Ke2Canh.INP";
                            fileOut = @"D:\Ke2Canh.OUT";
                            AdjacencyList adjacencyList = new AdjacencyList();
                            adjacencyList.Convert_From_AdjacencyList_To_EdgeList(fileIn, fileOut);
                        }
                        break;
                    case 10:
                        {
                            fileIn = @"D:\MaTranKe2DSKe.INP";
                            fileOut = @"D:\MaTranKe2DSKe.OUT";
                            AdjacencyMatrix adjacencyMatrix = new AdjacencyMatrix();
                            adjacencyMatrix.Convert_From_AdjacencyMatrix_To_AdjacencyList(fileIn, fileOut);
                        }
                        break;
                    case 11:
                        {
                            fileIn = @"D:\MaTranKe2DSCanh.INP";
                            fileOut = @"D:\MaTranKe2DSCanh.OUT";
                            AdjacencyMatrix adjacencyMatrix = new AdjacencyMatrix();
                            adjacencyMatrix.Convert_From_AdjacencyMatrix_To_EdgeList(fileIn, fileOut);
                        }
                        break;
                    case 12:
                        {
                            fileIn = @"D:\DSKe2Canh.INP";
                            fileOut = @"D:\DSKe2Canh.OUT";
                            AdjacencyList adjacencyList = new AdjacencyList();
                            adjacencyList.ReverseGraph_AdjacencyList(fileIn, fileOut);
                        }
                        break;
                    case 13:
                        {
                            fileIn = @"D:\TrungBinhCanh.INP";
                            fileOut = @"D:\TrungBinhCanh.OUT";
                            EdgeWeightedList edgeWeightedList = new EdgeWeightedList();
                            edgeWeightedList.Read_EdgeList(fileIn);
                            edgeWeightedList.Print_EdgeList(fileOut);
                        }
                        break;
                    case 14:
                        {
                            fileIn = @"D:\TrungBinhCanh.INP";
                            fileOut = @"D:\TrungBinhCanh.OUT";
                            EdgeWeightedList edgeWeightedList = new EdgeWeightedList();
                            edgeWeightedList.Read_EdgeList(fileIn);
                            edgeWeightedList.In_Do_Dai_Trung_Binh_Cua_Canh(fileOut);
                        }
                        break;
                    case 15:
                        {
                            fileIn = @"D:\BFS_Bai1.INP";
                            fileOut = @"D:\BFS_Bai1.OUT";
                            AdjacencyList adjacencyList = new AdjacencyList();
                            adjacencyList.Read_AdjacencyList(fileIn);
                            Console.Write("Nhap dinh bat dau duyet: ");
                            int start = int.Parse(Console.ReadLine());
                            adjacencyList.Print_BFS(start, fileOut);
                        }
                        break;
                    case 16:
                        {
                            fileIn = @"D:\BFS_Bai2.INP";
                            fileOut = @"D:\BFS_Bai2.OUT";
                            AdjacencyList adjacencyList = new AdjacencyList();
                            adjacencyList.InCacDinhLienThongVoi_S(fileIn, fileOut);
                        }
                        break;
                    case 17:
                        {
                            fileIn = @"D:\TimDuong.INP";
                            fileOut = @"D:\TimDuong.OUT";
                            AdjacencyList adjacencyList = new AdjacencyList();
                            adjacencyList.InDuongDi_Tu_X_Den_Y(fileIn, fileOut);
                        }
                        break;
                    case 18:
                        {
                            fileIn = @"D:\LienThong.INP";
                            fileOut = @"D:\LienThong.OUT";
                            AdjacencyList adjacencyList = new AdjacencyList();
                            adjacencyList.KiemTraDoThiLienThong_BFS(fileIn, fileOut);
                        }
                        break;
                    case 19:
                        {
                            fileIn = @"D:\DemLienThong.INP";
                            fileOut = @"D:\DemLienThong.OUT";
                            AdjacencyList adjacencyList = new AdjacencyList();
                            adjacencyList.DemSoMienLienThong(fileIn, fileOut);
                        }
                        break;
                    case 20:
                        fileIn = @"D:\MienLienThongBFS.INP"; fileOut = @"D:\MienLienThongBFS.OUT";
                        new AdjacencyList().InDanhSachCacMienLienThong(fileIn, fileOut);
                        break;
                    case 21:
                        fileIn = @"D:\CanhCau.INP"; fileOut = @"D:\CanhCau.OUT";
                        new AdjacencyList().InKiemTraCanhCau(fileIn, fileOut);
                        break;
                    case 22:
                        fileIn = @"D:\DinhKhop.INP"; fileOut = @"D:\DinhKhop.OUT";
                        new AdjacencyList().InKiemTraDinhKhop(fileIn, fileOut);
                        break;
                    case 23:
                        fileIn = @"D:\Grid.INP"; fileOut = @"D:\Grid.OUT";
                        Grid grid = new Grid();
                        int sX, sY, eX, eY;
                        grid.ReadGridFromFile(fileIn, out sX, out sY, out eX, out eY);
                        grid.PrintGrid();
                        break;
                    case 24:
                        fileIn = @"D:\Grid.INP"; fileOut = @"D:\Grid.OUT";
                        new Grid().In_BFS_Grid(fileIn, fileOut);
                        break;
                    case 25:
                        fileIn = @"D:\BONCHUA.INP"; fileOut = @"D:\BONCHUA.OUT";
                        AdjacencyMatrix am = new AdjacencyMatrix();
                        am.ReadMaxtrix(fileIn);
                        am.InBonChua(fileOut);
                        break;
                    case 26:
                        {
                            fileIn = @"D:\DFS_Example.INP";
                            fileOut = @"D:\DFS_Example.OUT";
                            AdjacencyList adjacencyList = new AdjacencyList();
                            adjacencyList.In_DFS_DeQuy(fileIn, fileOut);
                            break;
                        }
                    case 27:
                        {
                            fileIn = @"D:\DFS_Example.INP";
                            fileOut = @"D:\DFS_Example.OUT";
                            AdjacencyList adjacencyList = new AdjacencyList();
                            adjacencyList.In_DFS_Stack(fileIn, fileOut);
                            break;
                        }
                    case 28:
                        {
                            fileIn = @"D:\DFS.INP";
                            fileOut = @"D:\DFS.OUT";
                            AdjacencyList adjacencyList = new AdjacencyList();
                            adjacencyList.In_Bai1_Buoi5(fileIn, fileOut);
                            break;
                        }
                    case 29:
                        {
                            fileIn = @"D:\TimDuongDFS.INP";
                            fileOut = @"D:\TimDuongDFS.OUT";
                            AdjacencyList adjacencyList = new AdjacencyList();
                            adjacencyList.In_Bai2_Buoi5(fileIn, fileOut);
                            break;
                        }
                    case 30:
                        {
                            fileIn = @"D:\PhanDoi.INP";
                            fileOut = @"D:\PhanDoi.OUT";
                            AdjacencyList adjacencyList = new AdjacencyList();
                            adjacencyList.In_Bai3_Buoi5(fileIn, fileOut);
                            break;
                        }
                    case 31:
                        {
                            fileIn = @"D:\ChuTrinh.INP";
                            fileOut = @"D:\ChuTrinh.OUT";
                            AdjacencyList adjacencyList = new AdjacencyList();
                            adjacencyList.In_Bai4_Buoi5(fileIn, fileOut);
                            break;
                        }
                    case 32:
                        {
                            fileIn = @"D:\TopoSort.INP";
                            fileOut = @"D:\TopoSort.OUT";
                            AdjacencyList adjacencyList = new AdjacencyList();
                            adjacencyList.In_Bai5_Buoi5(fileIn, fileOut);
                            break;
                        }
                    case 33:
                        {
                            fileIn = @"D:\Dijkstra.INP";
                            fileOut = @"D:\Dijkstra.OUT";
                            EdgeWeightedList edgeWeightedList = new EdgeWeightedList();
                            edgeWeightedList.In_Bai1_Buoi6(fileIn, fileOut);
                            break;
                        }
                    case 34:
                        {
                            fileIn = @"D:\NganNhatX.INP";
                            fileOut = @"D:\NganNhatX.OUT";
                            EdgeWeightedList edgeWeightedList = new EdgeWeightedList();
                            edgeWeightedList.In_Bai2_Buoi6(fileIn, fileOut);
                            break;
                        }
                    case 35:
                        {
                            fileIn = @"D:\FloydWarshall.INP";
                            fileOut = @"D:\FloydWarshall.OUT";
                            AdjacencyMatrix adjacencymatrix = new AdjacencyMatrix();
                            adjacencymatrix.In_Bai3_Buoi6(fileIn, fileOut);
                            break;
                        }
                    case 36:
                        {
                            fileIn = @"D:\RaBien.INP";
                            fileOut = @"D:\RaBien.OUT";
                            Grid grid1 = new Grid();
                            grid1.In_Bai4_Buoi6(fileIn, fileOut);
                            break;
                        }
                    case 37:
                        {
                            fileIn = @"D:\ChonThanhPho.INP";
                            fileOut = @"D:\ChonThanhPho.OUT";
                            AdjacencyMatrix am2 = new AdjacencyMatrix();
                            am2.In_Bai5_Buoi6(fileIn, fileOut);
                            break;
                        }
                } 
            } while (choice != 0);
        }
    }
}