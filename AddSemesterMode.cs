using System;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SMS
{
  class AddSemesterMode : IMode
  {

    public void modeImplement()
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
            Console.WriteLine("Enter course credit:");
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

          Console.WriteLine("Data updated");

        }

        //debug 
      }
      if (foundStudent == false)
      {
        Console.WriteLine("No such student found to add semester\n");
      }


    }
  }
}