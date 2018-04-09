using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for JsonTablo
/// </summary>
/// 

[DataContract]
public class JsonTablo
{
    [DataMember]
    List<Dictionary<string,object>> Satirlar { get; set; }

    public void doldurTablo(DataTable dt)
    {
        Satirlar = new List<Dictionary<string, object>>();
        Dictionary<string, object> satir;
        foreach (DataRow dr in dt.Rows)
        {
            satir = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                satir.Add(col.ColumnName, dr[col]);
            }
            Satirlar.Add(satir);
        }
    }
}