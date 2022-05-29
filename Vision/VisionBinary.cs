using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace Vision
{
    public class VisionBinary : Common
    {
        public unsafe static Bitmap Run(Bitmap source)
        {
            LockBits(ref source, out BitmapData sourceBD, out int sourceWidth, out int sourceHeight, out int sourceStride, out Bitmap target, out BitmapData targetBD);
            byte* ptrSource = (byte*)sourceBD.Scan0;
            byte* ptrTarget = (byte*)targetBD.Scan0;

            switch (Image.GetPixelFormatSize(source.PixelFormat))
            {
                case 8:
                    Parallel.For(0, sourceHeight, y =>
                    {
                        //행 첫번째 위치
                        byte* pLine = ptrSource + y * sourceStride;
                        byte* pLine2 = ptrTarget + y * sourceStride;

                        for (int x = 0; x < sourceWidth; x++)
                        {
                            CompareRGB(&pLine[x], &pLine2[x], 128, 0, 255);
                        }
                    });
                    break;

                case 24:
                    Parallel.For(0, sourceHeight, y =>
                    {
                        byte* pLine = ptrSource + y * sourceStride;
                        byte* pLine2 = ptrTarget + y * sourceStride;

                        for (int x = 0; x < sourceWidth; x++)
                        {
                            CompareRGB(pLine, pLine2, 382, 0, 255);

                            pLine += 3;
                            pLine2 += 3;
                        }
                    });
                    break;

                case 32:
                    Parallel.For(0, sourceHeight, y =>
                    {
                        byte* pLine = ptrSource + y * sourceStride;
                        byte* pLine2 = ptrTarget + y * sourceStride;

                        for (int x = 0; x < sourceWidth; x++)
                        {
                            CompareRGBA(pLine, pLine2, 382, 0, 255);

                            pLine += 4;
                            pLine2 += 4;
                        }
                    });
                    break;
            }

            target.UnlockBits(targetBD);

            source.UnlockBits(sourceBD);

            return target;
        }
    }
}
