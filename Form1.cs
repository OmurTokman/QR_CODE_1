using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode;
using MessagingToolkit.QRCode.Codec;
using SolidWorks.Interop;
using SolidWorks.Interop.sldworks;
using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;
using SolidWorks.Interop.swconst;
using System.Runtime.InteropServices;


namespace QR_CODE_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        QRCodeEncoder code = new QRCodeEncoder();
        Image rsm;

        //public SldWorks swApp;
        public partial class SolidWorksMacro
        {
            IModelDoc2 swModel;
            IFeature swFeat;
            ISketchPicture swSketchPicture;
            ISelectionMgr swSelMgr;
            bool boolstatus;
            double width;
            double height;
            double angle;
            public void Main()
            {
                swModel = swApp.IActiveDoc2;
                swSelMgr = swModel.ISelectionManager;
                //swModel.SketchManager.InsertSketch(true);
                swSketchPicture = swModel.SketchManager.InsertSketchPicture2("C:\\Users\\Omur\\Desktop\\QR CODE-png.png", false);
                //swModel.SketchManager.InsertSketch(true);
            }
             public SldWorks swApp;
         }
            private void Form1_Load(object sender, EventArgs e)
            {
            }
            private void button1_Click(object sender, EventArgs e)
            {
                rsm = code.Encode(textBox1.Text);
                pictureBox1.Image = rsm;
            }

            private void button2_Click(object sender, EventArgs e)
            {
                SaveFileDialog sfd = new SaveFileDialog();//yeni bir kaydetme diyaloğu oluşturuyoruz.

                sfd.Filter = "PNG (*.png) | *.png";
                //    "jpeg (*.jpg)|*.jpg   |Bitmap(*.bmp)|*.bmp";    //.bmp veya .jpg olarak kayıt imkanı sağlıyoruz.
                //sfd.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG" +
                //"|All files(*.*)|*.*";
                sfd.Title = "Kayıt";//diğaloğumuzun başlığını belirliyoruz.

                sfd.FileName = "QR CODE";//kaydedilen resmimizin adını 'resim' olarak belirliyoruz.

                DialogResult sonuç = sfd.ShowDialog();

                if (sonuç == DialogResult.OK)
                {
                    pictureBox1.Image.Save(sfd.FileName);//Böylelikle resmi istediğimiz yere kaydediyoruz.
                }
            }

            private void button3_Click(object sender, EventArgs e)
            {

            SolidWorksMacro swclass = new SolidWorksMacro();
            swclass.Main();

            // Call Main

        }

    }
    }

