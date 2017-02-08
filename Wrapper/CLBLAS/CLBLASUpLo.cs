namespace CLMathLibraries.CLBLAS
{
    /** Used by the Hermitian, symmetric and triangular matrix
     * routines to specify whether the upper or lower triangle is being referenced.
     */
    public enum CLBLASUpLo {
        clblasUpper,               /**< Upper triangle. */
        clblasLower                /**< Lower triangle. */
    };
}