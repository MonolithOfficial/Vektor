using System;

class Vektor
{
    static void Main(string[] args)
    {
        Console.WriteLine("VEKTOR ALIVE;\n[VEKTOR] Choose operation: insert 1 for Dot product, or 2 for Cross product\n");
        String operation;
        do
        {
            operation = Console.ReadLine();
            if (operation != "1" && operation != "2")
            {
                Console.WriteLine("[VEKTOR] INVALID INPUT.");
            }
        }
        while (operation != "1" && operation != "2");

        if (operation == "1")
        {
            Console.WriteLine("[VEKTOR] Dot Product chosen.");

            Console.WriteLine("[VEKTOR] Choose dimensions: insert 2 for 2D, or 3 for 3D\n");
            String dimensions;

            do
            {
                dimensions = Console.ReadLine();
                if (dimensions != "2" && dimensions != "3")
                {
                    Console.WriteLine("[VEKTOR] INVALID INPUT.");
                }
            }
            while (dimensions != "2" && dimensions != "3");

            if (dimensions == "2")
            {
                Console.WriteLine("VEKTOR] Insert {x, y} values for each vector: ");


                Vector vct1 = Vector.getVectorInput("1");
                Vector vct2 = Vector.getVectorInput("2");

                Console.WriteLine("[VEKTOR] Dot product for V1({0}, {1}) and V2({2}, {3}) is {4}", vct1.x, vct1.y, vct2.x, vct2.y, vct1.calcDot(vct2));
            }
            else if (dimensions == "3")
            {
                Console.WriteLine("VEKTOR] Insert {x, y, z} values for each vector: ");


                Vector3D vct1 = Vector3D.getVectorInput("1");
                Vector3D vct2 = Vector3D.getVectorInput("2");

                Console.WriteLine(
                "[VEKTOR] Dot product of V1({0}, {1}, {2}) and V2({3}, {4}, {5}) is {6}",
                vct1.x, vct1.y, vct1.z, vct2.x, vct2.y, vct2.z, vct1.calcDot(vct2)
                );
            }
            else
            {
                Console.WriteLine("[VEKTOR] INVALID INPUT.");
            }


        }
        else if (operation == "2")
        {
            Console.WriteLine("[VEKTOR] Cross Product chosen.");
            Console.WriteLine("VEKTOR] Insert {x, y, z} values for each vector: ");


            Vector3D vct1 = Vector3D.getVectorInput("1");
            Vector3D vct2 = Vector3D.getVectorInput("2");

            Vector3D crossProd = vct1.calcCross(vct2);

            Console.WriteLine(
                "[VEKTOR] Cross product of V1({0}, {1}, {2}) and V2({3}, {4}, {5}) is V3({6}, {7}, {8})",
                vct1.x, vct1.y, vct1.z, vct2.x, vct2.y, vct2.z, crossProd.x, crossProd.y, crossProd.z
            );
        }
    }
}

class Vector
{
    public double x, y;

    public static Vector getVectorInput(String vectorID)
    {
        Console.WriteLine("[VEKTOR] Inputs for vector #{0}.", vectorID);
        int valInputIndex = 0;
        Vector vector = new Vector();
        do
        {
            switch (valInputIndex)
            {
                case 0:
                    Console.WriteLine("X: ");
                    vector.x = Helpers.getSecureDoubleInput();
                    break;
                case 1:
                    Console.WriteLine("Y: ");
                    vector.y = Helpers.getSecureDoubleInput();
                    break;
                default:
                    break;
            }
            valInputIndex++;
        }
        while (valInputIndex < 2);
        return vector;
    }

    public double calcDot(Vector other)
    {
        return (this.x * other.x) + (this.y * other.y);
    }

    public static double getVectorLength(Vector vector)
    {
        return Math.Sqrt(Math.Pow(vector.x, 2) + Math.Pow(vector.y, 2));
    }
}

class Vector3D
{
    public double x, y, z;
    public static Vector3D getVectorInput(String vectorID)
    {
        Console.WriteLine("[VEKTOR] Inputs for vector #{0}.", vectorID);
        int valInputIndex = 0;
        Vector3D vector = new Vector3D();
        do
        {
            switch (valInputIndex)
            {
                case 0:
                    Console.WriteLine("X: ");
                    vector.x = Helpers.getSecureDoubleInput();
                    break;
                case 1:
                    Console.WriteLine("Y: ");
                    vector.y = Helpers.getSecureDoubleInput();
                    break;
                case 2:
                    Console.WriteLine("Z: ");
                    vector.z = Helpers.getSecureDoubleInput();
                    break;
                default:
                    break;
            }
            valInputIndex++;
        }
        while (valInputIndex < 3);
        return vector;
    }

    public double calcDot(Vector3D other)
    {
        return (this.x * other.x) + (this.y * other.y) + (this.z * other.z);
    }

    public Vector3D calcCross(Vector3D other)
    {
        Vector3D crossProd = new Vector3D();
        crossProd.x = (this.y * other.z) - (this.z * other.y);
        crossProd.y = (this.z * other.x) - (this.x * other.z);
        crossProd.z = (this.x * other.y) - (this.y * other.x);

        return crossProd;
    }
}

class Helpers
{
    public static double getSecureDoubleInput()
    {
        String input;
        do
        {
            input = Console.ReadLine();
            if (!double.TryParse(input, out _))
            {
                Console.WriteLine("[VEKTOR] INVALID INPUT.");
            }
        }
        while (!double.TryParse(input, out _));

        return double.Parse(input);
    }
}