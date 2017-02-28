using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace RickettyBridges.API.Controllers
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web;

    [RoutePrefix("api/Upload")]
    public class UploadController : ApiController
    {
        //public Task<HttpResponseMessage> PostFile()
        //{
        //    HttpRequestMessage request = this.Request;
        //    if (!request.Content.IsMimeMultipartContent())
        //    {
        //        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        //    }

        //    string root = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/uploads");
        //    var provider = new MultipartFormDataStreamProvider(root);

        //    var task = request.Content.ReadAsMultipartAsync(provider).
        //        ContinueWith<HttpResponseMessage>(o =>
        //        {

        //            string file1 = provider.BodyPartFileNames.First().Value;
        //            // this is the file name on the server where the file was saved 

        //            return new HttpResponseMessage()
        //            {
        //                Content = new StringContent("File uploaded.")
        //            };
        //        }
        //    );
        //    return task;
        //} 


        [AllowAnonymous]
        public async Task<HttpResponseMessage> PostUserImage()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {
                var httpRequest = HttpContext.Current.Request;

                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {
                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {
                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {
                            var message = string.Format("Please Upload a file upto 1 mb.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else
                        {
                            var filePath = HttpContext.Current.Server.MapPath("~/Userimage/" + postedFile.FileName + extension);

                            postedFile.SaveAs(filePath);
                        }
                    }

                    var message1 = string.Format("Image Updated Successfully.");
                    return Request.CreateErrorResponse(HttpStatusCode.Created, message1); ;
                }
                var res = string.Format("Please Upload an Image.");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
            catch (Exception ex)
            {
                var res = string.Format("some Message");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
        }
    }  
}

