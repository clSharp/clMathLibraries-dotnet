namespace CLMathLibraries.CLBLAS
{
    /** Shows how matrices are placed in memory. */
    public enum CLBLASOrder {
        clblasRowMajor,           /**< Every row is placed sequentially */
        clblasColumnMajor         /**< Every column is placed sequentially */
    };
}