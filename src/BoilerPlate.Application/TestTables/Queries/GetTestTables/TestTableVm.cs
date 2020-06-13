using BoilerPlate.Application.Common.Mappings;
using BoilerPlate.Domain.Entities;

namespace BoilerPlate.Application.TestTables.Queries.GetTestTables
{
    public class TestTableVm : IMapFrom<TestTable>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
    }
}
