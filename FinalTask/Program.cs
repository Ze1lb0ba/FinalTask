using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



namespace FinalTask
{
    class Program
    {
        public const string adressGet = @"C:\FileManager4\Students.dat";
        const string desktopAdress = @"C:\Users\Stank\Desktop\Students\";
        static void Main(string[] args)
        {
            FileCreator.CreateDirectory(desktopAdress);
            Student.Deserilized();
            FileCreator.CreateFiles(desktopAdress);
        }
    }

    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
        public static Student[] students;

        public static void Deserilized()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = File.Open(Program.adressGet, FileMode.Open))
                students = (Student[])bf.Deserialize(fs);
        }

    }

    class FileCreator : Student
    {

        public static void CreateDirectory(string adress)
        {
            DirectoryInfo dir = new DirectoryInfo(adress);
            if (!Directory.Exists(adress))
                Directory.CreateDirectory(adress);
        }

        public static void CreateFiles(string adress)
        {
            foreach (var student in students)
                using (StreamWriter sw = File.AppendText(adress + student.Group + ".txt"))
                    sw.WriteLine(student.Name + " " + student.DateOfBirth);
        }
    }
}
