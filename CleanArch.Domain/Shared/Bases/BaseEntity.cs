using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Shared
{
    public class BaseEntity
    {
        public long Id { get; private set; }
        public DateTime CreationDate { get; }
        
        public BaseEntity()
        {
            CreationDate = new DateTime();
        }
    }

}

