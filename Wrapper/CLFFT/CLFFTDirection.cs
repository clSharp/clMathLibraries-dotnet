namespace CLMathLibraries.CLFFT
{
    public enum CLFFTDirection
    {
        CLFFT_FORWARD	= -1,		/*!< FFT transform from the time to the frequency domain. */
        CLFFT_BACKWARD	= 1,		/*!< FFT transform from the frequency to the time domain. */
        CLFFT_MINUS		= -1,		/*!< Alias for the forward transform. */
        CLFFT_PLUS		= 1		/*!< Alias for the backward transform. */
    }
}