using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    private static JsonTablo getJsonTablo(MySqlCommand cmd)
    {
        DataTable dt = DBHelper.getDBHelper().select(cmd);
        JsonTablo js = new JsonTablo();
        js.doldurTablo(dt);
        return js;
    }

    private static int getInt(MySqlCommand cmd)
    {
        DataTable dt = DBHelper.getDBHelper().select(cmd);
        if (dt.Rows.Count == 0) { return -1; }
        try
        {
            int i = int.Parse(dt.Rows[0][0].ToString());

            if (i == 0)
            { return 1; }
            else
            { return i + 1; }
        }
        catch
        {
            return 10000;
        }
        
    }

    public JsonTablo getirTurlerIdAd()
    {
        MySqlCommand cmd = new MySqlCommand();
        cmd.CommandText = "Select * from turler where idturler <>1000 order by sira";
        return getJsonTablo(cmd);
    }

    public JsonTablo getirYemekler()
    {
        MySqlCommand cmd = new MySqlCommand();
        cmd.CommandText = "SELECT * FROM  tblurunler y where sil=0 and turu<>1000 order by sira";
        return getJsonTablo(cmd);
    }

    public JsonTablo getirAdisyonAciklamalari(string adisyonKodu)
    {
        MySqlCommand cmd = new MySqlCommand();
        cmd.CommandText = "SELECT id_ingsizes as idtbl_ingsizes, ing_id, ing_name, price as fiyat, tur_id, ikram, privatecode as PrivateCode FROM roadisyon.tbl_selecteding t where adisyoncode=?adisyoncode";
        cmd.Parameters.AddWithValue("adisyoncode", adisyonKodu);
        return getJsonTablo(cmd);
    }

    public JsonTablo GetirMasaDurumlari()
    {
        MySqlCommand cmd = new MySqlCommand();
        cmd.CommandText = "SELECT * FROM tbl_masalar tm left join tbl_masadurumu tmd on tm.durumid=tmd.durumid order by sirano";
        return getJsonTablo(cmd);
    }

    public JsonTablo getirSadisyonBilgileri(string adisyonid)
    {
        MySqlCommand cmd = new MySqlCommand();
        cmd.CommandText = "SELECT * FROM tbl_sadisyonlar where idtbl_sadisyonlar=?adisyon_id ";
        cmd.Parameters.AddWithValue("?adisyon_id", adisyonid);
        return getJsonTablo(cmd);
    }


    public JsonTablo getirSadsIcerikleri(string adisyoncode)
    {
        MySqlCommand cmd = new MySqlCommand();
        cmd.CommandText = "SELECT * FROM roadisyon.tbl_sadisyonicerik t where adisyoncode=?adisyoncode ";
        cmd.Parameters.AddWithValue("?adisyoncode", adisyoncode);
        return getJsonTablo(cmd);
    }

    public JsonTablo fnc_GetirCokluOdeme(string ads_id)
    {
        MySqlCommand cmd = new MySqlCommand();
        cmd.CommandText = "SELECT * FROM roadisyon.tbl_masaodemeler t where ads_id=?ads_id";
        cmd.Parameters.AddWithValue("?ads_id", ads_id);
        return getJsonTablo(cmd);
    }

    public JsonTablo getirYemekAciklamalar()
    {
        MySqlCommand cmd = new MySqlCommand();
        cmd.CommandText = "SELECT * FROM roadisyon.tblexp t  order by grup,exp";
        return getJsonTablo(cmd);
    }

    public int GetirGunlukSadisyonNo()
    {
        MySqlCommand cmd = new MySqlCommand();
        cmd.CommandText = "SELECT coalesce(max(ads_no),0) FROM tbl_sadisyonlar where date(ad_open)=date(?acil)";
        DateTime tar = DateTime.Now;
        cmd.Parameters.AddWithValue("?acil", tar);
        return getInt(cmd);
    }

    public int KaydetSadisyon(int tableid, double adtotal, string paymentmedhod, int adsno, string adscode)
    {
        MySqlCommand cmd = new MySqlCommand();

        DateTime adopen = DateTime.Now;
        int ads_durum = 1;

        cmd.CommandText = "Insert into tbl_sadisyonlar (tableid,ad_open,ad_close,ad_total,ad_pmedhod,ads_no,ads_durum,ad_code) values (?tableid,?ad_open,?ad_open,?ad_total,?paymentmedhod,?adsno,?ads_durum,?ad_code)";
        cmd.Parameters.AddWithValue("?tableid", tableid);
        cmd.Parameters.AddWithValue("?ad_open", adopen);
        cmd.Parameters.AddWithValue("?ad_total", adtotal);
        cmd.Parameters.AddWithValue("?paymentmedhod", paymentmedhod);
        cmd.Parameters.AddWithValue("?adsno", adsno);
        cmd.Parameters.AddWithValue("?ads_durum", ads_durum);
        cmd.Parameters.AddWithValue("?ad_code", adscode);

        bool b=DBHelper.getDBHelper().insertUpdate(cmd);

        if (b)
        {
            MySqlCommand cmd2 = new MySqlCommand();

            //Burada mobil ve masaüstü çakışabilir !!!!!!!!!
            cmd2.CommandText = "Select Max(idtbl_sadisyonlar) as adsid from tbl_sadisyonlar";

            return getInt(cmd2);
        }else
        {
            return 0;
        }

    }
}
