using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piramida_i_kvadrat
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public partial class Form1 : Form
    {
        private object openGLControl1;
        private float rtri;

        public Form1()
        {
            InitializeComponent();
        }

        private static object GetDebuggerDisplay()
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            float rtri = 0;
        }

        private object GetOpenGLControl1()
        {
            return openGLControl1;
        }

        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args, object openGLControl1)
        {
            // Создаем экземпляр
            OpenGL gl = openGLControl1.OpenGL;
            // Очистка экрана и буфера глубин
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT);
            gl.Clear(OpenGL.GL_DEPTH_BUFFER_BIT);

            // Пирамида /////////////////////////////
            // Сбрасываем модельно-видовую матрицу
            gl.LoadIdentity();
            // Сдвигаем перо влево от центра и вглубь экрана
            gl.Translate(0.0f, 0.0f, -5.0f);
            // Вращаем пирамиду вокруг ее оси Y
            gl.Rotate(rtri, 0.0f, 1.0f, 0.0f);
            // Рисуем треугольники - грани пирамиды
            gl.Begin(OpenGL.GL_TRIANGLES);

            // Front
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            // Right
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(1.0f, -1.0f, -1.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            // Back
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(1.0f, -1.0f, -1.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);
            // Left
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);

            gl.End();
            // Контроль полной отрисовки следующего изображения
            gl.Flush();
            // Меняем угол поворота 
            rtri -= 3.0f;
        }
    }
}