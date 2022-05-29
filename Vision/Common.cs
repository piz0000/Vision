using System.Drawing;
using System.Drawing.Imaging;

namespace Vision
{
    public class Common
    {
        internal unsafe static void LockBits(ref Bitmap source, out BitmapData sourceBD, out int sourceWidth, out int sourceHeight, out int sourceStride, out Bitmap target, out BitmapData targetBD)
        {
            sourceBD = source.LockBits(new Rectangle(new Point(0, 0), source.Size), ImageLockMode.ReadOnly, source.PixelFormat);
            sourceWidth = sourceBD.Width;
            sourceHeight = sourceBD.Height;
            sourceStride = sourceBD.Stride;

            target = new Bitmap(sourceWidth, sourceHeight, source.PixelFormat);
            if (source.Palette.Entries != null && source.Palette.Entries.Length >= 1)
            {
                target.Palette = source.Palette;
            }
            targetBD = target.LockBits(new Rectangle(new Point(0, 0), source.Size), ImageLockMode.WriteOnly, source.PixelFormat);
        }

        /// <summary>
        /// 비교값이 크다면 최소값을 작다면 최대값을 할당
        /// </summary>
        /// <param name="sourceRGB"></param>
        /// <param name="targetRGB"></param>
        /// <param name="compareValue"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        internal unsafe static void CompareRGB(byte* sourceRGB, byte* targetRGB, int compareValue, byte minValue, byte maxValue)
        {
            byte value = *(sourceRGB + 2) + *(sourceRGB + 1) + *sourceRGB < compareValue ? minValue : maxValue;

            *(targetRGB + 2) = value;
            *(targetRGB + 1) = value;
            *targetRGB = value;
        }
        internal unsafe static void CompareRGBA(byte* sourceRGB, byte* targetRGB, int compareValue, byte minValue, byte maxValue)
        {
            byte value = *(sourceRGB + 2) + *(sourceRGB + 1) + *sourceRGB < compareValue ? minValue : maxValue;

            *(targetRGB + 3) = *(sourceRGB + 3);
            *(targetRGB + 2) = value;
            *(targetRGB + 1) = value;
            *targetRGB = value;
        }


        /// <summary>
        /// source 값 반전하여 target 넣기
        /// </summary>
        /// <param name="source">참조 대상</param>
        /// <param name="target">덮어쓰기 대상</param>
        internal unsafe static void InvertValue(byte* source, byte* target)
        {
            *target = (byte)(*source ^ 255);
        }
        /// <summary>
        /// sourceRGB 값 반전하여 targetRGB 넣기
        /// </summary>
        /// <param name="sourceRGB">참조 대상</param>
        /// <param name="targetRGB">덮어쓰기 대상</param>
        internal unsafe static void InvertRGB(byte* sourceRGB, byte* targetRGB)
        {
            *(targetRGB + 2) = (byte)(*(sourceRGB + 2) ^ 255);
            *(targetRGB + 1) = (byte)(*(sourceRGB + 1) ^ 255);
            *targetRGB = (byte)(*sourceRGB ^ 255);
        }
        /// <summary>
        /// sourceRGBA 값 반전하여 targetRGBA 넣기
        /// </summary>
        /// <param name="sourceRGBA"></param>
        /// <param name="targetRGBA"></param>
        internal unsafe static void InvertRGBA(byte* sourceRGBA, byte* targetRGBA)
        {
            *(targetRGBA + 3) = *(sourceRGBA + 3);
            *(targetRGBA + 2) = (byte)(*(sourceRGBA + 2) ^ 255);
            *(targetRGBA + 1) = (byte)(*(sourceRGBA + 1) ^ 255);
            *targetRGBA = (byte)(*sourceRGBA ^ 255);
        }

        /// <summary>
        /// Red 값을 ^ 255 반전
        /// </summary>
        /// <param name="sourceRGB"></param>
        /// <param name="targetRGB"></param>
        internal unsafe static void InvertRed(byte* sourceRGB, byte* targetRGB)
        {
            *(targetRGB + 2) = (byte)(*(sourceRGB + 2) ^ 255);
        }
        /// <summary>
        /// Green 값을 ^ 255 반전
        /// </summary>
        /// <param name="sourceRGB"></param>
        /// <param name="targetRGB"></param>
        internal unsafe static void InvertGreen(byte* sourceRGB, byte* targetRGB)
        {
            *(targetRGB + 1) = (byte)(*(sourceRGB + 1) ^ 255);
        }
        /// <summary>
        /// Blue 값을 ^ 255 반전
        /// </summary>
        /// <param name="sourceRGB"></param>
        /// <param name="targetRGB"></param>
        internal unsafe static void InvertBlue(byte* sourceRGB, byte* targetRGB)
        {
            *targetRGB = (byte)(*sourceRGB ^ 255);
        }


        /// <summary>
        /// sourceRGB 평균값으로 그레이 값 만들고 targetRGB 넣기
        /// </summary>
        /// <param name="sourceRGB">참조 대상</param>
        /// <param name="targetRGB">덮어쓰기 대상</param>
        internal unsafe static void AvgRGB(byte* sourceRGB, byte* targetRGB)
        {
            byte value = (byte)((*(sourceRGB + 2) + *(sourceRGB + 1) + *sourceRGB) / 3);

            *(targetRGB + 2) = value;
            *(targetRGB + 1) = value;
            *targetRGB = value;
        }
        /// <summary>
        /// sourceRGBA 평균값으로 그레이 값 만들고 targetRGBA 넣기
        /// </summary>
        /// <param name="sourceRGBA">참조 대상</param>
        /// <param name="targetRGBA">덮어쓰기 대상</param>
        internal unsafe static void AvgRGBA(byte* sourceRGBA, byte* targetRGBA)
        {
            *(targetRGBA + 3) = *(sourceRGBA + 3);

            AvgRGB(sourceRGBA, targetRGBA);
        }

        /// <summary>
        /// targetRGB 위치에 sourceRGB 위치의 값 복사하기
        /// </summary>
        /// <param name="sourceRGB">복사 대상</param>
        /// <param name="targetRGB">붙여넣기 대상</param>
        internal unsafe static void CopyRGB(byte* sourceRGB, byte* targetRGB)
        {
            *(targetRGB + 2) = *(sourceRGB + 2);
            *(targetRGB + 1) = *(sourceRGB + 1);
            *targetRGB = *sourceRGB;
        }
        /// <summary>
        /// sourceRGBA 위치의 RGBA targetRGBA 복사
        /// </summary>
        /// <param name="sourceRGBA">복사 대상</param>
        /// <param name="targetRGBA">붙여넣기 대상</param>
        internal unsafe static void CopyRGBA(byte* sourceRGBA, byte* targetRGBA)
        {
            *(targetRGBA + 3) = *(sourceRGBA + 3);

            CopyRGB(sourceRGBA, targetRGBA);
        }

    }
}
