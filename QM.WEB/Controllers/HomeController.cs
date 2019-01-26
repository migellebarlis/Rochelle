using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace QM.WEB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetResult(string given)
        {
            var strSumOfMinterms = given.Split(',');
            var sumOfMinterms = strSumOfMinterms.Select(x => int.Parse(x));

            var firstLevelRawDatas = new Dictionary<int, IEnumerable<int>>();

            foreach (var sumOfMinterm in sumOfMinterms)
            {
                if (!firstLevelRawDatas.ContainsKey(sumOfMinterm))
                    firstLevelRawDatas.Add(sumOfMinterm, GetBinaryValue(sumOfMinterm));
            }

            var secondLevelRawDatas = firstLevelRawDatas.GroupBy(x => x.Value.Sum(y => y)).OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.ToList());

            var noOfOnes = secondLevelRawDatas.Select(x => x.Key).ToList();

            var thirdLevelRawDatas = new Dictionary<>

            for (int i = 0; i < noOfOnes.Count; i++)
            {
                var groupNo = noOfOnes[i];

                foreach (var compareFrom in secondLevelRawDatas[groupNo])
                {
                    foreach (var compareTo in secondLevelRawDatas[groupNo + 1])
                    {

                    }
                }

            }

            var result = given;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<int> GetBinaryValue(int num)
        {
            var strBinary = Convert.ToString(num, 2);
            return strBinary.Split().Select(x => int.Parse(x));
        }
    }
}