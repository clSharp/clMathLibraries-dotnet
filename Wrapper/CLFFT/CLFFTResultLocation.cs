namespace CLMathLibraries.CLFFT
{
    public enum CLFFTResultLocation
    {
        CLFFT_INPLACE = 1,		/*!< The input and output buffers are the same (default). */
        CLFFT_OUTOFPLACE				/*!< Seperate input and output buffers. */
    }
}