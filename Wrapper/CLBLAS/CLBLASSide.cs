namespace CLMathLibraries.CLBLAS
{
    /** Indicates the side matrix A is located relative to matrix B during multiplication. */
    public enum CLBLASSide {
        clblasLeft,        /**< Multiply general matrix by symmetric,
                               Hermitian or triangular matrix on the left. */
        clblasRight        /**< Multiply general matrix by symmetric,
                               Hermitian or triangular matrix on the right. */
    };
}