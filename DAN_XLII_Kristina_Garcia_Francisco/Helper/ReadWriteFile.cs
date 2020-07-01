using DAN_XLII_Kristina_Garcia_Francisco.Model;
using System.Collections.Generic;
using System.IO;

namespace DAN_XLII_Kristina_Garcia_Francisco.Helper
{
    class ReadWriteFile
    {
        public void ReadLocationFromFile(List<tblLocation> location)
        {
            string file = @"~\..\..\..\Locations.txt";
            int id = 0;

            using (WorkerContext context = new WorkerContext())
            {
                if (File.Exists(file))
                {
                    string[] readFile = File.ReadAllLines(file);

                    for (int i = 0; i < readFile.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(readFile[i]))
                        {
                            string[] trim = readFile[i].Split(',');
                            string address = trim[0];
                            string city = trim[1];
                            string country = trim[2];
                            id++;

                            tblLocation s = new tblLocation(id, address, city, country);
                            location.Add(s);

                            context.tblLocations.Add(s);
                            context.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
