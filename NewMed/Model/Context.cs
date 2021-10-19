using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewMed.Model
{
    public static class Context
    {
        public static MedicalDBEntities _context = new MedicalDBEntities();
    }
}
