﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNetStudio.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }

    }

}
