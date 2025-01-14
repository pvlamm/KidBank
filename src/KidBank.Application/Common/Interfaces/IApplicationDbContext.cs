namespace KidBank.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KidBank.Domain.Entities;

using Microsoft.EntityFrameworkCore;

public interface IApplicationDbContext
{
    DbSet<AccountActivity> AccountActivities { get; set; }
    DbSet<Customer> Customers { get; set; }
    DbSet<SubAccount> SubAccounts { get; set; }
    DbSet<MainAccount> MainAccounts { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    Task BeginTransactionAsync(CancellationToken cancellationToken);
    Task CommitTransactionAsync(CancellationToken cancellationToken);
    void RollbackTransaction();
}
