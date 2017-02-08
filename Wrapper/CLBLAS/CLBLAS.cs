using System.Runtime.InteropServices;
using size_t = System.UInt32;
using cl_float = System.Single;
using cl_double= System.Double;
using cl_uint = System.UInt32;
using cl_mem = System.IntPtr;
using cl_event = System.IntPtr;
using cl_command_queue = System.IntPtr;

namespace CLMathLibraries.CLBLAS
{
    public static class CLBLAS
    {
        private const string PathToDll = "clBLAS.dll";
        
        #region Init

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clblasSetup")]
        public static extern CLBLASStatus Setup();

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clblasTeardown")]
        public static extern void Teardown();

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clblasGetVersion")]
        public static extern CLBLASStatus GetVersion(out size_t major, out size_t minor, out size_t patch);

        #endregion

        #region Level 3 General Matrix-Matrix multiplication

        /**
         * @brief Matrix-matrix product of general rectangular matrices with float
         *        elements. Extended version.
         *
         * Matrix-matrix products:
         *   - \f$ C \leftarrow \alpha A B + \beta C \f$
         *   - \f$ C \leftarrow \alpha A^T B + \beta C \f$
         *   - \f$ C \leftarrow \alpha A B^T + \beta C \f$
         *   - \f$ C \leftarrow \alpha A^T B^T + \beta C \f$
         *
         * @param[in] order     Row/column order.
         * @param[in] transA    How matrix \b A is to be transposed.
         * @param[in] transB    How matrix \b B is to be transposed.
         * @param[in] M         Number of rows in matrix \b A.
         * @param[in] N         Number of columns in matrix \b B.
         * @param[in] K         Number of columns in matrix \b A and rows in matrix \b B.
         * @param[in] alpha     The factor of matrix \b A.
         * @param[in] A         Buffer object storing matrix \b A.
         * @param[in] offA      Offset of the first element of the matrix \b A in the
         *                      buffer object. Counted in elements.
         * @param[in] lda       Leading dimension of matrix \b A. It cannot be less
         *                      than \b K when the \b order parameter is set to
         *                      \b clblasRowMajor,\n or less than \b M when the
         *                      parameter is set to \b clblasColumnMajor.
         * @param[in] B         Buffer object storing matrix \b B.
         * @param[in] offB      Offset of the first element of the matrix \b B in the
         *                      buffer object. Counted in elements.
         * @param[in] ldb       Leading dimension of matrix \b B. It cannot be less
         *                      than \b N when the \b order parameter is set to
         *                      \b clblasRowMajor,\n or less than \b K
         *                      when it is set to \b clblasColumnMajor.
         * @param[in] beta      The factor of matrix \b C.
         * @param[out] C        Buffer object storing matrix \b C.
         * @param[in]  offC     Offset of the first element of the matrix \b C in the
         *                      buffer object. Counted in elements.
         * @param[in] ldc       Leading dimension of matrix \b C. It cannot be less
         *                      than \b N when the \b order parameter is set to
         *                      \b clblasRowMajor,\n or less than \b M when
         *                      it is set to \b clblasColumnMajorOrder.
         * @param[in] numCommandQueues    Number of OpenCL command queues in which the
         *                                task is to be performed.
         * @param[in] commandQueues       OpenCL command queues.
         * @param[in] numEventsInWaitList Number of events in the event wait list.
         * @param[in] eventWaitList       Event wait list.
         * @param[in] events     Event objects per each command queue that identify
         *                       a particular kernel execution instance.
         *
         * @return
         *   - \b clblasSuccess on success;
         *   - \b clblasInvalidValue if either \b offA, \b offB or \b offC exceeds
         *        the size of the respective buffer object;
         *   - the same error codes as clblasSgemm() otherwise.
         *
         * @ingroup GEMM
         */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clblasSgemm")]
        public static extern CLBLASStatus
        Sgemm(
            CLBLASOrder order,
            CLBLASTranspose transA,
            CLBLASTranspose transB,
            size_t m,
            size_t n,
            size_t k,
            cl_float alpha,
            cl_mem a, // const cl_mem
            size_t offA,
            size_t lda,
            cl_mem b, // const cl_mem
            size_t offB,
            size_t ldb,
            cl_float beta,
            cl_mem c,
            size_t offC,
            size_t ldc,
            cl_uint numCommandQueues,
            [MarshalAs(UnmanagedType.LPArray)] cl_command_queue[] commandQueues,
            cl_uint numEventsInWaitList,
            [MarshalAs(UnmanagedType.LPArray)] cl_event[] eventWaitList,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] cl_event[] events);

