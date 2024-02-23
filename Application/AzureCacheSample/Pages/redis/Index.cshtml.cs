using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;

namespace AzureCacheSample.Pages.redis
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public string AccoutInfo { get; set; }

        public string MyResult { get; set; }


        private IDistributedCache _cache;
        public IndexModel(IDistributedCache cache)
        {
            _cache = cache;             
        }
        public void OnGet()
        {
       
            if (!String.IsNullOrEmpty(AccoutInfo))
            {
                //check if in cache 
                var key = $"Acc_{AccoutInfo}";

                var result = _cache.GetString(key);
                if (result == null)  //hit DB
                {
					MyResult = "DB" + AccoutInfo;
                    //save to cache 
                    _cache.SetString(key, $"Cache_{AccoutInfo}");

				}
                else
                {
                    MyResult = result;

				}
               
            }
        }
    }
}
