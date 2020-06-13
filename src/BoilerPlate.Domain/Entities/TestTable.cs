using BoilerPlate.Domain.Common;

namespace BoilerPlate.Domain.Entities
{
    public class TestTable : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
    }
}
