namespace CLMathLibraries.CLFFT
{
    public enum CLFFTPrecision
    {
        CLFFT_SINGLE = 1,	/*!< An array of complex numbers, with real and imaginary components as floats (default). */
        CLFFT_DOUBLE,			/*!< An array of complex numbers, with real and imaginary components as doubles. */
        CLFFT_SINGLE_FAST,		/*!< Faster implementation preferred. */
        CLFFT_DOUBLE_FAST,		/*!< Faster implementation preferred. */
    }
}