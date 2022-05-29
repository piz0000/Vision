using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Vision
{
    public partial class FormMain : Form
    {
        Bitmap LoadImage = null;
        Bitmap RotateFlipImage = null;

        VisionType VisionType = VisionType.Gray;
        RotateFlipType RotateFlip
        {
            get => (RotateFlipType)Enum.Parse(typeof(RotateFlipType), comboBoxRotateFlip.SelectedItem.ToString());
        }

        public class MouseInfo
        {
            public bool IsHover = false;
            public bool IsDown = false;
        }
        MouseInfo MouseImageLoad = new MouseInfo();
        MouseInfo MouseImageConvert = new MouseInfo();


        public FormMain()
        {
            InitializeComponent();

            Text = GetType().Namespace;

            buttonImageLoad.Click += ButtonImageLoad_Click;
            buttonURL.Click += ButtonURL_Click;
            buttonImageSave.Click += ButtonImageSave_Click;

            comboBoxType.DataSource = Enum.GetValues(typeof(VisionType));
            comboBoxType.SelectedIndexChanged += ComboBoxType_SelectedIndexChanged;
            comboBoxType.SelectedItem = VisionType.Gray;

            string[] rfts = Enum.GetNames(typeof(RotateFlipType));
            Array.Sort(rfts, StringComparer.InvariantCulture);
            Array.Reverse(rfts);
            comboBoxRotateFlip.DataSource = rfts;
            comboBoxRotateFlip.SelectedIndexChanged += ComboBoxRotateFlip_SelectedIndexChanged;
            comboBoxRotateFlip.SelectedItem = RotateFlipType.RotateNoneFlipNone.ToString();

            ImageBoxLoad.AutoFill = true;
            ImageBoxLoad.MouseWheel += ImageBox_MouseWheel;
            ImageBoxLoad.MouseHover += ImageBox_MouseHover;
            ImageBoxLoad.MouseLeave += ImageBox_MouseLeave;
            ImageBoxLoad.MouseDown += ImageBox_MouseDown;
            ImageBoxLoad.MouseUp += ImageBox_MouseUp;
            ImageBoxLoad.MouseMove += ImageBox_MouseMove;

            ImageBoxConvert.AutoFill = true;
            ImageBoxConvert.MouseWheel += ImageBox_MouseWheel;
            ImageBoxConvert.MouseHover += ImageBox_MouseHover;
            ImageBoxConvert.MouseDown += ImageBox_MouseDown;
            ImageBoxConvert.MouseUp += ImageBox_MouseUp;
            ImageBoxConvert.MouseMove += ImageBox_MouseMove;
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
        }

        void InovkeImageView(Image bmp, ImageBox imageBox)
        {
            if (imageBox.InvokeRequired)
            {
                imageBox.Invoke((MethodInvoker)delegate
                {
                    if (imageBox.Image != null)
                    {
                        imageBox.Image.Dispose();
                    }
                    imageBox.Image = bmp;
                });
            }
            else
            {
                if (imageBox.Image != null)
                {
                    imageBox.Image.Dispose();
                }
                imageBox.Image = bmp;
            }
        }

        void ButtonImageLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.RestoreDirectory = true;
                ofd.Multiselect = false;
                ofd.Filter = "bmp;jpeg;png|*.bmp;*.jpeg;*.jpg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    comboBoxRotateFlip.SelectedIndexChanged -= ComboBoxRotateFlip_SelectedIndexChanged;
                    comboBoxRotateFlip.SelectedItem = RotateFlipType.RotateNoneFlipNone;
                    comboBoxRotateFlip.SelectedIndexChanged += ComboBoxRotateFlip_SelectedIndexChanged;

                    LoadImage = (Bitmap)Image.FromFile(ofd.FileName);

                    InovkeImageView((Bitmap)LoadImage.Clone(), ImageBoxLoad);

                    ImageBoxLoad.OnAutoFill();

                    ImageConvert();
                }
            }
        }
        void ButtonURL_Click(object sender, EventArgs e)
        {
            using (FormURL url = new FormURL())
            {
                FormURL.DownComplete += FormURL_DownComplete;
                url.ShowDialog();
                FormURL.DownComplete -= FormURL_DownComplete;

                void FormURL_DownComplete(object sender23, EventArgs e23)
                {
                    Bitmap bmp = sender23 as Bitmap;

                    comboBoxRotateFlip.SelectedIndexChanged -= ComboBoxRotateFlip_SelectedIndexChanged;
                    comboBoxRotateFlip.SelectedItem = RotateFlipType.RotateNoneFlipNone;
                    comboBoxRotateFlip.SelectedIndexChanged += ComboBoxRotateFlip_SelectedIndexChanged;

                    LoadImage = (Bitmap)bmp.Clone();

                    InovkeImageView((Bitmap)LoadImage.Clone(), ImageBoxLoad);

                    ImageBoxLoad.OnAutoFill();

                    ImageConvert();
                }
            }
        }
        void ButtonImageSave_Click(object sender, EventArgs e)
        {
            if (ImageBoxConvert.Image == null) return;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.RestoreDirectory = true;
                sfd.Filter = "bmp|*.bmp|jpeg|*.jpeg|png|*.png";

                if (ImageBoxLoad.Image != null)
                {
                    if (ImageBoxLoad.Image.RawFormat.Equals(ImageFormat.Bmp))
                    {
                        sfd.FilterIndex = 1;
                        sfd.DefaultExt = "bmp";
                    }
                    else if (ImageBoxLoad.Image.RawFormat.Equals(ImageFormat.Jpeg))
                    {
                        sfd.FilterIndex = 2;
                        sfd.DefaultExt = "jpeg";
                    }
                    else
                    {
                        sfd.FilterIndex = 3;
                        sfd.DefaultExt = "png";
                    }
                }
                else
                {
                    sfd.FilterIndex = 3;
                    sfd.DefaultExt = "png";
                }


                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    switch (sfd.FilterIndex)
                    {
                        case 1: ImageBoxConvert.Image.Save(sfd.FileName, ImageFormat.Bmp); break;
                        case 2: ImageBoxConvert.Image.Save(sfd.FileName, ImageFormat.Jpeg); break;
                        case 3: ImageBoxConvert.Image.Save(sfd.FileName, ImageFormat.Png); break;
                    }
                }
            }
        }

        void ComboBoxRotateFlip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LoadImage == null) return;

            RotateFlipImage = (Bitmap)LoadImage.Clone();
            RotateFlipImage.RotateFlip(RotateFlip);

            ImageBoxLoad.Image = (Bitmap)RotateFlipImage.Clone();
            ImageBoxLoad.OnAutoFill();

            ImageConvert();
        }
        void ComboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            VisionType = (VisionType)cb.SelectedItem;

            ImageConvert();
        }

        void ImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            ImageBox ib = sender as ImageBox;

            if (ib == ImageBoxLoad)
            {
                if (MouseImageLoad.IsHover && MouseImageLoad.IsDown)
                {
                    ImageBoxConvert.Transformation = ImageBoxLoad.Transformation;
                }
            }
            else
            {
                if (MouseImageConvert.IsHover && MouseImageConvert.IsDown)
                {
                    ImageBoxLoad.Transformation = ImageBoxConvert.Transformation;
                }
            }
        }
        void ImageBox_MouseUp(object sender, MouseEventArgs e)
        {
            ImageBox ib = sender as ImageBox;

            if (ib == ImageBoxLoad)
            {
                MouseImageLoad.IsDown = false;
            }
            else
            {
                MouseImageConvert.IsDown = false;
            }
        }
        void ImageBox_MouseDown(object sender, MouseEventArgs e)
        {
            ImageBox ib = sender as ImageBox;

            if (ib == ImageBoxLoad)
            {
                MouseImageLoad.IsDown = true;
            }
            else
            {
                MouseImageConvert.IsDown = true;
            }
        }
        void ImageBox_MouseLeave(object sender, EventArgs e)
        {
            ImageBox ib = sender as ImageBox;

            if (ib == ImageBoxLoad)
            {
                MouseImageLoad.IsHover = false;
            }
            else
            {
                MouseImageConvert.IsHover = false;
            }
        }
        void ImageBox_MouseHover(object sender, EventArgs e)
        {
            ImageBox ib = sender as ImageBox;

            if (ib == ImageBoxLoad)
            {
                MouseImageLoad.IsHover = true;
            }
            else
            {
                MouseImageConvert.IsHover = true;
            }
        }
        void ImageBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ImageBox ibox = sender as ImageBox;

            if (ibox == ImageBoxLoad)
            {
                ImageBoxConvert.Transformation = ImageBoxLoad.Transformation;
            }
            else
            {
                ImageBoxLoad.Transformation = ImageBoxConvert.Transformation;
            }
        }

        void ImageConvert()
        {
            if (LoadImage == null) return;

            Bitmap bmp;
            switch (RotateFlip)
            {
                case RotateFlipType.RotateNoneFlipNone:
                    bmp = (Bitmap)LoadImage.Clone();
                    break;
                default:
                    if (RotateFlipImage != null)
                    {
                        bmp = (Bitmap)RotateFlipImage.Clone();
                    }
                    else
                    {
                        bmp = (Bitmap)LoadImage.Clone();
                    }
                    break;
            }

            Bitmap reValue;
            switch (VisionType)
            {
                case VisionType.Binary: reValue = VisionBinary.Run(bmp); break;
                case VisionType.Gray: reValue = VisionGray.Run(bmp); break;
                case VisionType.Invert: reValue = VisionInvert.Run(bmp); break;
                case VisionType.InvertRed: reValue = VisionInvertRed.Run(bmp); break;
                case VisionType.InvertGreen: reValue = VisionInvertGreen.Run(bmp); break;
                case VisionType.InvertBlue: reValue = VisionInvertBlue.Run(bmp); break;
                case VisionType.RelativeLowRed: reValue = VisionRelativeLowRed.Run(bmp); break;
                case VisionType.RelativeLowGreen: reValue = VisionRelativeLowGreen.Run(bmp); break;
                case VisionType.RelativeLowBlue: reValue = VisionRelativeLowBlue.Run(bmp); break;
                case VisionType.SimilarRed: reValue = VisionSimilarRed.Run(bmp); break;
                case VisionType.SimilarGreen: reValue = VisionSimilarGreen.Run(bmp); break;
                case VisionType.SimilarBlue: reValue = VisionSimilarBlue.Run(bmp); break;
                default: reValue = bmp; break;
            }

            InovkeImageView(reValue, ImageBoxConvert);

            ImageBoxConvert.Transformation = ImageBoxLoad.Transformation;
        }
    }
}
