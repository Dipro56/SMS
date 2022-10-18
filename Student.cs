using System;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace SMS
{
  enum Department
  {
    ComputerScience,
    BBA,
    English
  }

  enum Degree
  {
    BSC,
    BBA,
    BA,
    MSC,
    MBA,
    MA
  }

  class CoursePerSemester
  {

    // public Semester joiningBatch { get; set; }
    public Semester semester { get; set; }
    public List<Course> courses { get; set; }

    // public List<CoursePerSemester> coursePerSemester { get; set; }


    public CoursePerSemester()
    {
      courses = new List<Course>();
      // coursePerSemester = new List<CoursePerSemester>();
    }

  }



  class Student
  {
    public String firstName { get; set; }
    public String middleName { get; set; }
    public String lastName { get; set; }
    public String studentID { get; set; }
    public Semester joiningBatch { get; set; }
    public List<Semester> semesterAttend { get; set; }
    public List<CoursePerSemester> courseAttendPerSemester { get; set; }
    public Department department { get; set; }
    public Degree degree { get; set; }





    public Student()
    {
      semesterAttend = new List<Semester>();
      courseAttendPerSemester = new List<CoursePerSemester>();
    }

    public void showStudentList()
    {

      Console.WriteLine(studentID + "    " + firstName + " " + middleName + " " + lastName + "   " + department);

    }



    public void showStudentDetails()
    {
      Console.WriteLine("Full name: " + firstName + " " + middleName + " " + lastName);
      Console.WriteLine("StudentID: " + studentID);
      Console.WriteLine("Department: " + department);
      Console.WriteLine("Degree: " + degree);
      Console.WriteLine("Joining batch: " + joiningBatch.semesterCode + " " + joiningBatch.year);
      Console.WriteLine("Semester attended:");
      foreach (Semester item in semesterAttend)
      {
        Console.WriteLine(item.semesterName());
      }
      Console.WriteLine("Course attended:");
      Console.WriteLine("---------------------------------\n");
      foreach (CoursePerSemester item in courseAttendPerSemester)
      {
        Console.WriteLine("Semester:");
        Console.WriteLine(item.semester.semesterName() + "\n");

        Console.WriteLine("Courses:");
        foreach (Course course in item.courses)
        {
          Console.WriteLine("ID: " + course.CourseID + "   Credit: " + course.Credit + "   Name: " + course.CourseName);
        }
        Console.WriteLine("---------------------------------\n");
      }
    }

  }
}