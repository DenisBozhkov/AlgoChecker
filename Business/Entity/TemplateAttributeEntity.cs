using Business.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entity
{
    public class TemplateAttributeEntity : BaseAttributeEntity
    {
        public virtual TaskEntity InputTask { get; set; }
        public virtual TaskEntity OutputTask { get; set; }
    }
}
