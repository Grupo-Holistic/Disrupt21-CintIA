using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Disrupt.Web.TagHelpers
{
    public class MensagemTagHelper : TagHelper
    {
        public string Mensagem { get; set; }

        // <div class="alert alert-success">Texto</div>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Valida se o texto não está vazio ou nulo
            if (!string.IsNullOrEmpty(Mensagem))
            {
                //A tag que será criada
                output.TagName = "div";
                //Definir alguns atributos da tag html (name, class, id...)
                output.Attributes.SetAttribute("class", "alert alert-success");
                //Definir o conteúdo da tag
                output.Content.SetContent(Mensagem);
            }
        }
    }
}
