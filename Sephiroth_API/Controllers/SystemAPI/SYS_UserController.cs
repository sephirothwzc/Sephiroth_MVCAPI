using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sephiroth_API.Controllers.SystemAPI
{
    [RoutePrefix("SYS_UserAPI")]
    public class SYS_UserController : ApiController
    {
        DAO.SYS_User_DAO dao = new DAO.SYS_User_DAO();

        #region default
        // GET api/<controller>
        public IEnumerable<SYS_User> Get()
        {
            return dao.Get();
        }

        // GET api/<controller>/5
        public SYS_User Get(string id)
        {
            return dao.GetForId(id);
        }

        // POST api/<controller>
        public bool Post(SYS_User user)
        {
            return dao.Save(user);
        }

        // PUT api/<controller>/5
        public bool Put(string id, SYS_User user)
        {
            user.Id = id;
            return dao.Save(user);
        }

        // DELETE api/<controller>/5
        public bool Delete(string id)
        {
            return dao.Delete(id);
        }
        #endregion 

        [HttpPost]
        [Route("Login")]
        public SYS_User Login(string Usercode,string Password)
        {
            return dao.Login(Usercode, Password);
            //return dao.Login(user.Usercode, user.Password);
        }
    }
}
