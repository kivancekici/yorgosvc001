using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{
    [OperationContract]
    [WebGet(UriTemplate = "test", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
    string test();

    [OperationContract]
    [WebGet(UriTemplate = "getirTurlerIdAd", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
    JsonTablo getirTurlerIdAd();

    [OperationContract]
    [WebGet(UriTemplate = "getirYemekler", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
    JsonTablo getirYemekler();

    [OperationContract]
    [WebGet(UriTemplate = "getirAdisyonAciklamalari/{adisyonKodu}", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
    JsonTablo getirAdisyonAciklamalari(string adisyonKodu);


    [OperationContract]
    [WebGet(UriTemplate = "GetirMasaDurumlari", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
    JsonTablo GetirMasaDurumlari();

    
    [OperationContract]
    [WebGet(UriTemplate = "getirSadisyonBilgileri/{adisyonid}", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
    JsonTablo getirSadisyonBilgileri(string adisyonid);

    [OperationContract]
    [WebGet(UriTemplate = "getirSadsIcerikleri/{adisyoncode}", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
    JsonTablo getirSadsIcerikleri(string adisyoncode);

    [OperationContract]
    [WebGet(UriTemplate = "fnc_GetirCokluOdeme/{ads_id}", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
    JsonTablo fnc_GetirCokluOdeme(string ads_id);

    [OperationContract]
    [WebGet(UriTemplate = "getirYemekAciklamalar", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
    JsonTablo getirYemekAciklamalar();

    [OperationContract]
    [WebGet(UriTemplate = "GetirGunlukSadisyonNo", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
    int GetirGunlukSadisyonNo();

    [OperationContract]
    [WebGet(UriTemplate = "KaydetSadisyon/{tableid}/{adtotal}/{paymentmedhod}/{adsno}/{adscode}", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
    int KaydetSadisyon(int tableid, double adtotal, string paymentmedhod, int adsno, string adscode);



}
