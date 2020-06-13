using BoilerPlate.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BoilerPlate.Application.TestTables.Commands.CreateTestTable
{
    public class CreateTestTableCommandValidator : AbstractValidator<CreateTestTableCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateTestTableCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.")
                .MustAsync(BeUniqueTitle).WithMessage("The specified name already exists.");
        }

        public async Task<bool> BeUniqueTitle(string name, CancellationToken cancellationToken)
        {
            return await _context.TestTables
                .AllAsync(l => l.Name != name);
        }
    }
}
