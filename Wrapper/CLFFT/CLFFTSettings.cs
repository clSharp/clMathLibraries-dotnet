using System;
using System.Linq;

namespace CLMathLibraries.CLFFT
{
    public class CLFFTSettings : IEquatable<CLFFTSettings>
    {
        public CLFFTResultLocation ResultLocation { get; }
        public CLFFTDim Dimension { get; }
        public Tuple<CLFFTLayout, CLFFTLayout> Layout { get; }
        public ulong[] Size { get; }
        public ulong[] StrideIn { get; }
        public ulong[] StrideOut { get; }
        public ulong BatchSize { get; }
        public ulong PlanDistanceIn { get; }
        public ulong PlanDistanceOut { get; }

        public float ScaleForward { get; }
        public float ScaleBackward { get; }
        
        public CLFFTSettings(CLFFTDim dimension, ulong[] size, CLFFTResultLocation resultLocation, Tuple<CLFFTLayout, CLFFTLayout> layout, ulong[] strideIn, ulong[] strideOut, ulong batchSize, ulong planDistanceIn, ulong planDistanceOut, float scaleForward, float scaleBackward )
        {
            Dimension = dimension;
            ResultLocation = resultLocation;
            Layout = layout;
            Size = size;
            StrideIn = strideIn;
            StrideOut = strideOut;
            BatchSize = batchSize;
            PlanDistanceIn = planDistanceIn;
            PlanDistanceOut = planDistanceOut;
            ScaleForward = scaleForward;
            ScaleBackward = scaleBackward;
        }

        public bool Equals(CLFFTSettings other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return ResultLocation.Equals(other.ResultLocation)
                   && Dimension.Equals(other.Dimension)
                   && Layout.Equals(other.Layout)
                   && Size.SequenceEqual(other.Size)
                   && StrideIn.SequenceEqual(other.StrideIn)
                   && StrideOut.SequenceEqual(other.StrideOut)
                   && BatchSize.Equals(other.BatchSize)
                   && PlanDistanceIn.Equals(other.PlanDistanceIn)
                   && PlanDistanceOut.Equals(other.PlanDistanceOut)
                   && ScaleForward.Equals(other.ScaleForward)
                   && ScaleBackward.Equals(other.ScaleBackward);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((CLFFTSettings) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ResultLocation.GetHashCode();
                hashCode = (hashCode * 397) ^ Dimension.GetHashCode();
                hashCode = (hashCode * 397) ^ Layout.Item1.GetHashCode();
                hashCode = (hashCode * 397) ^ Layout.Item2.GetHashCode();
                hashCode = (hashCode * 397) ^ BatchSize.GetHashCode();
                hashCode = (hashCode * 397) ^ PlanDistanceIn.GetHashCode();
                hashCode = (hashCode * 397) ^ PlanDistanceOut.GetHashCode();
                hashCode = (hashCode * 397) ^ Size[0].GetHashCode();
                hashCode = (hashCode * 397) ^ ScaleForward.GetHashCode();
                hashCode = (hashCode * 397) ^ ScaleBackward.GetHashCode();
                if (Size.GetLength(0) > 1) hashCode = (hashCode * 397) ^ Size[1].GetHashCode();
                if (Size.GetLength(0) > 2) hashCode = (hashCode * 397) ^ Size[2].GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            var resultLocation = ResultLocation.ToString();
            var layoutFrom = Layout.Item1.ToString();
            var layoutTo = Layout.Item2.ToString();

            if (Dimension == CLFFTDim.CLFFT_1D) return $"CLFFTSetting(X: {Size[0]} B: {BatchSize}, {resultLocation}, {layoutFrom} -> {layoutTo})";
            if (Dimension == CLFFTDim.CLFFT_2D) return $"CLFFTSetting(X: {Size[0]} Y: {Size[1]} B: {BatchSize}, {resultLocation}, {layoutFrom} -> {layoutTo})";
            if (Dimension == CLFFTDim.CLFFT_3D) return $"CLFFTSetting(X: {Size[0]} Y: {Size[1]} Z: {Size[2]} B: {BatchSize}, {resultLocation}, {layoutFrom} -> {layoutTo})";
            throw new NotImplementedException();
        }
    }
}
