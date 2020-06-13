using BoilerPlate.Application.Common.Exceptions;
using BoilerPlate.Application.Common.Interfaces;
using BoilerPlate.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BoilerPlate.Application.TestTables.Commands.UpdateTestTable
{
    public class UpdateTestTableCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
    }

    public class UpdateTodoListCommandHandler : IRequestHandler<UpdateTestTableCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTodoListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTestTableCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TestTables.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TestTable), request.Id);
            }

            entity.Name = request.Name;
            entity.Remarks = request.Remarks;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
