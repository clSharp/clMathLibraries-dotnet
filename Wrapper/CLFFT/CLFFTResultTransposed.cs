namespace CLMathLibraries.CLFFT
{
    public enum CLFFTResultTransposed
    {
        CLFFT_NOTRANSPOSE = 1,		/*!< The results are returned in the original preserved order (default) */
        CLFFT_TRANSPOSED    		/*!< The result is transposed where transpose kernel is supported (possibly faster) */
    }
}