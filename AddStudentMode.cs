using System;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SMS
{
  class AddStudentMode : IMode
  {

    public void modeImplement()
    {
      bool IDValidation(String ID)
      {
        bool isValid = true;
        if (string.IsNullOrEmpty(ID))
          isValid = false;
        else
        {
          try
          {

            isValid = Regex.IsMatch(ID, @"^([0-9][0-9][0-9])-([0-9][0-9][0-9])-([0-9][0-9][0-9])$");
            Console.WriteLine(ID);
          }
          catch (FormatException fx)
          {
            isValid = false;
          }
        }
        return isValid;
      }
      Console.WriteLine("\nIn view mode\n");
      List<Student> studentList = new List<Student>();
      string studentDataString;
      using (StreamReader r = new StreamReader("Student.json"))
      {
        string json = r.ReadToEnd();
        studentList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Student>>(json);
        r.Close();
      }

      Console.WriteLine("Add student: \n");
      while (true)
      {
        Student student = new Student();
        Semester semester = new Semester();
        String FirstName, MiddleName, LastName, SemesterCode, Year, StudentID;
        String departMentOption, degreeOption;

        //input taking
        Console.WriteLine("Enter student name: ");

        Console.WriteLine("First name:");
        FirstName = Console.ReadLine();
        Console.WriteLine("Middle name:");
        MiddleName = Console.ReadLine();
        Console.WriteLine("Last  name:");
        LastName = Console.ReadLine();
        student.firstName = FirstName;
        student.middleName = MiddleName;
        student.lastName = LastName;
        //department 
        Console.WriteLine("Enter student department: ");
        Console.WriteLine("press 1 for ComputerScience");
        Console.WriteLine("press 2 for BBA");
        Console.WriteLine("press 3 for English\n");

        departMentOption = Console.ReadLine();
        if (departMentOption == "1")
        {
          student.department = Department.ComputerScience;
        }
        else if (departMentOption == "2")
        {
          student.department = Department.BBA;
        }
        else if (departMentOption == "3")
        {
          student.department = Department.English;
        }

        //degree adding 
        Console.WriteLine("Enter student degree: ");
        Console.WriteLine("press 1 for BSC");
        Console.WriteLine("press 2 for BBA");
        Console.WriteLine("press 3 for BA");
        Console.WriteLine("press 4 for MSC");
        Console.WriteLine("press 5 for MBA");
        Console.WriteLine("press 6 for MA\n");
        degreeOption = Console.ReadLine();

        if (degreeOption == "1")
        {
          student.degree = Degree.BSC;
        }
        else if (degreeOption == "2")
        {
          student.degree = Degree.BBA;
        }
        else if (degreeOption == "3")
        {
          student.degree = Degree.BA;
        }
        else if (degreeOption == "4")
        {
          student.degree = Degree.MSC;
        }
        else if (degreeOption == "5")
        {
          student.degree = Degree.MBA;
        }
        else if (degreeOption == "6")
        {
          student.degree = Degree.MA;
        }

        //student id
        Console.WriteLine("Enter student id: \n");

        StudentID = Console.ReadLine();
        bool idCheck = IDValidation(StudentID);

        if (idCheck == false) Console.WriteLine("Your data wont be saved add valid id");
        else
        {
          student.studentID = StudentID;
          //add joining semester
          Console.WriteLine("Add student joining semester: \n");
          Console.WriteLine("Enter semester code:");
          SemesterCode = Console.ReadLine();
          Console.WriteLine("Enter year:");
          Year = Console.ReadLine();
          semester.semesterCode = SemesterCode;
          semester.year = Year;
          student.joiningBatch = semester;
          Console.WriteLine("Student details: \n");
          student.showStudentDetails();


          studentList.Add(student);

          using (StreamWriter writer = new StreamWriter("Student.json"))
          {
            var newAddedStudentJSON = Newtonsoft.Json.JsonConvert.SerializeObject(studentList);
            writer.Write(newAddedStudentJSON);
            writer.Close();
          }
          string stopAdding;

          Console.WriteLine("Press 1 to stop");
          Console.WriteLine("Press 2 to continue");
          stopAdding = Console.ReadLine();
          if (stopAdding == "1") break;
          else if (stopAdding == "2") continue;
        }
      }
    }
  }
}