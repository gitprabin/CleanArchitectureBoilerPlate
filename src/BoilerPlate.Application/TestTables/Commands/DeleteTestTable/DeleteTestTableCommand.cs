using BoilerPlate.Application.Common.Exceptions;
using BoilerPlate.Application.Common.Interfaces;
using BoilerPlate.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BoilerPlate.Application.TestTables.Commands.DeleteTestTable
{
    public class DeleteTestTableCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTestTableCommandHandler : IRequestHandler<DeleteTestTableCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTestTableCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTestTableCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TestTables
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TestTable), request.Id);
            }

            _context.TestTables.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
