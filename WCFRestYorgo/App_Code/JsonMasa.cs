using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for JsonMasa
/// </summary>
/// 

[DataContract]
public class JsonMasa
{
    [DataMember]
    string Masa { get; set; }

    [DataMember]
    string Durum { get; set; }

}