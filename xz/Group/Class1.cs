using System;
using System.Collections.Generic;

namespace Group;

public class StudentGroup
{
    public string Name { get; set; }
    public string College { get; set; }
    public List<Student> student{ get; set; }
    public StudentGroup(string name, string college)
    {
        Name = name;
        College = college;
        student = new List<Student>();
    }
     public void AddStudent(Student studentn)
        {
            student.Add(studentn);
        }
    public void ShowAll()
    {
            student.Sort();
            foreach (var student in student)
            {
                student.Show();
            }
    }
}

public class Student: IComparable<Student>
{
    public string Name { get; set;}
    public double Ocenka { get; set; }
    public Student(string name, double ocenka){
        Name = name;
        Ocenka = ocenka;
    }
    public int CompareTo(Student other)
    {
        return Ocenka.CompareTo(other.Ocenka);
    }

    public void Show()
    {
        Console.WriteLine($"Name: {Name}, Ocenka: {Ocenka}");
    }
}