namespace KidBank.Application.Customer.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KidBank.Application.Common.Interfaces;
using KidBank.Domain.Entities;

using MediatR;

public class CreateCustomerCommand: IRequest<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Phone { get; set; }

}

public class CreateCustomreCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    public CreateCustomreCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = new Customer
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            EmailAddress = request.EmailAddress,
            Phone = request.Phone
        };
        _context.Customers.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}