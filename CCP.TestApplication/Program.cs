using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace CCP.TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientCredentials clientCredentials = new ClientCredentials();

            clientCredentials.UserName.UserName = "admin@cclearpartnersdemo.onmicrosoft.com";
            clientCredentials.UserName.Password = "Pass@word1";

            IOrganizationService organizationService = new OrganizationServiceProxy(new Uri("https://cclearpartnersdemo.crm4.dynamics.com/XRMServices/2011/Organization.svc"), null, clientCredentials, null);

            //Retrieve all accounts
            QueryExpression query = new QueryExpression("account");
            var result = organizationService.RetrieveMultiple(query);

            //Retrieve a specific account
            query = new QueryExpression("account");
            query.ColumnSet.AllColumns = true;
            query.Criteria.AddCondition("name", ConditionOperator.Equal, "C-Clear Partners");
            result = organizationService.RetrieveMultiple(query);

            //Create a new account
            Entity newAccount = new Entity("account");
            newAccount["name"] = "New account";
            newAccount["address1_line2"] = "Line 2";
            var accountId = organizationService.Create(newAccount);
        }


    }
}
