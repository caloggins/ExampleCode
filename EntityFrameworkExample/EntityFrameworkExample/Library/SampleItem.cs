using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkExample.Contracts;

namespace EntityFrameworkExample.Library
{
  [Persistent, Table("SampleItem")]
  public class SampleItem
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }
    public string Data { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }

  }
}