        /**
        * @example example_sgemm.c
        * This is an example of how to use the @ref clblasSgemmEx function.
        */

        /**
         * @brief Matrix-matrix product of general rectangular matrices with double
         *        elements. Extended version.
         *
         * Matrix-matrix products:
         *   - \f$ C \leftarrow \alpha A B + \beta C \f$
         *   - \f$ C \leftarrow \alpha A^T B + \beta C \f$
         *   - \f$ C \leftarrow \alpha A B^T + \beta C \f$
         *   - \f$ C \leftarrow \alpha A^T B^T + \beta C \f$
         *
         * @param[in] order     Row/column order.
         * @param[in] transA    How matrix \b A is to be transposed.
         * @param[in] transB    How matrix \b B is to be transposed.
         * @param[in] M         Number of rows in matrix \b A.
         * @param[in] N         Number of columns in matrix \b B.
         * @param[in] K         Number of columns in matrix \b A and rows in matrix \b B.
         * @param[in] alpha     The factor of matrix \b A.
         * @param[in] A         Buffer object storing matrix \b A.
         * @param[in] offA      Offset of the first element of the matrix \b A in the
         *                      buffer object. Counted in elements.
         * @param[in] lda       Leading dimension of matrix \b A. For detailed description,
         *                      see clblasSgemm().
         * @param[in] B         Buffer object storing matrix \b B.
         * @param[in] offB      Offset of the first element of the matrix \b B in the
         *                      buffer object. Counted in elements.
         * @param[in] ldb       Leading dimension of matrix \b B. For detailed description,
         *                      see clblasSgemm().
         * @param[in] beta      The factor of matrix \b C.
         * @param[out] C        Buffer object storing matrix \b C.
         * @param[in] offC      Offset of the first element of the matrix \b C in the
         *                      buffer object. Counted in elements.
         * @param[in] ldc       Leading dimension of matrix \b C. For detailed description,
         *                      see clblasSgemm().
         * @param[in] numCommandQueues    Number of OpenCL command queues in which the
         *                                task is to be performed.
         * @param[in] commandQueues       OpenCL command queues.
         * @param[in] numEventsInWaitList Number of events in the event wait list.
         * @param[in] eventWaitList       Event wait list.
         * @param[in] events     Event objects per each command queue that identify
         *                       a particular kernel execution instance.
         *
         * @return
         *   - \b clblasSuccess on success;
         *   - \b clblasInvalidDevice if a target device does not support floating
         *        point arithmetic with double precision;
         *   - \b clblasInvalidValue if either \b offA, \b offB or offC exceeds
         *        the size of the respective buffer object;
         *   - the same error codes as the clblasSgemm() function otherwise.
         *
         * @ingroup GEMM
         */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clblasDgemm")]
        public static extern CLBLASStatus
        Dgemm(
            CLBLASOrder order,
            CLBLASTranspose transA,
            CLBLASTranspose transB,
            size_t m,
            size_t n,
            size_t k,
            cl_double alpha,
            cl_mem a, // const cl_mem
            size_t offA,
            size_t lda,
            cl_mem b, // const cl_mem
            size_t offB,
            size_t ldb,
            cl_double beta,
            cl_mem c,
            size_t offC,
            size_t ldc,
            cl_uint numCommandQueues,
            [MarshalAs(UnmanagedType.LPArray)] cl_command_queue[] commandQueues,
            cl_uint numEventsInWaitList,
            [MarshalAs(UnmanagedType.LPArray)] cl_event[] eventWaitList,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] cl_event[] events);

        /**
         * @brief Matrix-matrix product of general rectangular matrices with float
         *        complex elements. Extended version.
         *
         * Matrix-matrix products:
         *   - \f$ C \leftarrow \alpha A B + \beta C \f$
         *   - \f$ C \leftarrow \alpha A^T B + \beta C \f$
         *   - \f$ C \leftarrow \alpha A B^T + \beta C \f$
         *   - \f$ C \leftarrow \alpha A^T B^T + \beta C \f$
         *
         * @param[in] order     Row/column order.
         * @param[in] transA    How matrix \b A is to be transposed.
         * @param[in] transB    How matrix \b B is to be transposed.
         * @param[in] M         Number of rows in matrix \b A.
         * @param[in] N         Number of columns in matrix \b B.
         * @param[in] K         Number of columns in matrix \b A and rows in matrix \b B.
         * @param[in] alpha     The factor of matrix \b A.
         * @param[in] A         Buffer object storing matrix \b A.
         * @param[in] offA      Offset of the first element of the matrix \b A in the
         *                      buffer object. Counted in elements.
         * @param[in] lda       Leading dimension of matrix \b A. For detailed description,
         *                      see clblasSgemm().
         * @param[in] B         Buffer object storing matrix \b B.
         * @param[in] offB      Offset of the first element of the matrix \b B in the
         *                      buffer object. Counted in elements.
         * @param[in] ldb       Leading dimension of matrix \b B. For detailed description,
         *                      see clblasSgemm().
         * @param[in] beta      The factor of matrix \b C.
         * @param[out] C        Buffer object storing matrix \b C.
         * @param[in] offC      Offset of the first element of the matrix \b C in the
         *                      buffer object. Counted in elements.
         * @param[in] ldc       Leading dimension of matrix \b C. For detailed description,
         *                      see clblasSgemm().
         * @param[in] numCommandQueues    Number of OpenCL command queues in which the
         *                                task is to be performed.
         * @param[in] commandQueues       OpenCL command queues.
         * @param[in] numEventsInWaitList Number of events in the event wait list.
         * @param[in] eventWaitList       Event wait list.
         * @param[in] events     Event objects per each command queue that identify
         *                       a particular kernel execution instance.
         *
         * @return
         *   - \b clblasSuccess on success;
         *   - \b clblasInvalidValue if either \b offA, \b offB or offC exceeds
         *        the size of the respective buffer object;
         *   - the same error codes as the clblasSgemm() function otherwise.
         *
         * @ingroup GEMM
         */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clblasCgemm")]
        public static extern CLBLASStatus
        Cgemm(
            CLBLASOrder order,
            CLBLASTranspose transA,
            CLBLASTranspose transB,
            size_t m,
            size_t n,
            size_t k,
            FloatComplex alpha,
            cl_mem a, // const cl_mem
            size_t offA,
            size_t lda,
            cl_mem b, // const cl_mem
            size_t offB,
            size_t ldb,
            FloatComplex beta,
            cl_mem c,
            size_t offC,
            size_t ldc,
            cl_uint numCommandQueues,
            [MarshalAs(UnmanagedType.LPArray)] cl_command_queue[] commandQueues,
            cl_uint numEventsInWaitList,
            [MarshalAs(UnmanagedType.LPArray)] cl_event[] eventWaitList,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] cl_event[] events);

        /**
         * @brief Matrix-matrix product of general rectangular matrices with double
         *        complex elements. Exteneded version.
         *
         * Matrix-matrix products:
         *   - \f$ C \leftarrow \alpha A B + \beta C \f$
         *   - \f$ C \leftarrow \alpha A^T B + \beta C \f$
         *   - \f$ C \leftarrow \alpha A B^T + \beta C \f$
         *   - \f$ C \leftarrow \alpha A^T B^T + \beta C \f$
         *
         * @param[in] order     Row/column order.
         * @param[in] transA    How matrix \b A is to be transposed.
         * @param[in] transB    How matrix \b B is to be transposed.
         * @param[in] M         Number of rows in matrix \b A.
         * @param[in] N         Number of columns in matrix \b B.
         * @param[in] K         Number of columns in matrix \b A and rows in matrix \b B.
         * @param[in] alpha     The factor of matrix \b A.
         * @param[in] A         Buffer object storing matrix \b A.
         * @param[in] offA      Offset of the first element of the matrix \b A in the
         *                      buffer object. Counted in elements.
         * @param[in] lda       Leading dimension of matrix \b A. For detailed description,
         *                      see clblasSgemm().
         * @param[in] B         Buffer object storing matrix \b B.
         * @param[in] offB      Offset of the first element of the matrix \b B in the
         *                      buffer object. Counted in elements.
         * @param[in] ldb       Leading dimension of matrix \b B. For detailed description,
         *                      see clblasSgemm().
         * @param[in] beta      The factor of matrix \b C.
         * @param[out] C        Buffer object storing matrix \b C.
         * @param[in] offC      Offset of the first element of the matrix \b C in the
         *                      buffer object. Counted in elements.
         * @param[in] ldc       Leading dimension of matrix \b C. For detailed description,
         *                      see clblasSgemm().
         * @param[in] numCommandQueues    Number of OpenCL command queues in which the
         *                                task is to be performed.
         * @param[in] commandQueues       OpenCL command queues.
         * @param[in] numEventsInWaitList Number of events in the event wait list.
         * @param[in] eventWaitList       Event wait list.
         * @param[in] events     Event objects per each command queue that identify
         *                       a particular kernel execution instance.
         *
         * @return
         *   - \b clblasSuccess on success;
         *   - \b clblasInvalidDevice if a target device does not support floating
         *        point arithmetic with double precision;
         *   - \b clblasInvalidValue if either \b offA, \b offB or offC exceeds
         *        the size of the respective buffer object;
         *   - the same error codes as the clblasSgemm() function otherwise.
         *
         * @ingroup GEMM
         */
         [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clblasZgemm")]
        public static extern CLBLASStatus
        Zgemm(
            CLBLASOrder order,
            CLBLASTranspose transA,
            CLBLASTranspose transB,
            size_t m,
            size_t n,
            size_t k,
            DoubleComplex alpha,
            cl_mem a, // const cl_mem
            size_t offA,
            size_t lda,
            cl_mem b, // const cl_mem
            size_t offB,
            size_t ldb,
            DoubleComplex beta,
            cl_mem c,
            size_t offC,
            size_t ldc,
            cl_uint numCommandQueues,
            [MarshalAs(UnmanagedType.LPArray)] cl_command_queue[] commandQueues,
            cl_uint numEventsInWaitList,
            [MarshalAs(UnmanagedType.LPArray)] cl_event[] eventWaitList,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] cl_event[] events);

        #endregion

        #region Level 3 Triangular Matrix-Matrix multiplication

        /*@}*/
        /**
         * @defgroup TRMM TRMM - Triangular matrix-matrix multiplication
         * @ingroup BLAS3
         */
        /*@{*/

        /**
         * @brief Multiplying a matrix by a triangular matrix with float elements.
         *        Extended version.
         *
         * Matrix-triangular matrix products:
         *   - \f$ B \leftarrow \alpha A B \f$
         *   - \f$ B \leftarrow \alpha A^T B \f$
         *   - \f$ B \leftarrow \alpha B A \f$
         *   - \f$ B \leftarrow \alpha B A^T \f$
         *
         * where \b T is an upper or lower triangular matrix.
         *
         * @param[in] order     Row/column order.
         * @param[in] side      The side of triangular matrix.
         * @param[in] uplo      The triangle in matrix being referenced.
         * @param[in] transA    How matrix \b A is to be transposed.
         * @param[in] diag      Specify whether matrix is unit triangular.
         * @param[in] M         Number of rows in matrix \b B.
         * @param[in] N         Number of columns in matrix \b B.
         * @param[in] alpha     The factor of matrix \b A.
         * @param[in] A         Buffer object storing matrix \b A.
         * @param[in] offA      Offset of the first element of the matrix \b A in the
         *                      buffer object. Counted in elements.
         * @param[in] lda       Leading dimension of matrix \b A. It cannot be less
         *                      than \b M when the \b side parameter is set to
         *                      \b clblasLeft,\n or less than \b N when it is set
         *                      to \b clblasRight.
         * @param[out] B        Buffer object storing matrix \b B.
         * @param[in] offB      Offset of the first element of the matrix \b B in the
         *                      buffer object. Counted in elements.
         * @param[in] ldb       Leading dimension of matrix \b B. It cannot be less
         *                      than \b N when the \b order parameter is set to
         *                      \b clblasRowMajor,\n or not less than \b M
         *                      when it is set to \b clblasColumnMajor.
         * @param[in] numCommandQueues    Number of OpenCL command queues in which the
         *                                task is to be performed.
         * @param[in] commandQueues       OpenCL command queues.
         * @param[in] numEventsInWaitList Number of events in the event wait list.
         * @param[in] eventWaitList       Event wait list.
         * @param[in] events     Event objects per each command queue that identify
         *                       a particular kernel execution instance.
         *
         * @return
         *   - \b clblasSuccess on success;
         *   - \b clblasInvalidValue if either \b offA or \b offB exceeds the size
         *        of the respective buffer object;
         *   - the same error codes as clblasStrmm() otherwise.
         *
         * @ingroup TRMM
         */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clblasStrmm")]
        public static extern CLBLASStatus
        Strmm(
            CLBLASOrder order,
            CLBLASSide side,
            CLBLASUpLo uplo,
            CLBLASTranspose transA,
            CLBLASDiag diag,
            size_t m,
            size_t n,
            cl_double alpha,
            cl_mem a, // const cl_mem
            size_t offA,
            size_t lda,
            cl_mem b,
            size_t offB,
            size_t ldb,
            cl_uint numCommandQueues,
            [MarshalAs(UnmanagedType.LPArray)] cl_command_queue[] commandQueues,
            cl_uint numEventsInWaitList,
            [MarshalAs(UnmanagedType.LPArray)] cl_event[] eventWaitList,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] cl_event[] events);
        

        /**
         * @example example_strmm.c
         * This is an example of how to use the @ref clblasStrmmEx function.
         */

        /**
         * @brief Multiplying a matrix by a triangular matrix with double elements.
         *        Extended version.
         *
         * Matrix-triangular matrix products:
         *   - \f$ B \leftarrow \alpha A B \f$
         *   - \f$ B \leftarrow \alpha A^T B \f$
         *   - \f$ B \leftarrow \alpha B A \f$
         *   - \f$ B \leftarrow \alpha B A^T \f$
         *
         * where \b T is an upper or lower triangular matrix.
         *
         * @param[in] order     Row/column order.
         * @param[in] side      The side of triangular matrix.
         * @param[in] uplo      The triangle in matrix being referenced.
         * @param[in] transA    How matrix \b A is to be transposed.
         * @param[in] diag      Specify whether matrix is unit triangular.
         * @param[in] M         Number of rows in matrix \b B.
         * @param[in] N         Number of columns in matrix \b B.
         * @param[in] alpha     The factor of matrix \b A.
         * @param[in] A         Buffer object storing matrix \b A.
         * @param[in] offA      Offset of the first element of the matrix \b A in the
         *                      buffer object. Counted in elements.
         * @param[in] lda       Leading dimension of matrix \b A. For detailed
         *                      description, see clblasStrmm().
         * @param[out] B        Buffer object storing matrix \b B.
         * @param[in] offB      Offset of the first element of the matrix \b B in the
         *                      buffer object. Counted in elements.
         * @param[in] ldb       Leading dimension of matrix \b B. For detailed
         *                      description, see clblasStrmm().
         * @param[in] numCommandQueues    Number of OpenCL command queues in which the
         *                                task is to be performed.
         * @param[in] commandQueues       OpenCL command queues.
         * @param[in] numEventsInWaitList Number of events in the event wait list.
         * @param[in] eventWaitList       Event wait list.
         * @param[in] events     Event objects per each command queue that identify
         *                       a particular kernel execution instance.
         *
         * @return
         *   - \b clblasSuccess on success;
         *   - \b clblasInvalidDevice if a target device does not support floating
         *     point arithmetic with double precision;
         *   - \b clblasInvalidValue if either \b offA or \b offB exceeds the size
         *        of the respective buffer object;
         *   - the same error codes as the clblasStrmm() function otherwise.
         *
         * @ingroup TRMM
         */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clblasDtrmm")]
        public static extern CLBLASStatus
        Dtrmm(
            CLBLASOrder order,
            CLBLASSide side,
            CLBLASUpLo uplo,
            CLBLASTranspose transA,
            CLBLASDiag diag,
            size_t m,
            size_t n,
            cl_double alpha,
            cl_mem a, // const cl_mem
            size_t offA,
            size_t lda,
            cl_mem b,
            size_t offB,
            size_t ldb,
            cl_uint numCommandQueues,
            [MarshalAs(UnmanagedType.LPArray)] cl_command_queue[] commandQueues,
            cl_uint numEventsInWaitList,
            [MarshalAs(UnmanagedType.LPArray)] cl_event[] eventWaitList,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] cl_event[] events);

        #endregion

        #region Triangular matrix solve
        /*@}*/

        /**
         * @defgroup TRSM TRSM - Solving triangular systems of equations
         * @ingroup BLAS3
         */
        /*@{*/

        /**
         * @brief Solving triangular systems of equations with multiple right-hand
         *        sides and float elements. Extended version.
         *
         * Solving triangular systems of equations:
         *   - \f$ B \leftarrow \alpha A^{-1} B \f$
         *   - \f$ B \leftarrow \alpha A^{-T} B \f$
         *   - \f$ B \leftarrow \alpha B A^{-1} \f$
         *   - \f$ B \leftarrow \alpha B A^{-T} \f$
         *
         * where \b T is an upper or lower triangular matrix.
         *
         * @param[in] order     Row/column order.
         * @param[in] side      The side of triangular matrix.
         * @param[in] uplo      The triangle in matrix being referenced.
         * @param[in] transA    How matrix \b A is to be transposed.
         * @param[in] diag      Specify whether matrix is unit triangular.
         * @param[in] M         Number of rows in matrix \b B.
         * @param[in] N         Number of columns in matrix \b B.
         * @param[in] alpha     The factor of matrix \b A.
         * @param[in] A         Buffer object storing matrix \b A.
         * @param[in] offA      Offset of the first element of the matrix \b A in the
         *                      buffer object. Counted in elements.
         * @param[in] lda       Leading dimension of matrix \b A. It cannot be less
         *                      than \b M when the \b side parameter is set to
         *                      \b clblasLeft,\n or less than \b N
         *                      when it is set to \b clblasRight.
         * @param[out] B        Buffer object storing matrix \b B.
         * @param[in] offB      Offset of the first element of the matrix \b B in the
         *                      buffer object. Counted in elements.
         * @param[in] ldb       Leading dimension of matrix \b B. It cannot be less
         *                      than \b N when the \b order parameter is set to
         *                      \b clblasRowMajor,\n or less than \b M
         *                      when it is set to \b clblasColumnMajor.
         * @param[in] numCommandQueues    Number of OpenCL command queues in which the
         *                                task is to be performed.
         * @param[in] commandQueues       OpenCL command queues.
         * @param[in] numEventsInWaitList Number of events in the event wait list.
         * @param[in] eventWaitList       Event wait list.
         * @param[in] events     Event objects per each command queue that identify
         *                       a particular kernel execution instance.
         *
         * @return
         *   - \b clblasSuccess on success;
         *   - \b clblasInvalidValue if either \b offA or \b offB exceeds the size
         *        of the respective buffer object;
         *   - the same error codes as clblasStrsm() otherwise.
         *
         * @ingroup TRSM
         */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clblasStrsm")]
        public static extern CLBLASStatus
        Strsm(
            CLBLASOrder order,
            CLBLASSide side,
            CLBLASUpLo uplo,
            CLBLASTranspose transA,
            CLBLASDiag diag,
            size_t m,
            size_t n,
            cl_float alpha,
            cl_mem a, // const cl_mem
            size_t offA,
            size_t lda,
            cl_mem b,
            size_t offB,
            size_t ldb,
            cl_uint numCommandQueues,
            [MarshalAs(UnmanagedType.LPArray)] cl_command_queue[] commandQueues,
            cl_uint numEventsInWaitList,
            [MarshalAs(UnmanagedType.LPArray)] cl_event[] eventWaitList,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] cl_event[] events);

        /**
         * @example example_strsm.c
         * This is an example of how to use the @ref clblasStrsmEx function.
         */

        /**
         * @brief Solving triangular systems of equations with multiple right-hand
         *        sides and double elements. Extended version.
         *
         * Solving triangular systems of equations:
         *   - \f$ B \leftarrow \alpha A^{-1} B \f$
         *   - \f$ B \leftarrow \alpha A^{-T} B \f$
         *   - \f$ B \leftarrow \alpha B A^{-1} \f$
         *   - \f$ B \leftarrow \alpha B A^{-T} \f$
         *
         * where \b T is an upper or lower triangular matrix.
         *
         * @param[in] order     Row/column order.
         * @param[in] side      The side of triangular matrix.
         * @param[in] uplo      The triangle in matrix being referenced.
         * @param[in] transA    How matrix \b A is to be transposed.
         * @param[in] diag      Specify whether matrix is unit triangular.
         * @param[in] M         Number of rows in matrix \b B.
         * @param[in] N         Number of columns in matrix \b B.
         * @param[in] alpha     The factor of matrix \b A.
         * @param[in] A         Buffer object storing matrix \b A.
         * @param[in] offA      Offset of the first element of the matrix \b A in the
         *                      buffer object. Counted in elements.
         * @param[in] lda       Leading dimension of matrix \b A. For detailed
         *                      description, see clblasStrsm().
         * @param[out] B        Buffer object storing matrix \b B.
         * @param[in] offB      Offset of the first element of the matrix \b A in the
         *                      buffer object. Counted in elements.
         * @param[in] ldb       Leading dimension of matrix \b B. For detailed
         *                      description, see clblasStrsm().
         * @param[in] numCommandQueues    Number of OpenCL command queues in which the
         *                                task is to be performed.
         * @param[in] commandQueues       OpenCL command queues.
         * @param[in] numEventsInWaitList Number of events in the event wait list.
         * @param[in] eventWaitList       Event wait list.
         * @param[in] events     Event objects per each command queue that identify
         *                       a particular kernel execution instance.
         *
         * @return
         *   - \b clblasSuccess on success;
         *   - \b clblasInvalidDevice if a target device does not support floating
         *        point arithmetic with double precision;
         *   - \b clblasInvalidValue if either \b offA or \b offB exceeds the size
         *        of the respective buffer object;
         *   - the same error codes as the clblasStrsm() function otherwise.
         *
         * @ingroup TRSM
         */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clblasDtrsm")]
        public static extern CLBLASStatus
        Dtrsm(
            CLBLASOrder order,
            CLBLASSide side,
            CLBLASUpLo uplo,
            CLBLASTranspose transA,
            CLBLASDiag diag,
            size_t m,
            size_t n,
            cl_double alpha,
            cl_mem a, // const cl_mem
            size_t offA,
            size_t lda,
            cl_mem b,
            size_t offB,
            size_t ldb,
            cl_uint numCommandQueues,
            [MarshalAs(UnmanagedType.LPArray)] cl_command_queue[] commandQueues,
            cl_uint numEventsInWaitList,
            [MarshalAs(UnmanagedType.LPArray)] cl_event[] eventWaitList,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] cl_event[] events);

        /**
         * @brief Solving triangular systems of equations with multiple right-hand
         *        sides and float complex elements. Extended version.
         *
         * Solving triangular systems of equations:
         *   - \f$ B \leftarrow \alpha A^{-1} B \f$
         *   - \f$ B \leftarrow \alpha A^{-T} B \f$
         *   - \f$ B \leftarrow \alpha B A^{-1} \f$
         *   - \f$ B \leftarrow \alpha B A^{-T} \f$
         *
         * where \b T is an upper or lower triangular matrix.
         *
         * @param[in] order     Row/column order.
         * @param[in] side      The side of triangular matrix.
         * @param[in] uplo      The triangle in matrix being referenced.
         * @param[in] transA    How matrix \b A is to be transposed.
         * @param[in] diag      Specify whether matrix is unit triangular.
         * @param[in] M         Number of rows in matrix \b B.
         * @param[in] N         Number of columns in matrix \b B.
         * @param[in] alpha     The factor of matrix \b A.
         * @param[in] A         Buffer object storing matrix \b A.
         * @param[in] offA      Offset of the first element of the matrix \b A in the
         *                      buffer object. Counted in elements.
         * @param[in] lda       Leading dimension of matrix \b A. For detailed
         *                      description, see clblasStrsm().
         * @param[out] B        Buffer object storing matrix \b B.
         * @param[in] offB      Offset of the first element of the matrix \b B in the
         *                      buffer object. Counted in elements.
         * @param[in] ldb       Leading dimension of matrix \b B. For detailed
         *                      description, see clblasStrsm().
         * @param[in] numCommandQueues    Number of OpenCL command queues in which the
         *                                task is to be performed.
         * @param[in] commandQueues       OpenCL command queues.
         * @param[in] numEventsInWaitList Number of events in the event wait list.
         * @param[in] eventWaitList       Event wait list.
         * @param[in] events     Event objects per each command queue that identify
         *                       a particular kernel execution instance.
         *
         * @return
         *   - \b clblasSuccess on success;
         *   - \b clblasInvalidValue if either \b offA or \b offB exceeds the size
         *        of the respective buffer object;
         *   - the same error codes as clblasStrsm() otherwise.
         *
         * @ingroup TRSM
         */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clblasCtrsm")]
        public static extern CLBLASStatus
        Ctrsm(
            CLBLASOrder order,
            CLBLASSide side,
            CLBLASUpLo uplo,
            CLBLASTranspose transA,
            CLBLASDiag diag,
            size_t m,
            size_t n,
            FloatComplex alpha,
            cl_mem a, // const cl_mem
            size_t offA,
            size_t lda,
            cl_mem b,
            size_t offB,
            size_t ldb,
            cl_uint numCommandQueues,
            [MarshalAs(UnmanagedType.LPArray)] cl_command_queue[] commandQueues,
            cl_uint numEventsInWaitList,
            [MarshalAs(UnmanagedType.LPArray)] cl_event[] eventWaitList,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] cl_event[] events);

        /**
         * @brief Solving triangular systems of equations with multiple right-hand
         *        sides and double complex elements. Extended version.
         *
         * Solving triangular systems of equations:
         *   - \f$ B \leftarrow \alpha A^{-1} B \f$
         *   - \f$ B \leftarrow \alpha A^{-T} B \f$
         *   - \f$ B \leftarrow \alpha B A^{-1} \f$
         *   - \f$ B \leftarrow \alpha B A^{-T} \f$
         *
         * where \b T is an upper or lower triangular matrix.
         *
         * @param[in] order     Row/column order.
         * @param[in] side      The side of triangular matrix.
         * @param[in] uplo      The triangle in matrix being referenced.
         * @param[in] transA    How matrix \b A is to be transposed.
         * @param[in] diag      Specify whether matrix is unit triangular.
         * @param[in] M         Number of rows in matrix \b B.
         * @param[in] N         Number of columns in matrix \b B.
         * @param[in] alpha     The factor of matrix \b A.
         * @param[in] A         Buffer object storing matrix \b A.
         * @param[in] offA      Offset of the first element of the matrix \b A in the
         *                      buffer object. Counted in elements.
         * @param[in] lda       Leading dimension of matrix \b A. For detailed
         *                      description, see clblasStrsm().
         * @param[out] B        Buffer object storing matrix \b B.
         * @param[in] offB      Offset of the first element of the matrix \b B in the
         *                      buffer object. Counted in elements.
         * @param[in] ldb       Leading dimension of matrix \b B. For detailed
         *                      description, see clblasStrsm().
         * @param[in] numCommandQueues    Number of OpenCL command queues in which the
         *                                task is to be performed.
         * @param[in] commandQueues       OpenCL command queues.
         * @param[in] numEventsInWaitList Number of events in the event wait list.
         * @param[in] eventWaitList       Event wait list.
         * @param[in] events     Event objects per each command queue that identify
         *                       a particular kernel execution instance.
         *
         * @return
         *   - \b clblasSuccess on success;
         *   - \b clblasInvalidDevice if a target device does not support floating
         *        point arithmetic with double precision;
         *   - \b clblasInvalidValue if either \b offA or \b offB exceeds the size
         *        of the respective buffer object;
         *   - the same error codes as the clblasStrsm() function otherwise
         *
         * @ingroup TRSM
         */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clblasZtrsm")]
        public static extern CLBLASStatus
        Ztrsm(
            CLBLASOrder order,
            CLBLASSide side,
            CLBLASUpLo uplo,
            CLBLASTranspose transA,
            CLBLASDiag diag,
            size_t m,
            size_t n,
            DoubleComplex alpha,
            cl_mem a, // const cl_mem
            size_t offA,
            size_t lda,
            cl_mem b,
            size_t offB,
            size_t ldb,
            cl_uint numCommandQueues,
            [MarshalAs(UnmanagedType.LPArray)] cl_command_queue[] commandQueues,
            cl_uint numEventsInWaitList,
            [MarshalAs(UnmanagedType.LPArray)] cl_event[] eventWaitList,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] cl_event[] events);

        #endregion
    }
}