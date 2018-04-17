using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleWindows
{
    public partial class Form1 : Form
    {
        Pen thePen;
        Brush theBrush;
        Font theFont;
        List<Image> imgList;
        private int puzzleSize = 16;
        int imgWidth = 100;
        int imgHeight = 100;
        PuzzleGameEngine pge;

        public Form1()
        {
            InitializeComponent();

            imgList = new List<Image>();

            for(int i = 0; i < puzzleSize; i++)
            {
                string fileName = string.Format("pic_{0}.png",(char)('a'+i));
                Image tmpI = Image.FromFile(fileName);
                imgList.Add(tmpI);
            }
            
            thePen = new Pen(Color.Red);
            theBrush = new SolidBrush(Color.Green);
            theFont = new Font("굴림", 15);

            pge = new PuzzleGameEngine();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            String strTime = String.Format("Time:{0:D3}", 99);

            e.Graphics.DrawRectangle(thePen, 0, 0, 100, 10);
            e.Graphics.DrawString(strTime, theFont, theBrush, 0, 10);
            for(int i = 0; i < 16; i++)
            {
                if(pge.GetViewIndex(i) != puzzleSize-1)
                    e.Graphics.DrawImage(imgList[pge.GetViewIndex(i)], imgWidth * (i%4)+50, imgHeight * (i/4)+50, imgWidth, imgHeight);

            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int tmpX = e.X;
            int tmpY = e.Y;
            /*int x = 50;
            int tmp=0;
            for (int i = 0; i < 4; i++)
            {
                if (tmpX > (x+i*100) && tmpX < (x+i*100)+100)
                {
                    if (tmpY > 50 && tmpY < 150)
                    {
                        tmp = i;
                    }
                    else if (tmpY > 150 && tmpY < 250)
                    {
                        tmp = i+4;
                    }
                    else if (tmpY > 250 && tmpY < 350)
                    {
                        tmp = i+8;

                    }
                    else if (tmpY > 350 && tmpY < 450)
                    {
                        tmp = i+12;
                    }
                }
                pge.Change(tmp);
            }*/
            if (!(50 <= tmpX && tmpX <= 4 * imgWidth + 50 && 50 <= tmpY && tmpY <= 4 * Height + 50))
            {
                return;
            }
            tmpX -= 50;
            tmpY -= 50;
            tmpX /= imgWidth;
            tmpY /= imgHeight;
            int index = tmpX + tmpY * 4;

            pge.Change(index);
            Invalidate();

            //다 맞췄으면,메시지 박스 ㅊㅋㅊㅋ
            //창닫자
            if (pge.isEnd())
            {
                MessageBox.Show("추카추카");
                Close();
            }
        }

        
    }
}
