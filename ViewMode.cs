using System;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SMS
{
  class ViewMode : IMode
  {

    public void modeImplement()
    {
      Console.WriteLine("\nIn view mode\n");
      List<Student> studentList = new List<Student>();
      using (StreamReader r = new StreamReader("Student.json"))
      {
        string json = r.ReadToEnd();
        studentList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Student>>(json);
      }
      Console.WriteLine("Give student id: ");
      String idToSearch = Console.ReadLine(); ;
      bool foundStudent = false;

      foreach (Student student in studentList)
      {
        if (student.studentID == idToSearch)
        {
          student.showStudentDetails();
          foundStudent = true;
        }
        if (foundStudent) break;
      }

      if (foundStudent == false)
      {
        Console.WriteLine("No such student found\n");
      }

    }
  }
}