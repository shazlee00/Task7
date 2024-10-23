using System.Net.NetworkInformation;

namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task 7 part 1
            Console.WriteLine("---------------------Task 7 part 1:-------------------------------");
            Console.Write("Enter First Point x,y,z:");
            try
            {
                string[] input = Console.ReadLine().Split(',');
                Point3D p1 = new Point3D(int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));
                Console.Write("Enter Second Point x,y,z:");
                input = Console.ReadLine().Split(',');
                Point3D p2 = new Point3D(int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));

                Console.WriteLine(p1.Equals(p2)? "Points are equal" : "Points are not equal");


            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

                StreamWriter logger = File.AppendText("ErrorLog.txt");

                logger.WriteLine($"{ex.Message} -{ex.Source}-{ex.TargetSite} -{DateTime.Now.ToString()}");
                logger.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                StreamWriter logger = File.AppendText("ErrorLog.txt");

                logger.WriteLine($"{ex.Message} -{ex.Source}-{ex.TargetSite} -{DateTime.Now.ToString()}");
                logger.Close();
            }
            #endregion

            Console.WriteLine("---------------------Task 7 part 2:-------------------------------");

            #region Singlton Task

            var nic = NIC.NICInstance;

            Console.WriteLine(nic);


            #endregion



        }

        public class NIC
        {
            public string Name { get; set; }

            public string Description { get; set; }
            public string Ip { get; set; }
            public string Mac { get; set; }

            public string Manufacturer { get; set; }

            public string Type { get; set; }



            private static NIC _nic;

            private  NIC()
            {
                var wifiDevice = NetworkInterface.GetAllNetworkInterfaces().Where(x => x.Name == "Ethernet").FirstOrDefault();

                

                Name= wifiDevice.Name;
                Ip = wifiDevice.GetIPProperties().UnicastAddresses[0].Address.ToString();
                Mac = wifiDevice.GetPhysicalAddress().ToString();
                Description = wifiDevice.Description;
                Manufacturer = wifiDevice.Description;
                Type = wifiDevice.NetworkInterfaceType.ToString();



            }


            public static NIC NICInstance
            {
                get
                {
                    if (_nic == null)
                    {
                        _nic = new NIC();
                    }
                    return _nic;
                }

                set
                {

                }
            }




            public override string ToString()
            {
                return $"Name:{Name}\nIp:{Ip}\nMac:{Mac}\nDescription:{Description}\nManufacturer:{Manufacturer} \nType:{Type}";
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
