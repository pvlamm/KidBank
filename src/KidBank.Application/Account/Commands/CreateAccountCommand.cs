\namespace KidBank.Application.Account.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KidBank.Application.Common.Interfaces;
using KidBank.Domain.Entities;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

public class CreateAccountCommand: IRequest<Guid>
{
    public string Name { get; set; }
    public Guid CustomerId { get; set; }
    public long? BeginingBalance { get; set; }

}

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
{

    private readonly IApplicationDbContext _context;
    public CreateAccountCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var customer = await _context.Customers
            .FirstOrDefaultAsync(x => x.Id== request.CustomerId);
        if (customer == null)
        {
            throw new Exception("Customer not found");
        }

        var account = new MainAccount
        {
            Id = Guid.NewGuid(),
            CustomerId = request.CustomerId,
            Name = request.Name,
            Balance = request.BeginingBalance ?? 0,
            OpenDate = DateOnly.FromDateTime(DateTime.Now),

        };

        await _context.MainAccounts.AddAsync(account);
        await _context.SaveChangesAsync(cancellationToken);

        return account.Id;
    }
}