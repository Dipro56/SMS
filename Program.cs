using System;
using Newtonsoft;
using System.Collections.Generic;


namespace SMS
{
  class Program
  {
    static void Main(string[] args)
    {
      // CoursePerSemester cs1 = new CoursePerSemester();
      // Semester s1 = new Semester();
      // s1.semesterCode = "test";
      // s1.year = "2024";

      // Course c1 = new Course();
      // c1.CourseID = "1";
      // c1.CourseName = "MAT101";
      // c1.setInstructorName("ASS");
      // c1.Credit = 4;

      // Course c2 = new Course();
      // c2.CourseID = "2";
      // c2.CourseName = "MAT121";
      // c2.setInstructorName("SMC");
      // c2.Credit = 4;





      Student student1 = new Student();

      student1.firstName = "Sadat ";
      student1.middleName = "Shahriar ";
      student1.lastName = "Bari ";
      student1.studentID = "170042056";
      student1.department = Department.English;
      student1.degree = Degree.MA;

      //semester realted stuffs
      Semester semester1 = new Semester();
      semester1.semesterCode = "Spring";
      semester1.year = "2017";

      Semester semester2 = new Semester();
      semester2.semesterCode = "Fall";
      semester2.year = "2017";

      student1.joiningBatch = semester1;

      student1.semesterAttend.Add(semester1);
      student1.semesterAttend.Add(semester2);




      //course
      Course eng1 = new Course();
      eng1.CourseID = "1";
      eng1.CourseName = "ENG101";
      eng1.setInstructorName("ABA");
      eng1.Credit = 3;

      Course eng2 = new Course();
      eng2.CourseID = "2";
      eng2.CourseName = "ENG201";
      eng2.setInstructorName("AAM");
      eng2.Credit = 3;

      Course eng3 = new Course();
      eng3.CourseID = "3";
      eng3.CourseName = "ENG103";
      eng3.setInstructorName("ABS");
      eng3.Credit = 3;

      Course history1 = new Course();
      history1.CourseID = "4";
      history1.CourseName = "EL103";
      history1.setInstructorName("SSB");
      history1.Credit = 3;

      CoursePerSemester cps1 = new CoursePerSemester();
      cps1.semester = semester1;
      cps1.courses.Add(eng1);
      cps1.courses.Add(eng2);
      student1.courseAttendPerSemester.Add(cps1);

      CoursePerSemester cps2 = new CoursePerSemester();
      cps2.semester = semester2;
      cps2.courses.Add(history1);
      cps2.courses.Add(eng2);
      cps2.courses.Add(eng3);
      student1.courseAttendPerSemester.Add(cps2);

      student1.showStudentDetails();


      // CoursePerSemester courseList1 = new CoursePerSemester();
      // courseList1.semester = semester1;
      // courseList1.courses.Add(eng1);
      // courseList1.courses.Add(history1);
      // student1.showStudentDetails();
      // courseList1.showCoursePerSemester();

      // Console.WriteLine("Course semester relation:");
      // var check = courseList1.test();
      // Console.WriteLine(check);
      // Console.WriteLine(returnValue);
      //courseList1.showCoursePerSemester();

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