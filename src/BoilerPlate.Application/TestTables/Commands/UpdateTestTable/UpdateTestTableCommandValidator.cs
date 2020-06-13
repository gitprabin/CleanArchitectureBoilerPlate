using BoilerPlate.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BoilerPlate.Application.TestTables.Commands.UpdateTestTable
{
    class UpdateTestTableCommandValidator : AbstractValidator<UpdateTestTableCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTestTableCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.")
                .MustAsync(BeUniqueName).WithMessage("The specified name already exists.");
        }

        public async Task<bool> BeUniqueName(UpdateTestTableCommand model, string name, CancellationToken cancellationToken)
        {
            return await _context.TestTables
                .Where(l => l.Id != model.Id)
                .AllAsync(l => l.Name != name);
        }
    }
}
