using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Net;
using System.Web.Hosting;

namespace SamsRestStubAPIService
{
    public class SamsRestStubAPIService : ISamsRestStubAPIService
    {
     
        public Stream GetAccount(string id="", string msd_id="", string level="")
        {
            int returnHttpCode = 200;
            XmlDocument xml_response = new XmlDocument();
            //string log = string.Empty;
            string FilePath = string.Empty;
            //Force a timeout
            //System.Threading.Thread.Sleep(20000);
            if (id == "1000" || msd_id== "1000")
            {
                FilePath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", string.Format("SamsGetAccNotFound.xml"));
                returnHttpCode = 404;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    id = msd_id;
                }
                FilePath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", string.Format("SamsGetAcc{0}Depth1.xml", id));
               //log = string.Format("<log>ELSE;id={0};msd_id:{1}</log>", id, msd_id);
            }
            xml_response.Load(FilePath);
            //xml_response.LoadXml(log);
            MemoryStream xmlStream = new MemoryStream();
            xml_response.Save(xmlStream);
            xmlStream.Flush();
            xmlStream.Position = 0;
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/xml";
            WebOperationContext.Current.OutgoingResponse.StatusCode = (HttpStatusCode)returnHttpCode; 
            return xmlStream;
        }

        public Stream GetAccountPreferences(string id)
        {
            XmlDocument xml_response = new XmlDocument();
            string FilePath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "SamsGetAccPref12467.xml");
            xml_response.Load(FilePath);
            MemoryStream xmlStream = new MemoryStream();
            xml_response.Save(xmlStream);
            xmlStream.Flush();
            xmlStream.Position = 0;
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/xml";
            return xmlStream;
        }

        public Stream PutAccount(string id)
        {
            MemoryStream xmlStream = new MemoryStream();
            int returnHttpCode = 204;
            if(id=="201")
            {
                XmlDocument xml_response = new XmlDocument();
                string FilePath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "SamsPutResponseCreated201.xml");
                xml_response.Load(FilePath);
                xml_response.Save(xmlStream);
                xmlStream.Flush();
                xmlStream.Position = 0;
                returnHttpCode = 201;
            }
            if (id == "403")
            {
                XmlDocument xml_response = new XmlDocument();
                string FilePath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "SamsPutErrorMessage403.xml");
                xml_response.Load(FilePath);
                xml_response.Save(xmlStream);
                xmlStream.Flush();
                xmlStream.Position = 0;
                returnHttpCode = 403;
            }
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/xml";
            WebOperationContext.Current.OutgoingResponse.StatusCode = (HttpStatusCode)returnHttpCode; 
            return xmlStream;
        }

        public Stream PostAccount(string id = "", string msd_id = "")
        {
            return PostAccountOrSub(id);
        }

        public Stream PostSubscription(string id = "")
        {
            return PostAccountOrSub(id);
        }

        public Stream PostAccountOrSub(string id)
        {
            MemoryStream xmlStream = new MemoryStream();
            int returnHttpCode = 204;
            if (id == "201")
            {
                XmlDocument xml_response = new XmlDocument();
                string FilePath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "SamsPutResponseCreated201.xml");
                xml_response.Load(FilePath);
                xml_response.Save(xmlStream);
                xmlStream.Flush();
                xmlStream.Position = 0;
                returnHttpCode = 201;
            }
            if (id == "403")
            {
                XmlDocument xml_response = new XmlDocument();
                string FilePath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "SamsPutErrorMessage403.xml");
                xml_response.Load(FilePath);
                xml_response.Save(xmlStream);
                xmlStream.Flush();
                xmlStream.Position = 0;
                returnHttpCode = 403;
            }
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/xml";
            WebOperationContext.Current.OutgoingResponse.StatusCode = (HttpStatusCode)returnHttpCode; ;
            return xmlStream;
        }

        public Stream DeleteOk(string id)
        {
            MemoryStream xmlStream = new MemoryStream();
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/xml";
            WebOperationContext.Current.OutgoingResponse.StatusCode = (HttpStatusCode)204; ;
            return xmlStream;
        }

        public Stream DeleteAccount(string id)
        {
            return DeleteOk(id);
        }

        public Stream DeleteCredentialUserPass(string id)
        {
            return DeleteOk(id);
        }

        public Stream DeleteCredentialIp(string id)
        {
            return DeleteOk(id);
        }

        public Stream DeleteCredentialLibCard(string id)
        {
            return DeleteOk(id);
        }

        public Stream DeleteCredentialReferer(string id)
        {
            return DeleteOk(id);
        }
        
    }
}
