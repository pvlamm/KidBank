namespace KidBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SubAccount
{
    public Guid Id { get; set; }
    public Guid ParentId { get; set; }
    public string Name { get; set; }
    public string MainAccountNumber { get; set; }
    public string AccountNumber { get; set; }

    public long Balance { get; set; }

    public DateOnly OpenDate { get; set; }
    public DateOnly? CloseDate { get; set; }
}
