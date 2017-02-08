using clsparseIdx_t = System.UInt32;
using cl_mem = System.IntPtr;

namespace CLMathLibraries.CLSparse
{
    public struct CLDenseMatrix
    {
        /** @name Dense matrix data */
        /**@{*/
        public clsparseIdx_t Num_rows;  /*!< Number of rows */
        public clsparseIdx_t Num_cols;  /*!< Number of columns */
        public clsparseIdx_t Lead_dim;  /*! Stride to the next row or column, in units of elements */

        public CLDenseMajor Major;  /*! Memory layout for dense matrix */
        /**@}*/

        public cl_mem Values;  /*!< Array of matrix values */

        /*! Given that cl_mem objects are opaque without pointer arithmetic, these offsets are added to
        * the cl_mem locations on device to define beginning of the data in the cl_mem buffers
        */
        public clsparseIdx_t Off_values;
    }
}