namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter First Point x,y,z:");
            try
            {
                string[] input = Console.ReadLine().Split(',');
                Point3D p1 = new Point3D(int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));
                Console.Write("Enter Second Point x,y,z:");
                input = Console.ReadLine().Split(',');
                Point3D p2 = new Point3D(int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));

                Console.WriteLine(p1.Equals(p2));


            }
          catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

                StreamWriter logger= File.AppendText("ErrorLog.txt");

                logger.WriteLine($"{ex.Message} -{ex.Source}-{ex.TargetSite} -{DateTime.Now.ToString()}" );
                logger.Close();


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                StreamWriter logger = File.AppendText("ErrorLog.txt");

                logger.WriteLine($"{ex.Message} -{ex.Source}-{ex.TargetSite} -{DateTime.Now.ToString()}");
                logger.Close();
            }
            
          
            
           

          

        }


        public class Point3D
        {
            public int x { get; set; }
            public int y { get; set; }
            public int z { get; set; }

            public Point3D(int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
            public Point3D(int x, int y):this(x, y, 0)
            {
            }
            public Point3D(int x) : this(x, 0, 0)
            {
            }
            public override string ToString()
            {
                return $"({x}, {y}, {z})";
            }

            public override bool Equals(object? obj)
            {
            if (obj is Point3D point)
                {
                    return x == point.x && y == point.y && z == point.z;
                }
                

            throw new ArgumentException("Object is not a Point3D");

            }

            public static bool operator ==(Point3D p1, Point3D p2)
            {
                return p1.x == p2.x && p1.y == p2.y && p1.z == p2.z;
            }
            public static bool operator !=(Point3D p1, Point3D p2)
            {
                return !(p1.x == p2.x && p1.y == p2.y && p1.z == p2.z);
            }


        }








    }
}
