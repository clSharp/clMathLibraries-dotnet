using System;
using clsparseIdx_t = System.UInt32;
using cl_mem = System.IntPtr;

namespace CLMathLibraries.CLSparse
{
    public struct CLSparseCsrMatrix
    {
        /** @name CSR matrix data */
        /**@{*/
        public clsparseIdx_t Num_rows;  /*!< Number of rows this matrix has if viewed as dense */
        public clsparseIdx_t Num_cols;  /*!< Number of columns this matrix has if viewed as dense */
        public clsparseIdx_t Num_nonzeros;  /*!< Number of values in matrix that are non-zero */
        /**@}*/

        /** @name OpenCL state */
        /**@{*/
        public cl_mem Values;  /*!< non-zero values in sparse matrix of size num_nonzeros */
        public cl_mem Col_indices;  /*!< column index for corresponding value of size num_nonzeros */
        public cl_mem Row_pointer;  /*!< Invariant: row_pointer[i+1]-row_pointer[i] = number of values in row i */
        /**@}*/

        /** @name Buffer offsets */
        /**@{*/
        /*! Given that cl_mem objects are opaque without pointer arithmetic, these offsets are added to
         * the cl_mem locations on device to define beginning of the data in the cl_mem buffers
         */
        public clsparseIdx_t Off_values;
        public clsparseIdx_t Off_col_indices;
        public clsparseIdx_t Off_row_pointer;

        /**@}*/

        /*! Pointer to a private structure that contains meta-information the library keeps on a 
        csr-encoded sparse matrix
        */
#pragma warning disable CS0169
        private IntPtr _meta;
#pragma warning restore CS0169
    }
}