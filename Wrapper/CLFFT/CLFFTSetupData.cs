using System;

namespace CLMathLibraries.CLFFT
{
    public struct CLFFTSetupData
    {
        public UInt32 Major;		/*!< Major version number of the project; signifies major API changes. */
        public UInt32 Minor;		/*!< Minor version number of the project; minor API changes that could break backwards compatibility. */
        public UInt32 Patch;		/*!< Patch version number of the project; Always incrementing number, signifies change over time. */

        /*! 	Bitwise flags that control the behavior of library debug logic. */
        public UInt64 DebugFlags;  /*! This should be set to zero, except when debugging the clAmdFft library.
	                           *  <p> debugFlags can be set to CLFFT_DUMP_PROGRAMS, in which case the dynamically generated OpenCL kernels will
	                           *  be written to text files in the current working directory.  These files will have a *.cl suffix.
	                           */
    };
}