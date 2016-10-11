﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiPay
{

    /**
   * 
   * 作用：记录请求服务器有关验证用户的数据实体
   * 作者：zhr
   * 编写日期：2014-12-25
   * 备注：通过请求到的json数据实例化实体对象，字段请勿修改
   * 
   * */
    public class OpenModel
    {

        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }
        public string openid { get; set; }
        public string scope { get; set; }

    }

    public class tokenModel
    {

        public string access_token { get; set; }
        public string expires_in { get; set; }

    }

    public class ticketModel
    {
        public string errcode { get; set; }
        public string errmsg { get; set; }
        public string ticket { get; set; }
        public string expires_in { get; set; }

    }
}
