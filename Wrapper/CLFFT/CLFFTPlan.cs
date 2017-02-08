using System;
using cl_mem = System.IntPtr;
using cl_event = System.IntPtr;
using cl_command_queue = System.IntPtr;
using cl_context = System.IntPtr;


namespace CLMathLibraries.CLFFT
{
    public class CLFFTPlan
    {
        public CLFFTPlanHandle Handle;

        #region Properties

        public bool IsBaked { get; private set; }

        public CLFFTResultLocation ResultLocation {
            get
            {
                CLFFTResultLocation resultLocation;
                var status = CLFFT.GetResultLocation(Handle, out resultLocation);
                CLFFT.CheckStatus(status);
                return resultLocation;
            }
            set
            {
                var status = CLFFT.SetResultLocation(Handle, value);
                CLFFT.CheckStatus(status);
                IsBaked = false;
            }
        }

        public CLFFTDim Dimension
        {
            get
            {
                CLFFTDim planDimension;
                UInt32 size;
                var status = CLFFT.GetPlanDim(Handle, out planDimension, out size);
                CLFFT.CheckStatus(status);
                return planDimension;
            }
            set
            {
                var status = CLFFT.SetPlanDim(Handle, value);
                CLFFT.CheckStatus(status);
                IsBaked = false;
            }
        }

        public UInt32 DimensionCount
        {
            get
            {
                CLFFTDim planDimension;
                UInt32 size;
                var status = CLFFT.GetPlanDim(Handle, out planDimension, out size);
                CLFFT.CheckStatus(status);
                return size;
            }
        }

        public ulong BatchSize
        {
            get
            {
                ulong size;
                var status = CLFFT.GetPlanBatchSize(Handle, out size);
                CLFFT.CheckStatus(status);
                return size;
            }
            set
            {
                var status = CLFFT.SetPlanBatchSize(Handle, value);
                CLFFT.CheckStatus(status);
            }
        }

        public Tuple<ulong, ulong> PlanDistance
        {
            get
            {
                ulong iDist, oDist;
                var status = CLFFT.GetPlanDistance(Handle, out iDist, out oDist);
                CLFFT.CheckStatus(status);
                return new Tuple<ulong, ulong>(iDist, oDist);
            }
            set 
            { 
                var status = CLFFT.SetPlanDistance(Handle, value.Item1, value.Item2);
                CLFFT.CheckStatus(status);
            }
        }

        public Tuple<CLFFTLayout, CLFFTLayout> Layout
        {
            get
            {
                CLFFTLayout iLayout;
                CLFFTLayout oLayout;
                var status = CLFFT.GetLayout(Handle, out iLayout, out oLayout);
                CLFFT.CheckStatus(status);
                return new Tuple<CLFFTLayout, CLFFTLayout>(iLayout, oLayout);
            }
            set
            {
                var status = CLFFT.SetLayout(Handle, value.Item1, value.Item2);
                CLFFT.CheckStatus(status);
                IsBaked = false;
            }
        }

        public ulong[] Length
        {
            get
            {
                var length = new ulong[DimensionCount];
                var status = CLFFT.GetPlanLength(Handle, Dimension, length);
                CLFFT.CheckStatus(status);
                return length;
            }

            set
            {
                var status = CLFFT.SetPlanLength(Handle, Dimension, value);
                CLFFT.CheckStatus(status);
                IsBaked = false;
            }
        }

        public ulong[] StrideIn
        {
            get
            {
                var strideIn = new ulong[DimensionCount];
                var status = CLFFT.GetPlanInStride(Handle, Dimension, strideIn);
                CLFFT.CheckStatus(status);
                return strideIn;
            }
            
            set
            {
                var status = CLFFT.SetPlanInStride(Handle, Dimension, value);
                CLFFT.CheckStatus(status);
                IsBaked = false;
            }
        }

        public ulong[] StrideOut
        {
            get
            {
                var strideOut = new ulong[DimensionCount];
                var status = CLFFT.GetPlanOutStride(Handle, Dimension, strideOut);
                CLFFT.CheckStatus(status);
                return strideOut;
            }

            set
            {
                var status = CLFFT.SetPlanOutStride(Handle, Dimension, value);
                CLFFT.CheckStatus(status);
                IsBaked = false;
            }
        }

