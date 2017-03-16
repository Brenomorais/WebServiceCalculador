using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService01
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        public decimal Caluladora(decimal valorA, decimal valorB, OperacoesBasicas TipoOperacao){
                
            decimal resultadoAB = 0;

            switch(TipoOperacao){
               case OperacoesBasicas.Adicao:{
                    resultadoAB = decimal.Add(valorA, valorB);
                    break;
                }
               case OperacoesBasicas.Divisao:{
                   resultadoAB = decimal.Divide(valorA, valorB);
                    break;
               }
               case OperacoesBasicas.Multiplicacao:{
                   resultadoAB = decimal.Multiply(valorA, valorB);
                   break;
               }
               case OperacoesBasicas.Subtracao:{
                   resultadoAB = decimal.Subtract(valorA, valorB);
                   break;
               }
            }
            return resultadoAB;
        }

        [WebMethod]
        public String getNome(String nome){

            String nomecompleto ="";

            nomecompleto = "Bem-Vindo,"+nome;

            return nomecompleto;

        }
    }
}

