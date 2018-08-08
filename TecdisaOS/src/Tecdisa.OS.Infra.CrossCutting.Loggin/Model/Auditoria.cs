using System;
using System.Web.Script.Serialization;

namespace Tecdisa.OS.Infra.CrossCutting.Loggin.Model
{
    public class Auditoria
    {
        public Auditoria(string userId, string sistema, string ip, string acao, string model = null)
        {
            UserId = userId;
            Sistema = sistema;
            IP = ip;
            Acao = acao;
            Model = model;
            LogId = Guid.NewGuid();
            DataOcorrencia = DateTime.Now;
        }

        public Guid LogId { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string Sistema { get; set; }
        public string UserId { get; set; }
        public string IP { get; set; }
        public string Acao { get; set; }
        public string Model { get; set; }

        public string ModelToJson(object model)
        {
            return new JavaScriptSerializer().Serialize(model);
        }
    }
}
