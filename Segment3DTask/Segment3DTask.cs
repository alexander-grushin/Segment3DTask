namespace Segment3DTask
{
    internal class Segment3DTask
    {
        public static Vector3D? GetIntersectionVector(Segment3D segment1, Segment3D segment2)
        {
            Vector3D? intersectionVector;

            if (segment1.IsIntersection(segment2, out intersectionVector))
            {
                return intersectionVector;
            }

            return intersectionVector;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Задача: трехмерный вектор и трехмерный отрезок.");
            Console.WriteLine("Тестирование:");

            Segment3D segment1 = new Segment3D(new Vector3D(2.5, 2.5, 0.0), new Vector3D(6.0, 5.0, 0.0));
            Segment3D segment2 = new Segment3D(new Vector3D(8.5, 2.0, 5.0), new Vector3D(8.0, 5.0, 0.0));

            Console.WriteLine($"Отрезок 1: {segment1} и отрезок 2: {segment2}");

            Vector3D? vector1 = GetIntersectionVector(segment1, segment2);

            if (vector1 == null)
            {
                Console.WriteLine("Отрезки не пересекаются.");
            }
            else
            {
                Console.WriteLine($"Отрезки пересекаются в точке: {vector1}");
            }

            Console.WriteLine();

            Segment3D segment3 = new Segment3D(new Vector3D(0.0, 0.0, 0.0), new Vector3D(16.1047, 13.7231, -22.6941));
            Segment3D segment4 = new Segment3D(new Vector3D(12.5339, 6.8616, -11.3471), new Vector3D(3.5708, 6.8616, -11.3471));

            Console.WriteLine($"Отрезок 1: {segment3} и отрезок 2: {segment4}");

            Vector3D? vector2 = GetIntersectionVector(segment3, segment4);

            if (vector2 == null)
            {
                Console.WriteLine("Отрезки не пересекаются.");
            }
            else
            {
                Console.WriteLine($"Отрезки пересекаются в точке: {vector2}");
            }

            Console.WriteLine();

            Segment3D segment5 = new Segment3D(new Vector3D(0.0, 0.0, 0.0), new Vector3D(10.0, 20.0, 12.0));
            Segment3D segment6 = new Segment3D(new Vector3D(-10.9325, 0.0, -5.0), new Vector3D(-3.4325, 15.0, 4.0));

            Console.WriteLine($"Отрезок 1: {segment5} и отрезок 2: {segment6}");

            if (segment5.IsParallel(segment6))
            {
                Console.WriteLine("Отрезки параллельны.");
            }
            else
            {
                Console.WriteLine("Отрезки не параллельны.");
            }

            Console.WriteLine();

            Segment3D segment7 = new Segment3D(new Vector3D(20, 20, -30), new Vector3D(0.00, 0.0, 0.0));
            Segment3D segment8 = new Segment3D(new Vector3D(5.5, 0, 10.9), new Vector3D(0.0, 0.0, 0.0));

            Console.WriteLine($"Отрезок 1: {segment7} и отрезок 2: {segment8}");

            Vector3D? vector3 = GetIntersectionVector(segment7, segment8);

            if (vector3 == null)
            {
                Console.WriteLine("Отрезки не пересекаются.");
            }
            else
            {
                Console.WriteLine($"Отрезки пересекаются в точке: {vector3}");
            }
        }
    }
}