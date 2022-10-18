using System;
using Newtonsoft;
using System.Collections.Generic;
using System.Text.Json;


namespace SMS
{

  class Program
  {



    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to student management system!!");
      Console.WriteLine("......................................\n");
      //read json data 
      using (StreamReader r = new StreamReader("Student.json"))
      {
        string studentData = r.ReadToEnd();

        List<Student> studentList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Student>>(studentData);
        Console.WriteLine("Student list: \n");

        Console.WriteLine("StudentID" + "    " + "Full name" + "              Department\n");

        foreach (Student student in studentList)
        {
          student.showStudentList();
          // student.showStudentDetails();
        }
        Console.WriteLine("\n");
      }

      //student information

      Console.WriteLine("Mode options: \n");
      Console.WriteLine("1.Press 1 to Add student");
      Console.WriteLine("2.Press 2 to View student");
      Console.WriteLine("3.Press 3 to Delete student");
      Console.WriteLine("4.Press 4 to Add semester to student");

      int option = Convert.ToInt32(Console.ReadLine());


      if (option == 1)
      {
        AddStudentMode addMode = new AddStudentMode();
        addMode.modeImplement();
      }

      else if (option == 2)
      {
        ViewMode viewMode = new ViewMode();
        viewMode.modeImplement();
      }
      else if (option == 3)
      {
        DeleteMode deleteMode = new DeleteMode();
        deleteMode.modeImplement();
      }
      else if (option == 4)
      {
        AddSemesterMode addSemesterMode = new AddSemesterMode();
        addSemesterMode.modeImplement();
      }
    }
  }
}