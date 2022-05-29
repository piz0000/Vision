using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace Vision
{
    public class VisionSimilarGreen : Common
    {
        public unsafe static Bitmap Run(Bitmap source)
        {
            LockBits(ref source, out BitmapData sourceBD, out int sourceWidth, out int sourceHeight, out int sourceStride, out Bitmap target, out BitmapData targetBD);
            byte* ptrSource = (byte*)sourceBD.Scan0;
            byte* ptrTarget = (byte*)targetBD.Scan0;

            switch (Image.GetPixelFormatSize(targetBD.PixelFormat))
            {
                case 8:
                    Parallel.For(0, sourceHeight, y =>
                    {
                        //행 첫번째 위치
                        byte* pLine = ptrSource + y * sourceStride;
                        byte* pLine2 = ptrTarget + y * sourceStride;

                        for (int x = 0; x < sourceWidth; x++)
                        {
                            pLine2[x] = pLine[x];
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
                            if (pLine[1] < pLine[0] || pLine[1] < pLine[2])
                                AvgRGB(pLine, pLine2);
                            else
                                CopyRGB(pLine, pLine2);

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
                            if (pLine[1] < pLine[0] || pLine[1] < pLine[2])
                                AvgRGBA(pLine, pLine2);
                            else
                                CopyRGBA(pLine, pLine2);

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
