using BoilerPlate.Application.Common.Interfaces;
using BoilerPlate.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BoilerPlate.Application.TestTables.Commands.CreateTestTable
{
    public partial class CreateTestTableCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Remarks { get; set; }
    }

    public class CreateTestTableCommandHandler : IRequestHandler<CreateTestTableCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTestTableCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTestTableCommand request, CancellationToken cancellationToken)
        {
            var entity = new TestTable();

            entity.Name = request.Name;
            entity.Remarks = request.Remarks;

            _context.TestTables.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
