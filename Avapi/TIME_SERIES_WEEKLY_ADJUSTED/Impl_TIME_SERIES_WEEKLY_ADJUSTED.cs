using System; 
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Avapi.AvapiTIME_SERIES_WEEKLY_ADJUSTED
{
    internal class AvapiResponse_TIME_SERIES_WEEKLY_ADJUSTED : IAvapiResponse_TIME_SERIES_WEEKLY_ADJUSTED
    {
        public string LastHttpRequest
        {
            get;
            internal set;

        }
        public string RawData
        {
            get;
            internal set;
        }

        public IAvapiResponse_TIME_SERIES_WEEKLY_ADJUSTED_Content Data
        {
            get;
            internal set;
        }
    }

    public class MetaData_Type_TIME_SERIES_WEEKLY_ADJUSTED
    {
        public string Information
        {
            internal set;
            get;
        }

        public string Symbol
        {
            internal set;
            get;
        }

        public string LastRefreshed
        {
            internal set;
            get;
        }

        public string TimeZone
        {
            internal set;
            get;
        }

    }

    public class TimeSeries_Type_TIME_SERIES_WEEKLY_ADJUSTED
    {
        public string open
        {
            internal set;
            get;
        }

        public string high
        {
            internal set;
            get;
        }

        public string low
        {
            internal set;
            get;
        }

        public string close
        {
            internal set;
            get;
        }

        public string adjustedclose
        {
            internal set;
            get;
        }

        public string volume
        {
            internal set;
            get;
        }

        public string dividendamount
        {
            internal set;
            get;
        }

        public string DateTime
        {
            internal set;
            get;
        }

    }

    internal class AvapiResponse_TIME_SERIES_WEEKLY_ADJUSTED_Content : IAvapiResponse_TIME_SERIES_WEEKLY_ADJUSTED_Content
    {
        internal AvapiResponse_TIME_SERIES_WEEKLY_ADJUSTED_Content()
        {
           MetaData = new MetaData_Type_TIME_SERIES_WEEKLY_ADJUSTED();
           TimeSeries = new List<TimeSeries_Type_TIME_SERIES_WEEKLY_ADJUSTED>();
        }

       public MetaData_Type_TIME_SERIES_WEEKLY_ADJUSTED MetaData
        {
            internal set;
            get;
        }

       public IList<TimeSeries_Type_TIME_SERIES_WEEKLY_ADJUSTED> TimeSeries
        {
            internal set;
            get;
        }

        public bool Error
        {
            internal set;
            get;
        }

        public string ErrorMessage
        {
            internal set;
            get;
        }
    }

	public class Impl_TIME_SERIES_WEEKLY_ADJUSTED : Int_TIME_SERIES_WEEKLY_ADJUSTED
	{
		const string s_function = "TIME_SERIES_WEEKLY_ADJUSTED";

		internal static string ApiKey
		{
			get;
			set;
		}

		internal static HttpClient RestClient
		{
			get;
			set;
		}

		internal static string AvapiUrl
		{
			get;
			set;
		}

		private static readonly Lazy<Impl_TIME_SERIES_WEEKLY_ADJUSTED> s_Impl_TIME_SERIES_WEEKLY_ADJUSTED =
			new Lazy<Impl_TIME_SERIES_WEEKLY_ADJUSTED>(() => new Impl_TIME_SERIES_WEEKLY_ADJUSTED());
		public static Impl_TIME_SERIES_WEEKLY_ADJUSTED Instance
		{
			get
			{
				return s_Impl_TIME_SERIES_WEEKLY_ADJUSTED.Value;
			}
		}
		private Impl_TIME_SERIES_WEEKLY_ADJUSTED()
		{
		}


		public IAvapiResponse_TIME_SERIES_WEEKLY_ADJUSTED QueryPrimitive(
			string symbol)
		{
			// Build Base Uri
			string queryString = AvapiUrl + "/query";

			// Build query parameters
			IDictionary<string, string> getParameters = new Dictionary<string, string>();
			getParameters.Add(new KeyValuePair<string, string>("function", s_function));
			getParameters.Add(new KeyValuePair<string, string>("apikey", ApiKey));
			getParameters.Add(new KeyValuePair<string, string>("symbol",symbol));
			queryString += UrlUtility.AsQueryString(getParameters);

			// Sent the Request and get the raw data from the Response
			string response = RestClient?.
				GetAsync(queryString)?.
				Result?.
				Content?.
				ReadAsStringAsync()?.
				Result; 

			IAvapiResponse_TIME_SERIES_WEEKLY_ADJUSTED ret = new AvapiResponse_TIME_SERIES_WEEKLY_ADJUSTED
			{
				RawData = response,
				Data = ParseInternal(response),
				LastHttpRequest = queryString
			};

			return ret;
		}

		public async Task<IAvapiResponse_TIME_SERIES_WEEKLY_ADJUSTED> QueryPrimitiveAsync(
			string symbol)
		{
			// Build Base Uri
			string queryString = AvapiUrl + "/query";

			// Build query parameters
			IDictionary<string, string> getParameters = new Dictionary<string, string>();
			getParameters.Add(new KeyValuePair<string, string>("function", s_function));
			getParameters.Add(new KeyValuePair<string, string>("apikey", ApiKey));
			getParameters.Add(new KeyValuePair<string, string>("symbol",symbol));
			queryString += UrlUtility.AsQueryString(getParameters);

			string response;
			using (var result = await RestClient.GetAsync(queryString))
			{
				response = await result.Content.ReadAsStringAsync();
			}
			IAvapiResponse_TIME_SERIES_WEEKLY_ADJUSTED ret = new AvapiResponse_TIME_SERIES_WEEKLY_ADJUSTED
			{
				RawData = response,
				Data = ParseInternal(response),
				LastHttpRequest = queryString
			};

			return ret;
		}

        public static IAvapiResponse_TIME_SERIES_WEEKLY_ADJUSTED_Content ParseInternal(string jsonInput)
        {
            if (string.IsNullOrEmpty(jsonInput))
            {
                return null;
            }
            if(jsonInput == "{}")
            {
                return null;
            }

            AvapiResponse_TIME_SERIES_WEEKLY_ADJUSTED_Content ret = new AvapiResponse_TIME_SERIES_WEEKLY_ADJUSTED_Content();
            JObject jsonInputParsed = JObject.Parse(jsonInput);
            string errorMessage = (string)jsonInputParsed["Error Message"];
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ret.Error = true;
                ret.ErrorMessage = errorMessage;
            }
            else
            {
                JToken metaData = jsonInputParsed["Meta Data"];
                ret.MetaData.Information = (string)metaData["1. Information"];
                ret.MetaData.Symbol = (string)metaData["2. Symbol"];
                ret.MetaData.LastRefreshed = (string)metaData["3. Last Refreshed"];
                ret.MetaData.TimeZone = (string)metaData["4. Time Zone"];
                string timeSeries = "Weekly Adjusted Time Series";
                JEnumerable<JToken> results = jsonInputParsed[timeSeries].Children();
                foreach (JToken result in results)
                {
                    TimeSeries_Type_TIME_SERIES_WEEKLY_ADJUSTED timeseries = new TimeSeries_Type_TIME_SERIES_WEEKLY_ADJUSTED
                    {
                        DateTime = ((JProperty)result).Name,
                        open = (string)result.First["1. open"],
                        high = (string)result.First["2. high"],
                        low = (string)result.First["3. low"],
                        close = (string)result.First["4. close"],
                        adjustedclose = (string)result.First["5. adjusted close"],
                        volume = (string)result.First["6. volume"],
                        dividendamount = (string)result.First["7. dividend amount"]
                    };
                    ret.TimeSeries.Add(timeseries);
                }
            }
            return ret;
        }
	}
}