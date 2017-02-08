using clsparseIdx_t = System.UInt32;
using cl_mem = System.IntPtr;

namespace CLMathLibraries.CLSparse
{
    public struct CLDenseVector
    {
        public clsparseIdx_t Num_values;  /*!< Length of dense vector */

        public cl_mem Values;  /*!< OpenCL 1.x memory handle */

        /*! Given that cl_mem objects are opaque without pointer arithmetic, this offset is added to
         * the cl_mem locations on device to define beginning of the data in the cl_mem buffers
         */
        public clsparseIdx_t Off_values;
    }
}