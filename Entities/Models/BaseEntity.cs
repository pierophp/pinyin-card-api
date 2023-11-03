namespace PinyinCardApi.Entities.Models;

using System;
using System.ComponentModel.DataAnnotations.Schema;

public class BaseEntity
{
    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}
