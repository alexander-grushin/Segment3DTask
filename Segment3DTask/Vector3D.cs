namespace Segment3DTask
{
    internal class Vector3D
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"{{{X}; {Y}; {Z}}}";
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Vector3D vector = (Vector3D)obj;

            return X == vector.X && Y == vector.Y && Z == vector.Z;
        }

        public override int GetHashCode()
        {
            const int prime = 37;
            int hash = 1;

            hash = prime * hash + X.GetHashCode();
            hash = prime * hash + Y.GetHashCode();
            hash = prime * hash + Z.GetHashCode();

            return hash;
        }
    }
}