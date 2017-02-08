namespace CLMathLibraries.CLFFT
{
    public enum CLFFTLayout
    {
        CLFFT_COMPLEX_INTERLEAVED = 1,	/*!< An array of complex numbers, with real and imaginary components together (default). */
        CLFFT_COMPLEX_PLANAR,				/*!< Arrays of real componets and arrays of imaginary components that have been seperated out. */
        CLFFT_HERMITIAN_INTERLEAVED,		/*!< Compressed form of complex numbers; complex-conjugates not stored, real and imaginary components in same array.*/
        CLFFT_HERMITIAN_PLANAR,				/*!< Compressed form of complex numbers; complex-conjugates not stored, real and imaginary components in separate arrays.*/
        CLFFT_REAL
    }
}