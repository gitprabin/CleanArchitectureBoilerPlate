using AutoMapper;
using BoilerPlate.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BoilerPlate.Application.TestTables.Queries.GetTestTables
{

    public class GetTestTablesQuery : IRequest<IList<TestTableVm>>
    {
    }

    public class GetTestTablesQueryHandler : IRequestHandler<GetTestTablesQuery, IList<TestTableVm>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTestTablesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<TestTableVm>> Handle(GetTestTablesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<TestTableVm>();
            var invoices = await _context.TestTables.ToListAsync();
            if (invoices != null)
            {
                result = _mapper.Map<List<TestTableVm>>(invoices);
            }

            return result;
        }
    }
}
