using System;

namespace CLMathLibraries.CLSparse
{
    public struct CLSparseScalar
    {
        public IntPtr Value;  /**< OpenCL 1.x memory handle */

        /*! Given that cl_mem objects are opaque without pointer arithmetic, this offset is added to
         * the cl_mem locations on device to define beginning of the data in the cl_mem buffers
         */
        public UInt32 Off_value;
    }
}