using System;
using Newtonsoft;
using System.Collections.Generic;
using System.Text.Json;


namespace SMS
{

  class Program
  {


    public void writeFile(String stringData)
    {
      using (StreamWriter r = new StreamWriter("Student.json"))
      {

        //string json = r.ReadToEnd();
        //Console.WriteLine(json);

        // List<Student> studentList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Student>>(json);
      }
    }
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to student management system!!");
      Console.WriteLine("......................................\n");
      //read json data 
      using (StreamReader r = new StreamReader("Student.json"))
      {
        string json = r.ReadToEnd();
        //Console.WriteLine(json);

        List<Student> studentList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Student>>(json);
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

      Console.WriteLine("Options: \n");
      Console.WriteLine("1.Press 1 to Add student");
      Console.WriteLine("2.Press 2 to View student");
      Console.WriteLine("3.Press 3 to Delete student");
      Console.WriteLine("4.Press 4 to Add semester to student");

      int option = Convert.ToInt32(Console.ReadLine());


      if (option == 1)
      {

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
        string stopAdding;
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

          // var testJSON = Newtonsoft.Json.JsonConvert.SerializeObject(studentList);
          // File.WriteAllText(@"C:\Users\USER\Documents\Astha IT\Assignments\SMS\\Student.json", testJSON);
          // Console.WriteLine("String convert: ", Newtonsoft.Json.JsonConvert.SerializeObject(studentList));

          using (StreamWriter writer = new StreamWriter("Student.json"))
          {
            var newAddedStudentJSON = Newtonsoft.Json.JsonConvert.SerializeObject(studentList);
            writer.Write(newAddedStudentJSON);

          }

          Console.WriteLine("Press 1 to stop");
          Console.WriteLine("Press 2 to continue");
          stopAdding = Console.ReadLine();

          if (stopAdding == "1") break;
          else if (stopAdding == "2") continue;
        }

      }

      else if (option == 2)
      {
        Console.WriteLine("\nIn view mode\n");
        using (StreamReader r = new StreamReader("Student.json"))
        {

          Console.WriteLine("Give student id: ");
          String idToSearch = Console.ReadLine(); ;
          bool foundStudent = false;

          string json = r.ReadToEnd();
          List<Student> studentList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Student>>(json);
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
      else if (option == 4)
      {
        List<Student> studentList = new List<Student>();
        Console.WriteLine("\nAdd semester mode\n");
        using (StreamReader r = new StreamReader("Student.json"))
        {
          string json = r.ReadToEnd();
          studentList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Student>>(json);
          r.Close();
        }

        Console.WriteLine("Give student id: ");
        String idToSearch = Console.ReadLine();
        bool foundStudent = false;


        foreach (Student student in studentList)
        {
          if (student.studentID == idToSearch)
          {
            Console.WriteLine("Student found");
            student.showStudentDetails();
            Console.WriteLine("\n");
            string SemesterCode, Year;
            CoursePerSemester cps = new CoursePerSemester();
            Semester addedSemester = new Semester();
            Console.WriteLine("Add semester:\n");
            Console.WriteLine("Semester code");
            SemesterCode = Console.ReadLine();
            Console.WriteLine("Year");
            Year = Console.ReadLine();
            addedSemester.semesterCode = SemesterCode;
            addedSemester.year = Year;
            student.semesterAttend.Add(addedSemester);
            cps.semester = addedSemester;
            Console.WriteLine("Enter number of courses want to add: ");
            int courseCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Add course to  semester\n");
            for (int i = 1; i <= courseCount; i++)
            {
              Course addedCourse = new Course();
              String courseID, courseName, instructorName;
              int credit;

              Console.WriteLine("Enter course ID:");
              courseID = Console.ReadLine();
              Console.WriteLine("Enter course name:");
              courseName = Console.ReadLine();
              Console.WriteLine("Enter instructor name:");
              instructorName = Console.ReadLine();
              Console.WriteLine("Enter course code:");
              credit = Convert.ToInt32(Console.ReadLine());
              addedCourse.CourseID = courseID;
              addedCourse.CourseName = courseName;
              addedCourse.setInstructorName(instructorName);
              addedCourse.Credit = credit;
              cps.courses.Add(addedCourse);
            }
            student.courseAttendPerSemester.Add(cps);
            foundStudent = true;

            using (StreamWriter writer = new StreamWriter("Student.json"))
            {
              var updatedJSON = Newtonsoft.Json.JsonConvert.SerializeObject(studentList);
              writer.Write(updatedJSON);
              writer.Close();
            }

            // var updatedJSON = Newtonsoft.Json.JsonConvert.SerializeObject(studentList);
            // File.WriteAllText(@"C:\Users\USER\Documents\Astha IT\Assignments\SMS\\Student.json", updatedJSON);

            Console.WriteLine("Data updated :");
            //update json file

          }

          //debug 
        }
        if (foundStudent == false)
        {
          Console.WriteLine("No such student found to add semester\n");
        }

        // Console.WriteLine("All data show :");

        // foreach (Student std in studentList)
        // {
        //   std.showStudentDetails();
        // }


      }
    }
  }
}