using acmeerrorlogDAL;
using acmeerrorlogDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acmeerrorlogBL
{
    public class acmeBL
    {
        acmeDAL dalObj = new acmeDAL();
        public List<acmeDTO> GetAllUser()
        {
            return dalObj.FetchAllUser();
        }
        public List<acmeDTO> GetUserByName(string name)
        {
            return dalObj.FetchUsersByemail();

        }
        public int AddNewUser(acmeDTO dtObj)
        {
            return dalObj.InsertUser(dtObj);
        }
    }
}
