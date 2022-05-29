using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision
{
    public partial class FormURL : Form
    {
        public static event EventHandler DownComplete;


        public FormURL()
        {
            InitializeComponent();

            progressBar1.Visible = false;
            progressBar1.MarqueeAnimationSpeed = 10;
        }

        async void buttonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) return;

            buttonOK.Enabled = false;
            buttonCancel.Enabled = false;

            progressBar1.Visible = true;
     
            string str = textBox1.Text;

            Task<Bitmap> task = Task.Run(() =>
            {
                byte[] imageBytes = new WebClient().DownloadData(str);

                Bitmap Bitmap = new Bitmap(new MemoryStream(imageBytes));

                return Bitmap;
            });

            Bitmap iscom = await task;

            DownComplete?.Invoke(iscom, null);

            Close();
        }

        void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