        public float ScaleForward
        {
            get
            {
                float scale;
                var status = CLFFT.GetPlanScale(Handle, CLFFTDirection.CLFFT_FORWARD, out scale);
                CLFFT.CheckStatus(status);
                return scale;
            }

            set
            {
                var status = CLFFT.SetPlanScale(Handle, CLFFTDirection.CLFFT_FORWARD, value);
                CLFFT.CheckStatus(status);
                IsBaked = false;
            }
        }

        public float ScaleBackward
        {
            get
            {
                float scale;
                var status = CLFFT.GetPlanScale(Handle, CLFFTDirection.CLFFT_BACKWARD, out scale);
                CLFFT.CheckStatus(status);
                return scale;
            }

            set
            {
                var status = CLFFT.SetPlanScale(Handle, CLFFTDirection.CLFFT_BACKWARD, value);
                CLFFT.CheckStatus(status);
                IsBaked = false;
            }
        }

	    private ulong? _temporaryBufferSize;
        public ulong TemporaryBufferSize
        {
            get
            {
                if (!IsBaked) throw new Exception("Plan was not baked yet");

	            if (!_temporaryBufferSize.HasValue)
	            {
					ulong temporaryBufferSize;
					var status = CLFFT.GetTmpBufSize(Handle, out temporaryBufferSize);
					CLFFT.CheckStatus(status);
					_temporaryBufferSize = temporaryBufferSize;
				}
				
                return _temporaryBufferSize.Value;
            }
        }

        #endregion

        #region Constructors

        public CLFFTPlan(cl_context contextHandle, CLFFTDim dimension, ulong[] size)
        {
            CLFFT.CheckStatus(CLFFT.CreateDefaultPlan(out Handle, contextHandle, dimension, size));
        }

        public CLFFTPlan(cl_context contextHandle, CLFFTSettings settings) : this(contextHandle, settings.Dimension, settings.Size)
        {
            if (settings.ResultLocation != CLFFTResultLocation.CLFFT_INPLACE) ResultLocation = settings.ResultLocation;

            if (settings.Layout.Item1 != CLFFTLayout.CLFFT_COMPLEX_INTERLEAVED || settings.Layout.Item1 != CLFFTLayout.CLFFT_COMPLEX_INTERLEAVED) Layout = settings.Layout;

            StrideIn = settings.StrideIn;
            StrideOut = settings.StrideOut;

            if (settings.BatchSize != 1)
            {
                BatchSize = settings.BatchSize;
                PlanDistance = new Tuple<ulong, ulong>(settings.PlanDistanceIn, settings.PlanDistanceOut);
            }

            ScaleForward = settings.ScaleForward;
            ScaleBackward = settings.ScaleBackward;
        }

        public CLFFTPlan(cl_context newContextHandle, CLFFTPlan other)
        {
            CLFFT.CopyPlan(out Handle, newContextHandle, other.Handle);
        }

        #endregion

        #region Baking

        public void Bake(IntPtr[] queueHandles)
        {
            if (IsBaked) return;
            
            CLFFT.CheckStatus(CLFFT.BakePlan(Handle, (uint)queueHandles.Length, queueHandles, null, IntPtr.Zero));
            IsBaked = true;
        }

        #endregion

        #region Teardown

        public void Destroy()
        {
            CLFFT.DestroyPlan(ref Handle);
        }

        #endregion

        #region Execution

        public void EnqueueTransform(
            CLFFTDirection dir,
            UInt32 numQueuesAndEvents,
            cl_command_queue[] commQueues,
            UInt32 numWaitEvents,
            cl_event[] waitEvents,
            cl_event[] outEvents,
            cl_mem[] inputBuffers,
            cl_mem[] outputBuffers,
            cl_mem tmpBuffer
            )
        {
            CLFFT.CheckStatus(CLFFT.EnqueueTransform(Handle, dir, numQueuesAndEvents, commQueues, numWaitEvents, waitEvents, outEvents, inputBuffers, outputBuffers, tmpBuffer));
            IsBaked = true;
        }
        #endregion
    }
}