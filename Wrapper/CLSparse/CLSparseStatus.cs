
namespace CLMathLibraries.CLSparse
{
    public enum CLSparseStatus
    {
        /** @name Inherited OpenCL codes */
        /**@{*/
        Success = 0,
        CompilerNotAvailable = -3,
        OutOfResources = -5,
        OutOfHostMemory = -6,
        BuildProgramFailure = -11,
        InvalidValue = -30,
        InvalidDevice = -33,
        InvalidContext = -34,
        InvalidCommandQueue = -36,
        InvalidMemObject = -38,
        InvalidKernelArgs = -52,
        InvalidEventWaitList = -57,
        InvalidEvent = -58,
        InvalidOperation = -59,
        /**@}*/

        /** @name Extended error codes */
        /**@{*/
        NotImplemented = -1024,  /**< Functionality is not implemented */
        NotInitialized,          /**< clsparse library is not initialized yet */
        StructInvalid,           /**< clsparse library is not initialized yet */
        InvalidSize,             /**< Invalid size of object > */
        InvalidMemObj,           /**< Checked object is no a valid cl_mem object */
        InsufficientMemory,      /**< The memory object for vector is too small */
        InvalidControlObject,    /**< clsparseControl object is not valid */
        InvalidFile,             /**< Error reading the sparse matrix file */
        InvalidFileFormat,       /**< Only specific documented sparse matrix files supported */
        InvalidKernelExecution,  /**< Problem with kernel execution */
        InvalidType,             /** < Wrong type provided > */
        /**@}*/

        /** @name Solver control codes */
        /**@{*/
        InvalidSolverControlObject = -2048,
        InvalidSystemSize,
        IterationsExceeded,
        ToleranceNotReached,
        SolverError,

    }
}