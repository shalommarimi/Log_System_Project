using Logging_System.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Logging_System.Controllers
{
    public class MonthlyController : Controller
    {
        // GET: Explorer
        [Authorize]
        public ActionResult MonthlyDownloads(string path)
        {
            string realPath;
            realPath = Server.MapPath("~/Monthly Evaluation Forms/" + path);
            // or realPath = "FullPath of the folder on server" 

            if (System.IO.File.Exists(realPath))
            {
                //http://stackoverflow.com/questions/1176022/unknown-file-type-mime
                return base.File(realPath, "application/octet-stream");
            }
            else if (System.IO.Directory.Exists(realPath))
            {

                Uri url = Request.Url;
                //Every path needs to end with slash
                if (url.ToString().Last() != '/')
                {
                    Response.Redirect("/Monthly/" + path + "/");
                }
              
                List<DirModel> dirListModel = new List<DirModel>();

                IEnumerable<string> dirList = Directory.EnumerateDirectories(realPath);
                foreach (string dir in dirList)
                {
                    DirectoryInfo d = new DirectoryInfo(dir);

                    DirModel dirModel = new DirModel();

                    dirModel.DirName = Path.GetFileName(dir);
                    dirModel.DirAccessed = d.LastAccessTime;

                    dirListModel.Add(dirModel);
                }


                List<FileModel> fileListModel = new List<FileModel>();

                IEnumerable<string> fileList = Directory.EnumerateFiles(realPath);
                foreach (string file in fileList)
                {
                    FileInfo f = new FileInfo(file);

                    FileModel fileModel = new FileModel();

                    if (f.Extension.ToLower() != "php" && f.Extension.ToLower() != "aspx"
                        && f.Extension.ToLower() != "asp")
                    {
                        fileModel.FileName = Path.GetFileName(file);
                        fileModel.FileAccessed = f.LastAccessTime;
                        fileModel.FileSizeText = (f.Length < 1024) ? f.Length.ToString() + " B" : f.Length / 1024 + " KB";

                        fileListModel.Add(fileModel);
                    }
                }

                ExplorerModel explorerModel = new ExplorerModel(dirListModel, fileListModel);

                return View(explorerModel);
            }
            else
            {
                return Content(path + " is not a valid file or directory.");
            }
        }
    }
}