using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallengeFiap.Domain.Entities
{
    public class Estado : BaseEntity
    {
        public string Descricao { get; set; }
        public Guid IdRegiao { get; set; }
        public Regiao Regiao { get; set; }
        List<DDD>? DDDs { get; set; }

        public Estado(string descricao)
        {
            Descricao = descricao;
        }

        public Estado() {}
    }
}
