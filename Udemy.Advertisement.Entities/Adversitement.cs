using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Advertisement.Entities
{
    public class Adversitement : BaseEntity
    {
        public string Title { get; set; }

        public bool Status { get; set; }

        public string Description { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
