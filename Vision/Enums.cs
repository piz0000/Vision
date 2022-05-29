namespace Vision
{
    public enum VisionType
    {
        /// <summary>
        /// 이진화
        /// </summary>
        Binary,

        /// <summary>
        /// 회색
        /// </summary>
        Gray,

        /// <summary>
        /// 반전
        /// </summary>
        Invert,
        /// <summary>
        /// Red 값 xor 반전
        /// </summary>
        InvertRed,
        /// <summary>
        /// Green 값 xor 반전
        /// </summary>
        InvertGreen,
        /// <summary>
        /// Blue 값 xor 반전
        /// </summary>
        InvertBlue,

        /// <summary>
        /// r이 g, b보다 적다면 gray 변경
        /// </summary>
        RelativeLowRed,
        /// <summary>
        /// g이 r, b보다 적다면 gray 변경
        /// </summary>
        RelativeLowGreen,
        /// <summary>
        /// b이 r, g보다 적다면 gray 변경
        /// </summary>
        RelativeLowBlue,

        /// <summary>
        /// Red 계열 색상만 검출
        /// </summary>
        SimilarRed,
        /// <summary>
        /// Green 계열 색상만 검출
        /// </summary>
        SimilarGreen,
        /// <summary>
        /// Blue 계열 색상만 검출
        /// </summary>
        SimilarBlue
    }
}
