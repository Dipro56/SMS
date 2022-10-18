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


          //json update 


          studentList.Add(student);
          // using (StreamWriter w = new StreamWriter("Student.json"))
          // {
          //   var writeData = studentList;

          // }
          var testJSON = Newtonsoft.Json.JsonConvert.SerializeObject(studentList);
          File.WriteAllText(@"C:\Users\USER\Documents\Astha IT\Assignments\SMS\\Student.json", testJSON);








          Console.WriteLine("String convert: ", Newtonsoft.Json.JsonConvert.SerializeObject(studentList));




          Console.WriteLine("Press 1 to stop");
          Console.WriteLine("Press 2 to continue");
          stopAdding = Console.ReadLine();

          if (stopAdding == "1") break;
          else if (stopAdding == "2") continue;
        }

        //add student mode
        // Student student1 = new Student();

        // student1.firstName = "Sadat ";
        // student1.middleName = "Shahriar ";
        // student1.lastName = "Bari ";
        // student1.studentID = "170042056";
        // student1.department = Department.English;
        // student1.degree = Degree.MA;

        //semester realted stuffs
        // Semester semester1 = new Semester();
        // semester1.semesterCode = "Spring";
        // semester1.year = "2017";

        // Semester semester2 = new Semester();
        // semester2.semesterCode = "Fall";
        // semester2.year = "2017";

        // student1.joiningBatch = semester1;

        // student1.semesterAttend.Add(semester1);
        // student1.semesterAttend.Add(semester2);




        //course
        // Course eng1 = new Course();
        // eng1.CourseID = "1";
        // eng1.CourseName = "ENG101";
        // eng1.setInstructorName("ABA");
        // eng1.Credit = 3;

        // Course eng2 = new Course();
        // eng2.CourseID = "2";
        // eng2.CourseName = "ENG201";
        // eng2.setInstructorName("AAM");
        // eng2.Credit = 3;

        // Course eng3 = new Course();
        // eng3.CourseID = "3";
        // eng3.CourseName = "ENG103";
        // eng3.setInstructorName("ABS");
        // eng3.Credit = 3;

        // Course history1 = new Course();
        // history1.CourseID = "4";
        // history1.CourseName = "EL103";
        // history1.setInstructorName("SSB");
        // history1.Credit = 3;

        // CoursePerSemester cps1 = new CoursePerSemester();
        // cps1.semester = semester1;
        // cps1.courses.Add(eng1);
        // cps1.courses.Add(eng2);
        // student1.courseAttendPerSemester.Add(cps1);

        // CoursePerSemester cps2 = new CoursePerSemester();
        // cps2.semester = semester2;
        // cps2.courses.Add(history1);
        // cps2.courses.Add(eng2);
        // cps2.courses.Add(eng3);
        // student1.courseAttendPerSemester.Add(cps2);

        // student1.showStudentDetails();
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


      //----------------------------------------





      //adding course
      // while (true)
      // {

      //   string courseID, courseName, instructorName;
      //   int credit;
      //   int stop;

      //   Console.WriteLine("Course ID:");
      //   courseID = Console.ReadLine();
      //   Console.WriteLine("\n");

      //   Console.WriteLine("Course name:");
      //   courseName = Console.ReadLine();
      //   Console.WriteLine("\n");

      //   Console.WriteLine("Instructor name:");
      //   instructorName = Console.ReadLine();
      //   Console.WriteLine("\n");

      //   Console.WriteLine("Course credit:");
      //   credit = Convert.ToInt32(Console.ReadLine());
      //   Console.WriteLine("\n");

      //   Course newCourse = new Course();
      //   newCourse.CourseID = courseID;
      //   newCourse.CourseName = courseName;
      //   newCourse.InstructorName = instructorName;
      //   newCourse.Credit = credit;


      //   var courseDataString = newCourse.JsonConvert();
      //   var courseDataJSON = Newtonsoft.Json.JsonConvert.DeserializeObject(courseDataString);

      //   courseList.Add(courseDataJSON);

      //   Console.WriteLine("Press 0 to stop and 1 to continue ");
      //   stop = Convert.ToInt32(Console.ReadLine());

      //   if (stop == 0) break;
      //   else if (stop == 1) continue;

      // }


    }
  }
}