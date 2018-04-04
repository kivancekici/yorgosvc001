using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for JsonMasalar
/// </summary>
/// 
[DataContract]
public class JsonMasalar
{
    [DataMember]
    List<string> masalar { get; set; }
}