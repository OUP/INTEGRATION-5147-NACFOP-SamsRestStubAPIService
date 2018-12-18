using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace SamsRestStubAPIService
{
   
    [ServiceContract]
    public interface ISamsRestStubAPIService
    {
        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "REST/account/?if_acc_id={id}&msd_customer_id={msd_id}&depth={level}"
            )
        ]
        Stream GetAccount(string id = "", string msd_id="", string level = "");

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            //ResponseFormat = WebMessageFormat.Xml,
            //BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "REST/account_preference?if_acc_id={id}"
            )
        ]
        Stream GetAccountPreferences(string id);

        [OperationContract]
        [WebInvoke(
            Method = "PUT",
            //ResponseFormat = WebMessageFormat.Xml,
            //BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "REST/account/?if_acc_id={id}"
            )
        ]
        Stream PutAccount(string id);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "REST/account/?if_acc_id={id}&msd_customer_id={msd_id}"
            )
        ]
        Stream PostAccount(string id = "", string msd_id="");

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "REST/subscription/?alternative_subs_id={id}"
            )
        ]
        Stream PostSubscription(string id = "");

        [OperationContract]
        [WebInvoke(
            Method = "DELETE",
            UriTemplate = "REST/account/?if_acc_id={id}"
            )
        ]
        Stream DeleteAccount(string id);


        [OperationContract]
        [WebInvoke(
            Method = "DELETE",
            UriTemplate = "REST/credential_userpass/{id}"
            )
        ]
        Stream DeleteCredentialUserPass(string id);

        [OperationContract]
        [WebInvoke(
            Method = "DELETE",
            UriTemplate = "REST/credential_ip/{id}"
            )
        ]
        Stream DeleteCredentialIp(string id);

        [OperationContract]
        [WebInvoke(
            Method = "DELETE",
            UriTemplate = "REST/credential_libcard/{id}"
            )
        ]
        Stream DeleteCredentialLibCard(string id);

        [OperationContract]
        [WebInvoke(
            Method = "DELETE",
            UriTemplate = "REST/credential_referer/{id}"
            )
        ]
        Stream DeleteCredentialReferer(string id);
    }
}
