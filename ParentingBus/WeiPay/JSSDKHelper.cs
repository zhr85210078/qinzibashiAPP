﻿/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：JSSDKHelper.cs
    文件功能描述：JSSDK生成签名的方法等
    
    
    创建标识：Senparc - 20150211
    
    修改标识：Senparc - 20150303
    修改描述：整理接口
    
    修改标识：HADB - 20150512
    修改描述：将方法调用改为静态方式
----------------------------------------------------------------*/

using System;
using System.Collections;
using System.Text;
//using Senparc.Weixin.MP.CommonAPIs;

namespace WeiPay
{
    public class JSSDKHelper
    {
        /// <summary>
        /// 获取随机字符串
        /// </summary>
        /// <returns></returns>
        public static string GetNoncestr()
        {
            var random = new Random();
            return MD5UtilHelper.GetMD5(random.Next(1000).ToString(), "GBK");
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimestamp()
        {
            var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /// <summary>
        /// sha1加密
        /// </summary>
        /// <returns></returns>
        private static string CreateSha1(Hashtable parameters)
        {
            var sb = new StringBuilder();
            var akeys = new ArrayList(parameters.Keys);
            akeys.Sort();

            foreach (var k in akeys)
            {
                if (parameters[k] != null)
                {
                    var v = (string)parameters[k];

                    if (sb.Length == 0)
                    {
                        sb.Append(k + "=" + v);
                    }
                    else
                    {
                        sb.Append("&" + k + "=" + v);
                    }
                }
            }
            return SHA1UtilHelper.GetSha1(sb.ToString()).ToLower();
        }

        /// <summary>
        /// 生成cardSign的加密方法
        /// </summary>
        /// <returns></returns>
        private static string CreateCardSha1(Hashtable parameters)
        {
            var sb = new StringBuilder();
            var akeys = new ArrayList(parameters.Keys);
            akeys.Sort();

            foreach (var k in akeys)
            {
                if (parameters[k] != null)
                {
                    var v = (string)parameters[k];
                    sb.Append(v);
                }
            }
            return SHA1UtilHelper.GetSha1(sb.ToString()).ToString().ToLower();
        }
		/// <summary>
		/// 添加卡券Ext参数的签名加密方法
		/// </summary>
		/// <param name="parameters"></param>
		/// <returns></returns>
		private static string CreateNonekeySha1(Hashtable parameters)
		{
			var sb = new StringBuilder();
			var aValues = new ArrayList(parameters.Values);
			aValues.Sort();

			foreach (var v in aValues)
			{
				sb.Append(v);
			}
			return SHA1UtilHelper.GetSha1(sb.ToString()).ToString().ToLower();
		}
        /// <summary>
        /// 获取JS-SDK权限验证的签名Signature
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="noncestr"></param>
        /// <param name="timestamp"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetSignature(string ticket, string noncestr, string timestamp, string url)
        {
            var parameters = new Hashtable();
            parameters.Add("jsapi_ticket", ticket);
            parameters.Add("noncestr", noncestr);
            parameters.Add("timestamp", timestamp);
            parameters.Add("url", url);
            return CreateSha1(parameters);
        }
    }
}
