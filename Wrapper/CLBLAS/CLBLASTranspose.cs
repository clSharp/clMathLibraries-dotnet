namespace CLMathLibraries.CLBLAS
{
    /** Used to specify whether the matrix is to be transposed or not. */
    public enum CLBLASTranspose {
        clblasNoTrans,           /**< Operate with the matrix. */
        clblasTrans,             /**< Operate with the transpose of the matrix. */
        clblasConjTrans          /**< Operate with the conjugate transpose of
                                     the matrix. */
    };
}