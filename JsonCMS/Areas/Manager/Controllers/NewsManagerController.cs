using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JsonCMS.Areas.Manager.Models;
using System.Configuration;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace JsonCMS.Areas.Manager.Controllers
{
    public class NewsManagerController : Controller
    {
        // GET: Manager/News
        public ActionResult News()
        {
            return View();
        }

        // GET: Manager/News/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Manager/News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/News/Create
        [HttpPost]
        public ActionResult Create(News Model)
        {

            string originPath = ConfigurationManager.AppSettings["jsonPathOrig"].ToString();
            string destinationPath = ConfigurationManager.AppSettings["jsonPathDest"].ToString();
            string newsFilePath = "/reloaded/assets/news";
            JsonHandler NewsMachine = new JsonHandler(originPath, destinationPath);
            JArray newsJson = (JArray)NewsMachine.readJsonFile();

            if (!ModelState.IsValid)
            {
                //string messages = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));

                ModelState.AddModelError("title", "Il titolo della news non può essere vuoto");
                return View(Model);
            }

            if (Model.img is HttpPostedFileBase[] && Model.img[0] != null)
            {
                try
                {
                    string path = HttpRuntime.AppDomainAppPath + newsFilePath + "\\" + Model.img[0].FileName.ToString();
                    newsFilePath = newsFilePath + "/" + Model.img[0].FileName.ToString();
                    Model.img[0].SaveAs(path);

                    ViewBag.fileStatus = "Immagine di copertina caricata correttamente";
                }
                catch (Exception)
                {
                    ViewBag.fileStatus = "Errore durante il caricamento del file";
                }
            }
            else {
                newsFilePath = "/reloaded/assets/sample-img.jpg";
            }
 

            JObject newsObj = JObject.FromObject(new
            {
                id = Convert.ToInt32(newsJson[newsJson.Count - 1]["id"]) + 1,
                title = (Model.title != null) ? Model.title : "",
                eyelet = (Model.eyelet != null) ? Model.eyelet : "",
                body = (Model.body != null) ? Model.body : "",
                author = (Model.author != null) ? Model.author : "Cadan",
                date = (Model.date[0] != "") ? Model.date[0] : DateTime.Today.ToString("yyyy-MM-dd"),
                img = newsFilePath,
                link = (Model.link != null) ? Model.link : "",
                target = (Model.target != null) ? Model.target : ((Model.link == null) ? "self" : "blank"),
                macroarea = (Model.macroarea != null) ? Model.macroarea : "news",
                category = (Model.category != null) ? Model.category : "Archivio Generico",
                tags = (Model.tags != null) ? Model.tags : ""
            });

            newsJson.Add(newsObj);

            NewsMachine.writeJsonFile(newsJson);

            TempData["message"] = "News salvata correttamente";
            TempData["classe"] = "alert alert-success slideOutFromLeft";
            TempData["Style"] = "left: 0%;";

            return RedirectToAction("News");
        }

        // GET: Manager/News/Edit/5
        public ActionResult Edit(int id)
        {
            string originPath = ConfigurationManager.AppSettings["jsonPathOrig"].ToString();
            string destinationPath = ConfigurationManager.AppSettings["jsonPathDest"].ToString();
            JsonHandler NewsMachine = new JsonHandler(originPath, destinationPath);
            JArray newsJson = (JArray)NewsMachine.readJsonFile();
            JObject current = null;

            for (int i = 0; i < newsJson.Count; i++)
            {
                if ((Convert.ToInt32(newsJson[i].SelectToken("id"))) == id)
                {
                    current = (JObject)newsJson[i];
                }
            }

            TempData["id"] = current.SelectToken("id");
            TempData["title"] = (current.SelectToken("title") != null) ? current.SelectToken("title") : "";
            TempData["eyelet"] = (current.SelectToken("eyelet") != null) ? current.SelectToken("eyelet") : "";
            TempData["body"] = (current.SelectToken("body") != null) ? current.SelectToken("body") : "";
            TempData["author"] = (current.SelectToken("author") != null) ? current.SelectToken("author") : "Cadan";
            TempData["date"] = ((string)current.SelectToken("date") != "") ? (string)current.SelectToken("date") : DateTime.Today.ToString("yyyy-MM-dd");
            TempData["img"] = (current.SelectToken("img") == null) ? "" : current.SelectToken("img").ToString();
            TempData["link"] = (current.SelectToken("link") != null) ? current.SelectToken("link") : "";
            TempData["target"] = (current.SelectToken("target") != null) ? current.SelectToken("target") : ((current.SelectToken("link") == null) ? "self" : "blank");
            TempData["macroarea"] = (current.SelectToken("macroarea") != null) ? current.SelectToken("macroarea") : "news";
            TempData["category"] = (current.SelectToken("category") != null) ? current.SelectToken("category") : "Archivio Generico";
            TempData["tags"] = (current.SelectToken("tags") != null) ? current.SelectToken("tags") : "";

            return View();
        }

        // POST: Manager/News/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, News Model)
        {
            string originPath = ConfigurationManager.AppSettings["jsonPathOrig"].ToString();
            string destinationPath = ConfigurationManager.AppSettings["jsonPathDest"].ToString();
            string newsFilePath = "/reloaded/assets/news";
            JsonHandler NewsMachine = new JsonHandler(originPath, destinationPath);
            JArray newsJson = (JArray)NewsMachine.readJsonFile();
            int currentIndex = 0;

            for (int i = 0; i < newsJson.Count; i++)
            {
                if ((Convert.ToInt32(newsJson[i].SelectToken("id"))) == id)
                {
                    currentIndex = i;
                }
            }

            if (Model.img is HttpPostedFileBase[] && Model.img[0] != null)
            {
                try
                {
                    string path = HttpRuntime.AppDomainAppPath + newsFilePath + "\\" + Model.img[0].FileName.ToString();
                    newsFilePath = newsFilePath + "/" + Model.img[0].FileName.ToString();
                    Model.img[0].SaveAs(path);

                    ViewBag.fileStatus = "Immagine di copertina caricata correttamente";
                }
                catch (Exception)
                {
                    ViewBag.fileStatus = "Errore durante il caricamento del file";
                }
            }
            else
            {
                newsFilePath = (string)newsJson[currentIndex].SelectToken("img");
            }

            if (!ModelState.IsValid)
            {
                //string messages = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                TempData["id"] = id;
                TempData["title"] = (Model.title != null) ? Model.title : "";
                TempData["eyelet"] = (Model.eyelet != null) ? Model.eyelet : "";
                TempData["body"] = (Model.body != null) ? Model.body : "";
                TempData["author"] = (Model.author != null) ? Model.author : "Cadan";
                TempData["date"] = (Model.date[0] != "") ? Model.date[0] : DateTime.Today.ToString("yyyy-MM-dd");
                TempData["img"] = newsFilePath;
                TempData["link"] = (Model.link != null) ? Model.link : "";
                TempData["target"] = (Model.target != null) ? Model.target : ((Model.link == null) ? "self" : "blank");
                TempData["macroarea"] = (Model.macroarea != null) ? Model.macroarea : "news";
                TempData["category"] = (Model.category != null) ? Model.category : "Archivio Generico";
                TempData["tags"] = (Model.tags != null) ? Model.tags : "";

                ModelState.AddModelError("title", "Il titolo della news non può essere vuoto");

                return View(Model);
            }

            //newsJson[currentIndex]["id"] = id;
            newsJson[currentIndex]["title"] = (Model.title != null) ? Model.title : "";
            newsJson[currentIndex]["eyelet"] = (Model.eyelet != null) ? Model.eyelet : "";
            newsJson[currentIndex]["body"] = (Model.body != null) ? Model.body : "";
            newsJson[currentIndex]["author"] = (Model.author != null) ? Model.author : "Cadan";
            newsJson[currentIndex]["date"] = (Model.date[0] != "") ? Model.date[0] : DateTime.Today.ToString("yyyy-MM-dd");
            newsJson[currentIndex]["img"] = newsFilePath;
            newsJson[currentIndex]["link"] = (Model.link != null) ? Model.link : "";
            newsJson[currentIndex]["target"] = (Model.target != null) ? Model.target : ((Model.link == null) ? "self" : "blank");
            newsJson[currentIndex]["macroarea"] = (Model.macroarea != null) ? Model.macroarea : "news";
            newsJson[currentIndex]["category"] = (Model.category != null) ? Model.category : "Archivio Generico";
            newsJson[currentIndex]["tags"] = (Model.tags != null) ? Model.tags : "";

            NewsMachine.writeJsonFile(newsJson);

            TempData["message"] = "News " + id + " modificata";
            TempData["classe"] = "alert alert-success slideOutFromLeft";
            TempData["Style"] = "left: 0%;";

            return RedirectToAction("News");
        }

        // GET: Manager/News/Delete/5
        public ActionResult Delete(int id)
        {
            string originPath = ConfigurationManager.AppSettings["jsonPathOrig"].ToString();
            string destinationPath = ConfigurationManager.AppSettings["jsonPathDest"].ToString();
            JsonHandler NewsMachine = new JsonHandler(originPath, destinationPath);
            JArray newsJson = (JArray)NewsMachine.readJsonFile();

            for (int i = 0; i < newsJson.Count; i++)
            {
                if ( (Convert.ToInt32(newsJson[i].SelectToken("id"))) == id )
                {
                    newsJson.RemoveAt(i);
                }
            }

            NewsMachine.writeJsonFile(newsJson);

            TempData["message"] = "News " + id.ToString() + " cancellata";
            TempData["classe"] = "alert alert-success slideOutFromLeft";
            TempData["Style"] = "left: 0%;";

            return RedirectToAction("News");
        }

        // POST: Manager/News/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
