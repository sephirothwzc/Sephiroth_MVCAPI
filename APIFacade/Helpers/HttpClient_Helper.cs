using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


/*************************************************************************************
   * CLR 版本：       4.0.30319.33440
   * 类 名 称：       HttpClient_Helper
   * 机器名称：       SEPHIROTHBF0C
   * 命名空间：       Interface_BusinessAPI.APIFacade
   * 文 件 名：       HttpClient_Helper
   * 创建时间：       15/5/20 20:48:20
   * 作    者：       吴占超
   * 说    明：        
   * 修改时间：
   * 修 改 人：
  *************************************************************************************/

namespace APIFacade
{
    /// <summary>
    /// httpclient 帮助类
    /// </summary>
    public class HttpClient_Helper
    {
        /// <summary>
        /// 获取webapi配置节 根目录
        /// </summary>
        /// <returns></returns>
        private static string GetWebAPIUrl()
        {
            try
            {
                return System.Configuration.ConfigurationManager.AppSettings["webapi"];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="datas"></param>
        /// <returns></returns>
        public static T DoPost<T>(string url, Dictionary<string,string> datas)
        {
            string apiurl = HttpClient_Helper.GetWebAPIUrl()+url;

            //设置HttpClientHandler的AutomaticDecompression
            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            //创建HttpClient（注意传入HttpClientHandler）
            using (var http = new HttpClient(handler))
            {
                ////使用FormUrlEncodedContent做HttpContent
                //var content = new FormUrlEncodedContent(new Dictionary<string, string>()       
                //{    {"Id","6"},
                //     {"Name","添加zzl"},
                //     {"Info", "添加动作"}//键名必须为空
                // });

                ////await异步等待回应

                //var response = await http.PostAsync(url, content);
                ////确保HTTP成功状态值
                //response.EnsureSuccessStatusCode();
                ////await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                //Console.WriteLine(await response.Content.ReadAsStringAsync());

                //吴占超 2015年5月20日21:29:19
                var content = new FormUrlEncodedContent(datas);
                var task = http.PostAsync(apiurl, content);
                task.Result.EnsureSuccessStatusCode();

                //var result = task.Result.Content.ReadAsStringAsync();

                //HttpResponseMessage response = task.Result;
                //var x = response.Content.ReadAsStringAsync();
                return ObjectConvertJson<T>(task.Result.Content.ReadAsStringAsync().Result);
            }
        }

        public static T DoGet<T>(string url)
        {
            string apiurl = HttpClient_Helper.GetWebAPIUrl() + url;

            //设置HttpClientHandler的AutomaticDecompression
            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            //创建HttpClient（注意传入HttpClientHandler）
            using (var http = new HttpClient(handler))
            {
                ////使用FormUrlEncodedContent做HttpContent
                //var content = new FormUrlEncodedContent(new Dictionary<string, string>()       
                //{    {"Id","6"},
                //     {"Name","添加zzl"},
                //     {"Info", "添加动作"}//键名必须为空
                // });

                ////await异步等待回应

                //var response = await http.PostAsync(url, content);
                ////确保HTTP成功状态值
                //response.EnsureSuccessStatusCode();
                ////await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                //Console.WriteLine(await response.Content.ReadAsStringAsync());

                //吴占超 2015年5月20日21:29:19

                var task = http.GetAsync(apiurl);
                task.Result.EnsureSuccessStatusCode();

                //var result = task.Result.Content.ReadAsStringAsync();

                //HttpResponseMessage response = task.Result;
                //var x = response.Content.ReadAsStringAsync();
                return ObjectConvertJson<T>(task.Result.Content.ReadAsStringAsync().Result);
            }
        }


        /// <summary>
        /// 字符串对象序列化
        /// </summary>
        /// <param name="jsonstr"></param>
        /// <returns></returns>
        public static T ObjectConvertJson<T>(string jsonstr)
        {
            try
            {
                T obj = JsonConvert.DeserializeObject<T>(jsonstr);
                return obj;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
