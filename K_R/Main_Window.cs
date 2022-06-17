using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace K_R
{
    public partial class Main_Window : Form
    {

        Graph Graph;       
        int selected1; //выбранные вершины, для соединения линиями
        int selected2;
        int act_Color=0;
        public Main_Window()
        {
            InitializeComponent();           
            Graph = new Graph(sheet.Width, sheet.Height);          
            sheet.Image = Graph.GetBitmap();
        }
        // кнопка "рисовать вершину"
        private void btn_Vertex_Click(object sender, EventArgs e)
        {
            btn_Vertex.Enabled = false;
            btn_Cursor.Enabled = true;
            btn_Edge.Enabled = true;
            btn_Delete.Enabled = true;
            Graph.clearSheet();
            Graph.drawALLGraph();
            sheet.Image = Graph.GetBitmap();
        }

        private void btn_Adj_Click(object sender, EventArgs e)
        {
            createAdjAndOut();
        }

        
        private void createAdjAndOut()
        {           
            Graph.fillAdjacencyMatrix();
            listBox1.Items.Clear();
            string sOut = "    ";
            for (int i = 0; i < Graph.List_V.Count; i++)
                sOut += (i + 1) + " ";
            listBox1.Items.Add(sOut);
            for (int i = 0; i < Graph.List_V.Count; i++)
            {
                sOut = (i + 1) + " | ";
                for (int j = 0; j < Graph.List_V.Count; j++)
                    sOut += Graph.GetTableAdj()[i, j] + " ";
                listBox1.Items.Add(sOut);
            }
        }
        // кнопка удалить всё
        private void btn_All_Delete_Click(object sender, EventArgs e)
        {
            btn_Cursor.Enabled = true;
            btn_Vertex.Enabled = true;
            btn_Edge.Enabled = true;
            btn_Delete.Enabled = true;
            Graph.List_V.Clear();
            Graph.List_E.Clear();
            Graph.clearSheet();
            sheet.Image = Graph.GetBitmap();
        }
        //кнопка выбрать вершину, ищем степень вершины
        private void btn_Cursor_Click(object sender, EventArgs e)
        {
            btn_Cursor.Enabled = false;
            btn_Vertex.Enabled = true;
            btn_Edge.Enabled = true;
            btn_Delete.Enabled = true;
            Graph.clearSheet();
            Graph.drawALLGraph();
            sheet.Image = Graph.GetBitmap();
            selected1 = -1;
        }
        // кнопка рисовать ребро
        private void btn_Edge_Click(object sender, EventArgs e)
        {
            btn_Edge.Enabled = false;
            btn_Cursor.Enabled = true;
            btn_Vertex.Enabled = true;
            btn_Delete.Enabled = true;
            Graph.clearSheet();
            Graph.drawALLGraph();
            sheet.Image = Graph.GetBitmap();
            selected1 = -1;
            selected2 = -1;
        }
        //нажата кнопка удалить элемент
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            btn_Delete.Enabled = false;
            btn_Cursor.Enabled = true;
            btn_Vertex.Enabled = true;
            btn_Edge.Enabled = true;
            Graph.clearSheet();
            Graph.drawALLGraph();
            sheet.Image = Graph.GetBitmap();
        }
        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {
            //нажата кнопка выбрать вершину, ищем степень вершины
            if (btn_Cursor.Enabled == false)
            {
                for (int i = 0; i < Graph.List_V.Count; i++)
                {
                    if (Math.Pow((Graph.List_V[i].x - e.X), 2) + Math.Pow((Graph.List_V[i].y - e.Y), 2) <= Graph.R * Graph.R)
                    {
                        if (selected1 != -1)
                        {
                            selected1 = -1;
                            Graph.clearSheet();
                            Graph.drawALLGraph();
                            sheet.Image = Graph.GetBitmap();
                        }
                        else
                        {
                            Graph.drawSelectedVertex(Graph.List_V[i].x, Graph.List_V[i].y);
                            selected1 = i;
                            sheet.Image = Graph.GetBitmap();
                            createAdjAndOut();
                            listBox1.Items.Clear();
                            int degree = 0;
                            for (int j = 0; j < Graph.List_V.Count; j++)
                                degree += Graph.Matrixadj[selected1, j];
                            listBox1.Items.Add("Степень вершины №" + (selected1 + 1) + " равна " + degree);
                            break;
                        }
                    }
                }
            }
            //нажата кнопка рисовать вершину
            if (btn_Vertex.Enabled == false)
            {
                Graph.List_V.Add(new Vertex(e.X, e.Y, Graph.List_V.Count));
                Graph.drawVertex(e.X, e.Y, Graph.List_V.Count.ToString());
                sheet.Image = Graph.GetBitmap();
            }
            //нажата кнопка рисовать ребро
            if (btn_Edge.Enabled == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < Graph.List_V.Count; i++)
                    {
                        if (Math.Pow((Graph.List_V[i].x - e.X), 2) + Math.Pow((Graph.List_V[i].y - e.Y), 2) <= Graph.R * Graph.R)
                        {
                            if (selected1 == -1)
                            {
                                Graph.drawSelectedVertex(Graph.List_V[i].x, Graph.List_V[i].y);
                                selected1 = i;
                                sheet.Image = Graph.GetBitmap();
                                break;
                            }
                            if (selected2 == -1)
                            {
                                Graph.drawSelectedVertex(Graph.List_V[i].x, Graph.List_V[i].y);
                                selected2 = i;
                                Graph.List_E.Add(new Edge(selected1, selected2));                                
                                Graph.drawEdge(Graph.List_V[selected1], Graph.List_V[selected2], Graph.List_E[Graph.List_E.Count - 1], Graph.List_E.Count - 1);
                                selected1 = -1;
                                selected2 = -1;
                                sheet.Image = Graph.GetBitmap();
                                break;
                            }
                        }
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    if ((selected1 != -1) &&
                        (Math.Pow((Graph.List_V[selected1].x - e.X), 2) + Math.Pow((Graph.List_V[selected1].y - e.Y), 2) <= Graph.R * Graph.R))
                    {
                        Graph.drawVertex(Graph.List_V[selected1].x, Graph.List_V[selected1].y, (selected1 + 1).ToString());
                        selected1 = -1;
                        sheet.Image = Graph.GetBitmap();
                    }
                }
            }
            //нажата кнопка удалить элемент
            if (btn_Delete.Enabled == false)
            {
                bool flag = false; //удалили ли что-нибудь по ЭТОМУ клику
                //ищем, возможно была нажата вершина
                for (int i = 0; i < Graph.List_V.Count; i++)
                {
                    if (Math.Pow((Graph.List_V[i].x - e.X), 2) + Math.Pow((Graph.List_V[i].y - e.Y), 2) <= Graph.R * Graph.R)
                    {
                        for (int j = 0; j < Graph.List_E.Count; j++)
                        {
                            if ((Graph.List_E[j].v1 == i) || (Graph.List_E[j].v2 == i))
                            {
                                Graph.List_E.RemoveAt(j);
                                j--;
                            }
                            else
                            {
                                if (Graph.List_E[j].v1 > i) Graph.List_E[j].v1--;
                                if (Graph.List_E[j].v2 > i) Graph.List_E[j].v2--;
                            }
                        }
                        Graph.List_V.RemoveAt(i);
                        flag = true;
                        break;
                    }
                }
                //ищем, возможно было нажато ребро
                if (!flag)
                {
                    for (int i = 0; i < Graph.List_E.Count; i++)
                    {
                        if (Graph.List_E[i].v1 == Graph.List_E[i].v2) //если это петля
                        {
                            if ((Math.Pow((Graph.List_V[Graph.List_E[i].v1].x - Graph.R - e.X), 2) + Math.Pow((Graph.List_V[Graph.List_E[i].v1].y - Graph.R - e.Y), 2) <= ((Graph.R + 2) * (Graph.R + 2))) &&
                                (Math.Pow((Graph.List_V[Graph.List_E[i].v1].x - Graph.R - e.X), 2) + Math.Pow((Graph.List_V[Graph.List_E[i].v1].y - Graph.R - e.Y), 2) >= ((Graph.R - 2) * (Graph.R - 2))))
                            {
                                Graph.List_E.RemoveAt(i);
                                flag = true;
                                break;
                            }
                        }
                        else //не петля
                        {
                            if (((e.X - Graph.List_V[Graph.List_E[i].v1].x) * (Graph.List_V[Graph.List_E[i].v2].y - Graph.List_V[Graph.List_E[i].v1].y) / (Graph.List_V[Graph.List_E[i].v2].x - Graph.List_V[Graph.List_E[i].v1].x) + Graph.List_V[Graph.List_E[i].v1].y) <= (e.Y + 4) &&
                                ((e.X - Graph.List_V[Graph.List_E[i].v1].x) * (Graph.List_V[Graph.List_E[i].v2].y - Graph.List_V[Graph.List_E[i].v1].y) / (Graph.List_V[Graph.List_E[i].v2].x - Graph.List_V[Graph.List_E[i].v1].x) + Graph.List_V[Graph.List_E[i].v1].y) >= (e.Y - 4))
                            {
                                if ((Graph.List_V[Graph.List_E[i].v1].x <= Graph.List_V[Graph.List_E[i].v2].x && Graph.List_V[Graph.List_E[i].v1].x <= e.X && e.X <= Graph.List_V[Graph.List_E[i].v2].x) ||
                                    (Graph.List_V[Graph.List_E[i].v1].x >= Graph.List_V[Graph.List_E[i].v2].x && Graph.List_V[Graph.List_E[i].v1].x >= e.X && e.X >= Graph.List_V[Graph.List_E[i].v2].x))
                                {
                                    Graph.List_E.RemoveAt(i);
                                    flag = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                //если что-то было удалено, то обновляем граф на экране
                if (flag)
                {
                    Graph.clearSheet();
                    Graph.drawALLGraph();
                    sheet.Image = Graph.GetBitmap();
                }
            }           

        }
        //кнопка раскраска графа
        private void btn_Pait_Click(object sender, EventArgs e)
        {
            if ((Graph.List_V.Count > 0) && (Graph.List_E.Count > 0))
            {
                Graph.clearSheet();
                Graph.fillAdjacencyMatrix();
                listBox1.Items.Clear();
                Graph.drawColoringGraph();
                sheet.Image = Graph.GetBitmap();
                act_Color = 1;
            }
            else
            {
                MessageBox.Show("Сначало нарисуйте граф", "Ошибка",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error,
        MessageBoxDefaultButton.Button1,
        MessageBoxOptions.DefaultDesktopOnly);

            }
        }
        //кнопка функция Гранди
        private void btn_Grandi_Click(object sender, EventArgs e)
        {
            if (act_Color == 1)
            {
                listBox1.Items.Clear();
                string sOut = "   ";               
                listBox1.Items.Add(sOut);
                for (int i = 0; i < Graph.color.Count; i++)
                {
                    sOut ="Цвет "+ (i+1)+ ": ";
                    for (int j = 0; j < Graph.color[i].Color_V.Count; j++)
                        if (j == Graph.color[i].Color_V.Count-1)
                        {
                            sOut += ++Graph.color[i].Color_V[j] + " ";
                        }
                    else
                        {
                            sOut += ++Graph.color[i].Color_V[j] + " и ";
                        }
                    listBox1.Items.Add(sOut);
                }     
            }
            else
            {
                MessageBox.Show(
        "Сначало раскрасьте граф",
        "Ошибка",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error,
        MessageBoxDefaultButton.Button1,
        MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}