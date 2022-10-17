using System;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;


namespace SMS
{

  class JsonData
  {
    public object data;

    JsonData(object data){
      this.data = data;
    }
  }
}