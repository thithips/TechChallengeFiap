using TechChallengeFiap.Domain.Models.DDDs;

namespace TechChallengeFiap.Domain.Models.Estados
{
    public class EstadoDDDViewModel
    {
        public string Descricao { get; set; }
        public IEnumerable<DDDViewModel> DDDs { get; set; }
    }
}
