using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using SAPbobsCOM;

namespace adminlte.Models
{
  public class KalemlerDataAccessLayer
  {
    string connectionString = "Data Source=localhost;Initial Catalog=SBODemoTR;User ID=sa;Password=1";

    //To View all employees details    
    public IEnumerable<Kalemler> GetAllKalemler()
    {
      List<Kalemler> lstKalem = new List<Kalemler>();

            SAPbobsCOM.Company company = new SAPbobsCOM.Company();
            int connectionResult;
            int errorCode = 0;
            string errorMessage = "";

            try
            {
                company.Server = ConfigurationManager.AppSettings["server"].ToString();
                company.CompanyDB = ConfigurationManager.AppSettings["companydb"].ToString();
                company.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2016;
                company.DbUserName = ConfigurationManager.AppSettings["dbuser"].ToString();
                company.DbPassword = ConfigurationManager.AppSettings["dbpassword"].ToString();
                company.UserName = ConfigurationManager.AppSettings["user"].ToString();
                company.Password = ConfigurationManager.AppSettings["password"].ToString();
                company.language = SAPbobsCOM.BoSuppLangs.ln_Turkish_Tr;
                company.UseTrusted = false;
                company.LicenseServer = ConfigurationManager.AppSettings["licenseServer"].ToString();
                company.SLDServer = ConfigurationManager.AppSettings["SLDServer"].ToString();

                connectionResult = company.Connect();

                if (connectionResult != 0)
                {
                    company.GetLastError(out errorCode, out errorMessage);
                }
                else
                {
                    //SAPbobsCOM.Items oItem = (Items)company.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oItems);
                    var oRecordSet = (Recordset)company.GetBusinessObject(BoObjectTypes.BoRecordset);
                    oRecordSet.DoQuery("select ItemCode, ItemName from dbo.OITM");
                    while (!oRecordSet.EoF)
                    {
                        //sorgu ile çekmek en kolayı zannedersem
                        //var key = oRecordSet.Fields.Item(0).Value.ToString();
                        //oItem.GetByKey(key);

                        lstKalem.Add(new Kalemler { ItemCode = oRecordSet.Fields.Item(0).Value.ToString(), ItemName = oRecordSet.Fields.Item(1).Value.ToString() });

                        oRecordSet.MoveNext();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstKalem;
    }
  }
}