using System;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;


namespace SMS
{

  class Semester
  {
    public String semesterCode { get; set; }
    public String year { get; set; }

    public String semesterName()
    {
      return semesterCode + " " + year;
    }

    // Semester(String semesterCode, String year)
    // {
    //   this.semesterCode = semesterCode;
    //   this.year = year;
    // }
  }
}