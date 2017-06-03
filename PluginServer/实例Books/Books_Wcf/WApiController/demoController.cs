using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Books_Wcf.Entity;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ServerController;
using EFWCoreLib.WcfFrame.ServerManage;
using EFWCoreLib.WebFrame.WebAPI;


namespace Books_Wcf.WApiController
{
    //控制器方法默认以get|post|put|delete这个几个字符开头，
    //或者使用[HttpGet][HttpPost][HttpPut][HttpDelete]这四个标签
    [efwplusApiController(PluginName = "Books.Service")]
    public class DemoController : WebApiController
    {
        // GET efwplusApi/<plugin>/<controller>/<action>
        public IEnumerator<Books> GetBooks()
        {
            List<Books> list = NewObject<Books>().getlist<Books>();
            return list.GetEnumerator();
        }

        // GET efwplusApi/<plugin>/<controller>/<action>/5
        public Books GetBook(int id)
        {
            DistributedCacheManage.SetCache("test", id.ToString(), "kakake");
            //DistributedCacheManage.SyncCache("test");
            return NewObject<Books>().getmodel(id) as Books;
        }

        // POST efwplusApi/<plugin>/<controller>/<action>
        public Books Post([FromBody]Books value)
        {
            return value;
        }

        // PUT efwplusApi/<plugin>/<controller>/<action>/5
        public Books Put(int id, [FromBody]Books value)
        {
            value.Id = id;
            return value;
        }

        // DELETE efwplusApi/<plugin>/<controller>/<action>/5
        public int Delete(int id)
        {
            return id;
        }

        [HttpGet]//efwplusApi/Books.Service/demo/book/1
        public Books book(int id)
        {
            Books book = NewObject<Books>().getmodel(id) as Books;
            //book.BookName = name;
            return book;
        }

        [HttpGet]//efwplusApi/Books.Service/demo/book/?id=1&name=kakake
        public Books book(int id, string name)
        {
            Books book = NewObject<Books>().getmodel(id) as Books;
            book.BookName = name;
            return book;
        }
    }
 
}
