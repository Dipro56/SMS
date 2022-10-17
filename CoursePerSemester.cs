// using System;
// using Newtonsoft;
// using Newtonsoft.Json.Linq;
// using System.Collections.Generic;


// namespace SMS
// {

//   class CoursePerSemester
//   {

//     // public Semester joiningBatch { get; set; }
//     public Semester semester { get; set; }
//     public List<Course> courses { get; set; }

//     public CoursePerSemester courseSemesterRelation;




//     // public List<CoursePerSemester> coursePerSemester { get; set; }


//     public CoursePerSemester()
//     {
//       courses = new List<Course>();
//       // coursePerSemester = new List<CoursePerSemester>();
//     }

//     public void showCoursePerSemester()
//     {

//       Console.WriteLine("Semester batch: " + semester.semesterName());

//       foreach (Course item in courses)
//       {
//         Console.WriteLine("Course name: " + item.CourseName);
//       }


//     }

//     public CoursePerSemester test()
//     {
//       courseSemesterRelation.semester = semester;
//       courseSemesterRelation.courses = courses;
//       return courseSemesterRelation;
//     }

//   }
// }