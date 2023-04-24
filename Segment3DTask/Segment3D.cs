namespace Segment3DTask
{
    internal class Segment3D
    {
        private readonly double Epsilon = 1.0e-10;

        private readonly double EpsilonDeterminingOnePlane = 1.0e-2;

        public Vector3D Start { get; private set; }

        public Vector3D End { get; private set; }

        public Segment3D(Vector3D start, Vector3D end)
        {
            if (start.Equals(end))
            {
                throw new ArgumentException($"Start and End must not be equal. Start = {start} and End = {end}");
            }

            Start = start;
            End = end;
        }

        public double GetLength()
        {
            return Math.Sqrt(Math.Pow(End.X - Start.X, 2) + Math.Pow(End.Y - Start.Y, 2) + Math.Pow(End.Z - Start.Z, 2));
        }

        public double GetDirectionVectorX()
        {
            return End.X - Start.X;
        }

        public double GetDirectionVectorY()
        {
            return End.Y - Start.Y;
        }

        public double GetDirectionVectorZ()
        {
            return End.Z - Start.Z;
        }

        public bool IsParallel(Segment3D segment)
        {
            var segment1Length = GetLength();
            var segment2Length = segment.GetLength();

            if (Math.Abs((GetDirectionVectorX() / segment1Length) - (segment.GetDirectionVectorX() / segment2Length)) < Epsilon
                && Math.Abs((GetDirectionVectorY() / segment1Length) - (segment.GetDirectionVectorY() / segment2Length)) < Epsilon
                && Math.Abs((GetDirectionVectorZ() / segment1Length) - (segment.GetDirectionVectorZ() / segment2Length)) < Epsilon)
            {
                return true;
            }

            return false;
        }

        public bool IsOnePlane(Segment3D segment)
        {
            var matrixDeterminant = (End.X - Start.X) * (segment.Start.Y - Start.Y) * (segment.End.Z - Start.Z)
                                    + (segment.End.X - Start.X) * (End.Y - Start.Y) * (segment.Start.Z - Start.Z)
                                    + (segment.Start.X - Start.X) * (segment.End.Y - Start.Y) * (End.Z - Start.Z)
                                    - (segment.End.X - Start.X) * (segment.Start.Y - Start.Y) * (End.Z - Start.Z)
                                    - (End.X - Start.X) * (segment.End.Y - Start.Y) * (segment.Start.Z - Start.Z)
                                    - (segment.Start.X - Start.X) * (End.Y - Start.Y) * (segment.End.Z - Start.Z);

            if (matrixDeterminant <= EpsilonDeterminingOnePlane)
            {
                return true;
            }

            return false;
        }

        public bool IsIntersection(Segment3D segment, out Vector3D? intersectionVector3D)
        {
            if (IsParallel(segment))
            {
                intersectionVector3D = null;

                return false;
            }

            if (!IsOnePlane(segment))
            {
                intersectionVector3D = null;

                return false;
            }

            var directionVectorX1 = GetDirectionVectorX();
            var directionVectorY1 = GetDirectionVectorY();

            var directionVectorX2 = segment.GetDirectionVectorX();
            var directionVectorY2 = segment.GetDirectionVectorY();

            var parameter2 = (directionVectorY1 * Start.X - directionVectorY1 * segment.Start.X + directionVectorX1 * segment.Start.Y - directionVectorX1 * Start.Y)
                / (directionVectorY1 * directionVectorX2 - directionVectorX1 * directionVectorY2);

            var parameter1 = (segment.Start.X - Start.X + directionVectorX2 * parameter2) / directionVectorX1;

            if (parameter1 < 0 || parameter1 > 1 || parameter2 < 0 || parameter2 > 1)
            {
                intersectionVector3D = null;

                return false;
            }

            intersectionVector3D = new Vector3D((End.X - Start.X) * parameter2 + Start.X, (End.Y - Start.Y) * parameter2 + Start.Y, (End.Z - Start.Z) * parameter2 + Start.Z);

            return true;
        }

        public override string ToString()
        {
            return $"({Start}, {End})";
        }
    }
}