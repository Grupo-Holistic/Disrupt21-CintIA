using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Watson.Assistant.v2;
using IBM.Watson.Assistant.v2.Model;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Disrupt.Web.Controllers
{
    public class WatsonController : Controller
    {
        public IActionResult Index()
        {
                        return View();
        }

        public IActionResult Watson(String pergunta)
        {
            IamAuthenticator authenticator = new IamAuthenticator(apikey: "neRUCd0_7lv6rHlOUPvGef_OTuoelnTuWH5oFCUxlSxg");

            AssistantService assistant = new AssistantService("2020-11-17", authenticator);
            assistant.SetServiceUrl("https://api.us-south.assistant.watson.cloud.ibm.com/instances/71eb6c35-f648-41b2-95a9-3c2615991f52");

            var result = assistant.MessageStateless(
                assistantId: "841b4a8c-0edb-4486-89af-d6d717775752",
                input: new MessageInputStateless()
                {
                    
                    Text = pergunta
                }
                );

            try
            {
                var response = JsonDocument.Parse(result.Response);
                var generic = response.RootElement;
                var output = generic.GetProperty("output").GetProperty("generic")[0].GetProperty("text");
                ViewBag.Resposta = output.GetString();
            }
            catch (Exception)
            {
                throw new Exception("Pergunta não existente.");
            }       

            return View();
        }
    }
}
