using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatePdfCore.Services
{
    public interface ICreateFile
    {
        byte[] Create();
    }
}
