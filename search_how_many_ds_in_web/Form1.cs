using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LitJson;
using System.Threading;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections;

namespace search_how_many_ds_in_web
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string WebRequest(string method, string url, string postData)
        {
            HttpWebRequest webRequest = null;
            StreamWriter requestWriter = null;
            string responseData = "";

            webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = method.ToString();
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.93 Safari/537.36";

            webRequest.Timeout = Convert.ToInt32(8888);

            if (method == "POST" || method == "PUT")
            {
                if (method == "PUT")
                {
                    webRequest.ContentType = "text/xml";
                    webRequest.Method = "PUT";
                }
                else
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                //webRequest.ContentType = "multipart/form-data";

                //POST the data.
                requestWriter = new StreamWriter(webRequest.GetRequestStream());
                try
                {
                    requestWriter.Write(postData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    requestWriter.Close();
                    requestWriter = null;
                }
            }

            responseData = WebResponseGet(webRequest);

            webRequest = null;

            return responseData;

        }

        public string WebResponseGet(HttpWebRequest webRequest)
        {
            StreamReader responseReader = null;
            string responseData = "";

            try
            {
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd();


                webRequest.GetResponse().GetResponseStream().Close();
                responseReader.Close();
                responseReader = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }

            return responseData;
        }

        private void start_Click(object sender, EventArgs e)
        {
            start.Enabled = false;

            Thread th_request;
            th_request = new Thread((ThreadStart)delegate()
            {

                do_th_request_count();
            });
            th_request.Start();
        }


        void do_th_request_count()
        {

            this.Invoke((MethodInvoker)delegate()
            {
                feedback.Text = "序号\t页面标题\t所含设备数\t所含数据流数\t页面URL\r\n";
                //    feedback.Text = feedback.Text + cc + bb;
            });

            StreamReader br = new StreamReader(txtpath.Text);

            for (int i = 0; i < 888; i++)
            {
                string path_url = "";
                try
                {
                    path_url = br.ReadLine();
                    if (path_url == "EOF") break;
                    if (path_url.Length < 5) break;
                }
                catch
                {
                    break;
                }
                string web_res = WebRequest("GET", path_url, "");

                Match match_title = Regex.Match(web_res, @"<title>\n *(.+)-中国移动物联网开放平台\n.*</title>");
                Match match_json = Regex.Match(web_res, @"options: JSON.parse\('(.*)'\),");

                if (match_json.Success && match_title.Success)
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        feedback.Text = feedback.Text + i + "\t";
                        feedback.Text = feedback.Text + match_title.Groups[1].Value + "\t";

                        //计算设备数量和数据流数量
                        LitJson.JsonData f = LitJson.JsonMapper.ToObject(match_json.Groups[1].Value);
                        int children_count = f["children"].Count;
                        ArrayList arr_dev = new ArrayList();
                        ArrayList arr_ds = new ArrayList();
                        for (int j = 0; j < children_count; j++)
                        {
                            string dev_id = "";
                            try
                            {
                                switch (f["children"][j]["CLASS"].ToString())
                                {
                                    case "text":
                                        dev_id = f["children"][j]["options"]["data"]["deviceId"].ToString();
                                        break;
                                    case "line-chart":
                                    case "bar-chart":
                                        for (int k = 0; k < f["children"][j]["options"]["series"].Count; k++)
                                        {
                                            try
                                            {
                                                dev_id = f["children"][j]["options"]["series"][k]["deviceId"].ToString();
                                                if (dev_id != "")
                                                {
                                                    if (!arr_dev.Contains(dev_id))
                                                    {
                                                        arr_dev.Add(dev_id);
                                                    }
                                                }
                                            }
                                            catch
                                            {
                                                continue;
                                            }
                                        }
                                        break;
                                    default:
                                        dev_id = f["children"][j]["options"]["deviceId"].ToString();
                                        break;
                                }

                                dev_id = f["children"][j]["options"]["deviceId"].ToString();
                            }
                            catch
                            {
                                ;
                            }
                            if (dev_id != "")
                            {
                                if (!arr_dev.Contains(dev_id))
                                {
                                    arr_dev.Add(dev_id);
                                }
                            }
                            //防止有些只有dsid没有devid以及只有devid没有dsid，写两次单独统计
                            string ds_id = "";
                            try
                            {
                                switch (f["children"][j]["CLASS"].ToString())
                                {
                                    case "text":
                                        ds_id = f["children"][j]["options"]["data"]["dsId"].ToString();
                                        break;
                                    case "line-chart":
                                    case "bar-chart":
                                        for (int k = 0; k < f["children"][j]["options"]["series"].Count; k++)
                                        {
                                            try
                                            {
                                                ds_id = f["children"][j]["options"]["series"][k]["dsId"].ToString();
                                                if (ds_id != "")
                                                {
                                                    if (!arr_ds.Contains(ds_id))
                                                    {
                                                        arr_ds.Add(ds_id);
                                                    }
                                                }
                                            }
                                            catch
                                            {
                                                ;
                                            }
                                        }
                                        break;
                                    default:
                                        ds_id = f["children"][j]["options"]["dsId"].ToString();
                                        break;
                                }

                            }
                            catch
                            {
                                continue;
                            }
                            if (ds_id != "")
                            {
                                if (!arr_ds.Contains(ds_id))
                                {
                                    arr_ds.Add(ds_id);
                                }
                            }
                        }//for j

                        int dev_count = arr_dev.Count;
                        int ds_count = arr_ds.Count;
                        arr_dev.Clear();
                        arr_ds.Clear();

                        feedback.Text = feedback.Text + dev_count + "\t" + ds_count + "\t";

                        feedback.Text = feedback.Text + path_url + "\r\n";
                    });
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        feedback.Text = feedback.Text + "未发现有效title\t未发现有效数据\t未发现有效数据\t";
                        feedback.Text = feedback.Text + path_url + "\r\n";

                    });
                }

            }//url循环的for



            br.Close();
            br.Dispose();

            this.Invoke((MethodInvoker)delegate()
            {
                start.Enabled = true;
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
