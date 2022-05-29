using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vision
{
    public class ImageBox : PictureBox
    {
        bool IsClickPoint = false;
        Point _clickedPoint = new Point(0, 0);
        ProTransformation _transformation = new ProTransformation(new Point(100, 0), 0.5f);

        public ProTransformation Transformation
        {
            get { return _transformation; }
            set
            {
                if (Image != null)
                {
                    _transformation = FixTranslation(value);

                    Invalidate();
                }
            }
        }



        public new Image Image
        {
            get { return base.Image; }
            set
            {
                base.Image = value;

                if (_AutoFill)
                {
                    OnAutoFill();
                }
            }
        }

        /// <summary>
        /// 이미지 전체 표시
        /// </summary>
        public bool AutoFill
        {
            get { return _AutoFill; }
            set
            {
                _AutoFill = value;

                if (_AutoFill)
                {
                    OnAutoFill();
                }
            }
        }
        bool _AutoFill = false;


        ProTransformation FixTranslation(ProTransformation value)
        {
            var maxScale = Math.Max((double)Image.Width / ClientRectangle.Width, (double)Image.Height / ClientRectangle.Height);

            if (value.Scale > maxScale)
            {
                value = value.SetScale(maxScale);
            }

            if (value.Scale < 0.3)
            {
                value = value.SetScale(0.3);
            }

            var rectSize = value.ConvertToIm(ClientRectangle.Size);

            var max = new Size(Image.Width - rectSize.Width, Image.Height - rectSize.Height);

            value = value.SetTranslate((new Point(Math.Min(value.Translation.X, max.Width), Math.Min(value.Translation.Y, max.Height))));

            if (value.Translation.X < 0 || value.Translation.Y < 0)
            {
                value = value.SetTranslate(new Point(Math.Max(value.Translation.X, 0), Math.Max(value.Translation.Y, 0)));
            }

            return value;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            ProTransformation transformation = _transformation;

            Point pos1 = transformation.ConvertToIm(e.Location);

            if (e.Delta > 0)
            {
                transformation = transformation.SetScale(Transformation.Scale / 1.25);
            }
            else
            {
                transformation = transformation.SetScale(Transformation.Scale * 1.25);
            }

            if (transformation.Scale <= 0.24)
            {
                return;
            }

            Point pos2 = transformation.ConvertToIm(e.Location);

            transformation = transformation.AddTranslate(pos1 - (Size)pos2);

            Transformation = transformation;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            IsClickPoint = false;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            Focus();

            IsClickPoint = true;

            _clickedPoint = _transformation.ConvertToIm(e.Location);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (IsClickPoint)
            {
                var p = _transformation.ConvertToIm((Size)e.Location);

                Transformation = _transformation.SetTranslate(_clickedPoint - p);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Image == null)
            {
                base.OnPaint(e);
            }
            else
            {
                Rectangle imRect = Transformation.ConvertToIm(ClientRectangle);

                e.Graphics.DrawImage(Image, ClientRectangle, imRect, GraphicsUnit.Pixel);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (_AutoFill)
            {
                Transformation = new ProTransformation(Point.Empty, int.MaxValue);
            }
        }

        public virtual void OnAutoFill()
        {
            Transformation = new ProTransformation(Point.Empty, int.MaxValue);
        }


        public struct ProTransformation
        {
            public Point Translation { get { return _translation; } }
            public double Scale { get { return _scale; } }

            readonly Point _translation;
            readonly double _scale;


            public ProTransformation(Point translation, double scale)
            {
                _translation = translation;
                _scale = scale;
            }

            public Point ConvertToIm(Point p)
            {
                return new Point((int)(p.X * _scale + _translation.X), (int)(p.Y * _scale + _translation.Y));
            }

            public Size ConvertToIm(Size p)
            {
                return new Size((int)(p.Width * _scale), (int)(p.Height * _scale));
            }

            public Rectangle ConvertToIm(Rectangle r)
            {
                return new Rectangle(ConvertToIm(r.Location), ConvertToIm(r.Size));
            }

            public Point ConvertToPb(Point p)
            {
                return new Point((int)((p.X - _translation.X) / _scale), (int)((p.Y - _translation.Y) / _scale));
            }

            public Size ConvertToPb(Size p)
            {
                return new Size((int)(p.Width / _scale), (int)(p.Height / _scale));
            }

            public Rectangle ConvertToPb(Rectangle r)
            {
                return new Rectangle(ConvertToPb(r.Location), ConvertToPb(r.Size));
            }

            public ProTransformation SetTranslate(Point p)
            {
                return new ProTransformation(p, _scale);
            }

            public ProTransformation AddTranslate(Point p)
            {
                return SetTranslate(new Point(p.X + _translation.X, p.Y + _translation.Y));
            }

            public ProTransformation SetScale(double scale)
            {
                return new ProTransformation(_translation, scale);
            }
        }
    }
}
