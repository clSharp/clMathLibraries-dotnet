
namespace CLMathLibraries.CLSparse
{
    public struct CLSparseCreateSolverResult
    {
        public CLSparseStatus Status;              /*!< Returned error code */
        public CLSparseSolverControl Control;      /*!< Returned control object that abstracts clsparse state */
    }
}