namespace KidBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AccountActivity
{
    public Guid Id { get; set; }
    public Guid SubAccountId { get; set; }
    public Guid MainAccountId { get; set; }
    public Guid? MemoPostId { get; set; }
    public string MainAccountNumber { get; set; }
    public string SubAccountNumber { get; set; }
    public string Description { get; set; }
    public DateTime TransactionDate { get; set; }
    public DateTime? TransactionCompleteDate { get; set; }
    public DateTime? TransactionCancelDate { get; set; }
    public long Amount { get; set; }




}
