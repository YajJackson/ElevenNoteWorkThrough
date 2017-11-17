using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.Controllers.WebAPI
{
    [Authorize]
    [RoutePrefix("api/Notes")]
    public class NotesController : ApiController
    {
        public bool Put(int id)
        {

        }

        public bool Delete(int id)
        {

        }
    }
}
