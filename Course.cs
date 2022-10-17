using System;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;


namespace SMS
{

  class Course
  {
    public string CourseID { get; set; }
    public string CourseName { get; set; }
    private string InstructorName;

    public void setInstructorName(String name)
    {
      InstructorName = name;
    }

    public string getInstructorName()
    {
      return InstructorName;
    }
    public int Credit { get; set; }

    public Course()
    {
      this.CourseID = CourseID;
      this.CourseName = CourseName;
      this.InstructorName = getInstructorName();
      this.Credit = Credit;

    }

    public void CourseDetails()
    {
      Console.Write("Course ID " + CourseID + " Course Name " + CourseName + " Credit " + Credit + "\n");
    }

    // public Course(string CourseID, string CourseName, string InstructionName, int Credit)
    // {
    //   this.CourseID = CourseID;
    //   this.CourseName = CourseName;
    //   this.InstructorName = InstructionName;
    //   this.Credit = Credit;
    // }



    public string JsonConvert()
    {
      var course = new JObject();

      course.Add("CourseID", CourseID);
      course.Add("CourseName", CourseName);
      course.Add("InstructorName", InstructorName);
      course.Add("Credit", Credit);

      string courseJSON = Newtonsoft.Json.JsonConvert.SerializeObject(course);
      // Console.WriteLine(testJSON);
      return courseJSON;
    }

    // public void addCourse()
    // {
    //   var courseJSON = Newtonsoft.Json.JsonConvert.DeserializeObject(JsonConvert());
    //   Console.WriteLine(courseJSON);
    //   courseData.Add(courseJSON);
    // }


  }
}