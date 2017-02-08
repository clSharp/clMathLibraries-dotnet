using System;
using System.Runtime.InteropServices;
using cl_mem = System.IntPtr;
using cl_event = System.IntPtr;
using cl_command_queue = System.IntPtr;
using cl_context = System.IntPtr;

namespace CLMathLibraries.CLFFT
{
    public static class CLFFT
    {
        private const string PathToDll = "clFFT.dll";

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftSetup")]
        public static extern CLFFTStatus Setup(CLFFTSetupData setupData);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftTeardown")]
        public static extern CLFFTStatus Teardown();

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftGetVersion")]
        public static extern CLFFTStatus GetVersion(out UInt32 major, out UInt32 minor, out UInt32 patch);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftCreateDefaultPlan")]
        public static extern CLFFTStatus CreateDefaultPlan(out CLFFTPlanHandle plHandle, cl_context context, CLFFTDim dim, UInt64[] clLengths);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftCopyPlan")]
        public static extern CLFFTStatus CopyPlan(out CLFFTPlanHandle outPlanHandle, cl_context newContext, CLFFTPlanHandle inPlanHandle);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftBakePlan")]
        public static extern CLFFTStatus BakePlan(
            CLFFTPlanHandle plHandle,
            UInt32 numQueues,
            [MarshalAs(UnmanagedType.LPArray)] cl_command_queue[] commQueueFFT,
            CLFFTCallback callback,
            IntPtr userData);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftDestroyPlan")]
        public static extern CLFFTStatus DestroyPlan(ref CLFFTPlanHandle plHandle);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftGetPlanContext")]
        public static extern CLFFTStatus GetPlanContext(CLFFTPlanHandle plHandle, out cl_context context);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftGetPlanPrecision")]
        public static extern CLFFTStatus GetPlanPrecision(CLFFTPlanHandle plHandle, out CLFFTPrecision precision);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftSetPlanPrecision")]
        public static extern CLFFTStatus SetPlanPrecision(CLFFTPlanHandle plHandle, CLFFTPrecision precision);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftGetPlanScale")]
        public static extern CLFFTStatus GetPlanScale(CLFFTPlanHandle plHandle, CLFFTDirection dir, out float scale);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftSetPlanScale")]
        public static extern CLFFTStatus SetPlanScale(CLFFTPlanHandle plHandle, CLFFTDirection dir, float scale);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftGetPlanBatchSize")]
        public static extern CLFFTStatus GetPlanBatchSize(CLFFTPlanHandle plHandle, out UInt64 batchSize);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftSetPlanBatchSize")]
        public static extern CLFFTStatus SetPlanBatchSize(CLFFTPlanHandle plHandle, UInt64 batchSize);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftGetPlanDim")]
        public static extern CLFFTStatus GetPlanDim(CLFFTPlanHandle plHandle, out CLFFTDim dim, out UInt32 size);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftSetPlanDim")]
        public static extern CLFFTStatus SetPlanDim(CLFFTPlanHandle plHandle, CLFFTDim dim);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftGetPlanLength")]
        public static extern CLFFTStatus GetPlanLength(CLFFTPlanHandle plHandle, CLFFTDim dim, [MarshalAs(UnmanagedType.LPArray)] UInt64[] clStrides);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftSetPlanLength")]
        public static extern CLFFTStatus SetPlanLength(CLFFTPlanHandle plHandle, CLFFTDim dim, [MarshalAs(UnmanagedType.LPArray)] UInt64[] clStrides);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftGetPlanInStride")]
        public static extern CLFFTStatus GetPlanInStride(CLFFTPlanHandle plHandle, CLFFTDim dim, [MarshalAs(UnmanagedType.LPArray)] UInt64[] clStrides);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftSetPlanInStride")]
        public static extern CLFFTStatus SetPlanInStride(CLFFTPlanHandle plHandle, CLFFTDim dim, [MarshalAs(UnmanagedType.LPArray)] UInt64[] clStrides);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftGetPlanOutStride")]
        public static extern CLFFTStatus GetPlanOutStride(CLFFTPlanHandle plHandle, CLFFTDim dim, [MarshalAs(UnmanagedType.LPArray)] UInt64[] clStrides);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftSetPlanOutStride")]
        public static extern CLFFTStatus SetPlanOutStride(CLFFTPlanHandle plHandle, CLFFTDim dim, [MarshalAs(UnmanagedType.LPArray)] UInt64[] clStrides);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftGetPlanDistance")]
        public static extern CLFFTStatus GetPlanDistance(CLFFTPlanHandle plHandle, out UInt64 iDist, out UInt64 oDist);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftSetPlanDistance")]
        public static extern CLFFTStatus SetPlanDistance(CLFFTPlanHandle plHandle, UInt64 iDist, UInt64 oDist);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftGetLayout")]
        public static extern CLFFTStatus GetLayout(CLFFTPlanHandle plHandle, out CLFFTLayout iLayout, out CLFFTLayout oLayout);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftSetLayout")]
        public static extern CLFFTStatus SetLayout(CLFFTPlanHandle plHandle, CLFFTLayout iLayout, CLFFTLayout oLayout);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftGetResultLocation")]
        public static extern CLFFTStatus GetResultLocation(CLFFTPlanHandle plHandle, out CLFFTResultLocation placeness);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftSetResultLocation")]
        public static extern CLFFTStatus SetResultLocation(CLFFTPlanHandle plHandle, CLFFTResultLocation placeness);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftGetPlanTransposeResult")]
        public static extern CLFFTStatus GetPlanTransposeResult(CLFFTPlanHandle plHandle, out CLFFTResultTransposed placeness);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftSetPlanTransposeResult")]
        public static extern CLFFTStatus SetPlanTransposeResult(CLFFTPlanHandle plHandle, CLFFTResultTransposed placeness);

        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftGetTmpBufSize")]
        public static extern CLFFTStatus GetTmpBufSize(CLFFTPlanHandle plHandle, out UInt64 size);
        
        [DllImport(PathToDll, CharSet = CharSet.Ansi, EntryPoint = "clfftEnqueueTransform")]
        public static extern CLFFTStatus EnqueueTransform(
            CLFFTPlanHandle plHandle,
            CLFFTDirection dir,
            UInt32 numQueuesAndEvents,
            [MarshalAs(UnmanagedType.LPArray)] cl_command_queue[] commQueues,
            UInt32 numWaitEvents,
            [MarshalAs(UnmanagedType.LPArray)] cl_event[] waitEvents,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] cl_event[] outEvents,
            [MarshalAs(UnmanagedType.LPArray)] cl_mem[] inputBuffers,
            [MarshalAs(UnmanagedType.LPArray)] cl_mem[] outputBuffers,
            cl_mem tmpBuffer
            );

        public static void CheckStatus(CLFFTStatus status)
        {
            if (status != CLFFTStatus.CL_SUCCESS) throw new Exception("CLFFT returned bad status: " + status + " !");
        }
    }
}