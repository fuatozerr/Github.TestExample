using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAppLibrary.Services
{
    public class IdentityValidator : IIdentityValidator
    {
        public bool CheckConnectionToRemoteServer()
        {
            throw new NotImplementedException();
        }

        public bool IsValid(string identityNumber)
        {
            return true;

        }
    }
}
