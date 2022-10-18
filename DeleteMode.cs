using System;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SMS
{
  class DeleteMode : IMode
  {

    public void modeImplement()
    {
      Console.WriteLine("\nIn delete mode\n");
      List<Student> studentList = new List<Student>();
      using (StreamReader r = new StreamReader("Student.json"))
      {
        string json = r.ReadToEnd();
        studentList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Student>>(json);
        r.Close();
      }
      Console.WriteLine("Give student id to delete: ");
      String idToSearch = Console.ReadLine(); ;
      bool foundStudent = false;

      foreach (Student student in studentList)
      {
        if (student.studentID == idToSearch)
        {
          foundStudent = true;
        }
        if (foundStudent)
        {
          studentList.Remove(student);
          break;
        };
      }

      if (foundStudent == false)
      {
        Console.WriteLine("No such student found\n");
      }
      else
      {
        // Console.WriteLine("Debug: \n");
        // foreach (Student student in studentList)
        // {
        //   student.showStudentDetails();
        // }
        Console.WriteLine("Student with ID " + idToSearch + " deleted successfully");
        using (StreamWriter writer = new StreamWriter("Student.json"))
        {
          var updatedStudentJSON = Newtonsoft.Json.JsonConvert.SerializeObject(studentList);
          writer.Write(updatedStudentJSON);
          writer.Close();
        }
      }

    }
  }
}