
namespace CLMathLibraries.CLBLAS
{
    public enum CLBLASStatus {
        clblasSuccess                   = 0,
        clblasInvalidValue              = -30,
        clblasInvalidCommandQueue       = -36,
        clblasInvalidContext            = -34,
        clblasInvalidMemObject          = -38,
        clblasInvalidDevice             = -33,
        clblasInvalidEventWaitList      = -57,
        clblasOutOfResources            = -5,
        clblasOutOfHostMemory           = -6,
        clblasInvalidOperation          = -59,
        clblasCompilerNotAvailable      = -3,
        clblasBuildProgramFailure       = -11,
        /* Extended error codes */
        clblasNotImplemented         = -1024, /**< Functionality is not implemented */
        clblasNotInitialized,                 /**< clblas library is not initialized yet */
        clblasInvalidMatA,                    /**< Matrix A is not a valid memory object */
        clblasInvalidMatB,                    /**< Matrix B is not a valid memory object */
        clblasInvalidMatC,                    /**< Matrix C is not a valid memory object */
        clblasInvalidVecX,                    /**< Vector X is not a valid memory object */
        clblasInvalidVecY,                    /**< Vector Y is not a valid memory object */
        clblasInvalidDim,                     /**< An input dimension (M,N,K) is invalid */
        clblasInvalidLeadDimA,                /**< Leading dimension A must not be less than the size of the first dimension */
        clblasInvalidLeadDimB,                /**< Leading dimension B must not be less than the size of the second dimension */
        clblasInvalidLeadDimC,                /**< Leading dimension C must not be less than the size of the third dimension */
        clblasInvalidIncX,                    /**< The increment for a vector X must not be 0 */
        clblasInvalidIncY,                    /**< The increment for a vector Y must not be 0 */
        clblasInsufficientMemMatA,            /**< The memory object for Matrix A is too small */
        clblasInsufficientMemMatB,            /**< The memory object for Matrix B is too small */
        clblasInsufficientMemMatC,            /**< The memory object for Matrix C is too small */
        clblasInsufficientMemVecX,            /**< The memory object for Vector X is too small */
        clblasInsufficientMemVecY             /**< The memory object for Vector Y is too small */
    };
}