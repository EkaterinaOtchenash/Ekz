using System;
using Group;

class Program
{
    static void Main(string[] args)
    {
        var group = new StudentGroup("AAAA", "BBBB");
        group.AddStudent(new Student("John Doe", 3.50));
        group.AddStudent(new Student("Jane Doe", 4.00));
        group.AddStudent(new Student("Jim Smith", 3.00));
        group.ShowAll();
    }
}