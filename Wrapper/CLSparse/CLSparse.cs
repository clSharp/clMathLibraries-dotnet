using System;
using System.Runtime.InteropServices;
using size_t = System.UInt32;

namespace CLMathLibraries.CLSparse
{
    public static class CLSparse
    {
        private const string PathToDll = "clSPARSE";

        #region Init

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clsparseSetup")]
        public static extern CLSparseStatus Setup();

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clsparseTeardown")]
        public static extern CLSparseStatus Teardown();

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clsparseGetVersion")]
        public static extern CLSparseStatus GetVersion(out size_t major, out size_t minor, out size_t patch, out size_t tweak);

        #endregion

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clsparseCreateControl")]
        public static extern CLSparseCreateResult CreateControl(IntPtr queue);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clsparseReleaseControl")]
        public static extern CLSparseStatus ReleaseControl(CLSparseControl control);

        #region Init

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clsparseInitScalar")]
        public static extern CLSparseStatus InitScalar(out CLSparseScalar scalar);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clsparseInitVector")]
        public static extern CLSparseStatus InitVector(out CLDenseVector vec);
        
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clsparseInitCsrMatrix")]
        public static extern CLSparseStatus InitCsrMatrix(out CLSparseCsrMatrix csrMatx);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clsparseInitCooMatrix")]
        public static extern CLSparseStatus InitCooMatrix(out CLSparseCooMatrix cooMatx);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "cldenseInitMatrix")]
        public static extern CLSparseStatus InitMatrix(out CLDenseMatrix denseMatx);

        #endregion

        #region Solvers

        /*!
        * \brief Create a clSParseSolverControl object to control clsparse iterative
        * solver operations
        *
        * \param[in] precond  A valid enumeration constant from PRECONDITIONER
        * \param[in] maxIters  Maximum number of iterations to converge before timing out
        * \param[in] relTol  Relative tolerance
        * \param[in] absTol  Absolute tolerance
        *
        * \returns \b clsparseSuccess
        *
        * \ingroup SOLVER
        */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clsparseCreateSolverControl")]
        public static extern CLSparseCreateSolverResult CreateSolverControl(
            CLPreconditioner precond, 
            int maxIters,
            double relTol,
            double absTol);

        /*!
         * \brief Release a clSParseSolverControl object created with clsparseCreateSolverControl
         *
         * \param[in,out] solverControl  clSPARSE object created with clsparseCreateSolverControl
         *
         * \returns \b clsparseSuccess
         *
         * \ingroup SOLVER
         */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clsparseReleaseSolverControl")]
        public static extern CLSparseStatus ReleaseSolverControl(CLSparseSolverControl solverControl);

        /*!
        * \brief Set clSParseSolverControl state
        *
        * \param[in] solverControl  clSPARSE object created with clsparseCreateSolverControl
        * \param[in] precond A valid enumeration constant from PRECONDITIONER, how to precondition sparse data
        * \param[in] maxIters  Maximum number of iterations to converge before timing out
        * \param[in] relTol  Relative tolerance
        * \param[in] absTol  Absolute tolerance
        *
        * \returns \b clsparseSuccess
        *
        * \ingroup SOLVER
        */
        //CLSPARSE_EXPORT clsparseStatus
        //clsparseSetSolverParams(clSParseSolverControl solverControl,
        //                         PRECONDITIONER precond,
        //                         cl_int maxIters, cl_double relTol, cl_double absTol);

        /*!
        * \brief Set the verbosity level of the clSParseSolverControl object
        *
        * \param[in] solverControl  clSPARSE object created with clsparseCreateSolverControl
        * \param[in] mode A valid enumeration constant from PRINT_MODE, to specify verbosity level
        *
        * \returns \b clsparseSuccess
        *
        * \ingroup SOLVER
        */
        //CLSPARSE_EXPORT clsparseStatus
        //clsparseSolverPrintMode(clSParseSolverControl solverControl, PRINT_MODE mode);

        /*!
        * \brief Execute a single precision Conjugate Gradients solver
        *
        * \param[in] x  the dense vector to solve for
        * \param[in] A  a clSPARSE CSR matrix with single precision data
        * \param[in] b  the input dense vector with single precision data
        * \param[in] solverControl  a valid clSParseSolverControl object created with clsparseCreateSolverControl
        * \param[in] control A valid clsparseControl created with clsparseCreateControl
        *
        * \returns \b clsparseSuccess
        *
        * \ingroup SOLVER
        */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clsparseScsrcg")]
        public static extern CLSparseStatus Scsrcg(
            ref CLDenseVector x,
            ref CLSparseCsrMatrix A,
            ref CLDenseVector b,
            CLSparseSolverControl solverControl, 
            CLSparseControl control );

        /*!
         * \brief Execute a single precision Bi-Conjugate Gradients Stabilized solver
         *
         * \param[in] x  the dense vector to solve for
         * \param[in] A  the clSPARSE CSR matrix with single precision data
         * \param[in] b  the input dense vector with single precision data
         * \param[in] solverControl  a valid clSParseSolverControl object created with clsparseCreateSolverControl
         * \param[in] control A valid clsparseControl created with clsparseCreateControl
         *
         * \returns \b clsparseSuccess
         *
         * \ingroup SOLVER
         */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clsparseScsrbicgStab")]
        public static extern CLSparseStatus ScsrbicgStab(
           ref CLDenseVector x,
           ref CLSparseCsrMatrix A,
           ref CLDenseVector b,
           CLSparseSolverControl solverControl,
           CLSparseControl control);

        #endregion

        #region BLAS Level 1

        /*!
         * \brief Single precision scale dense vector by a scalar
         * \details \f$ r \leftarrow \alpha \ast y \f$
         * \param[out] r  Output dense vector
         * \param[in] alpha  Scalar value to multiply
         * \param[in] y  Input dense vector
         * \param[in] control A valid clsparseControl created with clsparseCreateControl
         *
         * \ingroup BLAS-1
         */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "cldenseSscale")]
        public static extern CLSparseStatus Sscale(
            ref CLDenseVector r,
            ref CLSparseScalar alpha,
            ref CLDenseVector y,
            CLSparseControl control);

        /*!
         * \brief Calculate the single precision L2 norm of a dense vector
         * \param[out] s  Output scalar
         * \param[in] x  Input dense vector
         * \param[in] control A valid clsparseControl created with clsparseCreateControl
         *
         * \ingroup BLAS-1
         */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "cldenseSnrm2")]
        public static extern CLSparseStatus Snrm2(
            ref CLSparseScalar s,
            ref CLDenseVector x,
            CLSparseControl control );

        #endregion

        #region BLAS Level 2 

        /*!
         * \brief Single precision CSR sparse matrix times dense vector
         * \details \f$ y \leftarrow \alpha \ast A \ast x + \beta \ast y \f$
         * If the CSR sparse matrix structure has rowBlocks information included,
         * then the csr-adaptive algorithm is used.  Otherwise, the csr-vector
         * algorithm is used.
         * \param[in] alpha  Scalar value to multiply against sparse matrix
         * \param[in] matx  Input CSR sparse matrix
         * \param[in] x  Input dense vector
         * \param[in] beta  Scalar value to multiply against sparse vector
         * \param[out] y  Output dense vector
         * \param[in] control A valid clsparseControl created with clsparseCreateControl
         *
         * \ingroup BLAS-2
        */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clsparseScsrmv")]
        public static extern CLSparseStatus Scsrmv(
            ref CLSparseScalar alpha,
            ref CLSparseCsrMatrix matx,
            ref CLDenseVector x,
            ref CLSparseScalar beta,
            ref CLDenseVector y,
            CLSparseControl control);

        /*!
         * \brief Single precision COO sparse matrix times dense vector
         * \details \f$ y \leftarrow \alpha \ast A \ast x + \beta \ast y \f$
         * \param[in] alpha  Scalar value to multiply against sparse matrix
         * \param[in] matx  Input COO sparse matrix
         * \param[in] x  Input dense vector
         * \param[in] beta  Scalar value to multiply against sparse vector
         * \param[out] y  Output dense vector
         * \param[in] control A valid clsparseControl created with clsparseCreateControl
         *
         * \ingroup BLAS-2
        */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clsparseScoomv")]
        public static extern CLSparseStatus Scoomv(
            ref CLSparseScalar alpha,
            ref CLSparseCooMatrix matx,
            ref CLDenseVector x,
            ref CLSparseScalar beta,
            ref CLDenseVector y,
            CLSparseControl control);

        #endregion

        #region Convert

        /*!
         * \brief Convert a single precision COO encoded sparse matrix into a CSR encoded sparse matrix
         * \param[in] coo  Input COO encoded sparse matrix
         * \param[out] csr  Output CSR encoded sparse matrix
         * \param[in] control A valid clsparseControl created with clsparseCreateControl
         * \pre The sparse matrix data must first be sorted by rows, then by columns
         *
         * \ingroup CONVERT
         */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clsparseScoo2csr")]
        public static extern CLSparseStatus Scoo2csr(
            ref CLSparseCooMatrix coo,
            ref CLSparseCsrMatrix csr,
            CLSparseControl control);

        /*!
         * \brief Convert a single precision CSR encoded sparse matrix into a dense matrix
         * \param[in] csr  Input CSR encoded sparse matrix
         * \param[out] A  Output dense matrix
         * \param[in] control A valid clsparseControl created with clsparseCreateControl
         * \pre The sparse matrix data must first be sorted by rows, then by columns
         *
         * \ingroup CONVERT
         */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clsparseScsr2dense")]
        public static extern CLSparseStatus Scsr2dense(
            ref CLSparseCsrMatrix csr,
            ref CLDenseMatrix A,
            CLSparseControl control);

        /*!
         * \brief Convert a double precision dense matrix into a CSR encoded sparse matrix
         * \param[in] A  Input dense matrix
         * \param[out] csr  Output CSR encoded sparse matrix
         * \param[in] control A valid clsparseControl created with clsparseCreateControl
         * \pre The sparse matrix data must first be sorted by rows, then by columns
         *
         * \ingroup CONVERT
         */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clsparseSdense2csr")]
        public static extern CLSparseStatus Sdense2csr(
            ref CLDenseMatrix A,
            ref CLSparseCsrMatrix csr,
            CLSparseControl control);

        #endregion

        #region BLAS Level 3

        /*!
         * \brief Single Precision CSR Sparse Matrix times Sparse Matrix
         * \details \f$ C \leftarrow A \ast B \f$
         * \param[in] sparseMatA Input CSR sparse matrix
         * \param[in] sparseMatB Input CSR sparse matrix
         * \param[out] sparseMatC Output CSR sparse matrix
         * \param[in] control A valid clsparseControl created with clsparseCreateControl
         * \pre The input sparse matrices data must first be sorted by rows, then by columns
         * \ingroup BLAS-3
         */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clsparseScsrSpGemm")]
        public static extern CLSparseStatus ScsrSpGemm(
            ref CLSparseCsrMatrix sparseMatA,
            ref CLSparseCsrMatrix sparseMatB,
            out CLSparseCsrMatrix sparseMatC,
            CLSparseControl control);

        #endregion

        #region Meta

        /*!
         * \brief Allocate memory and calculate the meta-data for csr-adaptive SpM-dV algorithm
         * \details CSR-adaptive is a high performance sparse matrix times dense vector algorithm.  It requires a pre-processing
         * step to calculate meta-data on the sparse matrix.  This meta-data is stored alongside and carried along
         * with the other matrix data.  This function allocates memory for the meta-data and initializes it with proper values.
         * It is important to remember to deallocate the meta memory with clsparseCsrMetaDelete
         * \param[in,out] csrMatx  The CSR sparse structure that represents the matrix in device memory
         * \param[in] control  A valid clsparseControl created with clsparseCreateControl
         * \note This function assumes that the memory for rowBlocks has already been allocated by client program
         *
         * \ingroup FILE
         */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clsparseCsrMetaCreate")]
        public static extern CLSparseStatus CsrMetaCreate(
           ref CLSparseCsrMatrix csrMatx,
           CLSparseControl control);

        /*!
        * \brief Delete meta data associated with a CSR encoded matrix
        * \details Meta data for a sparse matrix may occupy device memory, and this informs the library to release it
        * \param[in,out] csrMatx  The CSR sparse structure that represents the matrix in device memory
        *
        * \ingroup FILE
        */
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clsparseCsrMetaDelete")]
        public static extern CLSparseStatus CsrMetaDelete(
              ref CLSparseCsrMatrix csrMatx);

        #endregion

        #region Error checking

        public static void CheckStatus(CLSparseStatus status)
        {
            if (status != CLSparseStatus.Success)
                throw new Exception("CLSparse returned bad status: " + status + " !");
        }

        #endregion
    }
}