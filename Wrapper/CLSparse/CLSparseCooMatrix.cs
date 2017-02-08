using clsparseIdx_t = System.UInt32;
using cl_mem = System.IntPtr;

namespace CLMathLibraries.CLSparse
{
    public struct CLSparseCooMatrix
    {
        /** @name COO matrix data */
        /**@{*/
        public clsparseIdx_t Num_rows;  /*!< Number of rows this matrix has if viewed as dense */
        public clsparseIdx_t Num_cols;  /*!< Number of columns this matrix has if viewed as dense */
        public clsparseIdx_t Num_nonzeros;  /*!< Number of values in matrix that are non-zero */
        /**@}*/

        /** @name OpenCL state */
        /**@{*/
        public cl_mem Values;  /*!< CSR non-zero values of size num_nonzeros */
        public cl_mem Col_indices;  /*!< column index for corresponding element; array size num_nonzeros */
        public cl_mem Row_indices;  /*!< row index for corresponding element; array size num_nonzeros */
        /**@}*/

        /** @name Buffer offsets */
        /**@{*/
        /*! Given that cl_mem objects are opaque without pointer arithmetic, these offsets are added to
        * the cl_mem locations on device to define beginning of the data in the cl_mem buffers
        */
        public clsparseIdx_t Off_values;
        public clsparseIdx_t Off_col_indices;
        public clsparseIdx_t Off_row_indices;
    }
}