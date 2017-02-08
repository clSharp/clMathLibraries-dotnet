using System;
using System.Diagnostics;

namespace CLMathLibraries.CLFFT
{
    public struct CLFFTPlanHandle
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IntPtr _value;

        /// <summary>
        /// Gets a logic value indicating whether the handle is valid.
        /// </summary>
        public bool IsValid => _value != IntPtr.Zero;

        /// <summary>
        /// Gets the value of the handle.
        /// </summary>
        public IntPtr Value => _value;

        /// <summary>
        /// Invalidates the handle.
        /// </summary>
        public void Invalidate()
        {
            _value = IntPtr.Zero;
        }
    }
}