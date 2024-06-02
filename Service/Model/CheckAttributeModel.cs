using Service.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class CheckAttributeModel(Guid id)
        : BaseAttributeModel(id)
    {
        public string Value { get; set; } = string.Empty;
        public TestCaseModel? TestCase { get; set; }
    }
}
