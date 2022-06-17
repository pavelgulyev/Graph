using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace K_R
{
    class Color
    {
        public List<int> Color_V;

        public Color()
        {
            Color_V = new List<int>();
        }        
        public void ColoringGraph(ref List<Color> Color_Vertex, int N, ref int[,] t_adj)
        {
            List<int> notUsedV = new List<int>(); 
            for (int i = 0; i < N; i++)
            {
                notUsedV.Add(i);
            }
            int noAdjV;

            for (int i = 0; i < notUsedV.Count; i++)
            {
                
                Color_Vertex.Add(new Color());
                //пока строка не будет 111111
                while (adj_q(t_adj, i, N) == false)
                {
                    
                    Color_Vertex[Color_Vertex.Count - 1].Color_V.Add(i);  
                    noAdjV = noAdj(t_adj, i,N); 
                    if (noAdjV != -1)                    {
                        editing(ref t_adj, i, plus(ref t_adj, i, noAdjV,N),N);
                        delete(ref t_adj, noAdjV,N); 
                                             
                        Color_Vertex[Color_Vertex.Count - 1].Color_V.Add(noAdjV);
                        notUsedV.Remove(noAdjV);
                    }
                }
                
            }

        }
        //Замена строки матрицы
        void editing(ref int[,] a, int v, int[] p, int N)
        {
            for (int i = 0; i < N; i++)
            {
                a[v, i] = p[i];
            }
        }
        //Сложение строк матрицы
        int[] plus(ref int[,] a, int v1, int v2, int N)
        {
            int[] plus = new int[N];
            int sum;
            for (int i = 0; i < N; i++)
            {
                sum = a[v2, i] + a[v1, i];
                if (sum == 2)
                {
                    plus[i] = 1;
                }
                else
                {
                    plus[i] = sum;
                }
            }            
            return plus;
        }
        //вершина со всеми смежна 
        bool adj_q(int[,] a, int v1, int n)
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[v1, i] == 1)
                {
                    count++;
                }
            }
            if (count == n)
            {
                return true;
            }
            else
                return false;
        }
        //Удаление строчки из матрицы 
        void delete(ref int[,] a, int v, int N)
        {            
            for (int i = 0; i < N; i++)
            {
                a[v, i] = 1;
            }
        }
        //Вершина не смежная 
        int noAdj(int[,] a, int v, int N)
        {
            int noAdj = -1;
            for (int i = 0; i < N; i++)
            {
                if (a[v, i] == 0)
                {                    
                    noAdj = i;
                }
            }
            return noAdj;
        }

    }
    
    class Graph
    {
        List<Vertex> Tops;
        List<Edge> Edg;
        int[,] t_adj;
        public List<Color> color;
        Bitmap bitmap;
        Pen blackPen;
        Pen redPen;
        Pen darkGoldPen;
        Graphics gr;
        Font fo;
        Brush br;
        PointF point;
        public int R = 20; //радиус окружности вершины       
        Color clr;
        public Graph(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            gr = Graphics.FromImage(bitmap);
            clearSheet();
            blackPen = new Pen(System.Drawing.Color.Black);
            blackPen.Width = 2;
            redPen = new Pen(System.Drawing.Color.Red);
            redPen.Width = 2;
            darkGoldPen = new Pen(System.Drawing.Color.Brown);
            darkGoldPen.Width = 2;
            fo = new Font("Arial", 15);
            br = Brushes.Black;
            Tops = new List<Vertex>();
            Edg = new List<Edge>();
            color = new List<Color>();
            clr = new Color();
        }

        public List<Vertex> List_V
        {
            get
            {
                return Tops;
            }
            set
            {
                Tops = value;
            }
        }
        public List<Edge> List_E
        {
            get
            {
                return Edg;
            }
            set
            {
                Edg = value;
            }
        }
        public int[,] Matrixadj
        {
            get
            {
                return t_adj;
            }
            set
            {
                t_adj = value;
            }
        }
        public Color Coloring
        {
            get
            {
                return clr;
            }
            set
            {
                clr = value;
            }
        }
        
        public Bitmap GetBitmap()
        {
            return bitmap;
        }
        public int[,] GetTableAdj()
        {
            return t_adj;
        }        
        public void clearSheet()
        {
            gr.Clear(System.Drawing.Color.White);
        }
        //Рисуем Вершину
        public void drawVertex(int x, int y, string number)
        {
            gr.FillEllipse(Brushes.White, (x - R), (y - R), 2 * R, 2 * R);
            gr.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
            point = new PointF(x - 9, y - 9);
            gr.DrawString(number, fo, br, point);
        }

        public void drawSelectedVertex(int x, int y)
        {
            gr.DrawEllipse(redPen, (x - R), (y - R), 2 * R, 2 * R);
        }
        //Рисуем Ребро
        public void drawEdge(Vertex V1, Vertex V2, Edge E, int numberE)
        {
            if (E.v1 == E.v2)
            {
                gr.DrawArc(darkGoldPen, (V1.x - 2 * R), (V1.y - 2 * R), 2 * R, 2 * R, 90, 270);
                point = new PointF(V1.x - (int)(2.75 * R), V1.y - (int)(2.75 * R));
                drawVertex(V1.x, V1.y, (E.v1 + 1).ToString());
            }
            else
            {
                Pen pen = new Pen(System.Drawing.Color.Brown, 4.0F);                                
                gr.DrawLine(pen, V1.x, V1.y, V2.x, V2.y);
                point = new PointF((V1.x + V2.x) / 2, (V1.y + V2.y) / 2);
                drawVertex(V1.x, V1.y, (E.v1 + 1).ToString());
                drawVertex(V2.x, V2.y, (E.v2 + 1).ToString());
            }
        }
        public void drawALLGraph()
        {
            //рисуем ребра
            for (int i = 0; i < Edg.Count; i++)
            {
                if (Edg[i].v1 == Edg[i].v2)
                {
                   
                    gr.DrawArc(darkGoldPen, (Tops[Edg[i].v1].x - 2 * R), (Tops[Edg[i].v1].y - 2 * R), 2 * R, 2 * R, 90, 270);
                    point = new PointF(Tops[Edg[i].v1].x - (int)(2.75 * R), Tops[Edg[i].v1].y - (int)(2.75 * R));
                    
                }
                else
                {
                    Pen pen = new Pen(System.Drawing.Color.Brown, 4.0F);                                  
                    gr.DrawLine(darkGoldPen, Tops[Edg[i].v1].x, Tops[Edg[i].v1].y, Tops[Edg[i].v2].x, Tops[Edg[i].v2].y);
                    point = new PointF((Tops[Edg[i].v1].x + Tops[Edg[i].v2].x) / 2, (Tops[Edg[i].v1].y + Tops[Edg[i].v2].y) / 2);
                }
            }
            //рисуем вершины
            for (int i = 0; i < Tops.Count; i++)
            {
                drawVertex(Tops[i].x, Tops[i].y, (i + 1).ToString());
            }
        }

        //заполняет матрицу смежности
        public void fillAdjacencyMatrix()
        {
            t_adj = new int[Tops.Count, Tops.Count];
            for (int i = 0; i < Tops.Count; i++)
                for (int j = 0; j < Tops.Count; j++)
                    t_adj[i, j] = 0;
            for (int i = 0; i < Edg.Count; i++)
            {
                t_adj[Edg[i].v1, Edg[i].v2] = 1;
                t_adj[Edg[i].v2, Edg[i].v1] = 1;
            }
        }

        public void drawColoringVertex(int x, int y, string number, Brush brush)
        {
            gr.FillEllipse(brush, (x - R), (y - R), 2 * R, 2 * R);
            gr.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
            point = new PointF(x - 9, y - 9);
            gr.DrawString(number, fo, br, point);
        }
        public void drawColoringGraph()
        {            
            for (int i = 0; i < Tops.Count; i++)
                for (int j = 0; j < Tops.Count; j++)
                    if (i == j)
                        t_adj[i, j] = 1;
            clr.ColoringGraph(ref color,Tops.Count, ref t_adj);
            Brush[] brushes;
            brushes = new Brush[color.Count+1];
            switch (color.Count)
            {
                case 2:
                    brushes[0] = Brushes.Green;
                    brushes[1] = Brushes.Red;
                    break;
                case 3:
                    brushes[0] = Brushes.Green;
                    brushes[1] = Brushes.Red;
                    brushes[2] = Brushes.Yellow;
                    break;
                case 4:
                    brushes[0] = Brushes.Green;
                    brushes[1] = Brushes.Red;
                    brushes[2] = Brushes.Yellow;
                    brushes[3] = Brushes.Blue;
                    break;
                case 5:
                    brushes[0] = Brushes.Green;
                    brushes[1] = Brushes.Red;
                    brushes[2] = Brushes.Yellow;
                    brushes[3] = Brushes.Blue;
                    brushes[4] = Brushes.Orange;
                    break;
            }
            //рисуем ребра
            for (int i = 0; i < Edg.Count; i++)
            {
                if (Edg[i].v1 == Edg[i].v2)
                {
                    gr.DrawArc(darkGoldPen, (Tops[Edg[i].v1].x - 2 * R), (Tops[Edg[i].v1].y - 2 * R), 2 * R, 2 * R, 90, 270);
                    point = new PointF(Tops[Edg[i].v1].x - (int)(2.75 * R), Tops[Edg[i].v1].y - (int)(2.75 * R));

                }
                else
                {
                    gr.DrawLine(darkGoldPen, Tops[Edg[i].v1].x, Tops[Edg[i].v1].y, Tops[Edg[i].v2].x, Tops[Edg[i].v2].y);
                    point = new PointF((Tops[Edg[i].v1].x + Tops[Edg[i].v2].x) / 2, (Tops[Edg[i].v1].y + Tops[Edg[i].v2].y) / 2);
                }
            }            
            //рисуем вершины
            for (int i = 0; i < Tops.Count; i++)
            {
                for (int j = 0; j < color.Count; j++)
                {
                    for (int d = 0; d < color[j].Color_V.Count; d++)
                    {
                        if (color[j].Color_V[d] == i)
                        {
                            drawColoringVertex(Tops[i].x, Tops[i].y, (i + 1).ToString(), brushes[j]);
                        }
                    }
                }
            }
        }
    }    
    class Edge
    {
        public int v1, v2;
        public Edge(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
    class Vertex
    {
        public int x, y;
        public int number;        
        public Vertex(int x, int y, int number)
        {
            this.x = x;
            this.y = y;
            this.number = number;
        }
    }

}
