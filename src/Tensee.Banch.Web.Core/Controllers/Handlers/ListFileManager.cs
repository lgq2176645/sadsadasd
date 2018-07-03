using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensee.Banch.Web.Controllers.Handlers
{
    public class ListFileManager : Handler
    {
        enum ResultState
        {
            Success,
            InvalidParam,
            AuthorizError,
            IOError,
            PathNotFound
        }

        private int Start;
        private int Size;
        private int Total;
        private ResultState State;
        private String PathToList;
        private String[] FileList;
        private String[] SearchExtensions;
        private string WebRootPath { get; set; }
        public ListFileManager(HttpContext context, string pathToList, string[] searchExtensions, string webRootPath)
            : base(context)
        {
            SearchExtensions = searchExtensions.Select(x => x.ToLower()).ToArray();
            PathToList = pathToList;
            WebRootPath = webRootPath;
        }

        public override ContentResult Process()
        {
            try
            {
                Start = String.IsNullOrEmpty(Request.Query["start"]) ? 0 : Convert.ToInt32(Request.Query["start"]);
                Size = String.IsNullOrEmpty(Request.Query["size"]) ? Config.GetInt("imageManagerListSize") : Convert.ToInt32(Request.Query["size"]);
            }
            catch (FormatException)
            {
                State = ResultState.InvalidParam;
                return WriteResult();
            }
            var buildingList = new List<String>();
            ContentResult result;
            try
            {
                var localPath = Path.Combine(WebRootPath, PathToList.Replace('/', Path.DirectorySeparatorChar));
                buildingList.AddRange(Directory.GetFiles(localPath, "*", SearchOption.AllDirectories)
                    .Where(x => SearchExtensions.Contains(Path.GetExtension(x).ToLower()))
                    .Select(x => PathToList + x.Substring(localPath.Length).Replace("\\", "/")));
                Total = buildingList.Count;
                FileList = buildingList.OrderBy(x => x).Skip(Start).Take(Size).ToArray();
            }
            catch (UnauthorizedAccessException)
            {
                State = ResultState.AuthorizError;
            }
            catch (DirectoryNotFoundException)
            {
                State = ResultState.PathNotFound;
            }
            catch (IOException)
            {
                State = ResultState.IOError;
            }
            finally
            {
                result =   WriteResult();
            }
            return result;
        }

        private ContentResult WriteResult()
        {
            return WriteJson(new
            {
                state = GetStateString(),
                list = FileList?.Select(x => new { url = x }),
                start = Start,
                size = Size,
                total = Total
            });
        }

        private string GetStateString()
        {
            switch (State)
            {
                case ResultState.Success:
                    return "SUCCESS";
                case ResultState.InvalidParam:
                    return "参数不正确";
                case ResultState.PathNotFound:
                    return "路径不存在";
                case ResultState.AuthorizError:
                    return "文件系统权限不足";
                case ResultState.IOError:
                    return "文件系统读取错误";
            }
            return "未知错误";
        }
    }
}
